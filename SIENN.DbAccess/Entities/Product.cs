using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SIENN.DbAccess.Abstractions;

namespace SIENN.DbAccess.Entities
{
    public class Product : IBaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Code { get; set; }

        [Required]
        [MaxLength(1024)]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 4)")]
        public decimal Price { get; set; }

        [Required]
        public bool IsAvailable { get; set; }

        [Required]
        public DateTimeOffset DeliveryDate { get; set; }

        public DateTimeOffset Created { get; set; }

        public DateTimeOffset Updated { get; set; }

        [ForeignKey("Type")]
        public int TypeId { get; set; }
        [JsonIgnore]
        public Type Type { get; set; }

        [ForeignKey("Unit")]
        public int UnitId { get; set; }
        [JsonIgnore]
        public Unit Unit { get; set; }

        [JsonIgnore]
        public ICollection<ProductCategory> Categories { get; set; } = new List<ProductCategory>();
    }
}
