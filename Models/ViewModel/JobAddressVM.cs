using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CVLookup_WebAPI.Models.ViewModel
{
	public class JobAddressVM
	{
		[Required(ErrorMessage = "{0} không được để trống")]
		[Display(Name = "Địa điểm")]
		public string Address { get; set; }
	}
}
