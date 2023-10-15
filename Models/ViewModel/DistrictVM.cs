using System.ComponentModel.DataAnnotations;

namespace CVLookup_WebAPI.Models.ViewModel
{
    public class DistrictVM
    {
        [Required(ErrorMessage = "{0} không được để trống")]
        [Display(Name = "Tên tỉnh thành")]
        public string ProvinceName { get; set; }

        [Required(ErrorMessage = "{0} không được để trống")]
        [Display(Name = "Tên quận")]
        public string Name { get; set; }
    }
}
