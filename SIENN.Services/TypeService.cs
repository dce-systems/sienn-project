using SIENN.DbAccess.Abstractions;
using SIENN.DbAccess.Entities;
using SIENN.DbAccess.Repositories.Abstractions;
using SIENN.Services.Models.DTO.Type;
using SIENN.Services.Abstractions;

namespace SIENN.Services
{
    public class TypeService : BaseService<Type, ITypeRepository>, ITypeService
    {
        public TypeService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        protected override void Initialize(out ITypeRepository repository)
        {
            repository = UnitOfWork.Types;
        }

        public void Update(TypeUpdateDto dto)
        {
            var productType = Get(dto.Id);
            if (productType == null)
                throw new System.Exception("Unit not found");
            productType.Code = dto.Code;
            productType.Description = dto.Description;
            base.Update(productType);
        }
    }
}
