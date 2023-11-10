using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CVLookup_WebAPI.Models.Domain
{
    public class Employer : User
    {
        [Required(ErrorMessage = "{0} không được để trống")]
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [Required(ErrorMessage = "{0} không được để trống")]
        [Display(Name = "Giới thiệu")]
        public string Description { get; set; }

		[Display(Name = "Địa chỉ trang web")]
		public string? Website { get; set; }

	}
}
