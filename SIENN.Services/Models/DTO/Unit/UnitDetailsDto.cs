using System;

namespace SIENN.Services.Models.DTO.Unit
{
    public class UnitDetailsDto : SimpleDto
    {
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Updated { get; set; }
    }
}
