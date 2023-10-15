using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CVLookup_WebAPI.Models.Domain
{
	public class JobAddress
	{
		[Key]
		public string Id { get; set; } = Guid.NewGuid().ToString();

		[Required(ErrorMessage = "{0} không được để trống")]
		[Display(Name = "Địa chỉ làm việc")]
		public string AddressDetail { get; set; }

		[Required(ErrorMessage = "{0} không được để trống")]
		[Display(Name = "Tỉnh thành")]
        public Province Province { get; set; }

    }
}
