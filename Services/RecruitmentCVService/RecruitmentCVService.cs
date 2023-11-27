using AutoMapper;
using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;
using CVLookup_WebAPI.Services.AuthService;
using CVLookup_WebAPI.Services.CurriculumService;
using CVLookup_WebAPI.Services.RecruitmentService;
using CVLookup_WebAPI.Utilities;
using FirstWebApi.Models.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage;
using System.Runtime.InteropServices;

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

				if (currentUser != recruitmentCV.CurriculumVitae.User)
				{
					throw new ExceptionModel(400, "Thất bại. Bạn không có quyền truy cập CV này");
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
						recruitment = new
						{
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

		public async Task<object> GetRecruitmentCVBy_RecruitmentId(string id)
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

		public async Task<object> GetRecruitmentCVBy_CVId(string id)
		{
			try
			{
				var result = await _dbContext.RecruitmentCV.Where(prop => prop.CurriculumVitaeId == id)
															.Include(props => props.CurriculumVitae)
															.FirstOrDefaultAsync();

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

		public async Task<object> GetAllCVApplied(string recruitmentId)
		{
			try
			{
				User currentUser = await _authService.GetCurrentLoginUser();
				var role = await _dbContext.UserRole
					.Include(prop => prop.Role)
					.Where(prop => prop.UserId == currentUser.Id)
					.Select(prop => new
					{
						prop.Role.RoleName
					})
					.FirstOrDefaultAsync();

				var isRecruitmentBelongToUser = await _dbContext.Recruitment.FirstOrDefaultAsync(prop => prop.Employer.Id == currentUser.Id);
				if (role?.RoleName != "Admin" && isRecruitmentBelongToUser == null)
				{
					throw new ExceptionModel(400, "Thất bại. Truy cập bị từ chối");
				}
				var result = await _dbContext.RecruitmentCV
					.Include(prop => prop.CurriculumVitae)
					.ThenInclude(prop => prop.User)
					.Where(prop => prop.RecruitmentId == recruitmentId)
					.OrderBy(prop => prop.AppliedAt)
					.Select(prop => new
					{
						prop.RecruitmentId,
						prop.CurriculumVitaeId,
						prop.IsPass,
						prop.IsView,
						prop.AppliedAt,
						prop.CurriculumVitae
					})
					.ToListAsync();

				return result;
			}
			catch (ExceptionModel e)
			{
				throw new ExceptionModel(e.Code, e.Message);
			}
		}

		public async Task<object> ReAppplyCV(string recruitmentId, string userId, string cvId)
		{
			IDbContextTransaction transaction = await _dbContext.Database.BeginTransactionAsync();
			try
			{
				var recruitment = await _dbContext.RecruitmentCV
					.Where(prop => prop.RecruitmentId == recruitmentId && prop.CurriculumVitae.User.Id == userId)
					.FirstOrDefaultAsync();

				var cv = await _dbContext.CurriculumVitae.FirstOrDefaultAsync(prop => prop.Id == cvId);

				if (recruitment == null || cv == null)
				{
					throw new ExceptionModel(404, "Thất bại. Không thể tìm thấy dữ liệu");
				}

				_dbContext.RecruitmentCV.Remove(recruitment);

				var newRecord = _mapper.Map<RecruitmentCV>(new RecruitmentCVVM()
				{
					RecruitmentId = recruitmentId,
					CurriculumVitaeId = cvId
				});

				await _dbContext.RecruitmentCV.AddAsync(newRecord);
				await _dbContext.SaveChangesAsync();
				await transaction.CommitAsync();

				return newRecord;

			}
			catch (ExceptionModel e)
			{
				await transaction.RollbackAsync();
				throw new ExceptionModel(e.Code, e.Message);
			}
		}

		public async Task<RecruitmentCV> UpdateIsView(string id)
		{
			try
			{
				var recruitmentCV = (RecruitmentCV)await this.GetRecruitmentCVBy_CVId(id);
				recruitmentCV.IsView = true;
				var result = _dbContext.RecruitmentCV.Update(recruitmentCV);
				if (result.State.ToString() == "Modified")
				{
					int saveState = await _dbContext.SaveChangesAsync();
					if (saveState <= 0)
					{
						throw new ExceptionModel(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
					}
					return recruitmentCV;

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

		public async Task<RecruitmentCV> ToggleIsPass(string id)
		{
			try
			{
				var recruitmentCV = (RecruitmentCV)await this.GetRecruitmentCVBy_CVId(id);
				recruitmentCV.IsPass = !recruitmentCV.IsPass;
				var result = _dbContext.RecruitmentCV.Update(recruitmentCV);
				if (result.State.ToString() == "Modified")
				{
					int saveState = await _dbContext.SaveChangesAsync();
					if (saveState <= 0)
					{
						throw new ExceptionModel(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
					}
					return recruitmentCV;

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

		public async Task<object> GetRecruitmentBy_UserId_And_RecruitmentId(string userId, string recruitmentId)
		{
			try
			{
				var result = await _dbContext.RecruitmentCV
					.Include(props => props.CurriculumVitae)
					.ThenInclude(prop => prop.User)
					.Where(prop => prop.CurriculumVitae.User.Id == userId && prop.RecruitmentId == recruitmentId).FirstOrDefaultAsync();

				if (result == null)
				{
					return result;
				}
				else
				{
					return new
					{
						result.RecruitmentId,
						result.CurriculumVitaeId,
						result.IsPass,
						result.IsView,
						result.AppliedAt
					};
				}

			}
			catch (ExceptionModel e)
			{
				throw new ExceptionModel(e.Code, e.Message);
			}
		}
	}
}

