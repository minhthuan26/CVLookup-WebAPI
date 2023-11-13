using CVLookup_WebAPI.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace CVLookup_WebAPI.Models.ViewModel
{
	public class CurriculumVitaeVM
	{
        [Required(ErrorMessage = "{0} không được để trống")]
        [Display(Name = "Họ và tên")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "{0} không được để trống")]
        [Display(Name = "Số điện thoại")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "{0} không được để trống")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Vui lòng nhập đúng email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} không được để trống")]
        [Display(Name = "Giới thiệu")]
        public string Introdution { get; set; }

        [Required(ErrorMessage = "{0} không được để trống")]
        [Display(Name = "CV")]
        public IFormFile CVFile { get; set; }
    }
}
