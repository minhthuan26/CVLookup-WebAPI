using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace CVLookup_WebAPI.Models.ViewModel
{
    public class AccountVM
    {
		public string Password { get; set; }

        public string Email { get; set; }
		
	}
}
