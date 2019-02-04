using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SIENN.Services.Models.DTO.Product
{
    public class ProductCreationDto : SimpleDtoWithAttributes
    {
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
