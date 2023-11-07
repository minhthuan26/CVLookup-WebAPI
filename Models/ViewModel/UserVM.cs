using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CVLookup_WebAPI.Models.ViewModel
{
	public abstract class UserVM
	{
		[Required(ErrorMessage = "{0} không được để trống")]
		[Display(Name = "Email")]
		[EmailAddress(ErrorMessage = "Yêu cầu nhập đúng email")]
		public string Email { get; set; }

		public string? PhoneNumber { get; set; }

		public IFormFile? Avatar { get; set; }
        [Required(ErrorMessage = "{0} không được để trống")]
        [Display(Name = "Tên người dùng")]
        public string Username { get; set; }

    }
}
