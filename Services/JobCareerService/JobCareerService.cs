using AutoMapper;
using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;
using CVLookup_WebAPI.Utilities;
using FirstWebApi.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace CVLookup_WebAPI.Services.JobCareerService
{
	public class JobCareerService : IJobCareerService
	{
		private readonly AppDBContext _dbContext;
		private readonly IMapper _mapper;

		public JobCareerService(AppDBContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}

		public async Task<JobCareer> Add(JobCareerVM jobCareerVM)
		{
			try
			{
				var jobCareer = _mapper.Map<JobCareer>(jobCareerVM);
				var addressExisted = await _dbContext.JobCareer.Where(prop => prop.Career == jobCareer.Career).FirstOrDefaultAsync();
				if (addressExisted != null)
				{
					throw new ExceptionReturn(400, "Thất bại. Tên nghề nghiệp đã tồn tại");
				}
				var result = await _dbContext.JobCareer.AddAsync(jobCareer);
				if (result.State.ToString() == "Added")
				{
					int saveState = await _dbContext.SaveChangesAsync();
					if (saveState <= 0)
					{
						throw new ExceptionReturn(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
					}
					return jobCareer;
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

		public async Task<JobCareer> Delete(string Id)
		{
			try
			{
				if (Id == null)
				{
					throw new ExceptionReturn(400, "Thất bại. Truy vấn không hợp lệ");
				}

				var jobCareer = await _dbContext.JobCareer.Where(prop => prop.Id == Id).FirstOrDefaultAsync();
				if (jobCareer == null)
				{
					throw new ExceptionReturn(404, "Thất bại. Không thể tìm thấy dữ liệu");
				}

				var result = _dbContext.JobCareer.Remove(jobCareer);
				if (result.State.ToString() == "Deleted")
				{
					var saveState = await _dbContext.SaveChangesAsync();
					if (saveState <= 0)
					{
						throw new ExceptionReturn(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
					}
					return jobCareer;
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

		public async Task<JobCareer> GetJobCareerById(string id)
		{
			try
			{
				if (id == null)
				{
					throw new ExceptionReturn(400, "Thất bại. Truy vấn không hợp lệ");
				}

				var result = await _dbContext.JobCareer.Where(prop => prop.Id == id).FirstOrDefaultAsync();
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

		public async Task<List<JobCareer>> GetJobCareersByName(string career)
		{
			try
			{
				if (career == null)
				{
					throw new ExceptionReturn(400, "Thất bại. Truy vấn không hợp lệ");
				}

				var result = await _dbContext.JobCareer.Where(prop => prop.Career.Contains(career)).ToListAsync();
				return result;
			}
			catch (ExceptionReturn e)
			{
				throw new ExceptionReturn(e.Code, e.Message);
			}
		}

		public async Task<List<JobCareer>> JobCareerList()
		{
			try
			{
				var jobCareerList = await _dbContext.JobCareer.ToListAsync();
				return jobCareerList;
			}
			catch (ExceptionReturn e)
			{
				throw new ExceptionReturn(500, e.Message);
			}
		}

		public async Task<JobCareer> Update(string Id, JobCareerVM newJobCareerVM)
		{
			try
			{
				var jobCareer = await _dbContext.JobCareer.Where(prop => prop.Id == Id).FirstOrDefaultAsync();
				if (jobCareer == null)
				{
					throw new ExceptionReturn(404, "Thất bại. Không thể tìm thấy dữ liệu");
				}

				jobCareer.Career = newJobCareerVM.Career;
				var result = _dbContext.JobCareer.Update(jobCareer);
				if (result.State.ToString() == "Modified")
				{
					int saveState = await _dbContext.SaveChangesAsync();
					if (saveState <= 0)
					{
						throw new ExceptionReturn(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
					}
					return jobCareer;

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
