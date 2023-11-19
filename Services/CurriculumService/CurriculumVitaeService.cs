using AutoMapper;
using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;
using CVLookup_WebAPI.Services.AuthService;
using CVLookup_WebAPI.Services.FileService;
using CVLookup_WebAPI.Services.UserService;
using CVLookup_WebAPI.Utilities;
using FirstWebApi.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace CVLookup_WebAPI.Services.CurriculumService
{
	public class CurriculumVitaeService : ICurriculumViateService
	{
		private AppDBContext _dbContext;
		private readonly IMapper _mapper;
		private readonly IAuthService _authService;
		private readonly IFileService _fileService;

		public CurriculumVitaeService(AppDBContext dbContext, IMapper mapper, IAuthService authService, IFileService fileService)
		{
			_dbContext = dbContext;
			_mapper = mapper;
			_authService = authService;
			_fileService = fileService;
		}

		public async Task<CurriculumVitae> Add(CurriculumVitaeVM curriculumVitaeVM)
		{
			try
			{
				var curriculumVitae = _mapper.Map<CurriculumVitae>(curriculumVitaeVM);
				var user = await _authService.GetCurrentLoginUser();

				string uploadPath = "App_Data\\Storage\\" + user.Email + "\\CV";
				curriculumVitae.User = user;

				string filePath = await _fileService.UploadFile(curriculumVitaeVM.CVFile, uploadPath);
				curriculumVitae.CVPath = filePath;

				var result = await _dbContext.CurriculumVitae.AddAsync(curriculumVitae);
				if (result.State.ToString() == "Added")
				{
					int saveState = await _dbContext.SaveChangesAsync();
					if (saveState <= 0)
					{
						throw new ExceptionModel(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
					}
					return curriculumVitae;
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

		public async Task<List<CurriculumVitae>> CurriculumVitaeList()
		{
			try
			{
				var curiculumVitae = await _dbContext.CurriculumVitae.ToListAsync();
				return curiculumVitae;
			}
			catch (ExceptionModel e)
			{
				throw new ExceptionModel(500, e.Message);
			}
		}

		public async Task<CurriculumVitae> Delete(string Id)
		{
			try
			{
				if (Id == null)
				{
					throw new ExceptionModel(400, "Thất bại. Truy vấn không hợp lệ");
				}

				var curriculumVitae = await _dbContext.CurriculumVitae.Where(prop => prop.Id == Id).FirstOrDefaultAsync();
				if (curriculumVitae == null)
				{
					throw new ExceptionModel(404, "Thất bại. Không thể tìm thấy dữ liệu");
				}

				var result = _dbContext.CurriculumVitae.Remove(curriculumVitae);
				if (result.State.ToString() == "Deleted")
				{
					var saveState = await _dbContext.SaveChangesAsync();
					if (saveState <= 0)
					{
						throw new ExceptionModel(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
					}
					return curriculumVitae;
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

		public async Task<CurriculumVitae> GetCurriculumVitaeById(string id)
		{
			try
			{
				if (id == null)
				{
					throw new ExceptionModel(400, "Thất bại. Truy vấn không hợp lệ");
				}

				var result = await _dbContext.CurriculumVitae.Where(prop => prop.Id == id).FirstOrDefaultAsync();
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


		public async Task<List<CurriculumVitae>> GetByCandidateId(string candidateId)
		{
			try
			{
				var curiculumVitae = await _dbContext.CurriculumVitae.Where(prop => prop.User.Id == candidateId).ToListAsync();
				return curiculumVitae;
			}
			catch (ExceptionModel e)
			{
				throw new ExceptionModel(e.Code, e.Message);
			}
		}


		public async Task<CurriculumVitae> Update(string Id, CurriculumVitaeVM newCurriculumVitaeVM)
		{
			try
			{
				var curriculumVitae = await _dbContext.CurriculumVitae.Where(prop => prop.Id == Id).FirstOrDefaultAsync();
				if (curriculumVitae == null)
				{
					throw new ExceptionModel(404, "Thất bại. Không thể tìm thấy dữ liệu");
				}
				var newCurriculumVitae = _mapper.Map<CurriculumVitae>(newCurriculumVitaeVM);
				curriculumVitae = newCurriculumVitae;
				var result = _dbContext.CurriculumVitae.Update(curriculumVitae);
				if (result.State.ToString() == "Modified")
				{
					int saveState = await _dbContext.SaveChangesAsync();
					if (saveState <= 0)
					{
						throw new ExceptionModel(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
					}
					return curriculumVitae;

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

		public async Task<FileDownload> DownloadCV(string id)
		{
			try
			{
				var cvInDB = await _dbContext.CurriculumVitae.Where(prop => prop.Id == id).FirstOrDefaultAsync();
				if (cvInDB == null)
				{
					throw new ExceptionModel(404, "Thất bại. Không thể tìm thấy dữ liệu");
				}
				var fileDownload = await _fileService.DownloadFile(cvInDB.CVPath);
				return fileDownload;
			}
			catch (ExceptionModel e)
			{
				throw new ExceptionModel(e.Code, e.Message);
			}
		}

		public async Task<object> GetCurrentUserCVUploaded()
		{
			try
			{
				User currentUser = await _authService.GetCurrentLoginUser();
				var curiculumVitae = await _dbContext.CurriculumVitae
					.Where(prop => prop.User.Id == currentUser.Id)
					.ToListAsync();
				return curiculumVitae;
			}
			catch (ExceptionModel e)
			{
				throw new ExceptionModel(e.Code, e.Message);
			}
			catch (Exception e)
			{
				throw new ExceptionModel(500, e.Message);
			}
		}
	}
}
