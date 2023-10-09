using AutoMapper;
using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;
using CVLookup_WebAPI.Utilities;
using FirstWebApi.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace CVLookup_WebAPI.Services.JobPositionService
{
	public class JobPositionService : IJobPositionService
	{
		private readonly AppDBContext _dbContext;
		private readonly IMapper _mapper;

		public JobPositionService(AppDBContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}
		public async Task<JobPosition> Add(JobPositionVM jobPositionVM)
		{
			try
			{
				var jobPosition = _mapper.Map<JobPosition>(jobPositionVM);
				var formExisted = await _dbContext.JobPosition.Where(prop => prop.Position == jobPosition.Position).FirstOrDefaultAsync();
				if (formExisted != null)
				{
					throw new ExceptionModel(400, "Thất bại. Tên vị trí đã tồn tại");
				}
				var result = await _dbContext.JobPosition.AddAsync(jobPosition);
				if (result.State.ToString() == "Added")
				{
					int saveState = await _dbContext.SaveChangesAsync();
					if (saveState <= 0)
					{
						throw new ExceptionModel(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
					}
					return jobPosition;
				}
				else
				{
					throw new ExceptionModel(500, "Thất bại. Có lỗi xảy ra trong quá trình thêm dữ liệu");
				}

			}
			catch (ExceptionModel e)
			{
				throw new ExceptionModel(e.Code, e.Message);
			}
		}

		public async Task<JobPosition> Delete(string Id)
		{
			try
			{
				if (Id == null)
				{
					throw new ExceptionModel(400, "Thất bại. Truy vấn không hợp lệ");
				}

				var jobPosition = await _dbContext.JobPosition.Where(prop => prop.Id == Id).FirstOrDefaultAsync();
				if (jobPosition == null)
				{
					throw new ExceptionModel(404, "Thất bại. Không thể tìm thấy dữ liệu");
				}

				var result = _dbContext.JobPosition.Remove(jobPosition);
				if (result.State.ToString() == "Deleted")
				{
					var saveState = await _dbContext.SaveChangesAsync();
					if (saveState <= 0)
					{
						throw new ExceptionModel(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
					}
					return jobPosition;
				}
				else
				{
					throw new ExceptionModel(500, "Thất bại. Có lỗi xảy ra trong quá trình xoá dữ liệu");
				}

			}
			catch (ExceptionModel e)
			{
				throw new ExceptionModel(e.Code, e.Message);
			}
		}

		public async Task<JobPosition> GetJobPositionById(string id)
		{
			try
			{
				if (id == null)
				{
					throw new ExceptionModel(400, "Thất bại. Truy vấn không hợp lệ");
				}

				var result = await _dbContext.JobPosition.Where(prop => prop.Id == id).FirstOrDefaultAsync();
				if (result == null)
				{
					throw new ExceptionModel(404, "Thất bại. Không thể tìm thấy dữ liệu");
				}
				return result;
			}
			catch (ExceptionModel e)
			{
				throw new ExceptionModel(e.Code, e.Message);
			}
		}

		public async Task<List<JobPosition>> GetJobPositionsByName(string position)
		{
			try
			{
				if (position == null)
				{
					throw new ExceptionModel(400, "Thất bại. Truy vấn không hợp lệ");
				}

				var result = await _dbContext.JobPosition.Where(prop => prop.Position.Contains(position)).ToListAsync();
				return result;
			}
			catch (ExceptionModel e)
			{
				throw new ExceptionModel(e.Code, e.Message);
			}
		}

		public async Task<List<JobPosition>> JobPositionList()
		{
			try
			{
				var jobPositionList = await _dbContext.JobPosition.ToListAsync();
				return jobPositionList;
			}
			catch (ExceptionModel e)
			{
				throw new ExceptionModel(500, e.Message);
			}
		}

		public async Task<JobPosition> Update(string Id, JobPositionVM newJobPositionVM)
		{
			try
			{
				var jobPosition = await _dbContext.JobPosition.Where(prop => prop.Id == Id).FirstOrDefaultAsync();
				if (jobPosition == null)
				{
					throw new ExceptionModel(404, "Thất bại. Không thể tìm thấy dữ liệu");
				}

				jobPosition.Position = newJobPositionVM.Position;
				var result = _dbContext.JobPosition.Update(jobPosition);
				if (result.State.ToString() == "Modified")
				{
					int saveState = await _dbContext.SaveChangesAsync();
					if (saveState <= 0)
					{
						throw new ExceptionModel(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
					}
					return jobPosition;

				}
				else
				{
					throw new ExceptionModel(500, "Thất bại. Có lỗi xảy ra trong quá trình cập nhật dữ liệu");
				}

			}
			catch (ExceptionModel e)
			{
				throw new ExceptionModel(e.Code, e.Message);
			}
		}
	}
}
