using AutoMapper;
using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;
using CVLookup_WebAPI.Utilities;
using FirstWebApi.Models.Database;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace CVLookup_WebAPI.Services.JobAddressService
{
	public class JobAddressService : IJobFieldService
	{
		private readonly AppDBContext _dbContext;
		private readonly IMapper _mapper;

		public JobAddressService(AppDBContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}

		public async Task<JobAddress> Add(JobAddressVM jobAddressVM)
		{
			try
			{
				var jobAddress = _mapper.Map<JobAddress>(jobAddressVM);
				var addressExisted = await _dbContext.JobAddress.Where(prop => prop.Address == jobAddress.Address).FirstOrDefaultAsync();
				if (addressExisted != null)
				{
					throw new ExceptionReturn(400, "Thất bại. Tên địa điểm đã tồn tại");
				}
				var result = await _dbContext.JobAddress.AddAsync(jobAddress);
				if (result.State.ToString() == "Added")
				{
					int saveState = await _dbContext.SaveChangesAsync();
					if (saveState <= 0)
					{
						throw new ExceptionReturn(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
					}
					return jobAddress;
				}
				else
				{
					throw new ExceptionReturn(500, "Thất bại. Có lỗi xảy ra trong quá trình thêm dữ liệu");
				}

			}
			catch (ExceptionReturn e)
			{
				throw new ExceptionReturn(e.Code, e.Message);
			}
		}

		public async Task<JobAddress> Delete(string Id)
		{
			try
			{
				if (Id == null)
				{
					throw new ExceptionReturn(400, "Thất bại. Truy vấn không hợp lệ");
				}

				var jobAddress = await _dbContext.JobAddress.Where(prop => prop.Id == Id).FirstOrDefaultAsync();
				if (jobAddress == null)
				{
					throw new ExceptionReturn(404, "Thất bại. Không thể tìm thấy dữ liệu");
				}

				var result = _dbContext.JobAddress.Remove(jobAddress);
				if (result.State.ToString() == "Deleted")
				{
					var saveState = await _dbContext.SaveChangesAsync();
					if (saveState <= 0)
					{
						throw new ExceptionReturn(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
					}
					return jobAddress;
				}
				else
				{
					throw new ExceptionReturn(500, "Thất bại. Có lỗi xảy ra trong quá trình xoá dữ liệu");
				}

			}
			catch (ExceptionReturn e)
			{
				throw new ExceptionReturn(e.Code, e.Message);
			}
		}

		public async Task<JobAddress> GetJobAddressById(string id)
		{
			try
			{
				if (id == null)
				{
					throw new ExceptionReturn(400, "Thất bại. Truy vấn không hợp lệ");
				}

				var result = await _dbContext.JobAddress.Where(prop => prop.Id == id).FirstOrDefaultAsync();
				if (result == null)
				{
					throw new ExceptionReturn(404, "Thất bại. Không thể tìm thấy dữ liệu");
				}
				return result;
			}
			catch (ExceptionReturn e)
			{
				throw new ExceptionReturn(e.Code, e.Message);
			}
		}

		public async Task<JobAddress> GetJobAddressByName(string address)
		{
			try
			{
				if (address == null)
				{
					throw new ExceptionReturn(400, "Thất bại. Truy vấn không hợp lệ");
				}

				var result = await _dbContext.JobAddress.Where(prop => prop.Address == address).FirstOrDefaultAsync();
				if (result == null)
				{
					throw new ExceptionReturn(404, "Thất bại. Không thể tìm thấy dữ liệu");
				}
				return result;
			}
			catch (ExceptionReturn e)
			{
				throw new ExceptionReturn(e.Code, e.Message);
			}
		}

		public async Task<List<JobAddress>> JobAddressList()
		{
			try
			{
				var jobAddressList = await _dbContext.JobAddress.ToListAsync();
				return jobAddressList;
			}
			catch (ExceptionReturn e)
			{
				throw new ExceptionReturn(500, e.Message);
			}
		}

		public async Task<JobAddress> Update(string Id, JobAddressVM newJobAddressVM)
		{
			try
			{
				var jobAddress = await _dbContext.JobAddress.Where(prop => prop.Id == Id).FirstOrDefaultAsync();
				if (jobAddress == null)
				{
					throw new ExceptionReturn(404, "Thất bại. Không thể tìm thấy dữ liệu");
				}

				jobAddress.Address = newJobAddressVM.Address;
				var result = _dbContext.JobAddress.Update(jobAddress);
				if (result.State.ToString() == "Modified")
				{
					int saveState = await _dbContext.SaveChangesAsync();
					if (saveState <= 0)
					{
						throw new ExceptionReturn(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
					}
					return jobAddress;

				}
				else
				{
					throw new ExceptionReturn(500, "Thất bại. Có lỗi xảy ra trong quá trình cập nhật dữ liệu");
				}

			}
			catch (ExceptionReturn e)
			{
				throw new ExceptionReturn(e.Code, e.Message);
			}
		}
	}
}
