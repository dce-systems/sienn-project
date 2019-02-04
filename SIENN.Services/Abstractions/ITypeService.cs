using SIENN.DbAccess.Entities;
using SIENN.Services.Models.DTO.Type;

namespace SIENN.Services.Abstractions
{
    public interface ITypeService : IBaseService<Type>
    {
        void Update(TypeUpdateDto dto);
    }
}
