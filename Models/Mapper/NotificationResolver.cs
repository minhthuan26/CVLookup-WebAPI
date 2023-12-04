using AutoMapper;
using CVLookup_WebAPI.Models.Domain;
using CVLookup_WebAPI.Models.ViewModel;
using CVLookup_WebAPI.Utilities;
using FirstWebApi.Models.Database;

namespace CVLookup_WebAPI.Models.Mapper
{
    public class NotificationResolver
    {
        public class UserResolver : IValueResolver<NotificationVM, Notification, User>
        {
            private readonly AppDBContext _dbContext;
            public UserResolver(AppDBContext dbContext)
            {
                _dbContext = dbContext;
            }
            public User Resolve(NotificationVM source, Notification destination, User destMember, ResolutionContext context)
            {
                try
                {
                    var user = _dbContext.User.FirstOrDefault(prop => prop.Id == source.UserId);
                    if (user == null)
                    {
                        throw new ExceptionModel(404, "Thất bại không thể tìm thấy người nhận thông báo");
                    }
                    return user;
                }
                catch (ExceptionModel e)
                {
                    throw new ExceptionModel(e.Code, e.Message);
                }

            }
        }
        public class RecruitmentCVResolver : IValueResolver<NotificationVM, Notification, RecruitmentCV>
        {
            private readonly AppDBContext _dbContext;
            public RecruitmentCVResolver(AppDBContext dbContext)
            {
                _dbContext = dbContext;
            }
            public RecruitmentCV Resolve(NotificationVM source, Notification destination, RecruitmentCV destMember, ResolutionContext context)
            {
                try
                {
                    var recruitmentCv = _dbContext.RecruitmentCV.FirstOrDefault(prop => prop.CurriculumVitaeId == source.CvId && prop.RecruitmentId == source.RecruitmentId);
                    if (recruitmentCv == null)
                    {
                        throw new ExceptionModel(404, "Thất bại không thể tìm thấy dữ liệu");
                    }
                    return recruitmentCv;
                } catch (ExceptionModel e)
                {
                    throw new ExceptionModel(e.Code, e.Message);
                }
            }
        }
    }
}