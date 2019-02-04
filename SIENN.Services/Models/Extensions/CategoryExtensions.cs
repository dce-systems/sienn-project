using SIENN.DbAccess.Entities;
using SIENN.Services.Models.DTO.Category;

namespace SIENN.Services.Models.Extensions
{
    public static class CategoryExtensions
    {
        public static Category ToEntity(this CategoryCreationDto dto)
        {
            return new Category
            {
                Description = dto.Description,
                Code = dto.Code
            };
        }

        public static CategorySummaryDto ToSummary(this Category category)
        {
            return new CategorySummaryDto
            {
                Description = category.Description,
                Code = category.Code,
                Id = category.Id
            };
        }
    }
}
