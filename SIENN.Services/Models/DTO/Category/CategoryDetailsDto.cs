using System;
using System.Collections.Generic;
using SIENN.Services.Models.DTO.Product;

namespace SIENN.Services.Models.DTO.Category
{
    public class CategoryDetailsDto : SimpleDto
    {
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Updated { get; set; }
        public ICollection<ProductSummaryDto> Products { get; set; } = new List<ProductSummaryDto>();
    }
}
