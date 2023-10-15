using System.ComponentModel.DataAnnotations;

namespace CVLookup_WebAPI.Models.ViewModel
{
    public class ProvinceVM
    {
        [Required(ErrorMessage = "{0} không được để trống")]
        [Display(Name = "Tên tỉnh thành")]
        public string Name { get; set; } 
    }
}
