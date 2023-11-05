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
                    { "6b9a30fb-146c-47d7-af09-8b826212b329", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cvlookup.sgu.2023_candidate@gmail.com", new DateTime(2023, 11, 6, 1, 16, 53, 615, DateTimeKind.Local).AddTicks(3301), "4EvS5r40usEAzXH5nw6YyjfVVpQdHt7K+e7DBWXhKPKdrduCQ6W3M3Ala03/Tw8kFhLEGxHwealuxejQLZqg0y4nsngohze7rnldfpPHQ1Y=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "ddad3b28-5a76-44fc-8a3f-ac3ad13da419", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cvlookup.sgu.2023_employer@gmail.com", new DateTime(2023, 11, 6, 1, 16, 53, 615, DateTimeKind.Local).AddTicks(3288), "4EvS5r40usEAzXH5nw6YyjfVVpQdHt7K+e7DBWXhKPKdrduCQ6W3M3Ala03/Tw8kFhLEGxHwealuxejQLZqg0y4nsngohze7rnldfpPHQ1Y=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "e75a027a-bfa8-430f-a3f0-82629734d6e8", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cvlookup.sgu.2023@gmail.com", new DateTime(2023, 11, 6, 1, 16, 53, 615, DateTimeKind.Local).AddTicks(3262), "4EvS5r40usEAzXH5nw6YyjfVVpQdHt7K+e7DBWXhKPKdrduCQ6W3M3Ala03/Tw8kFhLEGxHwealuxejQLZqg0y4nsngohze7rnldfpPHQ1Y=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Experience",
                columns: new[] { "Id", "Exp" },
                values: new object[,]
                {
                    { "0618e5f5-ed7b-4902-9fef-430e47803546", "Từ 3-5 năm" },
                    { "2d96ef3c-907d-4c18-82f3-483c8f441c0d", "Từ 1-2 năm" },
                    { "3ff7e0b6-dc4e-4719-844a-9040cb2e6dba", "Trên 10 năm" },
                    { "529e1e07-e1c0-4689-a568-9c302f57034e", "Dưới 1 năm" },
                    { "5bae8db6-098d-4de6-97de-2e635d5ce709", "Từ 2-3 năm" },
                    { "70434a5b-998a-4367-8cdf-ad8159ebd3b5", "Tất cả kinh nghiệm" },
                    { "79ce8ed8-eac9-4f48-863e-0ab9963c8c01", "Chưa có kinh nghiệm" },
                    { "c847f343-8d49-4bf0-8822-dfe57e0ece16", "Từ 5-10 năm" }
                });

            migrationBuilder.InsertData(
                table: "JobCareer",
                columns: new[] { "Id", "Career" },
                values: new object[,]
                {
                    { "0317293f-122f-42c1-ab38-a9a886a95222", "Hàng không" },
                    { "0807ea3f-e875-4936-8daf-28bc573fdb5c", "Hành chính / Văn phòng" },
                    { "0ac74cd5-7cfc-451a-889d-1c87d7f47b1b", "Hàng cao cấp" },
                    { "0e4888a8-7f00-47c8-9739-27b248ab5bdd", "IT Phần cứng / Mạng" },
                    { "12f488d3-25ea-4442-b9d4-b915ecd0d0f7", "Tài chính / Đầu tư" },
                    { "17719137-36df-4746-95f6-99de8e89d10a", "Kế toán / Kiểm toán" },
                    { "1bee17c5-3789-47e1-a475-f70a8205bb75", "Spa / Làm đẹp" },
                    { "1e2d74a0-dd05-46e0-8772-40f2c3bfdb37", "Hàng gia dụng" },
                    { "1febb0fc-4b8b-4fed-8a4e-bf375c5d7e03", "Công nghệ Ô tô" },
                    { "218376a1-3e1f-49b2-aa8e-ce8d29233750", "Mỹ thuật / Nghệ thuật / Điện ảnh" },
                    { "255451e7-f8fb-465b-8998-9b78d141ca11", "Nhân sự" },
                    { "39363182-ed24-4181-b2e8-7f96e879b98b", "Điện tử viễn thông" },
                    { "40490d97-2a5a-43f6-b478-8b8d706098d7", "Dịch vụ khách hàng" },
                    { "4603d4fb-9c3f-4aa0-a1cd-0bfa4a2092b8", "Bất động sản" },
                    { "47d10397-52ae-4764-8ad0-23086dcb635d", "Biên / Phiên dịch" },
                    { "4894bc84-7f94-4f33-9e0c-48a17db81c88", "Thiết kế đồ họa" },
                    { "48a4e6a5-7cbf-4d38-860d-eeb4839cf7ee", "Tất cả ngành nghề" },
                    { "48c894a7-7693-4945-9c56-dcd0f8eaa534", "Kinh doanh / Bán hàng" },
                    { "4aad94b9-8dde-4d11-97cb-edfd3f31f4ac", "Xuất nhập khẩu" },
                    { "53eeffd7-e0dd-45fd-b422-641d23f0d3d5", "Bảo trì / Sửa chữa" },
                    { "548c6719-f6d0-4da0-a7b0-fa2c08047fa7", "Hoá học / Sinh học" },
                    { "559a4411-632e-4a5d-bed0-f6f133509429", "Luật / Pháp lý" },
                    { "5c1a63db-403b-47fe-8ba9-a3dc200b47ba", "Quản lý điều hành" },
                    { "5f4a455e-b2a5-4178-ab67-e42667ed0200", "Kiến trúc" },
                    { "5fc1f6c8-9a42-4bb6-a7e5-eb09012501d9", "Xây dựng" },
                    { "6301387a-5a7e-40a4-9e7e-7e304e254cfa", "Quản lý chất lượng (QA/QC)" },
                    { "6539d92d-b7f1-43f2-9930-6230e061ee94", "Sản xuất" },
                    { "659b3522-874f-4ba9-acbb-e2fc61c9d125", "Thiết kế nội thất" },
                    { "69aebe57-5658-4ebb-9b79-e2541fe0b1a8", "Nông / Lâm / Ngư nghiệp" },
                    { "6e45d8b4-7a90-4671-8a5c-dde9dc3605e9", "Ngành nghề khác" },
                    { "73f3a77a-caa7-4796-9135-396e8e531402", "Môi trường / Xử lý chất thải" }
                });

            migrationBuilder.InsertData(
                table: "JobCareer",
                columns: new[] { "Id", "Career" },
                values: new object[,]
                {
                    { "799fd7e4-a4e5-49a3-8858-2ba477df89e7", "IT phần mềm" },
                    { "7a3e8fa8-9683-49e8-a3a6-1664f8d1fba4", "Báo chí / Truyền hình" },
                    { "7dcd81ab-290d-4bd3-9dca-ccd6c8cec093", "Điện / Điện tử / Điện lạnh" },
                    { "7e30face-75df-43bf-a846-1ad5f53008bb", "Dệt may / Da giày" },
                    { "7feb6f2a-d7cf-4d03-bbec-6579ae5c3ddd", "Y tế / Dược" },
                    { "81066e08-259d-4536-879f-9e3116fce1b0", "Chứng khoán / Vàng / Ngoại tệ" },
                    { "830de325-7ae1-417c-a5ee-8a712cf58958", "Khách sạn / Nhà hàng" },
                    { "8aa0a7fa-8a90-4140-b969-3d13ab55bf32", "Hàng hải" },
                    { "8ec234ae-ea5b-421d-8f93-7f324afcab9b", "Cơ khí / Chế tạo / Tự động hóa" },
                    { "8f58e47d-3cb7-4542-a9c5-f8bffee14461", "Marketing / Truyền thông / Quảng cáo" },
                    { "93eaa686-1e1c-46f3-8e3a-21983fcdf9b7", "Bán hàng kỹ thuật" },
                    { "992325bd-0f9f-4f1d-aebb-7c6e6465d105", "Công nghệ cao" },
                    { "a4346f57-50c1-4637-a7da-a0cddda10d08", "Tư vấn" },
                    { "ab3e81c4-76bc-4c7d-a9b6-bc0c51c6d762", "Thời trang" },
                    { "ab9b6430-4696-453a-9094-9768de940210", "Bưu chính - Viễn thông" },
                    { "b10943cc-1201-407a-87ca-53ab79b29f12", "Bảo hiểm" },
                    { "b9883d92-c1ae-4c7a-9f6f-5a621a94f327", "In ấn / Xuất bản" },
                    { "bb8f3f0b-0fd2-4286-ba25-723a68929717", "Du lịch" },
                    { "bf11d7e2-1316-433c-a4f2-44741b2cb79b", "Dược phẩm / Công nghệ sinh học" },
                    { "bf490c13-caaa-418d-ae78-1198047e9d3f", "Mỹ phẩm / Trang sức" },
                    { "c944a834-cb57-4cd3-941d-6288e6c90c85", "Bán lẻ / bán sỉ" },
                    { "da2b4404-339d-4188-80f9-d9e42250cf3e", "Hàng tiêu dùng" },
                    { "daff4621-a121-4085-a1a7-54b4ace2f2af", "Dầu khí/Hóa chất" },
                    { "db9f7bac-9878-487c-8242-00b5e4c18c92", "Vận tải / Kho vận" },
                    { "df6583b2-dbf7-4476-83c5-68fef4dd1218", "Giáo dục / Đào tạo" },
                    { "e17b46a8-19e8-4e56-af24-08efc66e7aa7", "Hoạch định / Dự án" },
                    { "e1d43503-83b4-422f-a0d0-e6c7e629bf16", "Thư ký / Trợ lý" },
                    { "e42ddef5-a0b5-479d-a3db-34255e94cada", "Ngân hàng / Tài chính" },
                    { "e65dde36-9376-4a34-a8b1-8171b9971c90", "Logistics" },
                    { "ea67ba93-ffbb-4f0a-ba4f-a513f62ecbed", "Phi chính phủ / Phi lợi nhuận" },
                    { "ec506cbe-4d63-43b4-abc4-f74378122ba5", "Địa chất / Khoáng sản" },
                    { "f1bfa9ef-d0c3-464b-bc17-68f1c44d58c7", "Công nghệ thông tin" },
                    { "f4c1d51d-3fc0-4920-8884-3903f5848fc5", "Thực phẩm / Đồ uống" },
                    { "f56d586b-7faa-474e-b40e-008c18141415", "Sản phẩm công nghiệp" },
                    { "f9d21a34-cd17-4834-85d4-55189a7198c5", "NGO / Phi chính phủ / Phi lợi nhuận" },
                    { "fa2b3843-68a5-41bb-8d93-d3217cd4b38c", "An toàn lao động" },
                    { "fc997b4c-e21e-4111-8c94-5abd30fbf600", "Tổ chức sự kiện / Quà tặng" }
                });

            migrationBuilder.InsertData(
                table: "JobField",
                columns: new[] { "Id", "Field" },
                values: new object[,]
                {
                    { "01046d87-d172-4444-bed2-5252ef32f72c", "Agency (Marketing/Advertising)" },
                    { "09300ab1-4de9-44ad-9c88-d51f4415751a", "Ngân hàng" },
                    { "0a722cc6-a6f7-4f8f-93bf-e702674d7f00", "Môi trường" },
                    { "15dfd8db-675a-4837-aa70-f0aab7a23c7b", "Tổ chức phi lợi nhuận" },
                    { "19b5a718-56aa-4794-a21d-6f975ca7ccb6", "Bảo trì / Sửa chữa" }
                });

            migrationBuilder.InsertData(
                table: "JobField",
                columns: new[] { "Id", "Field" },
                values: new object[,]
                {
                    { "1cf5279f-855c-4088-85db-a0b0fa7f73f9", "In ấn / Xuất bản" },
                    { "22857b19-1a25-4a8f-bab4-151dbcd96c1f", "Bất động sản" },
                    { "23680af2-a8a1-403f-acbd-a3e5053aa912", "Kế toán / Kiểm toán" },
                    { "2ea855af-4759-4e42-ae8b-22e6296d8260", "Xuất nhập khẩu" },
                    { "32d358eb-4030-45ca-add4-a4dd0d6c4608", "Agency (Design/Development)" },
                    { "34654014-34ef-4057-bc5b-7e2cde7ea240", "Thương mại điện tử" },
                    { "350b3495-fab6-4270-bb7c-8073a680aa0f", "Tự động hóa" },
                    { "37bc2e75-03af-4b79-a12a-95d545b084d1", "Nhân sự" },
                    { "45edcf10-b743-4579-b550-235bc371f8cb", "Chứng khoán" },
                    { "48497ebf-43f4-4133-a29f-fdfc4b0083c7", "Bán lẻ - Hàng tiêu dùng - FMCG" },
                    { "5551c8c0-ec8b-4e5f-bcb9-59d21090f3f6", "Viễn thông" },
                    { "564a865e-b9b0-4514-b351-4881b333ea92", "Internet / Online" },
                    { "57cb40bd-da24-401d-b8ab-f505de442c3c", "Bảo hiểm" },
                    { "64464489-3616-4fe3-8e3b-97569cbe696b", "Năng lượng" },
                    { "6f0718d7-0d25-484c-8f0e-13fa6c4eb590", "Giáo dục / Đào tạo" },
                    { "732b3ce6-49b1-4d79-b23a-aa3d0a24e03f", "Luật" },
                    { "785d1855-dd49-4bbb-8c8d-f6ae66b68814", "Tư vấn" },
                    { "8b069135-b224-4d9a-a3b0-729e4e75122c", "Cơ khí" },
                    { "9187732c-8fbe-4491-b9c3-9348caaed3f7", "Sản xuất" },
                    { "94363b3a-83fc-47d9-a726-10e6435f30fb", "Khác" },
                    { "944ef24f-d127-4da5-9aaa-c017d414b037", "Tất cả lĩnh vực" },
                    { "9eb12e7d-daf6-4caf-9dac-e8708c7c44e1", "Logistics - Vận tải" },
                    { "a1dc4c82-9898-4102-af1c-a0313a8f4636", "Thời trang" },
                    { "a73102a4-5c75-4866-9264-3e42e39f2955", "Giải trí" },
                    { "ab8c756d-dfe6-44e0-be17-be25c7bd643d", "Nông Lâm Ngư nghiệp" },
                    { "afdb1dea-6193-4792-9292-77153ae4df90", "Tài chính" },
                    { "bc464176-348c-4391-8015-978211aa15bb", "Điện tử / Điện lạnh" },
                    { "c4814505-8d49-4c99-a290-f83f0db955eb", "Marketing / Truyền thông / Quảng cáo" },
                    { "c78fb66b-b814-4622-b902-54c39df0ef84", "IT - Phần mềm" },
                    { "d14225f5-17ef-4597-a79f-93a157caef0e", "Cơ quan nhà nước" },
                    { "d6e7353c-fc17-44c4-85ba-f41c204b6589", "IT - Phần cứng" },
                    { "e11796e7-38ce-4f22-ad42-20d8da2a8612", "Nhà hàng / Khách sạn" },
                    { "e48c3988-cf2f-40a7-9d1b-f398cd06a49d", "Xây dựng" },
                    { "e4fe9798-9227-4741-a8fa-7346f033ce65", "Du lịch" },
                    { "e952dd9d-14a3-43f1-b394-ba4bcbcaaff7", "Dược phẩm / Y tế / Công nghệ sinh học" },
                    { "f12f84fb-dbeb-4640-9082-487965abe439", "Thiết kế / kiến trúc" }
                });

            migrationBuilder.InsertData(
                table: "JobForm",
                columns: new[] { "Id", "Form" },
                values: new object[,]
                {
                    { "1938a494-15e5-47d5-827d-64875d08c764", "Tất cả hình thức" },
                    { "286d2a5a-88ec-41fc-b610-eb49767cec15", "Bán thời gian" },
                    { "82d71796-7507-4e9a-b8d3-3a081a136fd8", "Toàn thời gian" },
                    { "d4da3724-920a-4f55-aa8a-aba9cfcbe7f6", "Thực tập" }
                });

            migrationBuilder.InsertData(
                table: "JobPosition",
                columns: new[] { "Id", "Position" },
                values: new object[,]
                {
                    { "0cfca20f-157e-4563-b1ac-21193bca7b30", "Phó giám đốc" },
                    { "32f3e53b-8a3a-4fbc-8d7b-6ed443910097", "Tất cả vị trí" }
                });

            migrationBuilder.InsertData(
                table: "JobPosition",
                columns: new[] { "Id", "Position" },
                values: new object[,]
                {
                    { "6adaac2d-d89e-47c7-8a96-15d07126af47", "Thực tập sinh" },
                    { "78b5f795-d229-4792-a8ed-a69a63033154", "Giám đốc" },
                    { "7b3b9401-0b9d-4428-bcaa-8d558813f272", "Quản lí / Giám sát" },
                    { "c71c275a-0047-4133-8d61-4f459e725a6a", "Nhân viên" },
                    { "d4e052c3-241c-4205-bd3a-ed5359eda713", "Trưởng / Phó phòng" },
                    { "d8bc4a41-9d2b-4142-bd30-fd61351ac9a6", "Trưởng nhóm" },
                    { "fcb4f4e9-7fdf-4eb3-a339-63e8d5af048d", "Trưởng chi nhánh" }
                });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "08c232e2-61e1-4f22-9ed9-79eb62d25bd7", "Bắc Giang" },
                    { "0d08b49e-06d4-41c4-9c13-2eec36fde72d", "Bắc Kạn" },
                    { "0ddd2a3b-afab-4188-a7b5-80e091d9ff41", "Bình Dương" },
                    { "0f5e8336-5727-4b71-99fa-622da9230ccf", "Bắc Ninh" },
                    { "1012b77f-1b3c-4218-8dee-bdd3bf80704b", "Thái Nguyên" },
                    { "175667fe-e6cf-47e4-8c26-1aeabd2c9f22", "Bình Phước" },
                    { "1ae68c87-f646-43f9-88e6-ed405bb8d457", "Thừa Thiên Huế" },
                    { "2a4055e5-fca2-4cc0-adf3-ca35404edd60", "Phú Yên" },
                    { "2c4a60cc-29be-4991-9393-c114b91ef999", "Ninh Thuận" },
                    { "2dba2874-3822-41da-9a4d-748187b52307", "Bến Tre" },
                    { "307f175e-ec2a-4905-9668-020ec7c93a8c", "Hồ Chí Minh" },
                    { "31794c62-6614-40bf-a7cb-af78351e6a66", "Vĩnh Long" },
                    { "3972691d-bede-4b11-b680-09326c1653dd", "Quảng Bình" },
                    { "3bdbb152-45d4-4f0b-8c43-14e63df2cd64", "Hà Nam" },
                    { "3de3bd37-c588-4ccd-9c10-805851893475", "Hà Nội" },
                    { "3e92e6c3-e1b9-40e6-aea7-9879d7b8a7e3", "Cao Bằng" },
                    { "41dc8467-cdeb-43df-a77b-c6deef848529", "Đà Nẵng" },
                    { "497c9470-2b22-4eb1-bbdb-45af5eb67e42", "Long An" },
                    { "50a13510-4caa-4920-8ef9-740d38c39ee5", "Gia Lai" },
                    { "5a4cd04e-1ca6-4f01-80b7-13b42df91b67", "Đắk Lắk" },
                    { "5a6abc58-eafe-4bff-8fe1-0ff31ce79730", "Hải Phòng" },
                    { "5b3a34a2-b6e1-4fb6-bbbd-15295e28a16a", "Nam Định" },
                    { "5f0986c4-8761-48df-9fbd-6f8efa949214", "Cần Thơ" },
                    { "62d36a2e-c586-4f5d-b98f-9e32e7786930", "Hà Tĩnh" },
                    { "6713a4b5-38b0-4c19-b13c-31d1149afc3e", "Tây Ninh" },
                    { "6b55023b-67c5-4f62-bf23-fdd8c290cadc", "Lâm Đồng" },
                    { "6ca8b7d2-42e6-4114-b5d0-f349ee8966d9", "Quảng Trị" },
                    { "6e2d0804-6cb0-4ebe-a1f7-137bdb653f0e", "Yên Bái" },
                    { "70c952a3-edf0-4abc-afe7-1bcd8ef224a8", "Đắk Nông" },
                    { "711a1042-c09a-4f6d-8763-e3507f610cb1", "Tất cả tỉnh thành" },
                    { "72c55f14-cc20-4c9f-898b-88cec83782bf", "Vĩnh Phúc" },
                    { "7d31a645-af7c-4a48-87b2-ac337741559a", "Hòa Bình" },
                    { "7f07bacb-66f4-4a61-8d25-d6f774b44cc0", "Đồng Nai" },
                    { "8ad2cb42-fb77-4447-911a-3484705ef689", "Kon Tum" },
                    { "97290cd4-ef7e-4226-842d-ad8611a9bd64", "Bà Rịa-Vũng Tàu" }
                });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "9783bb78-913c-43db-bc1f-0b992d5889e1", "Đồng Tháp" },
                    { "99912c78-d33b-450a-aeaa-b314726348f1", "Hải Dương" },
                    { "9a32cc2c-acc8-4cb6-8699-48b5337e5f37", "Hà Giang" },
                    { "9e8e6358-f5f7-4d8a-85a6-9749dc4748cc", "Bình Thuận" },
                    { "a77fe4f0-d207-4e1b-8e2b-aabc387586b9", "Trà Vinh" },
                    { "ac9cfe94-86a5-45bc-bc4e-4337903afde6", "Tiền Giang" },
                    { "af2b8de5-cf93-4acd-b72c-01254bc2e7ba", "Quảng Nam" },
                    { "b215893e-f7ac-4f64-8b43-b0dccb383acb", "Hậu Giang" },
                    { "b562472d-fc7d-421b-8d57-8926ce68d7a1", "Khánh Hòa" },
                    { "b9934fe7-065d-43a5-8174-90c149fbc166", "Thanh Hóa" },
                    { "bec7979e-56f7-4ec8-a5f4-c29247cc1e19", "Lai Châu" },
                    { "cd525cb4-f3e9-4968-91a0-7fc733350da9", "Quảng Ngãi" },
                    { "cf9ed239-ec4d-45dc-b981-399c35feeb16", "Điện Biên" },
                    { "d08b918c-c958-4cad-8c33-48b228efee84", "Lào Cai" },
                    { "d17b344c-f8ba-403b-ab86-1a25aed0943b", "Cà Mau" },
                    { "d1bd7c7c-354c-4770-8385-b2e43973dd91", "An Giang" },
                    { "d1fe24c1-e18b-4694-8f1a-8b6006c6d844", "Phú Thọ" },
                    { "dd178d6c-ab38-4674-9f3a-7b31cc037791", "Kiên Giang" },
                    { "e085bb33-ddf7-48a5-9fa8-06364bb8796f", "Sóc Trăng" },
                    { "e30f9b9a-4d75-4590-85c7-e9ed521e0aa3", "Quảng Ninh" },
                    { "e5434957-d8db-4364-8da6-2781b8251d72", "Nghệ An" },
                    { "e5e555cd-cea0-452a-a443-426d787c84e5", "Thái Bình" },
                    { "e7f7a193-e194-495a-a4d9-214c4275d794", "Tuyên Quang" },
                    { "f28cfe8e-feac-4200-b70f-c07d11c6ec78", "Bình Định" },
                    { "f29d8c0f-1dc6-48f1-8f6a-a2938ddd11ce", "Ninh Bình" },
                    { "f7838fcb-5fa7-4796-9355-ae840d08397d", "Hưng Yên" },
                    { "f867e8f8-666e-44fe-8d34-e1b56b6846d0", "Bạc Liêu" },
                    { "fb3a2d04-c115-4cdb-963b-7e448e153e33", "Lạng Sơn" },
                    { "fcb840a3-5fb5-4c6d-8348-660823cf139c", "Sơn La" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { "2392dcd4-ac7f-4641-ab1c-46ffb86a8940", "Employer" },
                    { "4afc488c-c376-419f-832a-1489672d3032", "Candidate" },
                    { "c2a0726f-8aa6-4908-acc5-4bc0c729be6a", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Avatar", "DateOfBirth", "Discriminator", "Email", "PhoneNumber", "Username" },
                values: new object[] { "618963b2-d047-4be9-81c4-ad1a048c32f2", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Candidate", "cvlookup.sgu.2023_candidate@gmail.com", null, "Candidate Admin" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Address", "Avatar", "Description", "Discriminator", "Email", "PhoneNumber", "Username" },
                values: new object[] { "83928c30-2194-46a8-8e14-74a5e8fc98b6", "Admin", null, "Admin", "Employer", "cvlookup.sgu.2023_employer@gmail.com", null, "Employer Admin" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Avatar", "Discriminator", "Email", "PhoneNumber", "Username" },
                values: new object[] { "3b6ccf20-922f-42f1-ac31-92af6cd03aea", null, "User", "cvlookup.sgu.2023@gmail.com", null, "General Admin" });

            migrationBuilder.InsertData(
                table: "AccountUser",
                columns: new[] { "AccountId", "UserId" },
                values: new object[,]
                {
                    { "6b9a30fb-146c-47d7-af09-8b826212b329", "618963b2-d047-4be9-81c4-ad1a048c32f2" },
                    { "ddad3b28-5a76-44fc-8a3f-ac3ad13da419", "83928c30-2194-46a8-8e14-74a5e8fc98b6" },
                    { "e75a027a-bfa8-430f-a3f0-82629734d6e8", "3b6ccf20-922f-42f1-ac31-92af6cd03aea" }
                });

            migrationBuilder.InsertData(
                table: "District",
                columns: new[] { "Id", "Name", "ProvinceId" },
                values: new object[,]
                {
                    { "013b2311-dc23-477b-9395-76eb7b970f31", "Quận Đống Đa", "3de3bd37-c588-4ccd-9c10-805851893475" },
                    { "0cdcb0f6-db65-465f-bc47-1a17e97486d1", "Quận Hồng Bàng", "5a6abc58-eafe-4bff-8fe1-0ff31ce79730" },
                    { "1707b38a-1007-49ce-a30d-df379bb27c10", "Quận Tân Bình", "307f175e-ec2a-4905-9668-020ec7c93a8c" },
                    { "19473dac-5d3a-44f4-9469-290976247b8e", "Quận Long Biên", "3de3bd37-c588-4ccd-9c10-805851893475" },
                    { "1a036894-f659-44a5-bc19-f0708d7ab957", "Quận Hoàn Kiếm", "3de3bd37-c588-4ccd-9c10-805851893475" },
                    { "20c64b52-4b7c-4c76-8e43-1fe6068db681", "Quận 4", "307f175e-ec2a-4905-9668-020ec7c93a8c" },
                    { "242b4442-5546-4a45-b55b-b66f55e8b118", "Quận 9", "307f175e-ec2a-4905-9668-020ec7c93a8c" },
                    { "2a684023-c2a4-46c1-9656-816ba3bdb5d9", "Quận 10", "307f175e-ec2a-4905-9668-020ec7c93a8c" },
                    { "338f26fe-ac3f-40ec-b746-8cc51caa5a2f", "Quận Thanh Khê", "41dc8467-cdeb-43df-a77b-c6deef848529" },
                    { "3a2924b8-ef89-41a3-9e72-4ef17b448bbc", "Quận Đồ Sơn", "5a6abc58-eafe-4bff-8fe1-0ff31ce79730" },
                    { "3ae7cd5b-13a6-4c5e-a723-ae59352b2b60", "Quận 7", "307f175e-ec2a-4905-9668-020ec7c93a8c" },
                    { "3cc9ad8b-1030-4675-bab8-1feb96c36db8", "Quận 8", "307f175e-ec2a-4905-9668-020ec7c93a8c" },
                    { "3e3fd2d1-79ac-4317-a2e0-3b7be17dae9d", "Quận Gò Vấp", "307f175e-ec2a-4905-9668-020ec7c93a8c" },
                    { "3f35c3db-2648-4d19-b85e-204fd36decc7", "Quận Hải Châu", "41dc8467-cdeb-43df-a77b-c6deef848529" },
                    { "4511a11d-5c47-4d80-bd00-f9a356224092", "Quận 11", "307f175e-ec2a-4905-9668-020ec7c93a8c" },
                    { "45b19cf4-5e28-4bc2-b86b-f06ba8b1889e", "Quận Cầu Giấy", "3de3bd37-c588-4ccd-9c10-805851893475" },
                    { "496ef908-e4ba-4ffc-8ff1-904422dff7eb", "Quận Tây Hồ", "3de3bd37-c588-4ccd-9c10-805851893475" },
                    { "4b904219-622b-4be8-900a-bdbd00d7f743", "Quận Bình Thạnh", "307f175e-ec2a-4905-9668-020ec7c93a8c" },
                    { "4c1c3aca-fca8-4fec-8b6c-e6d941bc29dc", "Quận Ngũ Hành Sơn", "41dc8467-cdeb-43df-a77b-c6deef848529" },
                    { "4cbbfc10-c264-4809-9e61-bdaa9169f44a", "Quận 6", "307f175e-ec2a-4905-9668-020ec7c93a8c" },
                    { "4e3ece98-07a6-428d-97fe-b4ed3c306c87", "Quận Ba Đình", "3de3bd37-c588-4ccd-9c10-805851893475" },
                    { "559535fb-88e5-48ea-b74c-0c5c62cde688", "Quận Cái Răng", "5f0986c4-8761-48df-9fbd-6f8efa949214" },
                    { "5f882947-424f-4cb5-85ae-c662740554fd", "Quận Liên Chiểu", "41dc8467-cdeb-43df-a77b-c6deef848529" },
                    { "624a7459-8fab-46e9-a9d7-aa780cf1eb89", "Quận Cẩm Lệ", "41dc8467-cdeb-43df-a77b-c6deef848529" },
                    { "65a2b53b-de13-4999-9d56-6a870ad044e5", "Quận 5", "307f175e-ec2a-4905-9668-020ec7c93a8c" },
                    { "7962e6e3-7d09-4b4c-b94b-b1b5df292012", "Quận Tân Phú", "307f175e-ec2a-4905-9668-020ec7c93a8c" },
                    { "7b815bf5-f370-4baf-b4d4-81e48727e522", "Quận Ninh Kiều", "5f0986c4-8761-48df-9fbd-6f8efa949214" },
                    { "7e7537b9-b6c1-4e4e-ae1e-2130305c44cd", "Quận Kiến An", "5a6abc58-eafe-4bff-8fe1-0ff31ce79730" },
                    { "8a3aa266-e44d-4f3f-90a7-92bd86925063", "Quận Hoàng Mai", "3de3bd37-c588-4ccd-9c10-805851893475" },
                    { "92eda654-9cd9-4afe-8f5a-6816a56011c1", "Quận Bình Tân", "307f175e-ec2a-4905-9668-020ec7c93a8c" },
                    { "98481f8d-c528-48fd-bde7-c5cf458b9224", "Quận Bắc Từ Liêm", "3de3bd37-c588-4ccd-9c10-805851893475" },
                    { "9acc8823-07d5-45ae-84f4-62e725135c9a", "Quận Nam Từ Liêm", "3de3bd37-c588-4ccd-9c10-805851893475" },
                    { "9bec27cb-0712-405f-bac1-88c6fc3f9e70", "Quận Bình Thuỷ", "5f0986c4-8761-48df-9fbd-6f8efa949214" },
                    { "a242cfcb-7e77-4075-b09c-281dc6cacdaf", "Quận Ngô Quyền", "5a6abc58-eafe-4bff-8fe1-0ff31ce79730" },
                    { "af5e616d-bc42-4379-9184-4e66f5b28e58", "Quận Ô Môn", "5f0986c4-8761-48df-9fbd-6f8efa949214" },
                    { "b613cb4a-638e-4130-b22d-6cd0d9a29dea", "Quận Dương Kinh", "5a6abc58-eafe-4bff-8fe1-0ff31ce79730" },
                    { "b67ce97c-06c0-4e58-a010-96641a828a3f", "Quận Hai Bà Trưng", "3de3bd37-c588-4ccd-9c10-805851893475" },
                    { "b77b7606-d3f4-4f8c-8365-fc79e8b0e33b", "Quận Phú Nhuận", "307f175e-ec2a-4905-9668-020ec7c93a8c" },
                    { "b87a29fe-17b4-44f6-b987-b88a25671a2b", "Quận 12", "307f175e-ec2a-4905-9668-020ec7c93a8c" }
                });

            migrationBuilder.InsertData(
                table: "District",
                columns: new[] { "Id", "Name", "ProvinceId" },
                values: new object[,]
                {
                    { "c28dcb2a-2be0-4943-960c-3e6779b5b63d", "Quận Thanh Xuân", "3de3bd37-c588-4ccd-9c10-805851893475" },
                    { "c6d0a093-8cdb-4bc7-b409-4ab0d7d9e598", "Quận Lê Chân", "5a6abc58-eafe-4bff-8fe1-0ff31ce79730" },
                    { "c96f7058-1531-4cc9-ae55-0cde60fc33af", "Quận 3", "307f175e-ec2a-4905-9668-020ec7c93a8c" },
                    { "cc2f7b5e-3f1f-45b1-90e3-60f660ad3c25", "Quận 1", "307f175e-ec2a-4905-9668-020ec7c93a8c" },
                    { "cd828f83-042b-41aa-a7e3-cff1c353c2d9", "Quận Sơn Trà", "41dc8467-cdeb-43df-a77b-c6deef848529" },
                    { "de9c3115-52e9-4724-9766-bfba6cad2691", "Quận Hải An", "5a6abc58-eafe-4bff-8fe1-0ff31ce79730" },
                    { "e0080ee6-48b3-46d2-9c25-a4700032b403", "Quận Hà Đông", "3de3bd37-c588-4ccd-9c10-805851893475" },
                    { "e434d09b-9014-4f1d-9e27-b7d7c0a8de5c", "Quận Thốt Nốt", "5f0986c4-8761-48df-9fbd-6f8efa949214" },
                    { "e4494246-3939-475d-b8ca-20a87894cbde", "Quận 2", "307f175e-ec2a-4905-9668-020ec7c93a8c" },
                    { "f8e7044f-6efa-4a4a-8c04-69674098ce57", "Quận Thủ Đức", "307f175e-ec2a-4905-9668-020ec7c93a8c" }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2392dcd4-ac7f-4641-ab1c-46ffb86a8940", "83928c30-2194-46a8-8e14-74a5e8fc98b6" },
                    { "4afc488c-c376-419f-832a-1489672d3032", "618963b2-d047-4be9-81c4-ad1a048c32f2" },
                    { "c2a0726f-8aa6-4908-acc5-4bc0c729be6a", "3b6ccf20-922f-42f1-ac31-92af6cd03aea" }
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
