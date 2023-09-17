using System.ComponentModel.DataAnnotations;

namespace CVLookup_WebAPI.Models.ViewModel
{
	public class ExperienceVM
	{
		[Required(ErrorMessage = "{0} không được để trống")]
		[Display(Name = "Kinh nghiệm")]
		public string Exp { get; set; }
	}
}
