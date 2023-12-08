using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CVLookup_WebAPI.Migrations
{
    public partial class InitDB_and_SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Actived = table.Column<bool>(type: "bit", nullable: false),
                    IssuedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActivedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Experience",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Exp = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experience", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HubConnection",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ConnectionId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HubConnection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobCareer",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Career = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCareer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobField",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Field = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobField", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobForm",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Form = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobForm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobPosition",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPosition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Province",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Province", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "District",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinceId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_District", x => x.Id);
                    table.ForeignKey(
                        name: "FK_District_Province_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Province",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobAddress",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AddressDetail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinceId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobAddress_Province_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Province",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountUser",
                columns: table => new
                {
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountUser", x => new { x.AccountId, x.UserId });
                    table.ForeignKey(
                        name: "FK_AccountUser_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountUser_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CurriculumVitae",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CVPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Introdution = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UploadedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurriculumVitae", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurriculumVitae_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Token",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Token", x => new { x.UserId, x.AccountId });
                    table.ForeignKey(
                        name: "FK_Token_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Token_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Token_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.RoleId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recruitment",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmployerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    JobTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Salary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobAddressId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    JobCareerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    JobFieldId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    JobFormId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ExperienceId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    JobPositionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApplicationDeadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsExpired = table.Column<bool>(type: "bit", nullable: false),
                    JobDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobRequirement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Benefit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recruitment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recruitment_Experience_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experience",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recruitment_JobAddress_JobAddressId",
                        column: x => x.JobAddressId,
                        principalTable: "JobAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recruitment_JobCareer_JobCareerId",
                        column: x => x.JobCareerId,
                        principalTable: "JobCareer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recruitment_JobField_JobFieldId",
                        column: x => x.JobFieldId,
                        principalTable: "JobField",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recruitment_JobForm_JobFormId",
                        column: x => x.JobFormId,
                        principalTable: "JobForm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recruitment_JobPosition_JobPositionId",
                        column: x => x.JobPositionId,
                        principalTable: "JobPosition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recruitment_User_EmployerId",
                        column: x => x.EmployerId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RecruitmentCV",
                columns: table => new
                {
                    RecruitmentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CurriculumVitaeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AppliedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsView = table.Column<bool>(type: "bit", nullable: false),
                    IsPass = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecruitmentCV", x => new { x.RecruitmentId, x.CurriculumVitaeId });
                    table.ForeignKey(
                        name: "FK_RecruitmentCV_CurriculumVitae_CurriculumVitaeId",
                        column: x => x.CurriculumVitaeId,
                        principalTable: "CurriculumVitae",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecruitmentCV_Recruitment_RecruitmentId",
                        column: x => x.RecruitmentId,
                        principalTable: "Recruitment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NotifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SenderId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecruitmentCVRecruitmentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RecruitmentCVCurriculumVitaeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsView = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notification_RecruitmentCV_RecruitmentCVRecruitmentId_RecruitmentCVCurriculumVitaeId",
                        columns: x => new { x.RecruitmentCVRecruitmentId, x.RecruitmentCVCurriculumVitaeId },
                        principalTable: "RecruitmentCV",
                        principalColumns: new[] { "RecruitmentId", "CurriculumVitaeId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notification_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "Actived", "ActivedAt", "Email", "IssuedAt", "Password", "UpdatedAt" },
                values: new object[,]
                {
                    { "07b60274-35f5-4179-8e06-4132cc4fe1bf", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cvlookup.sgu.2023_employer@gmail.com", new DateTime(2023, 12, 8, 17, 40, 48, 518, DateTimeKind.Local).AddTicks(5847), "4EvS5r40usEAzXH5nw6YyjfVVpQdHt7K+e7DBWXhKPKdrduCQ6W3M3Ala03/Tw8kFhLEGxHwealuxejQLZqg0y4nsngohze7rnldfpPHQ1Y=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "2bb35655-1118-477e-b4c0-64263fe98e47", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cvlookup.sgu.2023@gmail.com", new DateTime(2023, 12, 8, 17, 40, 48, 518, DateTimeKind.Local).AddTicks(5779), "4EvS5r40usEAzXH5nw6YyjfVVpQdHt7K+e7DBWXhKPKdrduCQ6W3M3Ala03/Tw8kFhLEGxHwealuxejQLZqg0y4nsngohze7rnldfpPHQ1Y=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "4d2df3b3-b06e-4a8e-a84a-d2e6515d0d2a", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cvlookup.sgu.2023_candidate@gmail.com", new DateTime(2023, 12, 8, 17, 40, 48, 518, DateTimeKind.Local).AddTicks(5863), "4EvS5r40usEAzXH5nw6YyjfVVpQdHt7K+e7DBWXhKPKdrduCQ6W3M3Ala03/Tw8kFhLEGxHwealuxejQLZqg0y4nsngohze7rnldfpPHQ1Y=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Experience",
                columns: new[] { "Id", "Exp" },
                values: new object[,]
                {
                    { "1f5b6a87-4283-4739-995e-2a42d65dfed1", "Từ 2-3 năm" },
                    { "2a24408b-6a0b-4afa-8b30-d9d0d4d4017b", "Dưới 1 năm" },
                    { "3b61250c-2259-4fbe-841b-9d45811a3cdb", "Tất cả kinh nghiệm" },
                    { "3d766ce7-6ca5-48b3-bb8b-05d92a0ebdfc", "Từ 3-5 năm" },
                    { "5ff176ac-abab-47e6-ac59-5da28984ccd7", "Chưa có kinh nghiệm" },
                    { "7ef908dd-7ba8-4394-8da0-abfe29c8cc6c", "Từ 5-10 năm" },
                    { "8c882c4b-231c-428b-a667-48785db74829", "Trên 10 năm" },
                    { "bc687070-a77d-4017-8495-ed8f5a30d59e", "Từ 1-2 năm" }
                });

            migrationBuilder.InsertData(
                table: "JobCareer",
                columns: new[] { "Id", "Career" },
                values: new object[,]
                {
                    { "01eac1fa-c305-42b4-9767-15eb5dbfda3a", "An toàn lao động" },
                    { "05aed7c9-15d0-4a86-a471-afa2011088f5", "Xuất nhập khẩu" },
                    { "07e41ff7-24b9-49ba-a835-171e2fc78182", "Marketing / Truyền thông / Quảng cáo" },
                    { "08e24d4a-684a-4216-bad9-933d453a4ee1", "Vận tải / Kho vận" },
                    { "0f321f7e-c229-489b-a859-efb1daab4b85", "Chứng khoán / Vàng / Ngoại tệ" },
                    { "1c088f44-02e8-44d4-b143-720ce0e0e1c6", "Hàng gia dụng" },
                    { "1c0ce586-90be-4df3-b062-32a2831108c0", "Biên / Phiên dịch" },
                    { "1f427985-1449-4e84-9714-cb7cf9de5a94", "Bán lẻ / bán sỉ" },
                    { "2368666b-182d-40b7-8c7b-eab3c104d9ca", "IT phần mềm" },
                    { "242633e0-df5d-4083-b86b-3d113521df4e", "Khách sạn / Nhà hàng" },
                    { "24a4eab3-0966-43ec-97e9-5f70764bad8f", "Môi trường / Xử lý chất thải" },
                    { "256c193f-e0b5-42a8-bd22-96e612543998", "Hàng tiêu dùng" },
                    { "2c70f344-774f-4c5b-a8b2-4d4db2390d73", "Dịch vụ khách hàng" },
                    { "2f608172-a42e-4cf3-ac78-e237194c2587", "Hàng không" },
                    { "322f7c60-c680-4d16-b387-1afe88ffd499", "Kiến trúc" },
                    { "3bcad873-f4ed-422b-b85a-a3828ccd2002", "Cơ khí / Chế tạo / Tự động hóa" },
                    { "3e6a0bd2-423b-4a67-a15f-e58f74288b57", "Tổ chức sự kiện / Quà tặng" },
                    { "3fb8d7d9-1a99-4ce1-81e4-020cee8c3586", "Luật / Pháp lý" },
                    { "4193d7e4-c128-4621-8433-c8def1f09b28", "Điện tử viễn thông" },
                    { "42f30675-f734-451b-a874-ac8afdf3f787", "Địa chất / Khoáng sản" },
                    { "443d95f1-3b64-489b-8ca0-40752914b877", "Y tế / Dược" },
                    { "4577e700-be68-4adc-85ca-8d422f06b9ec", "Dược phẩm / Công nghệ sinh học" },
                    { "4b89249d-ea53-44b9-a7ed-ef0997b1f491", "Dệt may / Da giày" },
                    { "4e4cc86c-e11f-4b07-a61c-8fee89d9f028", "Dầu khí/Hóa chất" },
                    { "52737c37-d4bf-482c-8119-87249fc26815", "Thực phẩm / Đồ uống" },
                    { "53cae740-998b-413e-9d52-3ce9a8a134b6", "Hành chính / Văn phòng" },
                    { "558d1c0b-ad11-4576-85dd-334469f3de7f", "Spa / Làm đẹp" },
                    { "58bc6d10-6f28-423d-b5fb-8acdfd1b4612", "Công nghệ Ô tô" },
                    { "5aed4b6b-3e43-413c-8d67-2b779ff2decd", "Tài chính / Đầu tư" },
                    { "62246917-7cd3-4e57-8031-5ab17dce7e12", "Ngành nghề khác" },
                    { "68f2ae11-d991-4d6f-8ed0-0d7a00181dab", "Bảo trì / Sửa chữa" }
                });

            migrationBuilder.InsertData(
                table: "JobCareer",
                columns: new[] { "Id", "Career" },
                values: new object[,]
                {
                    { "71e3797d-990b-4cf9-9af6-2da6e68c0b15", "Thiết kế nội thất" },
                    { "77e87e9e-de86-4d3e-be1f-4cfeba3cdf57", "Điện / Điện tử / Điện lạnh" },
                    { "78dc5d3d-de16-466e-9984-b8b016a04da7", "In ấn / Xuất bản" },
                    { "8cd31b18-a203-4f49-96e6-48ffca54e86a", "IT Phần cứng / Mạng" },
                    { "9379d3d1-036d-45ca-99d4-fa3893ce8226", "Du lịch" },
                    { "94ba49b3-3e06-40dd-ab0b-17140ea7295a", "NGO / Phi chính phủ / Phi lợi nhuận" },
                    { "9c9f6da7-b27d-478a-a47a-b78e7b931dc5", "Nhân sự" },
                    { "9e245442-30b4-478e-a639-d95fb11579e9", "Bưu chính - Viễn thông" },
                    { "a41d2bdf-2b64-4b67-a525-bd5bda88f100", "Báo chí / Truyền hình" },
                    { "a5632a7e-9239-4fd4-9f25-13391f5554b3", "Bảo hiểm" },
                    { "a67b2e98-5599-4a41-81ca-4af6175c7932", "Công nghệ cao" },
                    { "a67e0f1d-b7b5-473b-9b68-defba36c55d2", "Bất động sản" },
                    { "aa182277-ae76-48a0-a6a9-e8b1103503a8", "Phi chính phủ / Phi lợi nhuận" },
                    { "b1544dbd-2acc-4f70-80fb-c6086e2df1ef", "Công nghệ thông tin" },
                    { "b16f3be3-7af6-486d-85f0-915e03237939", "Tất cả ngành nghề" },
                    { "b6129f83-0870-42a6-8c30-881cea556b6e", "Kinh doanh / Bán hàng" },
                    { "c388ce85-d270-4974-b24c-cf2ef9e613cb", "Bán hàng kỹ thuật" },
                    { "c5d37ef1-0169-40fa-852b-b4b8facd03a4", "Giáo dục / Đào tạo" },
                    { "c8754076-f337-4197-bf21-c75d664f0d6f", "Thư ký / Trợ lý" },
                    { "cb80b84c-eb92-493b-b0a5-3988138da358", "Tư vấn" },
                    { "cf9714db-e7c3-4e2f-943d-5c04dd8d21ca", "Quản lý chất lượng (QA/QC)" },
                    { "d0875f8d-f90e-4235-b34a-93aac1319236", "Hoạch định / Dự án" },
                    { "dabfbe1a-e790-4187-b745-523239ff1e07", "Xây dựng" },
                    { "db021c4a-b4ec-4ab3-940a-5904ff1937e7", "Hoá học / Sinh học" },
                    { "dcfb376c-e03c-450a-a45a-bf3462154cd7", "Logistics" },
                    { "dd77d2be-ef85-45f3-8527-b4a4eb0efd2a", "Quản lý điều hành" },
                    { "e03ae3d7-2014-4afb-a877-a6365d8d948d", "Hàng cao cấp" },
                    { "e059dc1b-ee4a-4025-88b0-8eb83ba0fef9", "Thời trang" },
                    { "e6c75381-124b-45d1-b21d-3f1275481252", "Hàng hải" },
                    { "ec1f1145-4751-4168-a261-aa12092f063e", "Mỹ thuật / Nghệ thuật / Điện ảnh" },
                    { "efee39cb-42d0-4627-83b4-125d6e008bda", "Sản xuất" },
                    { "f65c427a-80cd-4bc4-af75-d49cecb0b344", "Thiết kế đồ họa" },
                    { "f73ac9e2-0304-4ecf-81ec-e00bb6b6750d", "Sản phẩm công nghiệp" },
                    { "f77ba53a-c9ff-4909-9bf0-0aa3ab66942b", "Nông / Lâm / Ngư nghiệp" },
                    { "f950cfd1-fe47-49ae-b7e8-9063093c0741", "Kế toán / Kiểm toán" },
                    { "fb348e44-82cc-49d9-9db7-6ed81a447748", "Mỹ phẩm / Trang sức" },
                    { "ff7a86da-a6f4-4ea4-9a73-3ac1581caa90", "Ngân hàng / Tài chính" }
                });

            migrationBuilder.InsertData(
                table: "JobField",
                columns: new[] { "Id", "Field" },
                values: new object[,]
                {
                    { "021121a6-df38-48f9-92b7-821e4a16937d", "Xuất nhập khẩu" },
                    { "062f572b-dbfe-412d-906f-63e359f709e2", "IT - Phần cứng" },
                    { "19de77c0-2255-479c-9567-3e0b575d8bc5", "Tự động hóa" },
                    { "1ca9c0f2-736c-49ca-97ed-f9e774279d4e", "Nhà hàng / Khách sạn" },
                    { "2664d3fe-f718-44a2-9a67-f13ae02d5b0a", "Ngân hàng" }
                });

            migrationBuilder.InsertData(
                table: "JobField",
                columns: new[] { "Id", "Field" },
                values: new object[,]
                {
                    { "269d104c-d71f-4f49-ac42-91e5fa3196c6", "Bảo trì / Sửa chữa" },
                    { "31c1c930-3c01-45fe-b323-5375b119d68d", "In ấn / Xuất bản" },
                    { "3660af23-9b61-472b-8a20-417d6777422c", "Điện tử / Điện lạnh" },
                    { "3c8a395e-2120-448a-9d06-88dc2e0a1a32", "Tài chính" },
                    { "3f957d0f-1853-41f5-9442-9da4ef759247", "Sản xuất" },
                    { "44524f99-0ce5-43b5-a87e-11e700712a83", "Tổ chức phi lợi nhuận" },
                    { "49e42e41-c491-4cdd-9159-769fc0640b1d", "Cơ quan nhà nước" },
                    { "4aeba296-1229-45e0-83cd-98c8cde1fb68", "Giải trí" },
                    { "4b6f463c-2335-49f8-a241-b0d8fef999c8", "Internet / Online" },
                    { "4c2fa464-0676-45d5-bbd2-f6c2941ec6b9", "Năng lượng" },
                    { "669943dc-5bcb-4629-a3d4-a9f34d9db393", "Logistics - Vận tải" },
                    { "68f0f358-b80d-4499-8873-6c5da8d5f9bc", "Thiết kế / kiến trúc" },
                    { "70400bbe-b27c-44e8-af70-966026606607", "Tư vấn" },
                    { "752c53cd-5dd3-40cb-8788-ae5a5c42786b", "Nông Lâm Ngư nghiệp" },
                    { "760fe351-b626-4045-9a34-8c067b055c1a", "Bán lẻ - Hàng tiêu dùng - FMCG" },
                    { "762cebb3-6a64-46ce-a6ea-df810dd3cf78", "Chứng khoán" },
                    { "7e8be181-d251-4bc7-a584-725b787ba980", "Dược phẩm / Y tế / Công nghệ sinh học" },
                    { "7fdb9fc8-5db9-4313-80ef-b2c17599f102", "IT - Phần mềm" },
                    { "8521bd64-863f-4d64-8084-44552407f7d0", "Nhân sự" },
                    { "8cb145c9-b79d-4eb1-912a-46992bdcda29", "Môi trường" },
                    { "9432120b-2f9d-44eb-a83e-8546a6499afe", "Tất cả lĩnh vực" },
                    { "9fa680e9-ed1a-4a36-acae-430bc5b1a018", "Cơ khí" },
                    { "a4ca0410-a9ae-468d-b2e9-b72206d3e161", "Luật" },
                    { "a6b81925-b24c-45dc-b762-a83b1f3fb19e", "Agency (Design/Development)" },
                    { "b32b4557-70c9-4475-a956-0bb8dcf3c023", "Thời trang" },
                    { "b922c59e-c173-4df3-8457-05e7d2f4e291", "Agency (Marketing/Advertising)" },
                    { "bbd181ae-8534-4188-9174-584175b6446d", "Du lịch" },
                    { "bff779a0-c3cd-457b-98d8-aad42a9740de", "Giáo dục / Đào tạo" },
                    { "c17353e1-5f04-473b-a4c0-9c365de0466d", "Bất động sản" },
                    { "c28e4131-6434-4378-a18f-1fb84563704d", "Khác" },
                    { "c6bc60c9-2cf8-4d2e-ada1-28c8436fbae9", "Xây dựng" },
                    { "d17ba40f-ac02-4667-ad8a-6b85545dc0a3", "Marketing / Truyền thông / Quảng cáo" },
                    { "e508d84b-6d16-49af-ae06-33dd7a4230ef", "Bảo hiểm" },
                    { "f20f5fe8-1792-4271-90c7-b4dbde94c44e", "Thương mại điện tử" },
                    { "fc7e9051-d928-492f-838f-2dbc830298e5", "Kế toán / Kiểm toán" },
                    { "ff43f1ee-2dfc-4b60-a4da-49d4d9dfc8ea", "Viễn thông" }
                });

            migrationBuilder.InsertData(
                table: "JobForm",
                columns: new[] { "Id", "Form" },
                values: new object[,]
                {
                    { "1fd1e3e5-e11c-4d5b-b9cc-57731e29c33c", "Toàn thời gian" },
                    { "35604340-db69-4afb-bb5e-980dc23d58d2", "Bán thời gian" },
                    { "6bbb90e1-5397-486e-8457-bccf0b5e21f6", "Tất cả hình thức" },
                    { "7efac69a-a3d7-4ec5-a377-cb7f9c267ad0", "Thực tập" }
                });

            migrationBuilder.InsertData(
                table: "JobPosition",
                columns: new[] { "Id", "Position" },
                values: new object[,]
                {
                    { "463b1d24-8f73-484a-8e97-5b8ea16da6a8", "Quản lí / Giám sát" },
                    { "7241c7a0-b750-4a35-9b37-aba500afa4f7", "Tất cả vị trí" }
                });

            migrationBuilder.InsertData(
                table: "JobPosition",
                columns: new[] { "Id", "Position" },
                values: new object[,]
                {
                    { "88186bc7-47c8-4c14-9fe7-d3711ee7e787", "Trưởng nhóm" },
                    { "a2ae8f71-40ac-46b9-9174-ce3730f33644", "Phó giám đốc" },
                    { "c621a30f-2b10-4926-8bda-77dd689fe961", "Thực tập sinh" },
                    { "cb0c8e1a-f6cb-44f7-81cb-f0d5d3f9a3f9", "Nhân viên" },
                    { "d50bad41-dbba-4c8c-a9b3-dfa0c0d7b389", "Trưởng chi nhánh" },
                    { "da6a0c2c-1e82-4372-9068-a2bc554a8911", "Giám đốc" },
                    { "febe39be-ef64-48a1-93fa-35b9b109e8a2", "Trưởng / Phó phòng" }
                });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "0221d295-c1e7-4a68-9f27-6d221d11e719", "Hải Phòng" },
                    { "09c9999a-91e6-45c4-b3d6-5929a46c9ae7", "Hưng Yên" },
                    { "0c45f09f-3376-44fd-a9bf-e1dc0366bfde", "Điện Biên" },
                    { "0dcbc7b5-c435-4fe8-8c05-8b1e07e2c34d", "Vĩnh Phúc" },
                    { "16d6db15-ddf3-46e7-99a9-02f5203a75bf", "Tuyên Quang" },
                    { "1797cd19-35e4-4b97-b1e1-d470846762a0", "Nghệ An" },
                    { "1e063990-42b4-44bc-8cb9-7f3692c5477e", "Đắk Nông" },
                    { "20719df2-6f57-48c3-9d93-b72439b8e3f5", "Quảng Nam" },
                    { "23eff5af-6f7e-4d23-897d-af4fdf617428", "Bà Rịa-Vũng Tàu" },
                    { "250e6870-4e86-4ec5-bdf3-fd691e0bdc55", "Quảng Ngãi" },
                    { "25585a81-6816-4ebd-8d01-3c456784972b", "Lạng Sơn" },
                    { "29911acf-b0e7-4f2c-aea9-0de305b01f6a", "Sơn La" },
                    { "2a113429-8fa9-49b9-8de2-e0357e5f3988", "Lào Cai" },
                    { "3521db9e-35f2-42d3-bcf1-84b3c47adeb0", "Cà Mau" },
                    { "36886b16-ae74-4934-8232-b3cb7a2ab753", "Hà Tĩnh" },
                    { "38583ffd-99d4-4766-aede-a18db81f1281", "Đắk Lắk" },
                    { "3b315afe-8ed0-4cf3-9b6e-199c00396c52", "Kiên Giang" },
                    { "3f22a5ef-16be-45a7-bf99-7f3991c891b1", "Hòa Bình" },
                    { "3fb526d4-c3ca-455b-afdc-c1fedaf779eb", "Kon Tum" },
                    { "4322dbbc-98e7-4f66-a290-23254c224be0", "Bắc Ninh" },
                    { "4439fcea-0fdb-43a9-bc9b-3a3a225e9588", "Bắc Kạn" },
                    { "46ac54f1-5223-4244-8a46-c6bdc59b0eec", "Vĩnh Long" },
                    { "48dc41bd-51eb-400f-a515-eeedbdb16cc5", "Quảng Ninh" },
                    { "4a186d7a-4121-4522-a753-baa893914e09", "Hậu Giang" },
                    { "4d3457b1-f628-4765-8737-d9e1ee4de5e5", "Bạc Liêu" },
                    { "4e5f5f31-5fc7-40e8-a214-1b18b08e97cc", "Bình Dương" },
                    { "506956d9-c2b1-4f65-88e3-614fa744b391", "Thái Bình" },
                    { "5746fa4e-7c8a-4803-9851-b2bac36ab71c", "Hà Giang" },
                    { "59ca230e-9abc-4a39-9cef-5ab0dd66ed5c", "Hà Nội" },
                    { "5c944d88-210d-4b5e-b2fa-66bbc0194072", "An Giang" },
                    { "62cf91df-7708-434d-9007-2628e8612c97", "Trà Vinh" },
                    { "6e9d5499-16f9-4a66-9269-673588dc4ce3", "Hà Nam" },
                    { "6fca81e9-a566-41e1-827b-68ddf10a7790", "Lâm Đồng" },
                    { "6fd74f0e-5c8c-4cdb-bef6-bd1efc00c2db", "Bắc Giang" },
                    { "735f23b4-5b6c-4580-8820-1ccf926321ef", "Tiền Giang" }
                });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "783e6571-3c77-4d8f-a1c1-8bc6b4559213", "Đà Nẵng" },
                    { "79f12a69-e1a0-487f-a0fa-979459dd0c30", "Hải Dương" },
                    { "82b6b8f5-4c44-47bb-9f54-d28cf628f796", "Lai Châu" },
                    { "834a7595-fd35-46b6-b40b-44e5842fd5ed", "Thanh Hóa" },
                    { "88da862c-f1c7-45e8-ae25-f920b1114950", "Tất cả tỉnh thành" },
                    { "8a329c39-3a43-4fa5-bd6b-9aadf24b5175", "Phú Thọ" },
                    { "8a68b8a3-e1dc-4716-8c37-38637771c048", "Thái Nguyên" },
                    { "8ac48bab-1695-491b-a426-d11c36162d0e", "Gia Lai" },
                    { "8c25912d-451d-44eb-9917-1faed922a231", "Bến Tre" },
                    { "94e4e646-4048-4c12-a918-8ed3fe092a0e", "Đồng Tháp" },
                    { "9682bf30-f4dd-418f-8051-6dfd17ff8f18", "Quảng Bình" },
                    { "9b20e40e-5786-4456-a658-02f223ff9aef", "Bình Phước" },
                    { "9f2e83b2-a709-488f-ac38-7102e857f0bf", "Phú Yên" },
                    { "a3d31502-7b6c-4b94-bdc6-19aba96e36ec", "Cần Thơ" },
                    { "b5557d0e-d6dc-46d6-916c-3eadfcf2e53b", "Bình Định" },
                    { "b889d348-b88b-46b4-a715-2efdf4c33286", "Long An" },
                    { "bab9f527-eb44-41a0-9320-9857d6d25be7", "Cao Bằng" },
                    { "bef1d679-f907-4b8a-8ae0-5caeccd8dd1d", "Ninh Thuận" },
                    { "c3fb6918-ee12-4ba4-8299-74674fe59b19", "Hồ Chí Minh" },
                    { "c5102340-9da7-4803-82c3-4bdeb287fcde", "Sóc Trăng" },
                    { "d617efa6-cb4d-4853-9f1a-0fbe125f1b66", "Tây Ninh" },
                    { "d7436211-66b4-4b85-b4d2-e1d9299e500c", "Nam Định" },
                    { "d7bd8102-8ff1-4ebb-abac-8a41ee252cb8", "Thừa Thiên Huế" },
                    { "d8ebd879-c29e-409b-b63d-74ed59f09f96", "Khánh Hòa" },
                    { "e8319743-92d3-4592-9c45-b89aec52e9aa", "Yên Bái" },
                    { "f068da66-c135-4659-b37e-c10b1d8fdd45", "Đồng Nai" },
                    { "f343edc2-2725-486e-b727-80e65d7d0b53", "Quảng Trị" },
                    { "feff0c28-bdc3-448b-a54e-945eb18661eb", "Bình Thuận" },
                    { "ff5ace69-d053-457f-ae18-443c85d7aece", "Ninh Bình" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { "2f485acf-e824-431b-8867-c3b7664e90f7", "Employer" },
                    { "8e6f7973-d40d-4cd0-a95e-ea3021180a48", "Candidate" },
                    { "cf01d0d0-eb7b-44a6-8a48-b5b3868bf929", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Avatar", "DateOfBirth", "Discriminator", "Email", "PhoneNumber", "Username" },
                values: new object[] { "85bf9cae-46cd-41d8-b545-8da6f9dd8f9a", null, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Candidate", "cvlookup.sgu.2023_candidate@gmail.com", null, "Candidate Admin" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Address", "Avatar", "Description", "Discriminator", "Email", "PhoneNumber", "Username", "Website" },
                values: new object[] { "f600fa3f-a9af-4995-9d31-4f4646e636a4", "Admin", null, "Admin", "Employer", "cvlookup.sgu.2023_employer@gmail.com", null, "Employer Admin", null });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Avatar", "Discriminator", "Email", "PhoneNumber", "Username" },
                values: new object[] { "39a29e9f-5c55-4c19-bc37-d9558dc353c7", null, "User", "cvlookup.sgu.2023@gmail.com", null, "General Admin" });

            migrationBuilder.InsertData(
                table: "AccountUser",
                columns: new[] { "AccountId", "UserId" },
                values: new object[,]
                {
                    { "07b60274-35f5-4179-8e06-4132cc4fe1bf", "f600fa3f-a9af-4995-9d31-4f4646e636a4" },
                    { "2bb35655-1118-477e-b4c0-64263fe98e47", "39a29e9f-5c55-4c19-bc37-d9558dc353c7" },
                    { "4d2df3b3-b06e-4a8e-a84a-d2e6515d0d2a", "85bf9cae-46cd-41d8-b545-8da6f9dd8f9a" }
                });

            migrationBuilder.InsertData(
                table: "District",
                columns: new[] { "Id", "Name", "ProvinceId" },
                values: new object[,]
                {
                    { "042346ed-8df3-40e9-9056-444ac0a9659f", "Quận 8", "c3fb6918-ee12-4ba4-8299-74674fe59b19" },
                    { "07c15a3e-390c-453d-8d1e-b218b7c532d7", "Quận 5", "c3fb6918-ee12-4ba4-8299-74674fe59b19" },
                    { "081025ad-7622-4186-bf19-2673048d9adc", "Quận Ngũ Hành Sơn", "783e6571-3c77-4d8f-a1c1-8bc6b4559213" },
                    { "0ef9c822-219c-4f50-a7c9-f1d3c3954316", "Quận Kiến An", "0221d295-c1e7-4a68-9f27-6d221d11e719" },
                    { "0f0f4b59-6557-4785-8d8c-e1353a417a41", "Quận 11", "c3fb6918-ee12-4ba4-8299-74674fe59b19" },
                    { "0fe79213-80c4-4afc-b1b6-27fd96aab468", "Tất cả", "783e6571-3c77-4d8f-a1c1-8bc6b4559213" },
                    { "126fd77e-4945-4dc1-ab1b-8ef4cee29286", "Quận Nam Từ Liêm", "59ca230e-9abc-4a39-9cef-5ab0dd66ed5c" },
                    { "12bd7b26-5b0c-40a0-b34f-a5188617c98a", "Quận Đồ Sơn", "0221d295-c1e7-4a68-9f27-6d221d11e719" },
                    { "1ad35006-aae4-4760-9ce9-7b637da3437c", "Quận Phú Nhuận", "c3fb6918-ee12-4ba4-8299-74674fe59b19" },
                    { "2409cb96-3dc1-46da-a6c1-f9b28f73078c", "Quận Hà Đông", "59ca230e-9abc-4a39-9cef-5ab0dd66ed5c" },
                    { "2c8dc9d5-2016-4018-8ba0-4bfb7190196a", "Quận 2", "c3fb6918-ee12-4ba4-8299-74674fe59b19" },
                    { "2c9126e4-02de-4f35-a83e-7857b245c222", "Quận 3", "c3fb6918-ee12-4ba4-8299-74674fe59b19" },
                    { "2d9aa52d-616a-4a32-86cc-a4e366469ab5", "Quận Tây Hồ", "59ca230e-9abc-4a39-9cef-5ab0dd66ed5c" },
                    { "35273eaf-dc1d-47b9-8aed-19164b3b9b98", "Tất cả", "59ca230e-9abc-4a39-9cef-5ab0dd66ed5c" },
                    { "3acd89b7-1129-4d81-b5dc-1588ed6e06c5", "Quận Long Biên", "59ca230e-9abc-4a39-9cef-5ab0dd66ed5c" },
                    { "3b7444da-aa9c-4bca-95df-966f54bf8512", "Quận Thốt Nốt", "a3d31502-7b6c-4b94-bdc6-19aba96e36ec" },
                    { "43ca3397-5123-489e-b703-79095979a0a8", "Quận Bình Tân", "c3fb6918-ee12-4ba4-8299-74674fe59b19" },
                    { "455b03d7-a24a-447d-a371-8900841954ed", "Quận Đống Đa", "59ca230e-9abc-4a39-9cef-5ab0dd66ed5c" },
                    { "48102b36-e5e4-4879-85f6-968eba74bb9e", "Tất cả", "c3fb6918-ee12-4ba4-8299-74674fe59b19" },
                    { "53060f9c-a3ad-4b56-a50c-891350d6d17e", "Quận Dương Kinh", "0221d295-c1e7-4a68-9f27-6d221d11e719" },
                    { "54d0b3f0-61c4-4ffa-9558-a88378a73787", "Quận Bình Thạnh", "c3fb6918-ee12-4ba4-8299-74674fe59b19" },
                    { "573d4775-0db0-4089-98bd-92883a0815c0", "Quận 9", "c3fb6918-ee12-4ba4-8299-74674fe59b19" },
                    { "59523a8a-7436-495d-8022-e2febca1f02a", "Quận Cầu Giấy", "59ca230e-9abc-4a39-9cef-5ab0dd66ed5c" },
                    { "5b820163-8fe1-4f3b-9775-bcdd08fac856", "Quận Hải Châu", "783e6571-3c77-4d8f-a1c1-8bc6b4559213" },
                    { "60224ffd-850d-4ce5-b25e-45666b2486d1", "Quận 4", "c3fb6918-ee12-4ba4-8299-74674fe59b19" },
                    { "61e7f591-9148-4bf9-a410-76bb07274206", "Quận Tân Phú", "c3fb6918-ee12-4ba4-8299-74674fe59b19" },
                    { "6353c89e-ecb2-4c5c-8e76-d60553e7016d", "Quận Thanh Khê", "783e6571-3c77-4d8f-a1c1-8bc6b4559213" },
                    { "63a3fc70-5b78-46cc-911c-87ec462ea7f2", "Quận 12", "c3fb6918-ee12-4ba4-8299-74674fe59b19" },
                    { "68a7178e-e826-42cb-ac76-16bd9446f5bc", "Tất cả", "0221d295-c1e7-4a68-9f27-6d221d11e719" },
                    { "6901a1f9-ade1-431e-9516-4840c1bfdfa4", "Quận Hoàn Kiếm", "59ca230e-9abc-4a39-9cef-5ab0dd66ed5c" },
                    { "6a70ea64-0d72-4b57-9cc0-db61701d793e", "Quận Hải An", "0221d295-c1e7-4a68-9f27-6d221d11e719" },
                    { "709f8eaa-6384-4e9a-9a79-a1ca8875a45e", "Quận Hoàng Mai", "59ca230e-9abc-4a39-9cef-5ab0dd66ed5c" },
                    { "73420251-f1ee-467d-b068-6d30ef9a96ef", "Quận Hai Bà Trưng", "59ca230e-9abc-4a39-9cef-5ab0dd66ed5c" },
                    { "75efcc57-23a7-4ebf-9bb1-e6647fdfe2a8", "Quận Lê Chân", "0221d295-c1e7-4a68-9f27-6d221d11e719" },
                    { "7813c8f6-253c-42e9-b013-c0b3ce32f929", "Quận Ninh Kiều", "a3d31502-7b6c-4b94-bdc6-19aba96e36ec" },
                    { "7afa6954-4bf6-4ab7-815c-13d3c973c777", "Quận Ngô Quyền", "0221d295-c1e7-4a68-9f27-6d221d11e719" },
                    { "80f830c1-f32c-4fbe-b275-e8a82ec54def", "Quận 7", "c3fb6918-ee12-4ba4-8299-74674fe59b19" },
                    { "811932e1-86af-425c-ae10-d2797e8ab2df", "Quận Gò Vấp", "c3fb6918-ee12-4ba4-8299-74674fe59b19" },
                    { "964d82c1-9249-4e6b-9692-0aa959d371c2", "Quận Hồng Bàng", "0221d295-c1e7-4a68-9f27-6d221d11e719" }
                });

            migrationBuilder.InsertData(
                table: "District",
                columns: new[] { "Id", "Name", "ProvinceId" },
                values: new object[,]
                {
                    { "992cd3b8-841c-40cd-87f4-a20d3f8a9186", "Quận Thanh Xuân", "59ca230e-9abc-4a39-9cef-5ab0dd66ed5c" },
                    { "9bc3a50d-d7e7-4b1f-8a4b-7164fa570d1c", "Quận Thủ Đức", "c3fb6918-ee12-4ba4-8299-74674fe59b19" },
                    { "a33c2465-dddc-4aca-a3c0-022f6bcec02b", "Quận 1", "c3fb6918-ee12-4ba4-8299-74674fe59b19" },
                    { "a781ccac-c68a-4618-90a8-4a0b5c6506b3", "Tất cả", "a3d31502-7b6c-4b94-bdc6-19aba96e36ec" },
                    { "ae339b02-af8c-42bf-afd1-e31e9cadc325", "Quận Cái Răng", "a3d31502-7b6c-4b94-bdc6-19aba96e36ec" },
                    { "bfa3923e-bb28-4947-93b5-d12a76baea29", "Quận Ô Môn", "a3d31502-7b6c-4b94-bdc6-19aba96e36ec" },
                    { "bfda2a34-81da-440f-ad4a-e85e57dd4450", "Quận Bình Thuỷ", "a3d31502-7b6c-4b94-bdc6-19aba96e36ec" },
                    { "ca3bc354-c2c2-4f19-9c56-81a55adec6b2", "Quận Sơn Trà", "783e6571-3c77-4d8f-a1c1-8bc6b4559213" },
                    { "cbda43a3-0c08-4c35-b5ff-92c1bdb51483", "Quận 6", "c3fb6918-ee12-4ba4-8299-74674fe59b19" },
                    { "cf7626cd-a1cb-4e01-a3f5-4753c01a6e4d", "Quận Liên Chiểu", "783e6571-3c77-4d8f-a1c1-8bc6b4559213" },
                    { "d91bfb69-3482-4068-9284-11dd0a514091", "Quận Cẩm Lệ", "783e6571-3c77-4d8f-a1c1-8bc6b4559213" },
                    { "dacb65dd-8f38-4b28-aa15-53b382f9b345", "Quận 10", "c3fb6918-ee12-4ba4-8299-74674fe59b19" },
                    { "dbccfcc8-6267-43ef-921a-a05ebd75c124", "Quận Ba Đình", "59ca230e-9abc-4a39-9cef-5ab0dd66ed5c" },
                    { "ec5b5301-0d26-4220-a89f-eb386001d006", "Quận Tân Bình", "c3fb6918-ee12-4ba4-8299-74674fe59b19" },
                    { "f30f87c5-fda4-4e52-8233-fdf77fb03d23", "Quận Bắc Từ Liêm", "59ca230e-9abc-4a39-9cef-5ab0dd66ed5c" }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2f485acf-e824-431b-8867-c3b7664e90f7", "f600fa3f-a9af-4995-9d31-4f4646e636a4" },
                    { "8e6f7973-d40d-4cd0-a95e-ea3021180a48", "85bf9cae-46cd-41d8-b545-8da6f9dd8f9a" },
                    { "cf01d0d0-eb7b-44a6-8a48-b5b3868bf929", "39a29e9f-5c55-4c19-bc37-d9558dc353c7" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_Email",
                table: "Account",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountUser_UserId",
                table: "AccountUser",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CurriculumVitae_UserId",
                table: "CurriculumVitae",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_District_ProvinceId",
                table: "District",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_JobAddress_ProvinceId",
                table: "JobAddress",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_RecruitmentCVRecruitmentId_RecruitmentCVCurriculumVitaeId",
                table: "Notification",
                columns: new[] { "RecruitmentCVRecruitmentId", "RecruitmentCVCurriculumVitaeId" });

            migrationBuilder.CreateIndex(
                name: "IX_Notification_UserId",
                table: "Notification",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Recruitment_EmployerId",
                table: "Recruitment",
                column: "EmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_Recruitment_ExperienceId",
                table: "Recruitment",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_Recruitment_JobAddressId",
                table: "Recruitment",
                column: "JobAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Recruitment_JobCareerId",
                table: "Recruitment",
                column: "JobCareerId");

            migrationBuilder.CreateIndex(
                name: "IX_Recruitment_JobFieldId",
                table: "Recruitment",
                column: "JobFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Recruitment_JobFormId",
                table: "Recruitment",
                column: "JobFormId");

            migrationBuilder.CreateIndex(
                name: "IX_Recruitment_JobPositionId",
                table: "Recruitment",
                column: "JobPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_RecruitmentCV_CurriculumVitaeId",
                table: "RecruitmentCV",
                column: "CurriculumVitaeId");

            migrationBuilder.CreateIndex(
                name: "IX_Token_AccountId",
                table: "Token",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Token_RoleId",
                table: "Token",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                table: "UserRole",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountUser");

            migrationBuilder.DropTable(
                name: "District");

            migrationBuilder.DropTable(
                name: "HubConnection");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "Token");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "RecruitmentCV");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "CurriculumVitae");

            migrationBuilder.DropTable(
                name: "Recruitment");

            migrationBuilder.DropTable(
                name: "Experience");

            migrationBuilder.DropTable(
                name: "JobAddress");

            migrationBuilder.DropTable(
                name: "JobCareer");

            migrationBuilder.DropTable(
                name: "JobField");

            migrationBuilder.DropTable(
                name: "JobForm");

            migrationBuilder.DropTable(
                name: "JobPosition");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Province");
        }
    }
}
