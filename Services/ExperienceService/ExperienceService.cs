using AutoMapper;
using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;
using CVLookup_WebAPI.Utilities;
using FirstWebApi.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace CVLookup_WebAPI.Services.ExperienceService
{
	public class ExperienceService : IExperienceService
	{
		private readonly AppDBContext _dbContext;
		private readonly IMapper _mapper;

		public ExperienceService(AppDBContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}

		public async Task<Experience> Add(ExperienceVM experienceVM)
		{
			try
			{
				var jobExp = _mapper.Map<Experience>(experienceVM);
				var addressExisted = await _dbContext.Experience.Where(prop => prop.Exp == jobExp.Exp).FirstOrDefaultAsync();
				if (addressExisted != null)
				{
					throw new ExceptionModel(400, "Thất bại. Tên kinh nghiệm đã tồn tại");
				}
				var result = await _dbContext.Experience.AddAsync(jobExp);
				if (result.State.ToString() == "Added")
				{
					int saveState = await _dbContext.SaveChangesAsync();
					if (saveState <= 0)
					{
						throw new ExceptionModel(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
					}
					return jobExp;
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

		public async Task<Experience> Delete(string Id)
		{
			try
			{
				if (Id == null)
				{
					throw new ExceptionModel(400, "Thất bại. Truy vấn không hợp lệ");
				}

				var jobExp = await _dbContext.Experience.Where(prop => prop.Id == Id).FirstOrDefaultAsync();
				if (jobExp == null)
				{
					throw new ExceptionModel(404, "Thất bại. Không thể tìm thấy dữ liệu");
				}

				var result = _dbContext.Experience.Remove(jobExp);
				if (result.State.ToString() == "Deleted")
				{
					var saveState = await _dbContext.SaveChangesAsync();
					if (saveState <= 0)
					{
						throw new ExceptionModel(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
					}
					return jobExp;
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

		public async Task<Experience> GetExperienceById(string id)
		{
			try
			{
				if (id == null)
				{
					throw new ExceptionModel(400, "Thất bại. Truy vấn không hợp lệ");
				}

				var result = await _dbContext.Experience.Where(prop => prop.Id == id).FirstOrDefaultAsync();
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

		public async Task<List<Experience>> GetExperiencesByValue(string value)
		{
			try
			{
				if (value == null)
				{
					throw new ExceptionModel(400, "Thất bại. Truy vấn không hợp lệ");
				}

				var result = await _dbContext.Experience.Where(prop => prop.Exp.Contains(value)).ToListAsync();
				return result;
			}
			catch (ExceptionModel e)
			{
				throw new ExceptionModel(e.Code, e.Message);
			}
		}

		public async Task<List<Experience>> ExperienceList()
		{
			try
			{
				var jobExpList = await _dbContext.Experience.ToListAsync();
				return jobExpList;
			}
			catch (ExceptionModel e)
			{
				throw new ExceptionModel(500, e.Message);
			}
		}

		public async Task<Experience> Update(string Id, ExperienceVM newExperienceVM)
		{
			try
			{
				var jobExp = await _dbContext.Experience.Where(prop => prop.Id == Id).FirstOrDefaultAsync();
				if (jobExp == null)
				{
					throw new ExceptionModel(404, "Thất bại. Không thể tìm thấy dữ liệu");
				}

				jobExp.Exp = newExperienceVM.Exp;
				var result = _dbContext.Experience.Update(jobExp);
				if (result.State.ToString() == "Modified")
				{
					int saveState = await _dbContext.SaveChangesAsync();
					if (saveState <= 0)
					{
						throw new ExceptionModel(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
					}
					return jobExp;

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
