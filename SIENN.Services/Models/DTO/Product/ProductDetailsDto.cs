using System;
using System.Collections.Generic;
using SIENN.Services.Models.DTO.Category;
using SIENN.Services.Models.DTO.Type;
using SIENN.Services.Models.DTO.Unit;

namespace SIENN.Services.Models.DTO.Product
{
    public class ProductDetailsDto : SimpleDto
    {
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public DateTimeOffset DeliveryDate { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Updated { get; set; }
        public TypeSummaryDto Type { get; set; }
        public UnitSummaryDto Unit { get; set; }
        public IEnumerable<CategorySummaryDto> Categories { get; set; } = new List<CategorySummaryDto>();
    }
}
