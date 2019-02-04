using Microsoft.EntityFrameworkCore;
using SIENN.DbAccess.Repositories.Abstractions;
using SIENN.DbAccess.Entities;

namespace SIENN.DbAccess.Repositories
{
    public class UnitRepository : GenericRepository<Unit>, IUnitRepository
    {
        public UnitRepository(DbContext context) : base(context)
        {
        }
    }
}
