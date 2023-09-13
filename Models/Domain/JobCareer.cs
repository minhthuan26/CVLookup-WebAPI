using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CVLookup_WebAPI.Models.Domain
{
	public class JobCareer
	{
		[Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required(ErrorMessage = "{0} không được để trống")]
		[Display(Name = "Ngành nghề")]
		public string Career { get; set; }
	}
}
