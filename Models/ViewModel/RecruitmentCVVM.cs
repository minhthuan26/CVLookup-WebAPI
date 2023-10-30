using CVLookup_WebAPI.Models.Domain;

namespace CVLookup_WebAPI.Models.ViewModel
{
	public class RecruitmentCVVM
	{ 
		public string RecruitmentId { get; set; }
		public string CurriculumVitaeId { get; set; }

		public bool IsView { get; set; }
		public bool IsPass { get; set; }
	}
}
