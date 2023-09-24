using CVLookup_WebAPI.Models.Domain;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CVLookup_WebAPI.Models.ViewModel
{
	public class RefreshTokenVM
	{
		public string UserId { get; set; }
		public string AccountId { get; set; }

		[Required(ErrorMessage = "{0} không được để trống")]
		public string Token { get; set; }

		[Display(Name = "Ngày tạo")]
		public DateTime CreateAt { get; set; } = DateTime.Now;

		[Display(Name = "Ngày hết hạn")]
		public DateTime ExpiredAt { get; set; } = DateTime.Now.AddDays(7);
	}
}
