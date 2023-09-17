using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CVLookup_WebAPI.Models.ViewModel
{
	public abstract class UserVM
	{
		[Required(ErrorMessage = "{0} không được để trống")]
		[Display(Name = "Email")]
		public string Email { get; set; }

		public string? PhoneNumber { get; set; }

		public string? Avatar { get; set; }

	}
}
