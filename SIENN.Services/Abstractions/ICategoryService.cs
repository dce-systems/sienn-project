using SIENN.DbAccess.Entities;
using SIENN.Services.Models.DTO.Category;

namespace SIENN.Services.Abstractions
{
    public interface ICategoryService : IBaseService<Category>
    {
        void Update(CategoryUpdateDto dto);
    }
}
