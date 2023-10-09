using AutoMapper;
using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;
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
        private readonly IUserService _userService;

        public CurriculumVitaeService(AppDBContext dbContext, IMapper mapper, IUserService userService)
        {
			_dbContext = dbContext; 
            _mapper = mapper;
            _userService= userService;
        }

        public async Task<CurriculumVitae> Add(CurriculumVitaeVM curriculumVitaeVM)
		{
            try
            {
                var curriculumVitae = _mapper.Map<CurriculumVitae>(curriculumVitaeVM);
                var user = await _userService.GetUserByEmail(curriculumVitaeVM.Email);  
                curriculumVitae.FullName = curriculumVitaeVM.FullName;
                curriculumVitae.PhoneNumber = curriculumVitaeVM.PhoneNumber;
                curriculumVitae.CVPath = curriculumVitaeVM.CVPath;
                curriculumVitae.Introdution = curriculumVitaeVM.Introdution;
                curriculumVitae.Email = curriculumVitaeVM.Email;
                curriculumVitae.User = user;
                var result = await _dbContext.CurriculumVitae.AddAsync(curriculumVitae);
                if (result.State.ToString() == "Added")
                {
                    int saveState = await _dbContext.SaveChangesAsync();
                    if (saveState <= 0)
                    {
                        throw new ExceptionReturn(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
                    }
                    return curriculumVitae;
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

		public async Task<List<CurriculumVitae>> CurriculumVitaeList()
		{
            try
            {
                var curiculumVitae = await _dbContext.CurriculumVitae.ToListAsync();
                return curiculumVitae;
            }
            catch (ExceptionReturn e)
            {
                throw new ExceptionReturn(500, e.Message);
            }
        }

		public async Task<CurriculumVitae> Delete(string Id)
		{
            try
            {
                if (Id == null)
                {
                    throw new ExceptionReturn(400, "Thất bại. Truy vấn không hợp lệ");
                }

                var curriculumVitae = await _dbContext.CurriculumVitae.Where(prop => prop.Id == Id).FirstOrDefaultAsync();
                if (curriculumVitae == null)
                {
                    throw new ExceptionReturn(404, "Thất bại. Không thể tìm thấy dữ liệu");
                }

                var result = _dbContext.CurriculumVitae.Remove(curriculumVitae);
                if (result.State.ToString() == "Deleted")
                {
                    var saveState = await _dbContext.SaveChangesAsync();
                    if (saveState <= 0)
                    {
                        throw new ExceptionReturn(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
                    }
                    return curriculumVitae;
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

		public async Task<CurriculumVitae> GetCurriculumVitaeById(string id)
		{
            try
            {
                if (id == null)
                {
                    throw new ExceptionReturn(400, "Thất bại. Truy vấn không hợp lệ");
                }

                var result = await _dbContext.CurriculumVitae.Where(prop => prop.Id == id).FirstOrDefaultAsync();
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


        public async Task<CurriculumVitae> GetByCandidateId (string candidateId)
        {
            try
            {
                if (candidateId == null)
                {
                    throw new ExceptionReturn(400, "Thất bại. Truy vấn không hợp lệ");
                }
                var candidate = await _dbContext.Candidate.Where(prop => prop.Id == candidateId).FirstOrDefaultAsync();
                if (candidate == null)
                {
                    throw new ExceptionReturn(404, "Thất bại. Không thể tìm thấy dữ liệu");
                }

                var result = await _dbContext.CurriculumVitae.Where(prop => prop.User.Id == candidate.Id).FirstOrDefaultAsync();
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


		public async Task<CurriculumVitae> Update(string Id, CurriculumVitaeVM newCurriculumVitaeVM)
		{
            try
            {
                var curriculumVitae = await _dbContext.CurriculumVitae.Where(prop => prop.Id == Id).FirstOrDefaultAsync();
                if (curriculumVitae == null)
                {
                    throw new ExceptionReturn(404, "Thất bại. Không thể tìm thấy dữ liệu");
                }
                var newCurriculumVitae = _mapper.Map<CurriculumVitae>(newCurriculumVitaeVM);
                curriculumVitae = newCurriculumVitae;
                var result = _dbContext.CurriculumVitae.Update(curriculumVitae);
                if (result.State.ToString() == "Modified")
                {
                    int saveState = await _dbContext.SaveChangesAsync();
                    if (saveState <= 0)
                    {
                        throw new ExceptionReturn(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
                    }
                    return curriculumVitae;

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
