using AutoMapper;
using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;
using CVLookup_WebAPI.Utilities;
using FirstWebApi.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace CVLookup_WebAPI.Services.RecruitmentService
{
	public class RecruitmentService : IRecruitmentService
	{
		private readonly AppDBContext _dbContext;
		private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RecruitmentService(AppDBContext dbContext, IMapper mapper, IHttpContextAccessor httpContextAccessor)
		{
			_dbContext = dbContext;
			_mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }
		public async Task<Recruitment> Add(RecruitmentVM recruitmentVM)
		{
			try
			{
				
				var recruitment = _mapper.Map<Recruitment>(recruitmentVM);
				var result = await _dbContext.Recruitment.AddAsync(recruitment);
				if (result.State.ToString() == "Added")
				{
					int saveState = await _dbContext.SaveChangesAsync();
					if (saveState <= 0)
					{
						throw new ExceptionModel(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
					}
					return recruitment;
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

		public async Task<Recruitment> Delete(string Id)
		{
			try
			{
				if (Id == null)
				{
					throw new ExceptionModel(400, "Thất bại. Truy vấn không hợp lệ");
				}

				var recruitment = await _dbContext.Recruitment.Where(prop => prop.Id == Id).FirstOrDefaultAsync();
				if (recruitment == null)
				{
					throw new ExceptionModel(404, "Thất bại. Không thể tìm thấy dữ liệu");
				}

				var result = _dbContext.Recruitment.Remove(recruitment);
				if (result.State.ToString() == "Deleted")
				{
					var saveState = await _dbContext.SaveChangesAsync();
					if (saveState <= 0)
					{
						throw new ExceptionModel(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
					}
					return recruitment;
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

		public async Task<Recruitment> GetRecruitmentById(string id)
		{
			try
			{
				if (id == null)
				{
					throw new ExceptionModel(400, "Thất bại. Truy vấn không hợp lệ");
				}

				var result = await _dbContext.Recruitment.Where(prop => prop.Id == id).FirstOrDefaultAsync();
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

		public async Task<List<Recruitment>> GetRecruitmentsByTitle(string title)
		{
			try
			{
				if (title == null)
				{
					throw new ExceptionModel(400, "Thất bại. Truy vấn không hợp lệ");
				}

				var result = await _dbContext.Recruitment.Where(prop => prop.JobTitle.Contains(title)).ToListAsync();
				return result;
			}
			catch (ExceptionModel e)
			{
				throw new ExceptionModel(e.Code, e.Message);
			}
		}

        public Task<List<Recruitment>> GetRecruitmentsByUserId(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Recruitment>> RecruitmentList()
		{
			try
			{
				var recruitmentList = await _dbContext.Recruitment.ToListAsync();
				return recruitmentList;
			}
			catch (ExceptionModel e)
			{
				throw new ExceptionModel(500, e.Message);
			}
		}

		public async Task<Recruitment> Update(string Id, RecruitmentVM newRecruitmentVM)
		{
			try
			{
				var recruitment = await _dbContext.Recruitment.Where(prop => prop.Id == Id).FirstOrDefaultAsync();
				if (recruitment == null)
				{
					throw new ExceptionModel(404, "Thất bại. Không thể tìm thấy dữ liệu");
				}
				var newRecuitment = _mapper.Map<Recruitment>(newRecruitmentVM);
				recruitment = newRecuitment;
				var result = _dbContext.Recruitment.Update(recruitment);
				if (result.State.ToString() == "Modified")
				{
					int saveState = await _dbContext.SaveChangesAsync();
					if (saveState <= 0)
					{
						throw new ExceptionModel(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
					}
					return recruitment;

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
