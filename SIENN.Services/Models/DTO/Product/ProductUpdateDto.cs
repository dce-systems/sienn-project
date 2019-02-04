using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace SIENN.Services.Models.DTO.Product
{
    public class ProductUpdateDto : SimpleDtoWithAttributes
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public bool IsAvailable { get; set; }

        [Required]
        public DateTimeOffset DeliveryDate { get; set; }

        [Required]
        public int ProductTypeId { get; set; }

        [Required]
        public int UnitId { get; set; }

        [Required]
        public IEnumerable<int> CategoryIds { get; set; }
    }
}
