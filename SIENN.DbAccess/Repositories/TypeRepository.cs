using Microsoft.EntityFrameworkCore;
using SIENN.DbAccess.Repositories.Abstractions;
using SIENN.DbAccess.Entities;

namespace SIENN.DbAccess.Repositories
{
    public class TypeRepository : GenericRepository<Type>, ITypeRepository
    {
        public TypeRepository(DbContext context) : base(context)
        {
        }
    }
}
