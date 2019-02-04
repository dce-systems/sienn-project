using System.ComponentModel.DataAnnotations;

namespace SIENN.Services.Models.DTO.Unit
{
    public class UnitUpdateDto : SimpleDtoWithAttributes
    {
        [Required]
        public int Id { get; set; }
    }
}
