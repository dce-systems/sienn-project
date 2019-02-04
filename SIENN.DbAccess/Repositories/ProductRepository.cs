using Microsoft.EntityFrameworkCore;
using SIENN.DbAccess.Repositories.Abstractions;
using SIENN.DbAccess.Entities;

namespace SIENN.DbAccess.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(DbContext context) : base(context)
        {
        }
    }
}
