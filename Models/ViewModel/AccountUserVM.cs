using CVLookup_WebAPI.Models.Domain;

namespace CVLookup_WebAPI.Models.ViewModel
{
	public class AccountUserVM
	{
		public User User { get; set; }
		public Account Account { get; set; }
		public string AccountId { get; set; }
		public string UserId { get; set; }
	}
}
