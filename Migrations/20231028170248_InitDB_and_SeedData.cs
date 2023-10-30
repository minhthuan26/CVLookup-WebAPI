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
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    ProvinceId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
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
                    Benefit = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                        name: "FK_Recruitment_User_UserId",
                        column: x => x.UserId,
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
                    RecruitmentCVCurriculumVitaeId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    { "0e19dd20-be3d-4b3d-b073-fa85160d57bc", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cvlookup.sgu.2023@gmail.com", new DateTime(2023, 10, 29, 0, 2, 47, 650, DateTimeKind.Local).AddTicks(2791), "4EvS5r40usEAzXH5nw6YyjfVVpQdHt7K+e7DBWXhKPKdrduCQ6W3M3Ala03/Tw8kFhLEGxHwealuxejQLZqg0y4nsngohze7rnldfpPHQ1Y=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "46d92e6b-14ef-48ba-8782-da88ba73ca95", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cvlookup.sgu.2023_candidate@gmail.com", new DateTime(2023, 10, 29, 0, 2, 47, 650, DateTimeKind.Local).AddTicks(2839), "4EvS5r40usEAzXH5nw6YyjfVVpQdHt7K+e7DBWXhKPKdrduCQ6W3M3Ala03/Tw8kFhLEGxHwealuxejQLZqg0y4nsngohze7rnldfpPHQ1Y=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "f8b43c77-3727-4388-8048-a3cb2f642cfe", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cvlookup.sgu.2023_employer@gmail.com", new DateTime(2023, 10, 29, 0, 2, 47, 650, DateTimeKind.Local).AddTicks(2831), "4EvS5r40usEAzXH5nw6YyjfVVpQdHt7K+e7DBWXhKPKdrduCQ6W3M3Ala03/Tw8kFhLEGxHwealuxejQLZqg0y4nsngohze7rnldfpPHQ1Y=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Experience",
                columns: new[] { "Id", "Exp" },
                values: new object[,]
                {
                    { "036710e5-1b81-432d-8631-3e726c496943", "Dưới 1 năm" },
                    { "11df6b88-e13d-4461-ab60-bc330ac3c1b3", "Trên 10 năm" },
                    { "2c0635d0-5cae-4a11-a97a-af75ac593bc9", "Từ 1-2 năm" },
                    { "836c2da0-1c0a-44ca-87b8-2db6a4e3355d", "Từ 2-3 năm" },
                    { "a1ac0f08-d1c8-4c53-9c45-601a0c9270c0", "Từ 3-5 năm" },
                    { "b4cdac25-e3aa-42e3-8bc7-e71f4a4fd198", "Chưa có kinh nghiệm" },
                    { "d0156ffa-0a3f-4992-8fd7-54be0b096ded", "Từ 5-10 năm" },
                    { "e7b86899-4421-499e-99aa-b3050225c98a", "Tất cả kinh nghiệm" }
                });

            migrationBuilder.InsertData(
                table: "JobCareer",
                columns: new[] { "Id", "Career" },
                values: new object[,]
                {
                    { "0056aabc-696f-40c0-b011-b12c43d63672", "Hàng không" },
                    { "08c26f41-939d-41cc-8b38-edfb6a50f06d", "Phi chính phủ / Phi lợi nhuận" },
                    { "0b844741-9c15-448f-b9fa-1d42c291a762", "Kế toán / Kiểm toán" },
                    { "1484eae8-69d7-402d-8942-0298f3d24501", "Quản lý chất lượng (QA/QC)" },
                    { "17bc320c-9529-4811-8408-e82749cd4688", "Chứng khoán / Vàng / Ngoại tệ" },
                    { "18082fc6-2f86-4198-baa9-3f641728a3ef", "Hành chính / Văn phòng" },
                    { "1a82a86e-6cc8-458f-885f-40bc34c38e83", "Kiến trúc" },
                    { "205a20ea-be6f-4621-827f-3024f107912b", "Khách sạn / Nhà hàng" },
                    { "2093b680-2c2c-40d3-87d6-c3e4552acfc9", "IT Phần cứng / Mạng" },
                    { "334cbc77-436b-4181-8d50-07e2551e9a5c", "Điện tử viễn thông" },
                    { "33e67fe7-7af1-4c75-af5e-78093980374e", "Địa chất / Khoáng sản" },
                    { "350f48f6-8537-4929-a73c-218deed897b6", "Nhân sự" },
                    { "3664eaff-f789-419b-b82a-20830d69abe9", "Hàng tiêu dùng" },
                    { "36ae89ad-f562-494c-af73-7beee6a3bc1d", "Quản lý điều hành" },
                    { "38dc9c16-9014-4e7b-b1c5-249457cc80ef", "Sản phẩm công nghiệp" },
                    { "41b200d0-138f-40ed-975b-7b04043e8908", "Logistics" },
                    { "42f87df7-b4d7-4aba-aa7c-e649be4699e2", "Tư vấn" },
                    { "4449fe85-144b-4503-9abc-5c06b6909a1d", "Dầu khí/Hóa chất" },
                    { "45d6aab2-7e2e-45f9-b178-8315bcd2c5b2", "Luật / Pháp lý" },
                    { "48b2a07b-9a26-4dc0-81d8-8608c9440026", "Spa / Làm đẹp" },
                    { "4a641a14-e031-45e0-9254-b4d4a2e5fb1e", "Marketing / Truyền thông / Quảng cáo" },
                    { "4c08ac2e-8e3b-4375-b080-5bbae2ec370b", "Thư ký / Trợ lý" },
                    { "4cffa926-2f45-4eb2-8339-85c98327abf0", "Hàng gia dụng" },
                    { "50a63cdc-7fea-4d8f-840a-318ac9cc61c6", "Công nghệ cao" },
                    { "5209e957-7473-4344-9eb5-de83ef4d4d22", "Giáo dục / Đào tạo" },
                    { "52172e0f-0253-4a26-beec-940b0c71c76a", "Bán hàng kỹ thuật" },
                    { "5b171cee-582a-416f-ad7f-ab67b3577906", "Thời trang" },
                    { "5c3e9f69-420c-46bb-81ef-b2537f37d911", "Báo chí / Truyền hình" },
                    { "5fa22971-a9f5-4198-a058-f7f38cb84bb9", "Biên / Phiên dịch" },
                    { "67fe792a-dc9b-4bb5-b032-53d9e2b0725e", "Bất động sản" },
                    { "697031cc-f63c-401a-8105-7aa30ae15462", "Mỹ thuật / Nghệ thuật / Điện ảnh" }
                });

            migrationBuilder.InsertData(
                table: "JobCareer",
                columns: new[] { "Id", "Career" },
                values: new object[,]
                {
                    { "6bfd5df7-0b05-4d3f-a05c-a1795560709a", "Bảo trì / Sửa chữa" },
                    { "6ce24263-f216-4e47-a810-9f328fd97f1f", "Dệt may / Da giày" },
                    { "70aec933-cce8-4f3e-9761-965d1fbbf5c1", "Thiết kế đồ họa" },
                    { "717eb407-33eb-4a5f-8b33-8ba934229b7f", "Thực phẩm / Đồ uống" },
                    { "78f5a34e-550d-4d66-8bd4-c64fd3bc2b3f", "Kinh doanh / Bán hàng" },
                    { "7b037c20-5346-4890-9ea2-304491a88d7f", "Bán lẻ / bán sỉ" },
                    { "7b2e25ff-aa99-4d44-9842-6322f0c2f8ce", "Bưu chính - Viễn thông" },
                    { "7e0a7ae4-126c-4d3a-afa5-d78e33ae179a", "Hoạch định / Dự án" },
                    { "82e4051c-d759-4413-8b82-06520a1af53d", "Hoá học / Sinh học" },
                    { "84584544-7918-4662-83e3-a165ccd1516b", "Tổ chức sự kiện / Quà tặng" },
                    { "87472205-d93a-4cd3-8633-0d7ffc019d3e", "Ngân hàng / Tài chính" },
                    { "893294b7-ed61-4429-bdf3-cf52b14c5e0b", "Thiết kế nội thất" },
                    { "8c3186fe-024d-4d5e-906b-ab7fb7be02c6", "Tất cả ngành nghề" },
                    { "92fdc266-2bab-4e5c-b4f0-c9594af366f3", "Mỹ phẩm / Trang sức" },
                    { "9594e35b-a2af-4c5c-9cf2-4a0fc37fc500", "An toàn lao động" },
                    { "95b5e23b-fafb-4c59-b7cc-c36d6197b4b6", "Xây dựng" },
                    { "9847abc4-58fd-48cd-ad32-30d9e4a079c4", "IT phần mềm" },
                    { "a7c2e9f0-395e-4ec7-8e28-1815f2a386b1", "In ấn / Xuất bản" },
                    { "a9d23eaa-291a-4516-b3ee-203a112f5e0b", "Y tế / Dược" },
                    { "ab717be5-1e6b-432f-b7da-fcec494121ef", "Hàng cao cấp" },
                    { "b34070bc-4a17-4fe4-8bb0-a047b7a31b25", "Công nghệ thông tin" },
                    { "b71fe1e4-e01c-422e-b5f2-4384de9b508b", "NGO / Phi chính phủ / Phi lợi nhuận" },
                    { "c05b9190-e3df-4401-949a-03591fc24068", "Dược phẩm / Công nghệ sinh học" },
                    { "c26b3813-0991-41bf-97b2-28f10e6e3b28", "Ngành nghề khác" },
                    { "c33c4ff0-58bf-4fa9-b527-fd2ac8963d6b", "Dịch vụ khách hàng" },
                    { "c3dc73fc-da12-4154-98dd-cf333ea6d4c2", "Hàng hải" },
                    { "c804bfb4-8bcf-433d-b836-fcacae5cd33c", "Môi trường / Xử lý chất thải" },
                    { "cb3bb190-892d-4312-8968-4572f4c0faac", "Điện / Điện tử / Điện lạnh" },
                    { "cbbdcd56-6416-4e0a-9109-533e8155bd29", "Bảo hiểm" },
                    { "d3b55eb6-a188-4290-8460-c85485bb1de2", "Xuất nhập khẩu" },
                    { "e2331958-abae-44a0-90c4-3f25e13616db", "Sản xuất" },
                    { "eb33045a-4656-4daa-909d-3dcf4f945349", "Nông / Lâm / Ngư nghiệp" },
                    { "f1ff0541-5ff4-406e-870d-226980f48744", "Tài chính / Đầu tư" },
                    { "f4310e46-445a-4508-a680-4b673da11bde", "Vận tải / Kho vận" },
                    { "f4bfdf79-7cb0-46bf-8670-caa1d723e8ce", "Cơ khí / Chế tạo / Tự động hóa" },
                    { "f8f8776e-c1d6-48d5-b5da-de18d2f94f6f", "Du lịch" },
                    { "fb0bd02d-4d2d-4aaf-a95d-d549780edaae", "Công nghệ Ô tô" }
                });

            migrationBuilder.InsertData(
                table: "JobField",
                columns: new[] { "Id", "Field" },
                values: new object[,]
                {
                    { "05fe7f8f-bbff-4e4c-8999-f64ad56188e2", "Ngân hàng" },
                    { "09d17943-e3d4-4896-bffd-28f23c199fbb", "Bất động sản" },
                    { "1791c2d9-eb72-4762-a2ab-fd4b1351227f", "Logistics - Vận tải" },
                    { "1dc4cd74-3715-405c-ad62-4f77bcd88aa3", "IT - Phần mềm" },
                    { "2e9516d1-1b83-4776-aa5c-c6d1b972e9c6", "Chứng khoán" }
                });

            migrationBuilder.InsertData(
                table: "JobField",
                columns: new[] { "Id", "Field" },
                values: new object[,]
                {
                    { "2eed0729-07e8-497c-8124-1ba2b20008c1", "Khác" },
                    { "3021f6f5-f185-46b2-ac52-9c171bd9f113", "Giải trí" },
                    { "316f4e9d-dfde-49c4-bfc4-2873783dbf45", "Bảo hiểm" },
                    { "37a5d2f5-d62f-4916-bc33-7238eee5220f", "Dược phẩm / Y tế / Công nghệ sinh học" },
                    { "3aaae519-1332-4f5f-9675-ece7b03c4678", "Du lịch" },
                    { "3bfa2653-76d7-44cd-9e74-1a15da6670fb", "In ấn / Xuất bản" },
                    { "4862519f-2593-417a-963c-232356009075", "Cơ quan nhà nước" },
                    { "4aac1c91-ac64-4951-80ea-a2646bf0312b", "Bảo trì / Sửa chữa" },
                    { "4ce8a5ae-226b-4f1f-97f9-09893fd388cd", "Tổ chức phi lợi nhuận" },
                    { "5585b614-e778-428d-9d04-4e2abb6a1c5c", "Xây dựng" },
                    { "61422107-f0d9-4abc-8af3-7a98ab8c5d28", "Thương mại điện tử" },
                    { "686b7c7a-da25-42c0-b4cf-b8704d94e0de", "Internet / Online" },
                    { "69393f85-432b-466b-a334-7788e0f41731", "Năng lượng" },
                    { "695626a2-1991-44a6-b06f-67f7e0af7b0c", "Sản xuất" },
                    { "6cd4ff86-9c44-4a4a-b5ed-34897beae959", "Agency (Marketing/Advertising)" },
                    { "7c60b960-3c3c-49cf-b970-668d42639330", "Nhân sự" },
                    { "83295a88-f1f2-4f56-ad4f-8b06b8a3ff33", "Agency (Design/Development)" },
                    { "87233509-052c-4148-ad4a-ef1a56da8f00", "IT - Phần cứng" },
                    { "8af8a1f8-6779-443f-b0ef-bc32264ce839", "Tài chính" },
                    { "90d7dc67-5edd-4f93-a40b-bc1d69fb9d24", "Thiết kế / kiến trúc" },
                    { "9ebb9301-1c24-4269-b8d9-1f2adcbfff4f", "Xuất nhập khẩu" },
                    { "a33d6ea0-ce4b-4eb6-abbe-a08136961d75", "Nhà hàng / Khách sạn" },
                    { "abc01127-e952-43c0-9f16-a6383d3bea91", "Tất cả lĩnh vực" },
                    { "ad76cb5f-5778-401f-94b4-d5a6c35915a7", "Bán lẻ - Hàng tiêu dùng - FMCG" },
                    { "b239844e-16db-4450-9c0a-7cf061f2720f", "Môi trường" },
                    { "b89489d1-e660-4be8-8c9c-110bc9f37a59", "Viễn thông" },
                    { "bd56230b-4b1d-4b64-b462-00ab6297abb2", "Tư vấn" },
                    { "be660b6a-da2b-412e-9f34-8f20c3033ee0", "Marketing / Truyền thông / Quảng cáo" },
                    { "c1fae090-2b95-4c2e-9433-2ef56b9cd902", "Thời trang" },
                    { "cc8456a4-9e99-4ed1-a485-3807d35c03ed", "Giáo dục / Đào tạo" },
                    { "d131efa9-b3d7-4608-ba53-af927e9d6522", "Cơ khí" },
                    { "dd3e5100-f892-4727-b571-6f2491cdb749", "Nông Lâm Ngư nghiệp" },
                    { "e128497b-ecd3-4d15-b805-ed30a18eea35", "Luật" },
                    { "e666cc6e-b97c-41f4-a655-9ef9f372467f", "Tự động hóa" },
                    { "f281a86f-afd7-4b87-be91-6df4916ad53b", "Điện tử / Điện lạnh" },
                    { "fd19fe61-ee3f-4051-8472-700acf8ae32f", "Kế toán / Kiểm toán" }
                });

            migrationBuilder.InsertData(
                table: "JobForm",
                columns: new[] { "Id", "Form" },
                values: new object[,]
                {
                    { "1b591c9f-0cb1-4992-953c-248a6be9629e", "Tất cả hình thức" },
                    { "3d8cdebb-54a1-43b4-9962-1285cfd50204", "Toàn thời gian" },
                    { "513eb1c1-38ca-41e2-abb5-c4473cbc3fb9", "Thực tập" },
                    { "7f74c042-0dff-4f39-ae4a-3cc9baafc7ea", "Bán thời gian" }
                });

            migrationBuilder.InsertData(
                table: "JobPosition",
                columns: new[] { "Id", "Position" },
                values: new object[,]
                {
                    { "1322040a-c483-4282-984c-72c21373c2d2", "Giám đốc" },
                    { "34e09454-ef6d-465e-b277-dc21eb22a390", "Trưởng / Phó phòng" }
                });

            migrationBuilder.InsertData(
                table: "JobPosition",
                columns: new[] { "Id", "Position" },
                values: new object[,]
                {
                    { "3a26ec32-20c4-465b-b987-6f3dddaa4352", "Trưởng nhóm" },
                    { "49c95ca9-10b2-4309-bbf6-2302466702bc", "Quản lí / Giám sát" },
                    { "7657db3f-abf9-42d8-9268-7cb00a917e0d", "Nhân viên" },
                    { "769cad65-ac66-4a81-b382-0b255aba4fc7", "Tất cả vị trí" },
                    { "7dc7bc6c-4d54-49b5-b5ab-f0eade1201cd", "Trưởng chi nhánh" },
                    { "f5e0812c-7bec-4fec-a49d-a37c4af3f999", "Phó giám đốc" },
                    { "fe4676db-af8f-4bd7-bcb2-f1dc77bd0705", "Thực tập sinh" }
                });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "06269f50-15de-4992-a323-79f788f73b2c", "Đắk Lắk" },
                    { "06842989-40b3-433f-b0c1-2ea2348fc21a", "Hà Nam" },
                    { "07734283-9097-4e2d-ba33-eea57e9f5bb6", "Hưng Yên" },
                    { "15fe23b7-273c-4d1a-89e3-085fd9b1e3bd", "Tiền Giang" },
                    { "180481c7-7abb-49de-aeeb-e727f73ddec9", "Điện Biên" },
                    { "1b9e3976-8d39-4880-bf39-f25a28890b60", "Phú Thọ" },
                    { "23b70a4c-bd2d-41a1-9c0a-f381a9692817", "Sóc Trăng" },
                    { "23cd78f3-25c3-4803-9beb-9185d11f064e", "Bến Tre" },
                    { "252067cc-2247-4457-af0d-9c0bf4a9f02f", "Ninh Bình" },
                    { "29c9c897-4d81-4179-a806-2e5ea28b96d8", "Tây Ninh" },
                    { "2b2e143c-e396-4ccb-9e07-2dd47a55f640", "Quảng Ninh" },
                    { "2f105399-5f10-49ec-968c-1551e72eef07", "Cao Bằng" },
                    { "3683feee-3c3a-4101-9be7-9dcd6abcf638", "Nghệ An" },
                    { "3774e90f-aab6-47b3-8f36-5ae43c6f4704", "Hà Giang" },
                    { "3ceb9ceb-6450-4970-acfa-9b08af6a34e2", "Long An" },
                    { "3db006a5-f532-4f38-9d83-a7dc38db78a1", "Bạc Liêu" },
                    { "40102b9e-0c9f-4271-b9c9-53b0c96cea77", "Ninh Thuận" },
                    { "41a5c4ab-35fe-4176-b930-090a080bac8f", "Cần Thơ" },
                    { "45a7ca11-27be-4364-bc9c-7b13ac0b67cb", "Hòa Bình" },
                    { "4e5a3d2b-a392-4289-8c1b-0a02afc2d4f1", "Hải Dương" },
                    { "54394b12-8ab8-4eb3-9183-b8597a097c6e", "Bình Phước" },
                    { "60691a99-41c1-4388-b5d5-6f7b21324149", "Quảng Nam" },
                    { "610b5a1f-ce37-42f4-8cdc-57bd3670abf7", "Hà Nội" },
                    { "618bd45b-1418-4870-8af7-30a8556977f8", "Lào Cai" },
                    { "665885e5-8750-489b-8fa6-d87833e77219", "Khánh Hòa" },
                    { "686a06c6-94e1-4c45-b61a-c1f52f686344", "Kon Tum" },
                    { "6afb35fe-8cea-48ea-b828-6b8e653b7a9c", "Quảng Ngãi" },
                    { "6c979a18-a265-4f72-9c7c-1775734567b6", "Nam Định" },
                    { "6d8a878d-a88f-43a3-816e-ec7fb3c70715", "Quảng Bình" },
                    { "6e3d8607-408a-41af-ba4b-dd2db10050e1", "Cà Mau" },
                    { "71d59302-19d5-47ee-a2d7-181641a9cb09", "Thừa Thiên Huế" },
                    { "73e199a1-00df-4f6a-b81c-9cdb155488a0", "Bắc Giang" },
                    { "76586186-a181-4a74-a2ad-0901c69a3638", "Bình Định" },
                    { "7b0a834e-2b70-4301-ad37-7bb68196f2ca", "Bình Thuận" },
                    { "7ba2c830-55c0-4e36-80f3-dbf0de09a12c", "An Giang" }
                });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "7c5ee967-56e8-4e43-aa01-588c78e10aba", "Hậu Giang" },
                    { "7e6a225e-22b6-4e6a-bf6e-e422f9e98c6c", "Tất cả tỉnh thành" },
                    { "812e5f07-0b9a-4dd2-988a-ce740b7e4a9b", "Hà Tĩnh" },
                    { "821f3872-9c0a-4cd1-8e5c-8339916799f2", "Đắk Nông" },
                    { "88022b34-7713-4ac0-a7cf-90815201b176", "Lai Châu" },
                    { "96e2fe90-1b59-4889-a145-148af6cc5c3e", "Đà Nẵng" },
                    { "9fd2b9fe-e71d-4613-b62d-630eff330713", "Hồ Chí Minh" },
                    { "a253ea85-4aa1-4d1e-ade5-7faaf3f3a4c9", "Vĩnh Long" },
                    { "a752fcae-abff-4558-845d-1892361de05b", "Thanh Hóa" },
                    { "a9c3dfd9-8df7-4636-a9b2-f98c36948cbc", "Bà Rịa-Vũng Tàu" },
                    { "abf94057-08ed-48bb-8102-d6a21b0eff02", "Yên Bái" },
                    { "b4d7a0fc-c1b6-41ec-a15f-51987b09a349", "Thái Nguyên" },
                    { "b7d37573-b8cd-4f38-94c7-91b40621babc", "Phú Yên" },
                    { "ba18a21a-99ed-42bd-9357-5b3653b81257", "Gia Lai" },
                    { "bd1564c8-24cc-45f4-aa24-d9d09c5be301", "Bình Dương" },
                    { "be635da4-d1d9-4144-ad91-f0339b9e36b0", "Bắc Ninh" },
                    { "c60b0916-c92a-4e67-bac3-ef06d6256ff5", "Lạng Sơn" },
                    { "c6586aa2-1196-40a1-b427-c78488e9e799", "Tuyên Quang" },
                    { "c7248112-2920-497c-ac51-926f0ff79040", "Trà Vinh" },
                    { "c784594f-5c13-41f2-a42b-6fe99942bd5c", "Sơn La" },
                    { "cc10c736-e9ba-44aa-b6fa-af20f01f98eb", "Bắc Kạn" },
                    { "d1c49e1e-d422-4f69-8b69-050715881a3a", "Hải Phòng" },
                    { "d51bf627-274b-4bb8-87f2-17e057aecaa6", "Vĩnh Phúc" },
                    { "d754dc96-1e9d-40dc-a337-f94a449d68f1", "Lâm Đồng" },
                    { "df7ece84-b518-455c-884d-0da29c399f8f", "Quảng Trị" },
                    { "e1212f43-43bc-448f-aa4f-cc4db23bd1a5", "Kiên Giang" },
                    { "f067fe22-df90-49df-a37c-3925d0dd431a", "Đồng Nai" },
                    { "f820176c-6a45-47be-8782-fa96e9ab1654", "Đồng Tháp" },
                    { "f9706daa-91ab-4e1a-b567-1d3dbe30d1b8", "Thái Bình" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { "524d7e6a-1a12-4384-bb7b-73454435721a", "Admin" },
                    { "6c3e1ea0-545a-4f08-b01c-e62404a3bce7", "Employer" },
                    { "7bb1baa8-7d8a-4546-987f-bf40d4bc3e24", "Candidate" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Avatar", "DateOfBirth", "Discriminator", "Email", "PhoneNumber", "Username" },
                values: new object[] { "f2ff40e3-4b09-4742-930f-cc94d0797ac8", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Candidate", "cvlookup.sgu.2023_candidate@gmail.com", null, "Candidate Admin" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Address", "Avatar", "Description", "Discriminator", "Email", "PhoneNumber", "Username" },
                values: new object[] { "dc4f77ea-cbca-44ec-8d4c-18f81da56a46", "Admin", null, "Admin", "Employer", "cvlookup.sgu.2023_employer@gmail.com", null, "Employer Admin" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Avatar", "Discriminator", "Email", "PhoneNumber", "Username" },
                values: new object[] { "79e9ed9d-79e8-45c3-9113-4ef064a2a508", null, "User", "cvlookup.sgu.2023@gmail.com", null, "General Admin" });

            migrationBuilder.InsertData(
                table: "AccountUser",
                columns: new[] { "AccountId", "UserId" },
                values: new object[,]
                {
                    { "0e19dd20-be3d-4b3d-b073-fa85160d57bc", "79e9ed9d-79e8-45c3-9113-4ef064a2a508" },
                    { "46d92e6b-14ef-48ba-8782-da88ba73ca95", "f2ff40e3-4b09-4742-930f-cc94d0797ac8" },
                    { "f8b43c77-3727-4388-8048-a3cb2f642cfe", "dc4f77ea-cbca-44ec-8d4c-18f81da56a46" }
                });

            migrationBuilder.InsertData(
                table: "District",
                columns: new[] { "Id", "Name", "ProvinceId" },
                values: new object[,]
                {
                    { "0dd67798-bca2-4568-89c4-87276750284c", "Quận Cái Răng", "41a5c4ab-35fe-4176-b930-090a080bac8f" },
                    { "0f05dc98-687d-4022-a46d-c7fbd23fb532", "Quận 3", "9fd2b9fe-e71d-4613-b62d-630eff330713" },
                    { "0f8ea92e-5a4d-4c0a-93ca-75db5bee351a", "Quận Hồng Bàng", "d1c49e1e-d422-4f69-8b69-050715881a3a" },
                    { "140cd890-bb4f-41ef-816b-22d2fb838830", "Quận Hoàng Mai", "610b5a1f-ce37-42f4-8cdc-57bd3670abf7" },
                    { "19e866a7-3ddc-4c92-9ec0-c303e000f030", "Quận Tân Phú", "9fd2b9fe-e71d-4613-b62d-630eff330713" },
                    { "1db6cbb9-248a-43d9-ac38-b91319da5bfc", "Quận Hai Bà Trưng", "610b5a1f-ce37-42f4-8cdc-57bd3670abf7" },
                    { "26b6ca07-a4f4-43dc-8fee-06444ac87e1a", "Quận Hà Đông", "610b5a1f-ce37-42f4-8cdc-57bd3670abf7" },
                    { "36146a56-27a2-4663-bc28-9ddba0e699c8", "Quận Đống Đa", "610b5a1f-ce37-42f4-8cdc-57bd3670abf7" },
                    { "386b696a-12ed-4ff4-b0f1-ca9bc098da86", "Quận Bình Thạnh", "9fd2b9fe-e71d-4613-b62d-630eff330713" },
                    { "3b7c1094-fa18-48fb-af74-034e11a90ef4", "Quận Thốt Nốt", "41a5c4ab-35fe-4176-b930-090a080bac8f" },
                    { "43ba0170-ff16-46c4-836d-9dd7ac5b2c29", "Quận Cẩm Lệ", "96e2fe90-1b59-4889-a145-148af6cc5c3e" },
                    { "43cc9a62-c173-4431-93fa-e0f12d4e314c", "Quận 11", "9fd2b9fe-e71d-4613-b62d-630eff330713" },
                    { "450db330-fb7d-4a48-aa25-7318ce284d78", "Quận 9", "9fd2b9fe-e71d-4613-b62d-630eff330713" },
                    { "49184d9c-dc8e-4785-be33-3e888c44fb55", "Quận Bắc Từ Liêm", "610b5a1f-ce37-42f4-8cdc-57bd3670abf7" },
                    { "51731ca3-e5b4-43e0-b3b4-fe93aae3ecd8", "Quận 2", "9fd2b9fe-e71d-4613-b62d-630eff330713" },
                    { "56c5b518-f70b-41a8-aa18-b359d8516766", "Quận Sơn Trà", "96e2fe90-1b59-4889-a145-148af6cc5c3e" },
                    { "5b3b0bee-aebc-4925-9ee2-1b844bd54ab2", "Quận Bình Tân", "9fd2b9fe-e71d-4613-b62d-630eff330713" },
                    { "66dc4ff2-de00-4b83-9426-80faa47fdd85", "Quận Đồ Sơn", "d1c49e1e-d422-4f69-8b69-050715881a3a" },
                    { "6ca8c58d-6fc4-4421-92a5-1ece54d72ae3", "Quận Ô Môn", "41a5c4ab-35fe-4176-b930-090a080bac8f" },
                    { "711d3ebb-060f-4fa5-8a9e-1bb0cf09ee3c", "Quận 7", "9fd2b9fe-e71d-4613-b62d-630eff330713" },
                    { "776f7d2e-15c4-4d57-9aa4-015e451ad045", "Quận Bình Thuỷ", "41a5c4ab-35fe-4176-b930-090a080bac8f" },
                    { "7a63ccfb-1839-437e-ae91-60e33898f3af", "Quận Phú Nhuận", "9fd2b9fe-e71d-4613-b62d-630eff330713" },
                    { "7c70da85-d63d-468a-b1a6-b5d36bf1d32a", "Quận Ba Đình", "610b5a1f-ce37-42f4-8cdc-57bd3670abf7" },
                    { "82bfa3f5-466f-465e-8adb-c303baf8726e", "Quận Hải Châu", "96e2fe90-1b59-4889-a145-148af6cc5c3e" },
                    { "86aa8d8a-ad69-416b-beab-21ba6e89b79b", "Quận Lê Chân", "d1c49e1e-d422-4f69-8b69-050715881a3a" },
                    { "8a70d2ef-6a82-43b6-97d7-0ff26d851b07", "Quận Hoàn Kiếm", "610b5a1f-ce37-42f4-8cdc-57bd3670abf7" },
                    { "95860bf5-c75c-4a7d-9f75-486e2bf13bc2", "Quận 12", "9fd2b9fe-e71d-4613-b62d-630eff330713" },
                    { "9b69e3aa-6150-44e1-b363-759ab1b9ec19", "Quận 10", "9fd2b9fe-e71d-4613-b62d-630eff330713" },
                    { "9ff4fd3f-50dd-4368-b9d3-6938c9af8d8c", "Quận Thanh Khê", "96e2fe90-1b59-4889-a145-148af6cc5c3e" },
                    { "a019aebe-ee9e-4746-8ef5-811f60329de9", "Quận Thanh Xuân", "610b5a1f-ce37-42f4-8cdc-57bd3670abf7" },
                    { "a0288a0b-8c68-40ca-aa33-ae497d6e013d", "Quận Thủ Đức", "9fd2b9fe-e71d-4613-b62d-630eff330713" },
                    { "a55d5f40-607d-4bb0-92c9-a98b44333e76", "Quận Cầu Giấy", "610b5a1f-ce37-42f4-8cdc-57bd3670abf7" },
                    { "a78d3b56-b9b3-4070-a5a7-ced0a8b3a328", "Quận Ngô Quyền", "d1c49e1e-d422-4f69-8b69-050715881a3a" },
                    { "a83e0698-0ee2-4819-ae48-037be756219c", "Quận 5", "9fd2b9fe-e71d-4613-b62d-630eff330713" },
                    { "b05c91db-65e2-4a11-a7ac-bef9a66a4ac7", "Quận 1", "9fd2b9fe-e71d-4613-b62d-630eff330713" },
                    { "b2624c85-fe8f-4386-bf56-6f4a6b6b530f", "Quận Ngũ Hành Sơn", "96e2fe90-1b59-4889-a145-148af6cc5c3e" },
                    { "b60610d2-6bd5-4dbf-9393-720b26ab3edf", "Quận 4", "9fd2b9fe-e71d-4613-b62d-630eff330713" },
                    { "bc3adeaf-151d-4c41-8de0-ec0865e98280", "Quận Tây Hồ", "610b5a1f-ce37-42f4-8cdc-57bd3670abf7" },
                    { "c069ec02-b823-44c5-81ce-8cfa3331d821", "Quận Nam Từ Liêm", "610b5a1f-ce37-42f4-8cdc-57bd3670abf7" }
                });

            migrationBuilder.InsertData(
                table: "District",
                columns: new[] { "Id", "Name", "ProvinceId" },
                values: new object[,]
                {
                    { "cc193bf3-1289-406d-9d59-9849413a6489", "Quận Hải An", "d1c49e1e-d422-4f69-8b69-050715881a3a" },
                    { "d003907c-2968-4282-a857-4b835d34ea51", "Quận Liên Chiểu", "96e2fe90-1b59-4889-a145-148af6cc5c3e" },
                    { "d4afe7f3-6409-440a-afb7-6ce849b55a9b", "Quận Tân Bình", "9fd2b9fe-e71d-4613-b62d-630eff330713" },
                    { "dbb898bb-ff7c-4f45-930e-202e5dcd4b95", "Quận Long Biên", "610b5a1f-ce37-42f4-8cdc-57bd3670abf7" },
                    { "e3081654-c829-46e0-9fc2-eacb38ac6895", "Quận Gò Vấp", "9fd2b9fe-e71d-4613-b62d-630eff330713" },
                    { "e3da7eed-e6b4-4ae0-8071-17c7f21f0021", "Quận Dương Kinh", "d1c49e1e-d422-4f69-8b69-050715881a3a" },
                    { "e8dbe55f-9574-4890-aae1-6a42860f9591", "Quận Kiến An", "d1c49e1e-d422-4f69-8b69-050715881a3a" },
                    { "eaa18d4e-b986-4e8c-8435-3a657e19a8f4", "Quận 8", "9fd2b9fe-e71d-4613-b62d-630eff330713" },
                    { "f9823844-8c26-4dd3-9bcd-c11edf3da3dc", "Quận Ninh Kiều", "41a5c4ab-35fe-4176-b930-090a080bac8f" },
                    { "fa740e7d-680c-4147-aaf0-997201b2907b", "Quận 6", "9fd2b9fe-e71d-4613-b62d-630eff330713" }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "524d7e6a-1a12-4384-bb7b-73454435721a", "79e9ed9d-79e8-45c3-9113-4ef064a2a508" },
                    { "6c3e1ea0-545a-4f08-b01c-e62404a3bce7", "dc4f77ea-cbca-44ec-8d4c-18f81da56a46" },
                    { "7bb1baa8-7d8a-4546-987f-bf40d4bc3e24", "f2ff40e3-4b09-4742-930f-cc94d0797ac8" }
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
                name: "IX_Recruitment_UserId",
                table: "Recruitment",
                column: "UserId");

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
