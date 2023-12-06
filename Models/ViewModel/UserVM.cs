using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CVLookup_WebAPI.Models.ViewModel
{
	public abstract class UserVM
	{
		public string? PhoneNumber { get; set; }

		public IFormFile? Avatar { get; set; }
        [Required(ErrorMessage = "{0} không được để trống")]
        [Display(Name = "Tên người dùng")]
        public string Username { get; set; }

    }
}
