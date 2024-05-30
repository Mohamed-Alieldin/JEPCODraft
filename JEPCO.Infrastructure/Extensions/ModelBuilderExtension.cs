using Microsoft.EntityFrameworkCore;


namespace JEPCO.Infrastructure.Extensions;

public static class ModelBuilderExtension
{
    internal static ModelBuilder Seed(this ModelBuilder modelBuilder)
    {
        // Create and Call any functions needed for seeding data

       // SeedSites(modelBuilder);

        return modelBuilder;
    }


    //private static void SeedSites(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<LK_SiteEntity>().HasData(
    //                new LK_SiteEntity() { ID = SITE00, NameEN = "General Real Estate Registration Directorate", NameAR = "مديرية التسجيل العقاري العامة", IsMain = true },
    //                new LK_SiteEntity() { ID = SITE01, NameEN = "Al-Rasafa 1 Real Estate Registration Directorate 1", NameAR = "مديرية التسجيل العقاري في الرصافة الأولى - فرع 1", LK_JudiciaryID = ALRASAFA1 },
    //                new LK_SiteEntity() { ID = SITE02, NameEN = "Al-Rasafa 1 Real Estate Registration Directorate 2", NameAR = "مديرية التسجيل العقاري في الرصافة الأولى - فرع 2", LK_JudiciaryID = ALRASAFA1 },
    //                new LK_SiteEntity() { ID = SITE03, NameEN = "Al-Rasafa 2 Real Estate Registration Directorate", NameAR = "مديرية التسجيل العقاري في الرصافة الثانية", LK_JudiciaryID = ALRASAFA2 },
    //                new LK_SiteEntity() { ID = SITE04, NameEN = "Real Estate Registration Directorate 4", NameAR = "مديرية التسجيل العقاري 4", LK_JudiciaryID = JUDICIARY04 },
    //                new LK_SiteEntity() { ID = SITE05, NameEN = "Real Estate Registration Directorate 5", NameAR = "مديرية التسجيل العقاري 5", LK_JudiciaryID = JUDICIARY05 },
    //                new LK_SiteEntity() { ID = SITE06, NameEN = "Real Estate Registration Directorate 6", NameAR = "مديرية التسجيل العقاري 6", LK_JudiciaryID = JUDICIARY06 },
    //                new LK_SiteEntity() { ID = SITE10, NameEN = "Real Estate Registration Directorate 10", NameAR = "مديرية التسجيل العقاري 10", LK_JudiciaryID = JUDICIARY10 },
    //                new LK_SiteEntity() { ID = SITE11, NameEN = "Real Estate Registration Directorate 11", NameAR = "مديرية التسجيل العقاري 11", LK_JudiciaryID = JUDICIARY11 },
    //                new LK_SiteEntity() { ID = SITE12, NameEN = "Real Estate Registration Directorate 12", NameAR = "مديرية التسجيل العقاري 12", LK_JudiciaryID = JUDICIARY12 });
    //}
}