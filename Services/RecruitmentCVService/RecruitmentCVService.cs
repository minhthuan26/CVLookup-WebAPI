using AutoMapper;
using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;
using CVLookup_WebAPI.Services.AuthService;
using CVLookup_WebAPI.Services.CurriculumService;
using CVLookup_WebAPI.Services.RecruitmentService;
using CVLookup_WebAPI.Utilities;
using FirstWebApi.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace CVLookup_WebAPI.Services.RecruitmentCVService
{
	public class RecruitmentCVService : IRecruitmentCVService
	{
		private readonly AppDBContext _dbContext;
		private readonly IMapper _mapper;
		private readonly IRecruitmentService _recruitmentService;
		private readonly ICurriculumViateService _curriculumViateService;
		private readonly IAuthService _authService;

		public RecruitmentCVService(AppDBContext dbContext, IMapper mapper, IRecruitmentService recruitmentService, ICurriculumViateService curriculumViateService, IAuthService authService)
		{
			_dbContext = dbContext;
			_mapper = mapper;
			_recruitmentService = recruitmentService;
			_curriculumViateService = curriculumViateService;
			_authService = authService;
		}

		public async Task<object> ApplyToRecruitment(RecruitmentCVVM recruitmentCVVM)
		{
			try
			{
				var currentUser = await _authService.GetCurrentLoginUser();
				var recruitmentCV = _mapper.Map<RecruitmentCV>(recruitmentCVVM);

				if(currentUser != recruitmentCV.CurriculumVitae.User)
				{
					throw new ExceptionModel(400, "Thất bại. Bạn không có quyền truy cập CV này");
				}

				var existedRecruitmentCV = await _dbContext.RecruitmentCV.Where(prop => prop.CurriculumVitaeId == recruitmentCVVM.CurriculumVitaeId && prop.RecruitmentId == recruitmentCVVM.RecruitmentId).FirstOrDefaultAsync();
				if (existedRecruitmentCV != null)
				{
					throw new ExceptionModel(400, "Thất bại. CV này đã được nộp cho đơn tuyển dụng này trước đó");
				}

				var result = await _dbContext.RecruitmentCV.AddAsync(recruitmentCV);
				if (result.State.ToString() == "Added")
				{
					int saveState = await _dbContext.SaveChangesAsync();
					if (saveState <= 0)
					{
						throw new ExceptionModel(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
					}
					return new
					{
						recruitment = new {
							Id = recruitmentCV.RecruitmentId,
							title = recruitmentCV.Recruitment.JobTitle
						},
						curriculumVitae = new
						{
							Id = recruitmentCV.CurriculumVitaeId,
						},
						user = currentUser
					};
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

		public async Task<RecruitmentCV> Delete(string recruitmentId, string curriculumVitaeId)
		{
			try
			{
				if (recruitmentId == null || curriculumVitaeId == null)
				{
					throw new ExceptionModel(400, "Thất bại. Truy vấn không hợp lệ");
				}

				var recruitmentCV = await _dbContext.RecruitmentCV.Where(prop => prop.RecruitmentId == recruitmentId && prop.CurriculumVitaeId == curriculumVitaeId).FirstOrDefaultAsync();
				if (recruitmentCV == null)
				{
					throw new ExceptionModel(404, "Thất bại. Không thể tìm thấy dữ liệu");
				}

				var result = _dbContext.RecruitmentCV.Remove(recruitmentCV);
				if (result.State.ToString() == "Deleted")
				{
					var saveState = await _dbContext.SaveChangesAsync();
					if (saveState <= 0)
					{
						throw new ExceptionModel(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
					}
					return recruitmentCV;
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

		public async Task<object> GetRecruitmentCVByRecruitmentId(string id)
		{
			try
			{
				var result = await _dbContext.RecruitmentCV.Where(prop => prop.RecruitmentId == id)
					.Include(prop => prop.CurriculumVitae)
					.Include(prop => prop.Recruitment)
					.ToListAsync();

				if (result.Count == 0)
				{
					return result;
				}

				List<CurriculumVitae> cvList = new();
				foreach (var row in result)
				{
					cvList.Add(row.CurriculumVitae);
				}

				return new
				{
					Recruitment = result[0].Recruitment,
					CurriculumVitaes = cvList
				};
			}
			catch (ExceptionModel e)
			{
				throw new ExceptionModel(e.Code, e.Message);
			}
		}

		public async Task<RecruitmentCV> GetRecruitmentCVByCurriculumVitaeId(string id)
		{
			try
			{
				var result = await _dbContext.RecruitmentCV.Where(prop => prop.CurriculumVitaeId == id).Include(props => props.CurriculumVitae).FirstOrDefaultAsync();

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

		public Task<List<RecruitmentCV>> RecruitmentCVList()
		{
			throw new NotImplementedException();
		}

		public Task<RecruitmentCV> Update(string Id, RecruitmentCVVM newRecruitmentCV)
		{
			throw new NotImplementedException();
		}
	}
}
