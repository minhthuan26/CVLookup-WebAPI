using CVLookup_WebAPI.Models.Domain;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CVLookup_WebAPI.Models.ViewModel
{
	public class TokenVM
	{
		public string UserId { get; set; }
		public string AccountId { get; set; }
		public string RoleId { get; set; }

		[Required(ErrorMessage = "{0} không được để trống")]
		[Display(Name = "Refresh Token")]
		public string RefreshToken { get; set; }
	}
}
