using CVLookup_WebAPI.Models.Domain;

namespace CVLookup_WebAPI.Models.ViewModel
{
    public class UserListVM
    {
        public List<Candidate> Candidate { get; set; }    
        public List<Employer> Employer { get; set; }
    }
}
