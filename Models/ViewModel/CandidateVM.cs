using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CVLookup_WebAPI.Models.ViewModel
{
    public class CandidateVM : UserVM
    {
		[Required(ErrorMessage = "{0} không được để trống")]
        [Display(Name = "Tên")]
		public string LastName { get; set; }

		[Required(ErrorMessage = "{0} không được để trống")]
		[Display(Name = "Họ")]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "{0} không được để trống")]
		[Display(Name = "Ngày sinh")]
		public DateTime DateOfBirth { get; set; }

    }
}
