using SIENN.DbAccess.Entities;
using SIENN.Services.Models.DTO.Product;
using System.Linq;

namespace SIENN.Services.Models.Extensions
{
    public static class ProductExtensions
    {
        public static Product ToEntity(this ProductCreationDto dto)
        {
            return new Product
            {
                Code = dto.Code,
                DeliveryDate = dto.DeliveryDate,
                Description = dto.Description,
                IsAvailable = dto.IsAvailable,
                Price = dto.Price
            };
        }

        public static ProductDetailsDto ToDto(this Product product)
        {
            return new ProductDetailsDto
            {
                Code = product.Code,
                Description = product.Description,
                Created = product.Created,
                DeliveryDate = product.DeliveryDate,
                IsAvailable = product.IsAvailable,
                Price = product.Price,
                Type = product.Type.ToSummary(),
                Unit = product.Unit.ToSummary(),
                Updated = product.Updated,
                Id = product.Id,
                Categories = product.Categories.Select(t => t.Category.ToSummary())
            };
        }

        public static ProductSummaryDto ToSummaryDto(this Product product)
        {
            return new ProductSummaryDto
            {
                ProductDescription = $"({product.Code}) {product.Description}",
                Price = product.Price,
                IsAvailable = product.IsAvailable ? "Yes" : "No",
                DeliveryDate = product.DeliveryDate.ToString("dd-MM-yyyy"),
                CategoriesCount = product.Categories.Count(),
                Type = $"({product.Type.Code}) {product.Type.Description}",
                Unit = $"({product.Unit.Code}) {product.Unit.Description}"
            };
        }
    }
}
