using AutoMapper;
using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;
using CVLookup_WebAPI.Utilities;
using FirstWebApi.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace CVLookup_WebAPI.Models.Mapper
{
    public class DistrictResolver : IValueResolver<DistrictVM, District, string>
    {
        private readonly AppDBContext _dbContext;

        public DistrictResolver(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public string Resolve(DistrictVM source, District destination, string destMember, ResolutionContext context)
        {
            try
            {
                var province = _dbContext.Province.Where(prop => prop.Name == source.ProvinceName).FirstOrDefault();
                if (province == null)
                {
                    throw new ExceptionModel(400, "Thất bại. Tên tỉnh thành không hợp lệ");
                }
                return province.Id;
            }
            catch (ExceptionModel e)
            {
                throw new ExceptionModel(e.Code, e.Message);
            }
        }
    }
}
