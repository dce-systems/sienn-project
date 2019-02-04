using System;

namespace SIENN.Services.Models.DTO.Type
{
    public class TypeDetailsDto : SimpleDto
    {
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Updated { get; set; }
    }
}
