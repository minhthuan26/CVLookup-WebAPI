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
                    new {Id = entry.Value, RoleName = entry.Key}    
                );
            }

            User user = new User 
            { 
                Id = Guid.NewGuid().ToString(), 
                Email = "cvlookup.sgu.2023@gmail.com" 
            };
            modelBuilder.Entity<User>().HasData(
                user
            );

            Account account = new Account
            {
                Id = Guid.NewGuid().ToString(),
                Email = "cvlookup.sgu.2023@gmail.com",
                Password = "4EvS5r40usEAzXH5nw6YyjfVVpQdHt7K+e7DBWXhKPKdrduCQ6W3M3Ala03/Tw8kFhLEGxHwealuxejQLZqg0y4nsngohze7rnldfpPHQ1Y=",
                Actived = true,
            };
            modelBuilder.Entity<Account>().HasData(
                account
            );

            modelBuilder.Entity<UserRole>().HasData(
                new UserRole() 
                { 
                    RoleId = (string)roles["Admin"],
                    UserId = user.Id
                }    
            );
            modelBuilder.Entity<AccountUser>().HasData(
                new AccountUser()
                {
                    AccountId = account.Id,
                    UserId = user.Id
                }
            );

            ListDictionary provinces = new ListDictionary()
            {
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

            foreach(DictionaryEntry entry in provinces)
            {
                modelBuilder.Entity<Province>().HasData(
                    new {Id =  entry.Value, Name = entry.Key}    
                );
            }

            modelBuilder.Entity<District>().HasData(
                new { Id = Guid.NewGuid().ToString(), Name = "Quận Ninh Kiều", ProvinceId = provinces["Cần Thơ"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận Bình Thuỷ", ProvinceId = provinces["Cần Thơ"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận Cái Răng", ProvinceId = provinces["Cần Thơ"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận Thốt Nốt", ProvinceId = provinces["Cần Thơ"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận Ô Môn", ProvinceId = provinces["Cần Thơ"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận Liên Chiểu", ProvinceId = provinces["Đà Nẵng"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận Thanh Khê", ProvinceId = provinces["Đà Nẵng"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận Hải Châu", ProvinceId = provinces["Đà Nẵng"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận Sơn Trà", ProvinceId = provinces["Đà Nẵng"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận Ngũ Hành Sơn", ProvinceId = provinces["Đà Nẵng"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận Cẩm Lệ", ProvinceId = provinces["Đà Nẵng"] },
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
                new { Id = Guid.NewGuid().ToString(), Name = "Quận Hồng Bàng", ProvinceId = provinces["Hải Phòng"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận Ngô Quyền", ProvinceId = provinces["Hải Phòng"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận Lê Chân", ProvinceId = provinces["Hải Phòng"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận Hải An", ProvinceId = provinces["Hải Phòng"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận Kiến An", ProvinceId = provinces["Hải Phòng"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận Đồ Sơn", ProvinceId = provinces["Hải Phòng"] },
                new { Id = Guid.NewGuid().ToString(), Name = "Quận Dương Kinh", ProvinceId = provinces["Hải Phòng"] },
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
        }

    }
}
