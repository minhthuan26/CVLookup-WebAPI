using System.ComponentModel.DataAnnotations;

namespace CVLookup_WebAPI.Models.Domain
{
	public class Notification
	{
		[Key]
		public string Id { get; set; } = Guid.NewGuid().ToString();

		public string UserId { get; set; }

		public User User { get; set; }

		[Required(ErrorMessage = "{0} không được để trống")]
		[Display(Name = "Ngày nhận")]
		public DateTime NotifiedAt { get; set; } = DateTime.Now;

		[Required(ErrorMessage = "{0} không được để trống")]
		[Display(Name = "Id người gửi")]
		public string SenderId { get; set; }

		[Required(ErrorMessage = "{0} không được để trống")]
		[Display(Name = "Nội dung")]
		public string Message { get; set; }

		public RecruitmentCV RecruitmentCV { get; set; }

		public bool IsView { get; set; } = false;
	}
}
