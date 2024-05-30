using JEPCO.Domain.Entities;
using JEPCO.Infrastructure.Enums;
using JEPCO.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using JEPCO.Infrastructure.Extensions;
using JEPCO.Domain.Common;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace JEPCO.Infrastructure.Persistence
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
            // keep these configurations
            // Ensures that setting and geting datetimes are done in utc
            // Ensures taht no conversion for min and max datetimes are done in the db
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // keep this at top
            base.OnModelCreating(builder);

            // seed data
            builder.Seed();

            // Apply cutom enities configurations if any
            // builder.ApplyConfiguration(new UserConfiguration());

            // Add sequences if needed
            // builder.HasSequence(SequenceNameConstants.GovernmentSequence, (e) => { e.StartsAt(1000); });
        }
        public override int SaveChanges()
        {
            BeforeSaveChanges();
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            BeforeSaveChanges();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void BeforeSaveChanges()
        {
            ChangeTracker.DetectChanges();
            var auditEntries = new List<AuditEntry>();

            foreach (var entry in ChangeTracker.Entries())
            {
                // Fill audit proeprties
                FillAuditProperties(entry);

                // AuditLogEntity Logging 
                if (entry.Entity is not IAuditLoggableEntity || entry.Entity is AuditLogEntity || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                    continue;

                // implement audit logging
                var auditEntry = new AuditEntry(entry);
                auditEntry.TableName = entry.Entity.GetType().Name;
                auditEntries.Add(auditEntry);
                foreach (var property in entry.Properties)
                {
                    string propertyName = property.Metadata.Name;
                    if (property.Metadata.IsPrimaryKey())
                    {
                        auditEntry.KeyValues[propertyName] = property.CurrentValue;
                        continue;
                    }
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            auditEntry.AuditType = AuditType.Create;
                            auditEntry.NewValues[propertyName] = property.CurrentValue;
                            auditEntry.UserId = entry.Property("CreatedBy").CurrentValue != null ? entry.Property("CreatedBy").CurrentValue.ToString() : "Null";
                            break;
                        case EntityState.Deleted:
                            auditEntry.AuditType = AuditType.Delete;
                            auditEntry.OldValues[propertyName] = property.OriginalValue;
                            auditEntry.UserId = entry.Property("LastModifiedBy").CurrentValue != null ? entry.Property("LastModifiedBy").CurrentValue.ToString() : "Null";
                            break;
                        case EntityState.Modified:
                            if (property.IsModified)
                            {
                                auditEntry.ChangedColumns.Add(propertyName);
                                auditEntry.AuditType = entry.Property("IsDeleted").CurrentValue == "false" ? AuditType.Update : AuditType.SoftDelete;
                                auditEntry.OldValues[propertyName] = property.OriginalValue;
                                auditEntry.NewValues[propertyName] = property.CurrentValue;
                                auditEntry.UserId = entry.Property("LastModifiedBy").CurrentValue != null ? entry.Property("LastModifiedBy").CurrentValue.ToString() : "Null";
                            }
                            break;
                    }
                }
            }
            foreach (var auditEntry in auditEntries)
            {
                AuditLogs.Add(auditEntry.ToAudit());
            }
        }
        private void FillAuditProperties(EntityEntry entry)
        {
            var now = DateTime.UtcNow;

            // Fill AuditLogEntity Properties
            if (entry.Entity is IAuditableEntity ae)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        ae.CreatedAt = now;
                        ae.LastModifiedAt = now;
                        break;
                    case EntityState.Modified:
                        Entry(ae).Property(e => e.CreatedAt).IsModified = false;
                        ae.LastModifiedAt = now;
                        break;
                }
            }
        }

        


        #region Entities
        public DbSet<AuditLogEntity> AuditLogs { get; set; }
        public DbSet<ResellerEntity> Resellers { get; set; }
        #endregion
    }
}
