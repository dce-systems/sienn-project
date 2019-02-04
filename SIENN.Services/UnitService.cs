using System;
using SIENN.DbAccess.DAL;
using SIENN.DbAccess.Abstractions;
using SIENN.DbAccess.Entities;
using SIENN.DbAccess.Repositories.Abstractions;
using SIENN.Services.Models.DTO.Unit;
using SIENN.Services.Abstractions;

namespace SIENN.Services
{
    public class UnitService : BaseService<Unit, IUnitRepository>, IUnitService
    {
        public UnitService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        protected override void Initialize(out IUnitRepository repository)
        {
            repository = UnitOfWork.Units;
        }

        public void Update(UnitUpdateDto dto)
        {
            var unit = Get(dto.Id);
            if (unit == null)
                throw new Exception("Unit not found");
            unit.Code = dto.Code;
            unit.Description = dto.Description;
            base.Update(unit);
        }
    }
}
