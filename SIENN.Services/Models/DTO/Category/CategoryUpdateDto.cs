using System.ComponentModel.DataAnnotations;

namespace SIENN.Services.Models.DTO.Category
{
    public class CategoryUpdateDto : SimpleDtoWithAttributes
    {
        [Required]
        public int Id { get; set; }
    }
}
