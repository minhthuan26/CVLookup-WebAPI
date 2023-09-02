using CVLookup_WebAPI.Models.Domain;

namespace CVLookup_WebAPI.Services.JobAddressService
{
    public interface IJobAddressService
    {
        public Task<List<JobAddress>> JobAddressList();
		public Task<JobAddress> GetAccountById(int id);
        public Task<JobAddress> Add(JobAddress jobAddress);
        public Task<JobAddress> Update(string Id, JobAddress newJobAddress);
        public Task<JobAddress> Delete(string Id);
    }
}
