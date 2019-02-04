using System.ComponentModel.DataAnnotations;

namespace SIENN.Services.Models.DTO.Type
{
    public class TypeUpdateDto : SimpleDtoWithAttributes
    {
        [Required]
        public int Id { get; set; }
    }
}
