using System.ComponentModel.DataAnnotations;

namespace CVLookup_WebAPI.Models.Domain
{
	public class CurriculumVitae
	{
		[Key]
		public string Id { get; set; } = Guid.NewGuid().ToString();

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

		[Required(ErrorMessage = "CV không được để trống")]
		public string CVPath { get; set; }

		public string Introdution { get; set; }

		public string Base64StringFile { get; set; }
		public User User { get; set; }

		public DateTime UploadedAt { get; set; } = DateTime.Now;

	}
}
