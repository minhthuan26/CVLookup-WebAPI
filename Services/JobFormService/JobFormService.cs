using AutoMapper;
using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;
using CVLookup_WebAPI.Utilities;
using FirstWebApi.Models.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace CVLookup_WebAPI.Services.JobFormService
{
	public class JobFormService : IJobFormService
	{
		private readonly AppDBContext _dbContext;
		private readonly IMapper _mapper;

		public JobFormService(AppDBContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}
		public async Task<JobForm> Add(JobFormVM jobFormVM)
		{
			try
			{
				var jobForm = _mapper.Map<JobForm>(jobFormVM);
				var formExisted = await _dbContext.JobForm.Where(prop => prop.Form == jobForm.Form).FirstOrDefaultAsync();
				if (formExisted != null)
				{
					throw new ExceptionReturn(400, "Thất bại. Tên hình thức đã tồn tại");
				}
				var result = await _dbContext.JobForm.AddAsync(jobForm);
				if (result.State.ToString() == "Added")
				{
					int saveState = await _dbContext.SaveChangesAsync();
					if (saveState <= 0)
					{
						throw new ExceptionReturn(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
					}
					return jobForm;
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

		public async Task<JobForm> Delete(string Id)
		{
			try
			{
				if (Id == null)
				{
					throw new ExceptionReturn(400, "Thất bại. Truy vấn không hợp lệ");
				}

				var jobForm = await _dbContext.JobForm.Where(prop => prop.Id == Id).FirstOrDefaultAsync();
				if (jobForm == null)
				{
					throw new ExceptionReturn(404, "Thất bại. Không thể tìm thấy dữ liệu");
				}

				var result = _dbContext.JobForm.Remove(jobForm);
				if (result.State.ToString() == "Deleted")
				{
					var saveState = await _dbContext.SaveChangesAsync();
					if (saveState <= 0)
					{
						throw new ExceptionReturn(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
					}
					return jobForm;
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

		public async Task<JobForm> GetJobFormById(string id)
		{
			try
			{
				if (id == null)
				{
					throw new ExceptionReturn(400, "Thất bại. Truy vấn không hợp lệ");
				}

				var result = await _dbContext.JobForm.Where(prop => prop.Id == id).FirstOrDefaultAsync();
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

		public async Task<List<JobForm>> GetJobFormsByName(string form)
		{
			try
			{
				if (form == null)
				{
					throw new ExceptionReturn(400, "Thất bại. Truy vấn không hợp lệ");
				}

				var result = await _dbContext.JobForm.Where(prop => prop.Form.Contains(form)).ToListAsync();
				return result;
			}
			catch (ExceptionReturn e)
			{
				throw new ExceptionReturn(e.Code, e.Message);
			}
		}

		public async Task<List<JobForm>> JobFormList()
		{
			try
			{
				var jobFormList = await _dbContext.JobForm.ToListAsync();
				return jobFormList;
			}
			catch (ExceptionReturn e)
			{
				throw new ExceptionReturn(500, e.Message);
			}
		}

		public async Task<JobForm> Update(string Id, JobFormVM newJobFormVM)
		{
			try
			{
				var jobForm = await _dbContext.JobForm.Where(prop => prop.Id == Id).FirstOrDefaultAsync();
				if (jobForm == null)
				{
					throw new ExceptionReturn(404, "Thất bại. Không thể tìm thấy dữ liệu");
				}

				jobForm.Form = newJobFormVM.Form;
				var result = _dbContext.JobForm.Update(jobForm);
				if (result.State.ToString() == "Modified")
				{
					int saveState = await _dbContext.SaveChangesAsync();
					if (saveState <= 0)
					{
						throw new ExceptionReturn(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
					}
					return jobForm;

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
