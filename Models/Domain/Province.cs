using System.ComponentModel.DataAnnotations;

namespace CVLookup_WebAPI.Models.Domain
{
    public class Province
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required(ErrorMessage = "{0} không được để trống")]
        [Display(Name = "Tỉnh thành")]
        public string Name { get; set; }

        public List<District>? Districts { get; set; }
    }
}
