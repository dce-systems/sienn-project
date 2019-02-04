using System;
using System.Threading.Tasks;
using SIENN.DbAccess.Repositories;
using SIENN.DbAccess.Abstractions;
using SIENN.DbAccess.Repositories.Abstractions;

namespace SIENN.DbAccess.DAL
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        private IProductRepository _products;
        public IProductRepository Products => _products ?? (_products = new ProductRepository(_context));

        private ICategoryRepository _categories;
        public ICategoryRepository Categories => _categories ?? (_categories = new CategoryRepository(_context));

        private ITypeRepository _types;
        public ITypeRepository Types => _types ?? (_types = new TypeRepository(_context));

        private IUnitRepository _units;
        public IUnitRepository Units => _units ?? (_units = new UnitRepository(_context));

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            //GC.SuppressFinalize(this);
        }

    }
}
