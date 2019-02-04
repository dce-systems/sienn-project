using Microsoft.EntityFrameworkCore;
using SIENN.DbAccess.Repositories.Abstractions;
using SIENN.DbAccess.Entities;

namespace SIENN.DbAccess.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext context) : base(context)
        {
        }
    }
}
