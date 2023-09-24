namespace CVLookup_WebAPI.Models.ViewModel
{
	public class AuthVM
	{
		public string UserId { get; set; } 
		public string AccountId { get; set; }
		public string RoleId { get; set; }
        public TokenVM TokenVM { get; set; }
    }
}
