using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CVLookup_WebAPI.Models.ViewModel
{
	public class JobFieldVM
	{
		[Required(ErrorMessage = "{0} không được để trống")]
		[Display(Name = "Lĩnh vực công việc")]
		public string Field { get; set; }
	}
}
