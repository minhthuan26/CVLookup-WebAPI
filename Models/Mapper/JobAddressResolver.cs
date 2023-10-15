using AutoMapper;
using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;
using CVLookup_WebAPI.Utilities;
using FirstWebApi.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace CVLookup_WebAPI.Models.Mapper
{
    public class JobAddressResolver
    {
        public class ProvinceResolver : IValueResolver<JobAddressVM, JobAddress, Province>
    
        {
            private readonly AppDBContext _dbContext;

            public ProvinceResolver(AppDBContext dbContext)
            {
                _dbContext = dbContext;
            }
            public Province Resolve(JobAddressVM source, JobAddress destination, Province destMember, ResolutionContext context)
            {
                try
                {

                    var province = _dbContext.Province.Where(prop => prop.Name == source.Province).FirstOrDefault();
                    if (province == null)
                    {
                        throw new ExceptionModel(400, "Thất bại. Địa điểm công việc không hợp lệ");
                    }

                    if (source.District != null)
                    {
                        var district = _dbContext.District.Where(prop => prop.Name == source.District).FirstOrDefault();

                        if (district == null)
                        {
                            throw new ExceptionModel(400, "Thất bại. Địa điểm công việc không hợp lệ");
                        }

                        if (!province.Districts.Contains(district))
                        {
                            throw new ExceptionModel(400, "Thất bại. Địa điểm công việc không hợp lệ");
                        }
                    }


                    return province;
                }
                catch (ExceptionModel e)
                {
                    throw new ExceptionModel(e.Code, e.Message);
                }
            }
        }
    }
}
