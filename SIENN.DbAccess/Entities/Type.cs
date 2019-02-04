using System;
using System.ComponentModel.DataAnnotations;
using SIENN.DbAccess.Abstractions;

namespace SIENN.DbAccess.Entities
{
    public class Type: IBaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Code { get; set; }

        [Required]
        [MaxLength(1024)]
        public string Description { get; set; }

        public DateTimeOffset Created { get; set; }

        public DateTimeOffset Updated { get; set; }
    }
}
