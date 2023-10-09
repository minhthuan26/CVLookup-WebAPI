using AutoMapper;
using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;
using CVLookup_WebAPI.Utilities;
using FirstWebApi.Models.Database;

namespace CVLookup_WebAPI.Models.Mapper
{

    public class RecruitmentResolver
    {
        public class JobAddressResolver : IValueResolver<RecruitmentVM, Recruitment, JobAddress>
        {
            private readonly AppDBContext _dbContext;

            public JobAddressResolver(AppDBContext dbContext)
            {
                _dbContext = dbContext;
            }
            public JobAddress Resolve(RecruitmentVM source, Recruitment destination, JobAddress destMember, ResolutionContext context)
            {
                try
                {

                    var province = _dbContext.Province.Where(prop => prop.Name == source.JobAddress.Province).FirstOrDefault();
                    if (province == null)
                    {
                        throw new ExceptionModel(400, "Thất bại. Địa điểm công việc không hợp lệ");
                    }
                    var district = _dbContext.District.Where(prop => prop.Name == source.JobAddress.District).FirstOrDefault();

                    if (district == null)
                    {
                        throw new ExceptionModel(400, "Thất bại. Địa điểm công việc không hợp lệ");
                    }

                    if (!province.Districts.Contains(district))
                    {
                        throw new ExceptionModel(400, "Thất bại. Địa điểm công việc không hợp lệ");
                    }

                    JobAddress jobAddress = new JobAddress
                    {
                        AddressDetail = source.JobAddress.AddressDetail,
                        Province = province,
                        District = district
                    };
                    return jobAddress;
                }
                catch (ExceptionModel e)
                {
                    throw new ExceptionModel(e.Code, e.Message);
                }
            }
        }

        public class JobFormResolver : IValueResolver<RecruitmentVM, Recruitment, JobForm>
        {
            private readonly AppDBContext _dbContext;

            public JobFormResolver(AppDBContext dbContext)
            {
                _dbContext = dbContext;
            }
            public JobForm Resolve(RecruitmentVM source, Recruitment destination, JobForm destMember, ResolutionContext context)
            {
                try
                {
                    var jobForm = _dbContext.JobForm.Where(prop => prop.Form == source.JobForm).FirstOrDefault();
                    if (jobForm == null)
                    {
                        throw new ExceptionModel(400, "Thất bại. Hình thức công việc không hợp lệ");
                    }
                    return jobForm;
                }
                catch (ExceptionModel e)
                {
                    throw new ExceptionModel(e.Code, e.Message);
                }
            }
        }

        public class JobFieldResolver : IValueResolver<RecruitmentVM, Recruitment, JobField>
        {
            private readonly AppDBContext _dbContext;

            public JobFieldResolver(AppDBContext dbContext)
            {
                _dbContext = dbContext;
            }
            public JobField Resolve(RecruitmentVM source, Recruitment destination, JobField destMember, ResolutionContext context)
            {
                try
                {
                    var jobField = _dbContext.JobField.Where(prop => prop.Field == source.JobField).FirstOrDefault();
                    if (jobField == null)
                    {
                        throw new ExceptionModel(400, "Thất bại. Lĩnh vực công việc không hợp lệ");
                    }
                    return jobField;
                }
                catch (ExceptionModel e)
                {
                    throw new ExceptionModel(e.Code, e.Message);
                }
            }
        }

        public class JobPositionResolver : IValueResolver<RecruitmentVM, Recruitment, JobPosition>
        {
            private readonly AppDBContext _dbContext;

            public JobPositionResolver(AppDBContext dbContext)
            {
                _dbContext = dbContext;
            }
            public JobPosition Resolve(RecruitmentVM source, Recruitment destination, JobPosition destMember, ResolutionContext context)
            {
                try
                {
                    var jobPosition = _dbContext.JobPosition.Where(prop => prop.Position == source.JobPosition).FirstOrDefault();
                    if (jobPosition == null)
                    {
                        throw new ExceptionModel(400, "Thất bại. Vị trí công việc không hợp lệ");
                    }
                    return jobPosition;
                }
                catch (ExceptionModel e)
                {
                    throw new ExceptionModel(e.Code, e.Message);
                }
            }
        }

        public class ExperienceResolver : IValueResolver<RecruitmentVM, Recruitment, Experience>
        {
            private readonly AppDBContext _dbContext;

            public ExperienceResolver(AppDBContext dbContext)
            {
                _dbContext = dbContext;
            }
            public Experience Resolve(RecruitmentVM source, Recruitment destination, Experience destMember, ResolutionContext context)
            {
                try
                {
                    var experience = _dbContext.Experience.Where(prop => prop.Exp == source.Experience).FirstOrDefault();
                    if (experience == null)
                    {
                        throw new ExceptionModel(400, "Thất bại. Kinh nghiệm công việc không hợp lệ");
                    }
                    return experience;
                }
                catch (ExceptionModel e)
                {
                    throw new ExceptionModel(e.Code, e.Message);
                }
            }
        }

        public class JobCareerResolver : IValueResolver<RecruitmentVM, Recruitment, JobCareer>
        {
            private readonly AppDBContext _dbContext;

            public JobCareerResolver(AppDBContext dbContext)
            {
                _dbContext = dbContext;
            }
            public JobCareer Resolve(RecruitmentVM source, Recruitment destination, JobCareer destMember, ResolutionContext context)
            {
                try
                {
                    var jobCareer = _dbContext.JobCareer.Where(prop => prop.Career == source.JobCareer).FirstOrDefault();
                    if (jobCareer == null)
                    {
                        throw new ExceptionModel(400, "Thất bại. Ngành nghề công việc không hợp lệ");
                    }
                    return jobCareer;
                }
                catch (ExceptionModel e)
                {
                    throw new ExceptionModel(e.Code, e.Message);
                }
            }
        }
    }
}
