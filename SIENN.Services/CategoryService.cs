using System;
using SIENN.DbAccess.DAL;
using SIENN.DbAccess.Abstractions;
using SIENN.DbAccess.Entities;
using SIENN.DbAccess.Repositories.Abstractions;
using SIENN.Services.Models.DTO.Category;
using SIENN.Services.Abstractions;

namespace SIENN.Services
{
    public class CategoryService : BaseService<Category, ICategoryRepository>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        protected override void Initialize(out ICategoryRepository repository)
        {
            repository = UnitOfWork.Categories;
        }

        public void Update(CategoryUpdateDto dto)
        {
            var category = Get(dto.Id);
            if (category == null)
                throw new Exception("Unit not found");
            category.Code = dto.Code;
            category.Description = dto.Description;
            base.Update(category);
        }
    }
}
