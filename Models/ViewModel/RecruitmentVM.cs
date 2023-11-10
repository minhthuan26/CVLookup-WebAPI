using CVLookup_WebAPI.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace CVLookup_WebAPI.Models.ViewModel
{
	public class RecruitmentVM
	{
        [Required(ErrorMessage = "{0} không được để trống")]
        [Display(Name = "Tiêu đề")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "{0} phải từ {2} đến {1} kí tự")]
        public string JobTitle { get; set; }

        [Required(ErrorMessage = "{0} không được để trống")]
        public string Salary { get; set; }

        [Required(ErrorMessage = "{0} không được để trống")]
        [Display(Name = "Địa điểm công việc")]
        public JobAddressVM JobAddress { get; set; }

        [Required(ErrorMessage = "{0} không được để trống")]
        [Display(Name = "Ngành nghề")]
        public string JobCareer { get; set; }

        [Required(ErrorMessage = "{0} không được để trống")]
        [Display(Name = "Lĩnh vực công việc")]
        public string JobField { get; set; }

        [Required(ErrorMessage = "{0} không được để trống")]
        [Display(Name = "Hình thức công việc")]
        public string JobForm { get; set; }

        [Required(ErrorMessage = "{0} không được để trống")]
        [Display(Name = "Kinh nghiệm")]
        public string Experience { get; set; }

        [Required(ErrorMessage = "{0} không được để trống")]
        [Display(Name = "Vị trí công việc")]
        public string JobPosition { get; set; }

        [Required(ErrorMessage = "{0} không được để trống")]
        [Display(Name = "Thời hạn ứng tuyển")]
        public DateTime ApplicationDeadline { get; set; }


        [Required(ErrorMessage = "{0} không được để trống")]
        [Display(Name = "Mô tả công việc")]
        public string JobDescription { get; set; }
        [Required(ErrorMessage = "{0} không được để trống")]
        [Display(Name = "Yêu cẩu ứng viên")]
        public string JobRequirement { get; set; }

        [Required(ErrorMessage = "{0} không được để trống")]
        [Display(Name = "Phúc lợi")]
        public string Benefit { get; set; }

		[Required(ErrorMessage = "{0} không được để trống")]
		[Display(Name = "Số lượng")]
		public string Quantity { get; set; }
	}
}
