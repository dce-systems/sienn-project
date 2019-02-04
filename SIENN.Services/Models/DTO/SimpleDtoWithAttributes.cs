using System.ComponentModel.DataAnnotations;

namespace SIENN.Services.Models.DTO
{
    public class SimpleDtoWithAttributes
    {
        [Required]
        public int Code { get; set; }

        [MaxLength(1024)]
        public string Description { get; set; }
    }
}
