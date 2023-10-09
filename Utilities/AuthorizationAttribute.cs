using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Services.RoleService;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Specialized;
using System.Text.Json;

namespace CVLookup_WebAPI.Utilities
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizationAttribute : Attribute
    {
        private readonly string[] _Roles;

        public AuthorizationAttribute(params string[] Roles)
        {
            _Roles = Roles ?? new string[] { };
        }

        public string[] GetRole()
        {
            return _Roles;
        }
    }
}
