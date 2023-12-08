using CVLookup_WebAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Specialized;

namespace CVLookup_WebAPI.DBContext
{
    public static class SeedDataBuilder
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            ListDictionary roles = new ListDictionary()
            {
                { "Admin", Guid.NewGuid().ToString() },
                { "Candidate", Guid.NewGuid().ToString() },
                { "Employer", Guid.NewGuid().ToString() },
            };

            foreach (DictionaryEntry entry in roles)
            {
                modelBuilder.Entity<Role>().HasData(
                    new { Id = entry.Value, RoleName = entry.Key }
                );
            }

            User userAdmin = new User
            {
                Id = Guid.NewGuid().ToString(),
                Email = "cvlookup.sgu.2023@gmail.com",
                Username = "General Admin"
            };
            Employer userEmployer = new Employer
            {
                Id = Guid.NewGuid().ToString(),
                Email = "cvlookup.sgu.2023_employer@gmail.com",
                Address = "Admin",
                Description = "Admin",
                Username = "Employer Admin"
            };
            Candidate userCandidate = new Candidate
            {
                Id = Guid.NewGuid().ToString(),
                Email = "cvlookup.sgu.2023_candidate@gmail.com",
                Username = "Candidate Admin",
                DateOfBirth = new DateTime(2023,1,1)
            };
            modelBuilder.Entity<User>().HasData(
                userAdmin
            );
            modelBuilder.Entity<Employer>().HasData(
                userEmployer
            );
            modelBuilder.Entity<Candidate>().HasData(
                userCandidate
            );


            Account accountAdmin = new Account
            {
                Id = Guid.NewGuid().ToString(),
                Email = "cvlookup.sgu.2023@gmail.com",
                Password = "4EvS5r40usEAzXH5nw6YyjfVVpQdHt7K+e7DBWXhKPKdrduCQ6W3M3Ala03/Tw8kFhLEGxHwealuxejQLZqg0y4nsngohze7rnldfpPHQ1Y=",
                Actived = true,
            };
            Account accountEmployer = new Account
            {
                Id = Guid.NewGuid().ToString(),
                Email = "cvlookup.sgu.2023_employer@gmail.com",
                Password = "4EvS5r40usEAzXH5nw6YyjfVVpQdHt7K+e7DBWXhKPKdrduCQ6W3M3Ala03/Tw8kFhLEGxHwealuxejQLZqg0y4nsngohze7rnldfpPHQ1Y=",
                Actived = true,
            };
            Account accountCandidate = new Account
            {
                Id = Guid.NewGuid().ToString(),
                Email = "cvlookup.sgu.2023_candidate@gmail.com",
                Password = "4EvS5r40usEAzXH5nw6YyjfVVpQdHt7K+e7DBWXhKPKdrduCQ6W3M3Ala03/Tw8kFhLEGxHwealuxejQLZqg0y4nsngohze7rnldfpPHQ1Y=",
                Actived = true,
            };
            modelBuilder.Entity<Account>().HasData(
                accountAdmin,
                accountEmployer,
                accountCandidate
            );

            modelBuilder.Entity<UserRole>().HasData(
                new UserRole()
                {
                    RoleId = (string)roles["Admin"],
                    UserId = userAdmin.Id
                },
                new UserRole()
                {
                    RoleId = (string)roles["Employer"],
                    UserId = userEmployer.Id
                },
                new UserRole()
                {
                    RoleId = (string)roles["Candidate"],
                    UserId = userCandidate.Id
                }
            );
            modelBuilder.Entity<AccountUser>().HasData(
                new AccountUser()
                {
                    AccountId = accountAdmin.Id,
                    UserId = userAdmin.Id
                },
                new AccountUser()
                {
                    AccountId = accountEmployer.Id,
                    UserId = userEmployer.Id
                },
                new AccountUser()
                {
                    AccountId = accountCandidate.Id,
                    UserId = userCandidate.Id
                }
            );

            ListDictionary provinces = new ListDictionary()
            {
                { "Tất cả tỉnh thành", Guid.NewGuid().ToString() },
                { "An Giang", Guid.NewGuid().ToString() },
                { "Bà Rịa-Vũng Tàu", Guid.NewGuid().ToString() },
                { "Bắc Giang", Guid.NewGuid().ToString() },
                { "Bắc Kạn", Guid.NewGuid().ToString() },
                { "Bạc Liêu", Guid.NewGuid().ToString() },
                { "Bắc Ninh", Guid.NewGuid().ToString() },
                { "Bến Tre", Guid.NewGuid().ToString() },
                { "Bình Định", Guid.NewGuid().ToString() },
                { "Bình Dương", Guid.NewGuid().ToString() },
                { "Bình Phước", Guid.NewGuid().ToString() },
                { "Bình Thuận", Guid.NewGuid().ToString() },
                { "Cà Mau", Guid.NewGuid().ToString() },
                { "Cần Thơ", Guid.NewGuid().ToString() },
                { "Cao Bằng", Guid.NewGuid().ToString() },
                { "Đà Nẵng", Guid.NewGuid().ToString() },
                { "Đắk Lắk", Guid.NewGuid().ToString() },
                { "Đắk Nông", Guid.NewGuid().ToString() },
                { "Điện Biên", Guid.NewGuid().ToString() },
                { "Đồng Nai", Guid.NewGuid().ToString() },
                { "Đồng Tháp", Guid.NewGuid().ToString() },
                { "Gia Lai", Guid.NewGuid().ToString() },
                { "Hà Giang", Guid.NewGuid().ToString() },
                { "Hà Nam", Guid.NewGuid().ToString() },
                { "Hà Nội", Guid.NewGuid().ToString() },
                { "Hà Tĩnh", Guid.NewGuid().ToString() },
                { "Hải Dương", Guid.NewGuid().ToString() },
                { "Hải Phòng", Guid.NewGuid().ToString() },
                { "Hậu Giang", Guid.NewGuid().ToString() },
                { "Hòa Bình", Guid.NewGuid().ToString() },
                { "Hưng Yên", Guid.NewGuid().ToString() },
                { "Khánh Hòa", Guid.NewGuid().ToString() },
                { "Kiên Giang", Guid.NewGuid().ToString() },
                { "Kon Tum", Guid.NewGuid().ToString() },
                { "Lai Châu", Guid.NewGuid().ToString() },
                { "Lâm Đồng", Guid.NewGuid().ToString() },
                { "Lạng Sơn", Guid.NewGuid().ToString() },
                { "Lào Cai", Guid.NewGuid().ToString() },
                { "Long An", Guid.NewGuid().ToString() },
                { "Nam Định", Guid.NewGuid().ToString() },
                { "Nghệ An", Guid.NewGuid().ToString() },
                { "Ninh Bình", Guid.NewGuid().ToString() },
                { "Ninh Thuận", Guid.NewGuid().ToString() },
                { "Phú Thọ", Guid.NewGuid().ToString() },
                { "Phú Yên", Guid.NewGuid().ToString() },
                { "Quảng Bình", Guid.NewGuid().ToString() },
                { "Quảng Nam", Guid.NewGuid().ToString() },
                { "Quảng Ngãi", Guid.NewGuid().ToString() },
                { "Quảng Ninh", Guid.NewGuid().ToString() },
                { "Quảng Trị", Guid.NewGuid().ToString() },
                { "Sóc Trăng", Guid.NewGuid().ToString() },
                { "Sơn La", Guid.NewGuid().ToString() },
                { "Tây Ninh", Guid.NewGuid().ToString() },
                { "Thái Bình", Guid.NewGuid().ToString() },
                { "Thái Nguyên", Guid.NewGuid().ToString() },
                { "Thanh Hóa", Guid.NewGuid().ToString() },
                { "Thừa Thiên Huế", Guid.NewGuid().ToString() },
                { "Tiền Giang", Guid.NewGuid().ToString() },
                { "Hồ Chí Minh", Guid.NewGuid().ToString() },
                { "Trà Vinh", Guid.NewGuid().ToString() },
                { "Tuyên Quang", Guid.NewGuid().ToString() },
                { "Vĩnh Long", Guid.NewGuid().ToString() },
                { "Vĩnh Phúc", Guid.NewGuid().ToString() },
                { "Yên Bái", Guid.NewGuid().ToString() },
            };

            foreach (DictionaryEntry entry in provinces)
            {
                modelBuilder.Entity<Province>().HasData(
                    new { Id = entry.Value, Name = entry.Key }
                );
            }

            modelBuilder.Entity<District>().HasData(
                new { Id = Guid.NewGuid().ToString(), Name = "Tất cả", ProvinceId = provinces["Cần Thơ"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận Ninh Kiều", ProvinceId = provinces["Cần Thơ"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận Bình Thuỷ", ProvinceId = provinces["Cần Thơ"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận Cái Răng", ProvinceId = provinces["Cần Thơ"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận Thốt Nốt", ProvinceId = provinces["Cần Thơ"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận Ô Môn", ProvinceId = provinces["Cần Thơ"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Tất cả", ProvinceId = provinces["Đà Nẵng"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận Liên Chiểu", ProvinceId = provinces["Đà Nẵng"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận Thanh Khê", ProvinceId = provinces["Đà Nẵng"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận Hải Châu", ProvinceId = provinces["Đà Nẵng"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận Sơn Trà", ProvinceId = provinces["Đà Nẵng"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận Ngũ Hành Sơn", ProvinceId = provinces["Đà Nẵng"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận Cẩm Lệ", ProvinceId = provinces["Đà Nẵng"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Tất cả", ProvinceId = provinces["Hà Nội"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận Ba Đình", ProvinceId = provinces["Hà Nội"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận Hoàn Kiếm", ProvinceId = provinces["Hà Nội"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận Tây Hồ", ProvinceId = provinces["Hà Nội"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận Long Biên", ProvinceId = provinces["Hà Nội"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận Cầu Giấy", ProvinceId = provinces["Hà Nội"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận Đống Đa", ProvinceId = provinces["Hà Nội"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận Hai Bà Trưng", ProvinceId = provinces["Hà Nội"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận Hoàng Mai", ProvinceId = provinces["Hà Nội"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận Thanh Xuân", ProvinceId = provinces["Hà Nội"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận Nam Từ Liêm", ProvinceId = provinces["Hà Nội"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận Bắc Từ Liêm", ProvinceId = provinces["Hà Nội"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận Hà Đông", ProvinceId = provinces["Hà Nội"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Tất cả", ProvinceId = provinces["Hải Phòng"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận Hồng Bàng", ProvinceId = provinces["Hải Phòng"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận Ngô Quyền", ProvinceId = provinces["Hải Phòng"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận Lê Chân", ProvinceId = provinces["Hải Phòng"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận Hải An", ProvinceId = provinces["Hải Phòng"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận Kiến An", ProvinceId = provinces["Hải Phòng"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận Đồ Sơn", ProvinceId = provinces["Hải Phòng"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận Dương Kinh", ProvinceId = provinces["Hải Phòng"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Tất cả", ProvinceId = provinces["Hồ Chí Minh"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận 1", ProvinceId = provinces["Hồ Chí Minh"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận 2", ProvinceId = provinces["Hồ Chí Minh"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận 3", ProvinceId = provinces["Hồ Chí Minh"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận 4", ProvinceId = provinces["Hồ Chí Minh"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận 5", ProvinceId = provinces["Hồ Chí Minh"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận 6", ProvinceId = provinces["Hồ Chí Minh"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận 7", ProvinceId = provinces["Hồ Chí Minh"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận 8", ProvinceId = provinces["Hồ Chí Minh"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận 9", ProvinceId = provinces["Hồ Chí Minh"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận 10", ProvinceId = provinces["Hồ Chí Minh"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận 11", ProvinceId = provinces["Hồ Chí Minh"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận 12", ProvinceId = provinces["Hồ Chí Minh"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận Gò Vấp", ProvinceId = provinces["Hồ Chí Minh"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận Bình Thạnh", ProvinceId = provinces["Hồ Chí Minh"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận Tân Bình", ProvinceId = provinces["Hồ Chí Minh"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận Tân Phú", ProvinceId = provinces["Hồ Chí Minh"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận Phú Nhuận", ProvinceId = provinces["Hồ Chí Minh"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận Thủ Đức", ProvinceId = provinces["Hồ Chí Minh"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận Bình Tân", ProvinceId = provinces["Hồ Chí Minh"] }
            );


            modelBuilder.Entity<JobCareer>().HasData(
                new JobCareer { Career = "Tất cả ngành nghề" },
                new JobCareer { Career = "An toàn lao động" },
                new JobCareer { Career = "Bán hàng kỹ thuật" },
                new JobCareer { Career = "Bán lẻ / bán sỉ" },
                new JobCareer { Career = "Báo chí / Truyền hình" },
                new JobCareer { Career = "Bảo hiểm" },
                new JobCareer { Career = "Bảo trì / Sửa chữa" },
                new JobCareer { Career = "Bất động sản" },
                new JobCareer { Career = "Biên / Phiên dịch" },
                new JobCareer { Career = "Bưu chính - Viễn thông" },
                new JobCareer { Career = "Chứng khoán / Vàng / Ngoại tệ" },
                new JobCareer { Career = "Cơ khí / Chế tạo / Tự động hóa" },
                new JobCareer { Career = "Công nghệ cao" },
                new JobCareer { Career = "Công nghệ Ô tô" },
                new JobCareer { Career = "Công nghệ thông tin" },
                new JobCareer { Career = "Dầu khí/Hóa chất" },
                new JobCareer { Career = "Dệt may / Da giày" },
                new JobCareer { Career = "Địa chất / Khoáng sản" },
                new JobCareer { Career = "Dịch vụ khách hàng" },
                new JobCareer { Career = "Điện / Điện tử / Điện lạnh" },
                new JobCareer { Career = "Điện tử viễn thông" },
                new JobCareer { Career = "Du lịch" },
                new JobCareer { Career = "Dược phẩm / Công nghệ sinh học" },
                new JobCareer { Career = "Giáo dục / Đào tạo" },
                new JobCareer { Career = "Hàng cao cấp" },
                new JobCareer { Career = "Hàng gia dụng" },
                new JobCareer { Career = "Hàng hải" },
                new JobCareer { Career = "Hàng không" },
                new JobCareer { Career = "Hàng tiêu dùng" },
                new JobCareer { Career = "Hành chính / Văn phòng" },
                new JobCareer { Career = "Hoá học / Sinh học" },
                new JobCareer { Career = "Hoạch định / Dự án" },
                new JobCareer { Career = "In ấn / Xuất bản" },
                new JobCareer { Career = "IT Phần cứng / Mạng" },
                new JobCareer { Career = "IT phần mềm" },
                new JobCareer { Career = "Kế toán / Kiểm toán" },
                new JobCareer { Career = "Khách sạn / Nhà hàng" },
                new JobCareer { Career = "Kiến trúc" },
                new JobCareer { Career = "Kinh doanh / Bán hàng" },
                new JobCareer { Career = "Logistics" },
                new JobCareer { Career = "Luật / Pháp lý" },
                new JobCareer { Career = "Marketing / Truyền thông / Quảng cáo" },
                new JobCareer { Career = "Môi trường / Xử lý chất thải" },
                new JobCareer { Career = "Mỹ phẩm / Trang sức" },
                new JobCareer { Career = "Mỹ thuật / Nghệ thuật / Điện ảnh" },
                new JobCareer { Career = "Ngân hàng / Tài chính" },
                new JobCareer { Career = "Ngành nghề khác" },
                new JobCareer { Career = "NGO / Phi chính phủ / Phi lợi nhuận" },
                new JobCareer { Career = "Nhân sự" },
                new JobCareer { Career = "Nông / Lâm / Ngư nghiệp" },
                new JobCareer { Career = "Phi chính phủ / Phi lợi nhuận" },
                new JobCareer { Career = "Quản lý chất lượng (QA/QC)" },
                new JobCareer { Career = "Quản lý điều hành" },
                new JobCareer { Career = "Sản phẩm công nghiệp" },
                new JobCareer { Career = "Sản xuất" },
                new JobCareer { Career = "Spa / Làm đẹp" },
                new JobCareer { Career = "Tài chính / Đầu tư" },
                new JobCareer { Career = "Thiết kế đồ họa" },
                new JobCareer { Career = "Thiết kế nội thất" },
                new JobCareer { Career = "Thời trang" },
                new JobCareer { Career = "Thư ký / Trợ lý" },
                new JobCareer { Career = "Thực phẩm / Đồ uống" },
                new JobCareer { Career = "Tổ chức sự kiện / Quà tặng" },
                new JobCareer { Career = "Tư vấn" },
                new JobCareer { Career = "Vận tải / Kho vận" },
                new JobCareer { Career = "Xây dựng" },
                new JobCareer { Career = "Xuất nhập khẩu" },
                new JobCareer { Career = "Y tế / Dược" }
            );

            modelBuilder.Entity<JobField>().HasData(
                new JobField { Field = "Tất cả lĩnh vực" },
                new JobField { Field = "Agency (Design/Development)" },
                new JobField { Field = "Agency (Marketing/Advertising)" },
                new JobField { Field = "Bán lẻ - Hàng tiêu dùng - FMCG" },
                new JobField { Field = "Bảo hiểm" },
                new JobField { Field = "Bảo trì / Sửa chữa" },
                new JobField { Field = "Bất động sản" },
                new JobField { Field = "Chứng khoán" },
                new JobField { Field = "Cơ khí" },
                new JobField { Field = "Cơ quan nhà nước" },
                new JobField { Field = "Du lịch" },
                new JobField { Field = "Dược phẩm / Y tế / Công nghệ sinh học" },
                new JobField { Field = "Điện tử / Điện lạnh" },
                new JobField { Field = "Giải trí" },
                new JobField { Field = "Giáo dục / Đào tạo" },
                new JobField { Field = "In ấn / Xuất bản" },
                new JobField { Field = "Internet / Online" },
                new JobField { Field = "IT - Phần cứng" },
                new JobField { Field = "IT - Phần mềm" },
                new JobField { Field = "Kế toán / Kiểm toán" },
                new JobField { Field = "Khác" },
                new JobField { Field = "Logistics - Vận tải" },
                new JobField { Field = "Luật" },
                new JobField { Field = "Marketing / Truyền thông / Quảng cáo" },
                new JobField { Field = "Môi trường" },
                new JobField { Field = "Năng lượng" },
                new JobField { Field = "Ngân hàng" },
                new JobField { Field = "Nhà hàng / Khách sạn" },
                new JobField { Field = "Nhân sự" },
                new JobField { Field = "Nông Lâm Ngư nghiệp" },
                new JobField { Field = "Sản xuất" },
                new JobField { Field = "Tài chính" },
                new JobField { Field = "Thiết kế / kiến trúc" },
                new JobField { Field = "Thời trang" },
                new JobField { Field = "Thương mại điện tử" },
                new JobField { Field = "Tổ chức phi lợi nhuận" },
                new JobField { Field = "Tự động hóa" },
                new JobField { Field = "Tư vấn" },
                new JobField { Field = "Viễn thông" },
                new JobField { Field = "Xây dựng" },
                new JobField { Field = "Xuất nhập khẩu" }
            );

            modelBuilder.Entity<JobForm>().HasData(
                new JobForm { Form = "Tất cả hình thức" },
                new JobForm { Form = "Toàn thời gian" },
                new JobForm { Form = "Bán thời gian" },
                new JobForm { Form = "Thực tập" }
            );

            modelBuilder.Entity<JobPosition>().HasData(
                new JobPosition { Position = "Tất cả vị trí"},
                new JobPosition { Position = "Nhân viên"},
                new JobPosition { Position = "Trưởng nhóm"},
                new JobPosition { Position = "Trưởng / Phó phòng"},
                new JobPosition { Position = "Quản lí / Giám sát"},
                new JobPosition { Position = "Trưởng chi nhánh"},
                new JobPosition { Position = "Phó giám đốc"},
                new JobPosition { Position = "Giám đốc"},
                new JobPosition { Position = "Thực tập sinh"}
            );

            modelBuilder.Entity<Experience>().HasData(
                new Experience { Exp = "Tất cả kinh nghiệm"},
                new Experience { Exp = "Chưa có kinh nghiệm"},
                new Experience { Exp = "Dưới 1 năm"},
                new Experience { Exp = "Từ 1-2 năm"},
                new Experience { Exp = "Từ 2-3 năm"},
                new Experience { Exp = "Từ 3-5 năm"},
                new Experience { Exp = "Từ 5-10 năm"},
                new Experience { Exp = "Trên 10 năm"}
                    
            );
        }

    }
}
