using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CVLookup_WebAPI.Models.ViewModel
{
	public abstract class UserVM
	{

		public string Email { get; set; }

		public string PhoneNumber { get; set; }

		public string Avatar { get; set; }

	}
}
