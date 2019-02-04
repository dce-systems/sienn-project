using SIENN.DbAccess.Entities;
using SIENN.Services.Models.DTO.Unit;

namespace SIENN.Services.Abstractions
{
    public interface IUnitService : IBaseService<Unit>
    {
        void Update(UnitUpdateDto dto);
    }
}
