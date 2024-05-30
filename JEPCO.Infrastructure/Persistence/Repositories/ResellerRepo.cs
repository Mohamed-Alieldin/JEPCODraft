using JEPCO.Application.Interfaces.Repositories;
using JEPCO.Domain.Entities;
using JEPCO.Infrastructure.Persistence.Repositories.Base;

namespace JEPCO.Infrastructure.Persistence.Repositories;

public class ResellerRepo : Repository<ResellerEntity>, IResellerRepo
{
    public ResellerRepo(ApplicationDbContext context) : base(context) { }

}
