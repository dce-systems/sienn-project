using System;
using SIENN.DbAccess.Abstractions;
using SIENN.DbAccess.Entities;
using SIENN.Services.Models.DTO.Product;
using SIENN.Services.Abstractions;
using SIENN.Services.Models.Extensions;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace SIENN.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public ProductDetailsDto Get(int id)
        {
            return _unitOfWork.Products.GetAll()
                .Include(t => t.Type)
                .Include(t => t.Unit)
                .Include(t => t.Categories)
                .ThenInclude(t => t.Category).FirstOrDefault(t => t.Id == id).ToDto();
        }

        public IQueryable<ProductDetailsDto> GetAll()
        {
            return _unitOfWork.Products.GetAll()
                .Include(t => t.Type)
                .Include(t => t.Unit)
                .Include(t => t.Categories)
                .ThenInclude(t => t.Category).OrderBy(t => t.Id).Select(t => t.ToDto());
        }

        public virtual IQueryable<Product> Find(Expression<Func<Product, bool>> predicate)
        {
            var all = _unitOfWork.Products.GetAll();

            return all.Where(predicate ?? (x => true));
        }

        public virtual IQueryable<Product> GetRange(int start, int count)
        {
            var slice = _unitOfWork.Products.GetAll().OrderBy(t => t.Id)
                                           .Skip((start - 1) * count)
                                           .Take(count);

            return slice;
        }
        
        public virtual IQueryable<Product> GetRange(int start, int count, Expression<Func<Product, bool>> predicate)
        {
            var all = _unitOfWork.Products.GetAll();
            var queryable = all.Where(predicate ?? (x => true));
            var slice = queryable.OrderBy(t => t.Id)
                                 .Skip((start - 1) * count)
                                 .Take(count);

            return slice;
        }

        public virtual IQueryable<Product> GetRangeWithAvailable(int start, int count, bool? available = null)
        {
            var all = _unitOfWork.Products.GetAll();

            if (available.HasValue)
            {
              all = all.Where(x => x.IsAvailable == available.Value);
            }

            var slice = all.OrderBy(t => t.Id)
                           .Skip((start - 1) * count)
                           .Take(count);

            return slice;
        }

        public virtual IQueryable<Product> Search(ProductFiltersDto request)
        {
            var all = _unitOfWork.Products.GetAll()
                                          .Include(t => t.Type)
                                          .Include(t => t.Unit)
                                          .Include(t => t.Categories)
                                          .ThenInclude(t => t.Category);

            Expression<Func<Product, bool>> filter = x => (string.IsNullOrEmpty(request.SearchCriteria)
                                                         || x.Description.ToLower()
                                                             .Contains(request.SearchCriteria.ToLower())
                                                         || x.Code.ToString().ToLower()
                                                             .Contains(request.SearchCriteria.ToLower()))
                                                         && (request.Availability == null ||
                                                             x.IsAvailable == request.Availability.Value)
                                                         && (request.TypeFilter == null || !request.TypeFilter.Any() ||
                                                             request.TypeFilter.Any(t => t == x.TypeId))
                                                         && (request.UnitFilter == null || !request.UnitFilter.Any() ||
                                                             request.UnitFilter.Any(t => t == x.UnitId))
                                                         && (request.CategoryFilter == null ||
                                                             !request.CategoryFilter.Any() ||
                                                             request.CategoryFilter.Any(t =>
                                                                 x.Categories.Any(e => e.CategoryId == t)));

            var filtered = all.Where(filter);
            var take = request.PageSize;
            var skip = (request.PageNumber - 1) * request.PageSize;
            var range = new List<Product>();
            if (request.OrderByCode)
            {
                range = GetRange(filtered, x => x.Code, request.Ascending, skip, take);
            }
            else if (request.OrderByCreated)
            {
                range = GetRange(filtered, x => x.Created, request.Ascending, skip, take);
            }
            else if (request.OrderByDeliveryDate)
            {
                range = GetRange(filtered, x => x.DeliveryDate, request.Ascending, skip, take);
            }
            else if (request.OrderByPrice)
            {
                range = GetRange(filtered, x => x.Price, request.Ascending, skip, take);
            }
            else if (request.OrderByUpdated)
            {
                range = GetRange(filtered, x => x.Updated, request.Ascending, skip, take);
            }
            else if (request.OrderById)
            {
                range = GetRange(filtered, x => x.Id, request.Ascending, skip, take);
            }

            return range.AsQueryable();
        }

        private static List<Product> GetRange<TKey>(IEnumerable<Product> items, Expression<Func<Product, TKey>> orderBy, bool asc, int skip, int take)
        {
            return asc
                ? items.AsQueryable().OrderBy(orderBy).Skip(skip).Take(take).ToList()
                : items.AsQueryable().OrderByDescending(orderBy).Skip(skip).Take(take).ToList();
        }

        public int Count()
        {
            return _unitOfWork.Products.GetAll().ToList().Count(); 
        }

        public ProductSummaryDto ShowInfo(int id)
        {
            var product = _unitOfWork.Products.GetAll()
                .Include(t => t.Type)
                .Include(t => t.Unit)
                .Include(t => t.Categories)
                .ThenInclude(t => t.Category).FirstOrDefault(t => t.Id == id);
            if (product == null)
                throw new Exception("Product not found");

            return _unitOfWork.Products.GetAll()
                        .Include(t => t.Type)
                        .Include(t => t.Unit)
                        .Include(t => t.Categories)
                        .ThenInclude(t => t.Category).FirstOrDefault(t => t.Id == id).ToSummaryDto();
        }

        public void Add(ProductCreationDto dto)
        {
            if (dto == null)
                throw new Exception("No query parameters");
            if (dto.CategoryIds == null || !dto.CategoryIds.Any())
                throw new Exception("Category list is empty");
            var newProduct = dto.ToEntity();
            var productType = _unitOfWork.Types.Get(dto.ProductTypeId);
            var unit = _unitOfWork.Units.Get(dto.UnitId);
            newProduct.Unit = unit ?? throw new Exception("Wrong unit");
            newProduct.Type = productType ?? throw new Exception("Wrong product type");
            foreach (var categoryId in dto.CategoryIds)
            {
                var category = _unitOfWork.Categories.Get(categoryId);
                if (category == null)
                    throw new Exception("Wrong category");
                newProduct.Categories.Add(new ProductCategory
                {
                    Category = category,
                    Product = newProduct
                });
            }
            newProduct.Created = DateTimeOffset.UtcNow;
            _unitOfWork.Products.Add(newProduct);
            _unitOfWork.Save();
        }

        public void Update(ProductUpdateDto dto)
        {
            if (dto == null)
                throw new Exception("No query parameters");
            if (dto.CategoryIds == null || !dto.CategoryIds.Any())
                throw new Exception("Category list is empty");
            var target = _unitOfWork.Products.GetAll()
                .Include(t => t.Type)
                .Include(t => t.Unit)
                .Include(t => t.Categories)
                .ThenInclude(t => t.Category).FirstOrDefault(t => t.Id == dto.Id);
            if (target == null)
                throw new Exception("Prodcut not found");
            var productType = _unitOfWork.Types.Get(dto.ProductTypeId);
            var unit = _unitOfWork.Units.Get(dto.UnitId);
            target.Code = dto.Code;
            target.Description = dto.Description;
            target.DeliveryDate = dto.DeliveryDate;
            target.Price = dto.Price;
            target.IsAvailable = dto.IsAvailable;
            target.Type = productType ?? throw new Exception("Wrong product type");
            target.Unit = unit ?? throw new Exception("Wrong unit");
            foreach (var existingCategory in target.Categories.ToList())
            {
                target.Categories.Remove(existingCategory);
            }
            foreach (var categoryId in dto.CategoryIds)
            {
                var category = _unitOfWork.Categories.Get(categoryId);
                if (category == null)
                    throw new Exception("Wrong category");
                target.Categories.Add(new ProductCategory
                {
                    Category = category,
                    Product = target
                });
            }
            target.Updated = DateTimeOffset.UtcNow;
            _unitOfWork.Products.Update(target);
            _unitOfWork.Save();
        }

        public void Remove(int id)
        {
            var product = _unitOfWork.Products.GetAll()
                .Include(t => t.Type)
                .Include(t => t.Unit)
                .Include(t => t.Categories)
                .ThenInclude(t => t.Category).FirstOrDefault(t => t.Id == id);
            if (product == null)
                throw new Exception("Product not found");
            foreach (var category in product.Categories.ToList())
            {
                product.Categories.Remove(category);
            }
            _unitOfWork.Products.Remove(product);
            _unitOfWork.Save();
        }
    }
}
