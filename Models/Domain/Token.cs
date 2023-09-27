using System.ComponentModel.DataAnnotations;

namespace CVLookup_WebAPI.Models.Domain
{
	public class Token
    {
        public string UserId { get; set; }
        public string AccountId { get; set; }
        public string RoleId { get; set; }

        public User User { get; set; }
        public Account Account { get; set; }
		public Role Role { get; set; }

		[Required(ErrorMessage = "{0} không được để trống")]
        [Display(Name = "Refresh RefreshToken")]
		public string RefreshToken { get; set; }

	}
}
