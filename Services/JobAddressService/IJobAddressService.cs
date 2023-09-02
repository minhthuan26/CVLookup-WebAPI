using CVLookup_WebAPI.Models.Domain;

namespace CVLookup_WebAPI.Services.JobAddressService
{
    public interface IJobAddressService
    {
        public Task<List<JobAddress>> WorkAddressList { get; set; }
        public Task<JobAddress> GetAccountById(int id);
        public Task<JobAddress> Add(JobAddress workAddress);
        public Task<JobAddress> Update(string Id, JobAddress newWorkAddress);
        public Task<JobAddress> Delete(string Id);
    }
}
