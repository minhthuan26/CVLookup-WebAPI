using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;

namespace CVLookup_WebAPI.Services.JobAddressService
{
    public interface IJobFieldService
    {
        public Task<List<JobAddress>> JobAddressList();
		public Task<JobAddress> GetJobAddressById(string id);
		public Task<JobAddress> GetJobAddressByName(string adress);
        public Task<JobAddress> Add(JobAddressVM jobAddressVM);
        public Task<JobAddress> Update(string Id, JobAddressVM newJobAddressVM);
        public Task<JobAddress> Delete(string Id);
    }
}
