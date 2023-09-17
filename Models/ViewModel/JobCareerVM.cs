using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CVLookup_WebAPI.Models.ViewModel
{
	public class JobCareerVM
	{
		[Required(ErrorMessage = "{0} không được để trống")]
		[Display(Name = "Nghề nghiệp")]
		public string Career { get; set; }
	}
}
