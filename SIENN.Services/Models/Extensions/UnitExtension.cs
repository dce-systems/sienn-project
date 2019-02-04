using SIENN.DbAccess.Entities;
using SIENN.Services.Models.DTO.Unit;

namespace SIENN.Services.Models.Extensions
{
    public static class UnitExtensions
    {
        public static Unit ToEntity(this UnitCreationDto dto)
        {
            return new Unit
            {
                Description = dto.Description,
                Code = dto.Code
            };
        }

        public static UnitSummaryDto ToSummary(this Unit unit)
        {
            return new UnitSummaryDto
            {
                Code = unit.Code,
                Description = unit.Description,
                Id = unit.Id
            };
        }
    }
}
