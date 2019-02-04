using System.Threading.Tasks;
using SIENN.DbAccess.Repositories.Abstractions;

namespace SIENN.DbAccess.Abstractions
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }
        ITypeRepository Types { get; }
        IUnitRepository Units { get; }

        void Save();
        Task<int> SaveAsync();
    }
}
