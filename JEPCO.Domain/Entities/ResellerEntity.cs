using JEPCO.Domain.Common;


namespace JEPCO.Domain.Entities;

public class ResellerEntity : AuditableWithBaseEntity<Guid>, IAuditLoggableEntity
{
    public string Name { get; set; }
}
