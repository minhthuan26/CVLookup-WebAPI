using AutoMapper;
using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;
using CVLookup_WebAPI.Utilities;
using FirstWebApi.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace CVLookup_WebAPI.Services.RecruitmentCVService
{
    public class RecruitmentCVService : IRecruitmentCVService
    {
        private readonly AppDBContext _dbContext;
        private readonly IMapper _mapper;

        public RecruitmentCVService(AppDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;

        }

        public async Task<RecruitmentCV> Add(RecruitmentCVVM recruitmentCVVM)
        {
            try
            {
                var recruitmentCV = _mapper.Map<RecruitmentCV>(recruitmentCVVM);
                var result = await _dbContext.RecruitmentCV.AddAsync(recruitmentCV);
                if (result.State.ToString() == "Added")
                {
                    int saveState = await _dbContext.SaveChangesAsync();
                    if (saveState <= 0)
                    {
                        throw new ExceptionReturn(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
                    }
                    return recruitmentCV;
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

        public async Task<RecruitmentCV> Delete(string recruitmentId, string curriculumVitaeId)
        {
            try
            {
                if (recruitmentId == null || curriculumVitaeId == null)
                {
                    throw new ExceptionReturn(400, "Thất bại. Truy vấn không hợp lệ");
                }

                var recruitmentCV = await _dbContext.RecruitmentCV.Where(prop => prop.RecruitmentId == recruitmentId && prop.CurriculumVitaeId == curriculumVitaeId).FirstOrDefaultAsync();
                if (recruitmentCV == null)
                {
                    throw new ExceptionReturn(404, "Thất bại. Không thể tìm thấy dữ liệu");
                }

                var result = _dbContext.RecruitmentCV.Remove(recruitmentCV);
                if (result.State.ToString() == "Deleted")
                {
                    var saveState = await _dbContext.SaveChangesAsync();
                    if (saveState <= 0)
                    {
                        throw new ExceptionReturn(500, "Thất bại. Có lỗi xảy ra trong quá trình lưu dữ liệu");
                    }
                    return recruitmentCV;
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

        public async Task<RecruitmentCV> GetAccountByRecruitmentId(string id)
        {
            try
            {
                var result = await _dbContext.RecruitmentCV.Where(prop => prop.RecruitmentId == id).Include(props=>props.Recruitment).FirstOrDefaultAsync();

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
        
        public async Task<RecruitmentCV> GetAccountByCurriculumVitaeId  (string id)
        {
            try
            {
                var result = await _dbContext.RecruitmentCV.Where(prop => prop.CurriculumVitaeId == id).Include(props=>props.CurriculumVitae).FirstOrDefaultAsync();

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
