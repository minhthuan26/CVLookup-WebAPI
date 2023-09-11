using CVLookup_WebAPI.Models.ViewModel;

namespace CVLookup_WebAPI.Services.JobAddressService
{
    public interface IJobAddressService
    {
        public Task<List<JobAddressVM>> JobAddressList();
		public Task<JobAddressVM> GetAccountById(int id);
        public Task<JobAddressVM> Add(JobAddressVM jobAddress);
        public Task<JobAddressVM> Update(string Id, JobAddressVM newJobAddress);
        public Task<JobAddressVM> Delete(string Id);
    }
}
