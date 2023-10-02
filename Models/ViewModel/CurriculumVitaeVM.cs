using CVLookup_WebAPI.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace CVLookup_WebAPI.Models.ViewModel
{
	public class CurriculumVitaeVM
	{
		public string FullName { get; set; }

		public string PhoneNumber { get; set; }

		public string Email { get; set; }
		
		public string CVPath { get; set; }

		public string Introdution { get; set; }

	}
}
