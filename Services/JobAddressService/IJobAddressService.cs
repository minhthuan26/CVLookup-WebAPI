using CVLookup_WebAPI.Models.ViewModel;

namespace CVLookup_WebAPI.Services.JobAddressService
{
    public interface IJobAddressService
    {
        public Task<List<JobAddressVM>> JobAddressList();
		public Task<JobAddressVM> GetJobAddressById(string id);
		public Task<JobAddressVM> GetJobAddressByAddress(string adress);
        public Task<JobAddressVM> Add(JobAddressVM jobAddressVM);
        public Task<JobAddressVM> Update(string Id, JobAddressVM newJobAddressVM);
        public Task<JobAddressVM> Delete(string Id);
    }
}
