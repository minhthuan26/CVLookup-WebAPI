using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace CVLookup_WebAPI.Models.ViewModel
{
    public class AccountVM
    {
		[Required(ErrorMessage = "{0} không được để trống")]
		[Display(Name = "Mật khẩu")]
		[MinLength(8, ErrorMessage = "{0} phải có từ {1} kí tự trở lên")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required(ErrorMessage = "{0} không được để trống")]
		[Display(Name = "Email")]
		[EmailAddress(ErrorMessage = "Yêu cầu nhập đúng email")]
		public string Email { get; set; }

		[Display(Name = "Ngày kích hoạt tài khoản")]
		public DateTime ActivedAt { get; set; }

		[Display(Name = "Ngày cập nhật")]
		public DateTime UpdatedAt { get; set; }

		[Display(Name = "Trạng thái tài khoản")]
		public bool Actived { get; set; } = false;

	}
}
