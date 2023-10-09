using System.ComponentModel.DataAnnotations;

namespace CVLookup_WebAPI.Models.Domain
{
    public class District
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required(ErrorMessage = "{0} không được để trống")]
        [Display(Name = "Quận")]
        public string Name { get; set; }
    }
}
