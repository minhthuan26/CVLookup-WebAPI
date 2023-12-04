using AutoMapper;
using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;
using CVLookup_WebAPI.Utilities;
using FirstWebApi.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace CVLookup_WebAPI.Models.Mapper
{
	public class RecruitmentCVResolver
	{
		public class CurriculumVitaeResolver : IValueResolver<RecruitmentCVVM, RecruitmentCV, CurriculumVitae>
		{
			private readonly AppDBContext _dbContext;

			public CurriculumVitaeResolver(AppDBContext dbContext)
			{
				_dbContext = dbContext;
			}
			public CurriculumVitae Resolve(RecruitmentCVVM source, RecruitmentCV destination, CurriculumVitae destMember, ResolutionContext context)
			{
				try
				{
					var cv = _dbContext.CurriculumVitae.Where(prop => prop.Id == source.CurriculumVitaeId).FirstOrDefault();

					if(cv == null)
					{
						throw new ExceptionModel(404, "Thất bại. Không thể tìm thấy dữ liệu");
					}
					
					return cv;
				} catch (ExceptionModel e)
				{
					throw new ExceptionModel(e.Code, e.Message);
				}
			}
		}

		public class RecruitmentResolver : IValueResolver<RecruitmentCVVM, RecruitmentCV, Recruitment>
		{
			private readonly AppDBContext _dbContext;

			public RecruitmentResolver(AppDBContext dbContext)
			{
				_dbContext = dbContext;
			}
			public Recruitment Resolve(RecruitmentCVVM source, RecruitmentCV destination, Recruitment destMember, ResolutionContext context)
			{
				try
				{
					var recruitment = _dbContext.Recruitment
						.Include(prop => prop.Employer)
						.Where(prop => prop.Id == source.RecruitmentId).FirstOrDefault();

					if (recruitment == null)
					{
						throw new ExceptionModel(404, "Thất bại. Không thể tìm thấy dữ liệu");
					}

					return recruitment;
				}
				catch (ExceptionModel e)
				{
					throw new ExceptionModel(e.Code, e.Message);
				}
			}
		}
	}
}
