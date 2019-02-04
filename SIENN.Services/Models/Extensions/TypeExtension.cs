using SIENN.DbAccess.Entities;
using SIENN.Services.Models.DTO.Type;

namespace SIENN.Services.Models.Extensions
{
    public static class TypeExtensions
    {
        public static Type ToEntity(this TypeCreationDto dto)
        {
            return new Type
            {
                Description = dto.Description,
                Code = dto.Code
            };
        }

        public static TypeSummaryDto ToSummary(this Type type)
        {
            return new TypeSummaryDto
            {
                Description = type.Description,
                Code = type.Code,
                Id = type.Id
            };
        }
    }
}
