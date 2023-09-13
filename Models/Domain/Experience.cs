using System.ComponentModel.DataAnnotations;

namespace CVLookup_WebAPI.Models.Domain
{
	public class Experience
	{
		[Key]
		public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required(ErrorMessage = "{0} không được để trống")]
		[Display(Name = "Kinh nghiệm")]
		public string Exp { get; set; }
	}
}
