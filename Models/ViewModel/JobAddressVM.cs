using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CVLookup_WebAPI.Models.ViewModel
{
	public class JobAddressVM
	{
		[Required(ErrorMessage = "{0} không được để trống")]
		[Display(Name = "Địa chỉ")]
		public string AddressDetail { get; set; }

        [Required(ErrorMessage = "{0} không được để trống")]
        [Display(Name = "Tỉnh thành")]
        public string Province { get; set; }

        [Display(Name = "Quận")]
        public string? District { get; set; }
    }
}
