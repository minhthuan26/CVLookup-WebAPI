using CVLookup_WebAPI.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace CVLookup_WebAPI.Models.ViewModel
{
    public class NotificationVM
    {
        [Required(ErrorMessage = "{0} không được để trống")]
        [Display(Name = "Id người nhận")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "{0} không được để trống")]
        [Display(Name = "Id người gửi")]
        public string SenderId { get; set; }

        [Required(ErrorMessage = "{0} không được để trống")]
        [Display(Name = "Nội dung")]
        public string Message { get; set; }
        [Required(ErrorMessage = "{0} không được để trống")]
        [Display(Name = "Id tuyển dụng")]
        public string RecruitmentId { get; set; }
        [Required(ErrorMessage = "{0} không được để trống")]
        [Display(Name = "Id cv")]
        public string CvId { get; set; }
    }
}
