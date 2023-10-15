using AutoMapper;
using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;
using CVLookup_WebAPI.Utilities;

namespace CVLookup_WebAPI.Models.Mapper
{
    public class MappingProflie : Profile
    {
        public MappingProflie()
        {
            try
            {
                CreateMap<Account, AccountVM>().ReverseMap();
                CreateMap<AccountUser, AccountUserVM>().ReverseMap();
                CreateMap<User, UserVM>().ReverseMap();
                CreateMap<UserRole, UserRoleVM>().ReverseMap();
                CreateMap<JobAddressVM, JobAddress>().ReverseMap();
                CreateMap<JobField, JobFieldVM>().ReverseMap();
                CreateMap<JobCareer, JobCareerVM>().ReverseMap();
                CreateMap<JobPosition, JobPositionVM>().ReverseMap();
                CreateMap<Employer, EmployerVM>().ReverseMap();
                CreateMap<Candidate, CandidateVM>().ReverseMap();
                CreateMap<RecruitmentVM, Recruitment>()
                    .ForMember(domain => domain.JobAddress, options =>
                    {
                        options.MapFrom<RecruitmentResolver.JobAddressResolver>();
                    })
                    .ForMember(domain => domain.JobCareer, options =>
                    {
                        options.MapFrom<RecruitmentResolver.JobCareerResolver>();
                    })
                    .ForMember(domain => domain.JobField, options =>
                    {
                        options.MapFrom<RecruitmentResolver.JobFieldResolver>();
                    })
                    .ForMember(domain => domain.JobForm, options =>
                    {
                        options.MapFrom<RecruitmentResolver.JobFormResolver>();
                    })
                    .ForMember(domain => domain.Experience, options =>
                    {
                        options.MapFrom<RecruitmentResolver.ExperienceResolver>();
                    })
                    .ForMember(domain => domain.JobPosition, options =>
                    {
                        options.MapFrom<RecruitmentResolver.JobPositionResolver>();
                    });
                CreateMap<CurriculumVitaeVM, CurriculumVitae>().ReverseMap();
                CreateMap<Role, RoleVM>().ReverseMap();
                CreateMap<JobForm, JobFormVM>().ReverseMap();
                CreateMap<JobAddress, JobAddressVM>().ReverseMap();
                CreateMap<Token, TokenVM>().ReverseMap();
                CreateMap<ProvinceVM, Province>().ReverseMap();
                CreateMap<DistrictVM, District>().ForMember(domain => domain.ProvinceId, options =>
                {
                    options.MapFrom<DistrictResolver>();
                });
            }
            catch (ExceptionModel e)
            {
                throw new ExceptionModel(e.Code, e.Message);
            }

        }
    }
}
