using System.ComponentModel.DataAnnotations;

namespace CVLookup_WebAPI.Models.ViewModel
{
    public class TokenVM
    {
        [Key]
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
