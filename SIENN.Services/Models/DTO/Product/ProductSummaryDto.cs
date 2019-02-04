using System;

namespace SIENN.Services.Models.DTO.Product
{
    public class ProductSummaryDto
    {
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
        public string IsAvailable { get; set; }
        public string DeliveryDate { get; set; }
        public int CategoriesCount { get; set; }
        public string Type { get; set; }
        public string Unit { get; set; }
    }
}
