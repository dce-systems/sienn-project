using System;
using System.Linq.Expressions;
using SIENN.Services.Models.DTO.Product;
using SIENN.DbAccess.Entities;
//using SIENN.Services.Models.DTO.Page;
using System.Linq;

namespace SIENN.Services.Abstractions
{
    public interface IProductService
    {
        ProductDetailsDto Get(int id);

        IQueryable<ProductDetailsDto> GetAll();
        IQueryable<Product> Find(Expression<Func<Product, bool>> predicate);
        IQueryable<Product> GetRange(int start, int count);
        IQueryable<Product> GetRange(int start, int count, Expression<Func<Product, bool>> predicate);
        IQueryable<Product> GetRangeWithAvailable(int start, int count, bool? available = null);
        IQueryable<Product> Search(ProductFiltersDto request);

        int Count();
        ProductSummaryDto ShowInfo(int id);

        void Add(ProductCreationDto dto);
        void Update(ProductUpdateDto dto);  
        void Remove(int id);
    }
}
