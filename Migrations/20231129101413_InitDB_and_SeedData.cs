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
                    { "a58fa60e-2978-49c7-926d-c62fa9dabb1b", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cvlookup.sgu.2023_employer@gmail.com", new DateTime(2023, 11, 29, 17, 14, 12, 887, DateTimeKind.Local).AddTicks(7540), "4EvS5r40usEAzXH5nw6YyjfVVpQdHt7K+e7DBWXhKPKdrduCQ6W3M3Ala03/Tw8kFhLEGxHwealuxejQLZqg0y4nsngohze7rnldfpPHQ1Y=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "cf10c7b2-13a3-4307-875e-bb3d901bee9d", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cvlookup.sgu.2023_candidate@gmail.com", new DateTime(2023, 11, 29, 17, 14, 12, 887, DateTimeKind.Local).AddTicks(7547), "4EvS5r40usEAzXH5nw6YyjfVVpQdHt7K+e7DBWXhKPKdrduCQ6W3M3Ala03/Tw8kFhLEGxHwealuxejQLZqg0y4nsngohze7rnldfpPHQ1Y=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "f2c45b04-9bec-4296-b76c-7d15bd5b45a9", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cvlookup.sgu.2023@gmail.com", new DateTime(2023, 11, 29, 17, 14, 12, 887, DateTimeKind.Local).AddTicks(7527), "4EvS5r40usEAzXH5nw6YyjfVVpQdHt7K+e7DBWXhKPKdrduCQ6W3M3Ala03/Tw8kFhLEGxHwealuxejQLZqg0y4nsngohze7rnldfpPHQ1Y=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Experience",
                columns: new[] { "Id", "Exp" },
                values: new object[,]
                {
                    { "13ca4404-dd37-47a4-b075-eae11cb93181", "Từ 5-10 năm" },
                    { "21db5902-23c1-4c88-aee8-7aeecd49696e", "Tất cả kinh nghiệm" },
                    { "38615614-adf1-413e-9c7c-4c20b3040a83", "Trên 10 năm" },
                    { "4fe1041c-c8a2-4b40-905f-3d3940d9465a", "Từ 2-3 năm" },
                    { "5c4369e8-15ed-44c2-9b92-5bec15544433", "Dưới 1 năm" },
                    { "7d9f3311-f959-4c5f-9f6b-feeafee3258a", "Từ 1-2 năm" },
                    { "a69c815b-c4f9-4e12-8a01-53211d453bbd", "Chưa có kinh nghiệm" },
                    { "ab639afd-5def-4fc4-af63-a29bfbc177f7", "Từ 3-5 năm" }
                });

            migrationBuilder.InsertData(
                table: "JobCareer",
                columns: new[] { "Id", "Career" },
                values: new object[,]
                {
                    { "0679ed18-12dd-4a36-ae60-3f560442810c", "Công nghệ cao" },
                    { "09ccbdb4-35d5-40b8-b7c8-941542479fc5", "Xuất nhập khẩu" },
                    { "0b114a6f-fd79-46c0-8e41-4fe1e8ca871f", "Bán hàng kỹ thuật" },
                    { "0d7c8f00-b4df-4024-95c5-b7b37e6e05d0", "Mỹ phẩm / Trang sức" },
                    { "0e82d4f8-38c7-450f-8661-d3160bb1bbdf", "Ngành nghề khác" },
                    { "0e8d1cdd-1676-4999-bbdd-3e5c37fcd72c", "Thư ký / Trợ lý" },
                    { "12dd0ca1-e1e1-4da1-ae8a-c0c40e279c09", "Công nghệ thông tin" },
                    { "131d4659-4c23-4aa7-82cf-7c511061d8ae", "Hoạch định / Dự án" },
                    { "17943175-5f85-4780-9a65-866f70450a2f", "Thiết kế nội thất" },
                    { "1f56dc4e-f834-4412-9ba4-00bce00ad09d", "Xây dựng" },
                    { "2050e3fc-13ce-4169-942d-d9f34925aa45", "Tất cả ngành nghề" },
                    { "24bbf0d2-739c-44be-b15b-7fd007f27345", "Bưu chính - Viễn thông" },
                    { "2780015c-dc3d-4705-b179-eebcdcea500a", "Điện / Điện tử / Điện lạnh" },
                    { "28720c3f-2271-42c3-91c8-9215a1faf173", "Dầu khí/Hóa chất" },
                    { "2886f60e-54a9-4cdd-a303-365799c41226", "Thời trang" },
                    { "29db79be-f4a7-4799-86bd-a5c7daa8579c", "An toàn lao động" },
                    { "2b826860-837a-4c75-a3d9-195176f9f40d", "Địa chất / Khoáng sản" },
                    { "2de0dd31-b7c5-4859-b405-2ec0b2544bf6", "Nhân sự" },
                    { "36975481-2e2c-4344-8e67-07a12efd1533", "Thực phẩm / Đồ uống" },
                    { "39f725c4-6207-41e6-8e36-bd4e74ceadf4", "IT Phần cứng / Mạng" },
                    { "42539ee3-e203-4d28-b368-c4fc5cafe020", "Hành chính / Văn phòng" },
                    { "431fec55-2c2d-4a37-b801-5aa8dcb58ed7", "Kinh doanh / Bán hàng" },
                    { "4739567a-93ae-4971-9939-95747019eff2", "Marketing / Truyền thông / Quảng cáo" },
                    { "47cb3743-e7b0-4b63-b8e6-708029138af2", "Hàng gia dụng" },
                    { "49ed8a35-bf53-4ab0-93d9-5e3c7a799581", "Nông / Lâm / Ngư nghiệp" },
                    { "4d527ee9-3c88-40c3-80ba-9b5401f65737", "Kiến trúc" },
                    { "4d911153-0fd7-48b2-a93d-043a48419bb8", "Dệt may / Da giày" },
                    { "4f419a28-25b6-424d-8d7a-975e32bddb10", "Hàng hải" },
                    { "5089531c-cf38-403d-9423-b9a2b9dfb5ff", "Môi trường / Xử lý chất thải" },
                    { "54b9e09c-700c-45c6-a5e0-4aebed33f6c6", "IT phần mềm" },
                    { "55edb878-db14-4680-9ba4-1a3d36f03e1a", "Luật / Pháp lý" }
                });

            migrationBuilder.InsertData(
                table: "JobCareer",
                columns: new[] { "Id", "Career" },
                values: new object[,]
                {
                    { "56548f9d-0048-4312-b7e8-26c25194a6c1", "Tài chính / Đầu tư" },
                    { "57b503f2-6c44-4a9b-b978-3de22dbb1602", "Giáo dục / Đào tạo" },
                    { "5f3ba493-2ee0-44cc-ab87-2bc24f96e2d4", "Bất động sản" },
                    { "6298ac3b-d5be-40eb-be7d-50a4dc3253fd", "Vận tải / Kho vận" },
                    { "6e8d8c1d-aa36-4970-b953-e9f5c7199dc1", "Du lịch" },
                    { "7055229e-150a-4141-b9fd-4de24cdd3b8b", "Sản xuất" },
                    { "738713cc-8656-435e-bf6d-63084ab5ac4a", "Cơ khí / Chế tạo / Tự động hóa" },
                    { "785e793b-173a-4b66-9280-75efda5a9521", "Chứng khoán / Vàng / Ngoại tệ" },
                    { "815fb061-477a-408b-b1fa-1aa914925958", "In ấn / Xuất bản" },
                    { "89b9dbc1-ecdd-4cf3-aad2-46c0f79d1227", "Hàng tiêu dùng" },
                    { "8ac18114-2f8e-4dcd-a880-9c69bf74cb52", "Tư vấn" },
                    { "8f4af482-d9b7-499f-8459-8cd2eab367a0", "Kế toán / Kiểm toán" },
                    { "96573923-452b-4ced-89e4-f2c99ebb0845", "Phi chính phủ / Phi lợi nhuận" },
                    { "9773d247-697e-4a4d-a484-b1dd5ba10aaf", "Sản phẩm công nghiệp" },
                    { "979a7306-8eb4-4345-abc0-12a46426944d", "Dịch vụ khách hàng" },
                    { "98971bae-c003-4797-bf3b-307096bdb7eb", "Quản lý chất lượng (QA/QC)" },
                    { "992be4b0-4e06-43e0-8d87-785ec809fd07", "Điện tử viễn thông" },
                    { "9db2d558-38ad-46f1-bf16-26bbc838226f", "Tổ chức sự kiện / Quà tặng" },
                    { "a0e54be7-984b-425c-a389-ea04ad87efde", "Dược phẩm / Công nghệ sinh học" },
                    { "a3b3f9df-d710-46bf-8a8f-df3181eb6954", "Công nghệ Ô tô" },
                    { "a5508ef5-36b6-4eaf-9f2b-f7236675b897", "Hàng không" },
                    { "ab2c4fd1-7c89-4c34-8c7f-48c5f0474d10", "Bán lẻ / bán sỉ" },
                    { "ad84eaa8-7fa5-48e7-a8c1-bb2e5c4a0be5", "Mỹ thuật / Nghệ thuật / Điện ảnh" },
                    { "b1a4df4d-ea38-41af-8236-063488d7b72f", "Spa / Làm đẹp" },
                    { "b9a87607-1bba-4154-8c1a-2a5a7db7bb17", "NGO / Phi chính phủ / Phi lợi nhuận" },
                    { "c2412b77-d502-42fb-8f41-eed263b10f59", "Bảo hiểm" },
                    { "c65c1aee-de31-4663-9eae-af1e41a1cdf6", "Thiết kế đồ họa" },
                    { "ca442277-68e8-4152-be6c-933fbfc89e6e", "Quản lý điều hành" },
                    { "d250c3e9-9942-4d71-b758-1b48d2b49970", "Khách sạn / Nhà hàng" },
                    { "dd70a86c-f0de-483a-bc3f-a91e64dca87a", "Ngân hàng / Tài chính" },
                    { "e1581172-2e95-4325-90db-e1c8a0669210", "Báo chí / Truyền hình" },
                    { "e59574d0-185d-45cd-acd0-3ff9e49506e8", "Hàng cao cấp" },
                    { "e66a6434-514e-4b49-9a9f-69ab55f13667", "Logistics" },
                    { "e75d5445-1db1-440f-b566-9d86a2aae56c", "Biên / Phiên dịch" },
                    { "ea27751c-791e-4eb2-9d1a-3d46669848c4", "Y tế / Dược" },
                    { "f48ac7c9-6b80-4d2a-af8b-804365d628a4", "Hoá học / Sinh học" },
                    { "fa85df17-53dd-492b-acae-92f0c072d7e0", "Bảo trì / Sửa chữa" }
                });

            migrationBuilder.InsertData(
                table: "JobField",
                columns: new[] { "Id", "Field" },
                values: new object[,]
                {
                    { "0e7e9ec7-d77a-46ad-a26a-45a3846670dc", "Thương mại điện tử" },
                    { "232a9c0b-290a-4b09-9da4-3184a52d3c9e", "Agency (Marketing/Advertising)" },
                    { "2fd2175b-d968-4b08-bbf7-365f4623215a", "Bảo trì / Sửa chữa" },
                    { "2fe8e1e6-c22d-4e69-841e-942d3e75cd95", "Dược phẩm / Y tế / Công nghệ sinh học" },
                    { "3431ab7e-6688-4d47-94f7-7980464151af", "Xây dựng" }
                });

            migrationBuilder.InsertData(
                table: "JobField",
                columns: new[] { "Id", "Field" },
                values: new object[,]
                {
                    { "3c6ba32e-929c-453f-8ec4-c4ecc8dbb609", "Nhà hàng / Khách sạn" },
                    { "3d759f31-ce81-4089-bf07-283935f0f9ea", "Kế toán / Kiểm toán" },
                    { "532b9d54-7fc9-45b6-8564-35e0234a4293", "Marketing / Truyền thông / Quảng cáo" },
                    { "544c4786-cf33-4fa2-8fe7-3f53ae23b543", "Điện tử / Điện lạnh" },
                    { "581be607-99bd-42b1-8182-2c838c234907", "Sản xuất" },
                    { "5fddf421-9720-428c-b717-66209c22873c", "Tổ chức phi lợi nhuận" },
                    { "71747805-71b4-42e1-9981-d954bf9000b1", "Bất động sản" },
                    { "729447eb-420e-46d4-af1c-895992da42bd", "Thiết kế / kiến trúc" },
                    { "75a98165-626c-4e75-a79e-2d8bade73e5d", "Tất cả lĩnh vực" },
                    { "7716b455-e05c-48d4-a9e7-bb8dc042a031", "Nhân sự" },
                    { "7d52d709-8221-4022-881f-eeb7ed08499b", "Tư vấn" },
                    { "845877e1-0d93-4f48-ba49-83df050e499c", "Agency (Design/Development)" },
                    { "89df358e-af38-477a-9010-2653723c217c", "Giải trí" },
                    { "8df01985-67d0-452d-aef0-c48105067f4a", "Thời trang" },
                    { "8e25701b-fb5f-416a-98c3-137bc1af2039", "IT - Phần cứng" },
                    { "926662c6-6531-4b2b-9a90-61bc1eec87f9", "Cơ quan nhà nước" },
                    { "989527d7-6cc7-4da2-ab59-f611749c2bfd", "Bán lẻ - Hàng tiêu dùng - FMCG" },
                    { "ad3bfd22-49a0-4b7f-b169-0f2abda59956", "Giáo dục / Đào tạo" },
                    { "b14df983-83b5-49b4-ab98-01ed1fa057bd", "Tài chính" },
                    { "b4e7e70e-078d-42ce-a0fb-b889ce09429a", "Chứng khoán" },
                    { "b91061bd-ec68-4a19-9b0e-e2ca0828e80d", "Cơ khí" },
                    { "bc39d4e8-e7a5-4eb1-9fad-3138c4279b2b", "Xuất nhập khẩu" },
                    { "be54515d-2913-4276-9433-7e134377a241", "Nông Lâm Ngư nghiệp" },
                    { "c88288cc-b0a9-4cfc-b438-dc193e725200", "Môi trường" },
                    { "ca4cc88b-1436-4bc6-9900-4b571cb345b5", "In ấn / Xuất bản" },
                    { "d0890914-6404-4db7-93a7-28f660f3357c", "Logistics - Vận tải" },
                    { "d4dc7f6e-d60c-41d0-8b68-250ee3dff4f5", "Bảo hiểm" },
                    { "d8f3293a-bc2a-4b5a-8ab5-2743a7c27b2f", "Du lịch" },
                    { "e565f11e-3d43-4392-87a0-51bb1200d1f8", "Internet / Online" },
                    { "e91d3e2e-d133-45f9-b200-ded77edfe78c", "Năng lượng" },
                    { "f05fa11e-8d73-4ce5-8a4a-dba839c544a6", "Viễn thông" },
                    { "f557ab9c-2362-451c-b183-0dd4401e7da5", "IT - Phần mềm" },
                    { "f7ef5b80-0fb8-4c67-899d-35f0003dd20d", "Ngân hàng" },
                    { "faa5ca44-40d5-431b-82a8-51fe250db3de", "Luật" },
                    { "fc25aa4b-9a73-4c5b-9e05-d4d9eff5e1f3", "Tự động hóa" },
                    { "fc7643c6-a75f-405f-947f-79a13b8b4699", "Khác" }
                });

            migrationBuilder.InsertData(
                table: "JobForm",
                columns: new[] { "Id", "Form" },
                values: new object[,]
                {
                    { "42934a33-ad06-47fa-af1c-df3df8009022", "Toàn thời gian" },
                    { "7981a9a6-9df6-4836-8a01-9e516be67a90", "Bán thời gian" },
                    { "8f626c37-8c0e-481a-a13a-cd33b33a881f", "Tất cả hình thức" },
                    { "bef5a2b0-ae6a-4004-b2ca-af82f3e771d5", "Thực tập" }
                });

            migrationBuilder.InsertData(
                table: "JobPosition",
                columns: new[] { "Id", "Position" },
                values: new object[,]
                {
                    { "0e5a73c6-931a-4e8a-a222-b58bc3d1aebb", "Quản lí / Giám sát" },
                    { "4334b84d-0162-40fe-ba16-3d133699822b", "Tất cả vị trí" }
                });

            migrationBuilder.InsertData(
                table: "JobPosition",
                columns: new[] { "Id", "Position" },
                values: new object[,]
                {
                    { "61f14337-17c1-4f07-9e0d-4b7f6a5870c1", "Nhân viên" },
                    { "68867e2a-db59-4d15-9d57-fcd662426e25", "Trưởng chi nhánh" },
                    { "6edc81cf-e83c-4bf1-bb40-6381f211fb72", "Phó giám đốc" },
                    { "75091f63-8615-44d5-996b-53205c3f6197", "Trưởng nhóm" },
                    { "81e46379-27e3-4e86-9018-e91e33f6851e", "Thực tập sinh" },
                    { "897d813d-d035-4f05-8fd2-ea099444cb2f", "Trưởng / Phó phòng" },
                    { "8e25da0e-7226-455e-a4ed-3362fc114460", "Giám đốc" }
                });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "01a69359-d6fc-4116-bbd0-d127fe6d0774", "Hưng Yên" },
                    { "01d597dc-e64c-41ff-b74e-0bb051f6f6bb", "Trà Vinh" },
                    { "096bf491-05f4-488e-8eb8-d04a3d1844ef", "Vĩnh Long" },
                    { "0f825303-629c-485a-b9ed-c4d209fce825", "Hà Nội" },
                    { "0f90dffb-8722-42a6-8fac-70a972aada4f", "Bắc Kạn" },
                    { "0fe7d819-ec08-4f9e-8666-68ecd6fb6fed", "Cần Thơ" },
                    { "116bacfc-2a58-43fa-abfe-7ec2b4bd0def", "Hồ Chí Minh" },
                    { "1335a90f-4387-41a8-9b27-d6cef6ca864e", "Tuyên Quang" },
                    { "16d55e02-180f-4808-a0fb-eecd8c9739ac", "Lạng Sơn" },
                    { "16fa33a9-7a9e-4b2d-a72e-db9db299cba8", "Bắc Giang" },
                    { "19384841-22be-42ba-a526-7669bca8c69e", "Bà Rịa-Vũng Tàu" },
                    { "1aee2487-14cb-4ce6-8c4a-4cd16f8129b8", "Đà Nẵng" },
                    { "2212bede-4ec7-41a7-8fc0-444561de9c6e", "Thừa Thiên Huế" },
                    { "26fcc20d-7719-405b-963e-9b68fa39f239", "Hải Phòng" },
                    { "27e931df-094d-41e7-be5d-e28b0ffacb07", "Thái Nguyên" },
                    { "2a0750ec-c52f-4ec6-b2b4-23b9a82a0f63", "Nam Định" },
                    { "313f1e85-9967-4a19-9f77-e193e9b49a9b", "Sóc Trăng" },
                    { "328620ac-f228-4bf9-94ff-29710e3d88ed", "Bạc Liêu" },
                    { "32c8209e-e4ae-4fa1-86b3-08869ed92dd3", "Bắc Ninh" },
                    { "364c33ef-efa4-43a8-90ed-7f6709472fef", "Bình Dương" },
                    { "3c4b533b-8349-4054-9c3d-2b9fe6008387", "Hà Tĩnh" },
                    { "41d96a52-0dd5-4706-a827-c600d3e7dd97", "Lâm Đồng" },
                    { "48b05fb9-f523-4491-a302-5f6028b5ba02", "Điện Biên" },
                    { "4a7eccb3-ff28-439c-a5f0-7f0bf5ae376d", "Tây Ninh" },
                    { "4f324bea-20dc-468b-8ddc-964221892b1a", "Long An" },
                    { "510ea70f-e4fb-432e-ab13-3cf1147f2f85", "Hòa Bình" },
                    { "57f95061-b1a1-47e2-8a3a-21d7384145ee", "Cao Bằng" },
                    { "58b13a5e-09ec-4ace-ab89-4649b71805f4", "Quảng Nam" },
                    { "58da4453-4b58-4559-8b01-426a28c87106", "Vĩnh Phúc" },
                    { "5a2702f4-9456-40c9-b652-a762dc2d59c5", "Quảng Ngãi" },
                    { "5c96ae8f-c0ab-4193-a1eb-322ed21bf651", "Hà Giang" },
                    { "65d572ba-4999-409e-8a6b-b6aaf4d33cb8", "Hải Dương" },
                    { "678a39a3-5424-4ad2-9faa-eabdfb84be06", "Phú Yên" },
                    { "6843ab81-a062-4703-9bf6-c827dbcec017", "Đồng Nai" },
                    { "6fa92a53-6351-4789-a41d-7b28eb6bad4e", "Hậu Giang" }
                });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "7178d910-25d6-45a4-bc20-abdae916580d", "An Giang" },
                    { "72c0c4e2-dd6f-473a-8d42-5a266f9064f0", "Thái Bình" },
                    { "752dea7f-c234-4aaf-94bd-a246ac516c90", "Yên Bái" },
                    { "7713b5b2-75b7-4093-a792-4f85e21b71b9", "Phú Thọ" },
                    { "857a5b58-2ea0-4e6f-a006-67c60491eb3d", "Thanh Hóa" },
                    { "8a00a655-8443-49d0-99f2-655016a9f7a5", "Cà Mau" },
                    { "8be2e72b-ca5c-4d95-b064-48ed62f1d4d9", "Đắk Lắk" },
                    { "8d7d0fde-e647-4c65-9e4a-eb40005f92e6", "Bình Thuận" },
                    { "94f88325-e241-4bd8-9440-98f5e7cae041", "Quảng Bình" },
                    { "97faeafb-e21a-4dcc-b85b-0cee98f6f65a", "Bình Định" },
                    { "993f4aaa-2f09-4ad5-ad7e-1395b341729c", "Ninh Thuận" },
                    { "9f46e276-41db-42be-9370-d851669a8dcf", "Hà Nam" },
                    { "9ffb694b-415f-4dfd-b2aa-bbdd81ac4c22", "Nghệ An" },
                    { "a0e41235-c992-422d-8581-cc1a4e53e3fa", "Tiền Giang" },
                    { "a1a42b85-1cec-463a-91c2-84110e16e001", "Kiên Giang" },
                    { "a4b5a777-8639-4fb7-aee6-05a7ad86facd", "Đồng Tháp" },
                    { "ac3297e5-712f-4543-8ee4-599911993a70", "Đắk Nông" },
                    { "ac43fce2-d6d1-4b23-a54c-1822ea29da82", "Bến Tre" },
                    { "ae841211-472c-4565-a03e-772ce0d52ca2", "Kon Tum" },
                    { "b1bb3a0c-d7b6-4745-b5c3-85f5c488b921", "Lào Cai" },
                    { "b6596132-9b08-407b-8255-c78917f62562", "Quảng Trị" },
                    { "c7a3343b-1627-4809-8d94-8456702bd3b0", "Quảng Ninh" },
                    { "d0d623b7-9298-4040-a438-9697cb939b0b", "Bình Phước" },
                    { "daab2516-e67b-4b8d-95ca-5af15c8a8989", "Tất cả tỉnh thành" },
                    { "de275984-9f99-4469-961f-47b3e31ad204", "Gia Lai" },
                    { "ef6f4256-16d4-43c4-ae0c-75349a6cbc78", "Ninh Bình" },
                    { "efe903ab-0cf8-49db-b6d3-8c1c9177e2ce", "Sơn La" },
                    { "f33318f5-084a-4712-9294-cc8d41cad626", "Khánh Hòa" },
                    { "fe6f1826-142a-43a2-88e4-9c2513e27e80", "Lai Châu" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { "a0408ef1-b79a-4bb2-b4bd-d0995e215126", "Admin" },
                    { "c2747ae0-6246-47a3-9c63-950ebd356415", "Employer" },
                    { "e3b83463-1367-4405-8dc0-8176fb5a566b", "Candidate" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Avatar", "DateOfBirth", "Discriminator", "Email", "PhoneNumber", "Username" },
                values: new object[] { "e0c47a58-7731-4f26-8ff9-2b899b3019bc", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Candidate", "cvlookup.sgu.2023_candidate@gmail.com", null, "Candidate Admin" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Address", "Avatar", "Description", "Discriminator", "Email", "PhoneNumber", "Username", "Website" },
                values: new object[] { "f4c6aaf7-efd3-4905-859b-cb2f33c2e476", "Admin", null, "Admin", "Employer", "cvlookup.sgu.2023_employer@gmail.com", null, "Employer Admin", null });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Avatar", "Discriminator", "Email", "PhoneNumber", "Username" },
                values: new object[] { "a668be26-29c9-4653-a601-5faf023b5d73", null, "User", "cvlookup.sgu.2023@gmail.com", null, "General Admin" });

            migrationBuilder.InsertData(
                table: "AccountUser",
                columns: new[] { "AccountId", "UserId" },
                values: new object[,]
                {
                    { "a58fa60e-2978-49c7-926d-c62fa9dabb1b", "f4c6aaf7-efd3-4905-859b-cb2f33c2e476" },
                    { "cf10c7b2-13a3-4307-875e-bb3d901bee9d", "e0c47a58-7731-4f26-8ff9-2b899b3019bc" },
                    { "f2c45b04-9bec-4296-b76c-7d15bd5b45a9", "a668be26-29c9-4653-a601-5faf023b5d73" }
                });

            migrationBuilder.InsertData(
                table: "District",
                columns: new[] { "Id", "Name", "ProvinceId" },
                values: new object[,]
                {
                    { "026a6f54-f106-4501-bac7-80737ae1d4c5", "Quận Tây Hồ", "0f825303-629c-485a-b9ed-c4d209fce825" },
                    { "0c0a725d-1f40-4949-bb10-7322649c7791", "Quận Hoàng Mai", "0f825303-629c-485a-b9ed-c4d209fce825" },
                    { "0f2ac003-70dd-447e-aeb3-32caf5152f20", "Quận Cầu Giấy", "0f825303-629c-485a-b9ed-c4d209fce825" },
                    { "1b896913-5e7d-4375-8c81-49e8086f53df", "Quận 10", "116bacfc-2a58-43fa-abfe-7ec2b4bd0def" },
                    { "21a5c094-8784-4d24-a971-7680ca5d7b25", "Quận Bắc Từ Liêm", "0f825303-629c-485a-b9ed-c4d209fce825" },
                    { "23410ceb-bc05-48c3-9ac4-ba4cefa35632", "Quận Nam Từ Liêm", "0f825303-629c-485a-b9ed-c4d209fce825" },
                    { "2407872f-d053-4802-9dca-a251995748ab", "Quận 12", "116bacfc-2a58-43fa-abfe-7ec2b4bd0def" },
                    { "25f0ae60-aefe-4f7a-b8ef-84c5e0f1b41f", "Quận Bình Tân", "116bacfc-2a58-43fa-abfe-7ec2b4bd0def" },
                    { "3606ff8d-f9dd-44ac-845c-0c5a8292a8a8", "Quận Kiến An", "26fcc20d-7719-405b-963e-9b68fa39f239" },
                    { "3729cdb9-2361-4b55-a8f7-f9c1288c85c1", "Quận Liên Chiểu", "1aee2487-14cb-4ce6-8c4a-4cd16f8129b8" },
                    { "37dc9eb7-6400-4e8f-8f13-aa982fa97f27", "Quận 6", "116bacfc-2a58-43fa-abfe-7ec2b4bd0def" },
                    { "474e5b08-48eb-48bf-bae7-3c212da730f4", "Tất cả", "0fe7d819-ec08-4f9e-8666-68ecd6fb6fed" },
                    { "5f7e7425-482b-4b67-9498-1633f1f7b27b", "Quận Ngũ Hành Sơn", "1aee2487-14cb-4ce6-8c4a-4cd16f8129b8" },
                    { "61d0fad5-4b42-4344-9ad8-8fd7e0f53b97", "Quận 7", "116bacfc-2a58-43fa-abfe-7ec2b4bd0def" },
                    { "6291821c-b8b8-44d7-bc05-c1f76250a45a", "Tất cả", "116bacfc-2a58-43fa-abfe-7ec2b4bd0def" },
                    { "76ff1ef9-f688-491d-aa4a-a1e800de92b2", "Quận Lê Chân", "26fcc20d-7719-405b-963e-9b68fa39f239" },
                    { "771d2328-956e-48af-bb23-3df216e50d54", "Quận Thanh Khê", "1aee2487-14cb-4ce6-8c4a-4cd16f8129b8" },
                    { "77dd1540-84fa-4275-8016-353df65f5889", "Quận Tân Phú", "116bacfc-2a58-43fa-abfe-7ec2b4bd0def" },
                    { "7a637600-1295-4964-a042-59b0efa67f90", "Quận Ninh Kiều", "0fe7d819-ec08-4f9e-8666-68ecd6fb6fed" },
                    { "7b97df54-b2a0-48e0-a93b-d6407bf19cb0", "Quận Sơn Trà", "1aee2487-14cb-4ce6-8c4a-4cd16f8129b8" },
                    { "7ca7140a-7410-4f86-b8f5-1a5e940bca9c", "Quận Hải An", "26fcc20d-7719-405b-963e-9b68fa39f239" },
                    { "8355d50d-9201-4b00-87d3-2067154714e3", "Quận Phú Nhuận", "116bacfc-2a58-43fa-abfe-7ec2b4bd0def" },
                    { "84c1fcd2-c60d-462d-92f7-2dc85ace5e0c", "Quận Ngô Quyền", "26fcc20d-7719-405b-963e-9b68fa39f239" },
                    { "8ae94861-ba01-4285-8ac4-ebd8fd68eae3", "Quận 5", "116bacfc-2a58-43fa-abfe-7ec2b4bd0def" },
                    { "8c5aeaf6-1842-4a73-ad33-f6a6794696ec", "Quận Hà Đông", "0f825303-629c-485a-b9ed-c4d209fce825" },
                    { "95464e1a-fe23-4d92-9b60-9927c4da1826", "Quận 11", "116bacfc-2a58-43fa-abfe-7ec2b4bd0def" },
                    { "9781e632-6fd7-415f-b4e7-0a34a1d37372", "Tất cả", "26fcc20d-7719-405b-963e-9b68fa39f239" },
                    { "97a3e7a2-ea86-4f30-8484-8e61ea147cca", "Quận Thủ Đức", "116bacfc-2a58-43fa-abfe-7ec2b4bd0def" },
                    { "9e0b36f4-41aa-495f-8d74-8ac6e4117beb", "Quận 1", "116bacfc-2a58-43fa-abfe-7ec2b4bd0def" },
                    { "a048e95f-0363-42eb-974e-0294a30341d6", "Quận Thanh Xuân", "0f825303-629c-485a-b9ed-c4d209fce825" },
                    { "a05cb0cb-d331-47ad-9450-5fe37e327103", "Quận Tân Bình", "116bacfc-2a58-43fa-abfe-7ec2b4bd0def" },
                    { "a06e16e3-e294-4a97-b4a5-8cab03f36ea9", "Quận Hoàn Kiếm", "0f825303-629c-485a-b9ed-c4d209fce825" },
                    { "a2a34d97-41ba-4a51-bc91-418c72742079", "Quận Gò Vấp", "116bacfc-2a58-43fa-abfe-7ec2b4bd0def" },
                    { "a5b7ff19-f454-4b2a-b5a7-669359745029", "Quận Hồng Bàng", "26fcc20d-7719-405b-963e-9b68fa39f239" },
                    { "b8bcf9aa-5900-4294-ac6a-8c1654118152", "Quận Bình Thạnh", "116bacfc-2a58-43fa-abfe-7ec2b4bd0def" },
                    { "ba1c0460-bf4e-44be-be13-a93c0b63bb5a", "Quận Hai Bà Trưng", "0f825303-629c-485a-b9ed-c4d209fce825" },
                    { "bd1882f7-ab0a-4d48-8579-62d6d143de98", "Quận 4", "116bacfc-2a58-43fa-abfe-7ec2b4bd0def" },
                    { "c153c81c-f254-438c-83be-7c87d7f4c700", "Quận Bình Thuỷ", "0fe7d819-ec08-4f9e-8666-68ecd6fb6fed" },
                    { "c311b47d-251a-4047-80be-f3be75312826", "Quận Ba Đình", "0f825303-629c-485a-b9ed-c4d209fce825" }
                });

            migrationBuilder.InsertData(
                table: "District",
                columns: new[] { "Id", "Name", "ProvinceId" },
                values: new object[,]
                {
                    { "c3cbffa1-fb88-4761-9688-6102d37cd014", "Quận 9", "116bacfc-2a58-43fa-abfe-7ec2b4bd0def" },
                    { "c4556d30-01a7-4c23-b93e-4b37373e289a", "Quận Thốt Nốt", "0fe7d819-ec08-4f9e-8666-68ecd6fb6fed" },
                    { "c8456d7c-62e9-464c-83a6-b76a60e7fc86", "Quận Long Biên", "0f825303-629c-485a-b9ed-c4d209fce825" },
                    { "cb153c34-7edb-4419-bb5f-8c9805c4070e", "Quận 2", "116bacfc-2a58-43fa-abfe-7ec2b4bd0def" },
                    { "cfd87279-7a51-4741-9da5-7370913efe11", "Quận Đống Đa", "0f825303-629c-485a-b9ed-c4d209fce825" },
                    { "d817db7e-0e5b-49d3-a55c-d31a1095d6c1", "Quận Cái Răng", "0fe7d819-ec08-4f9e-8666-68ecd6fb6fed" },
                    { "db9ca9f8-6325-48d2-97c2-5a38c5e8eb6b", "Quận Ô Môn", "0fe7d819-ec08-4f9e-8666-68ecd6fb6fed" },
                    { "dfebbafd-a2f4-49c4-928f-f7900dc5329a", "Tất cả", "1aee2487-14cb-4ce6-8c4a-4cd16f8129b8" },
                    { "e56f31e5-76d6-4a3b-bd96-4dc189b7c8e7", "Quận Hải Châu", "1aee2487-14cb-4ce6-8c4a-4cd16f8129b8" },
                    { "ea055f4b-4a85-4c3a-a801-db50b18b6d11", "Quận 8", "116bacfc-2a58-43fa-abfe-7ec2b4bd0def" },
                    { "eb55a600-539a-42ba-a139-6c89442fe89e", "Quận Cẩm Lệ", "1aee2487-14cb-4ce6-8c4a-4cd16f8129b8" },
                    { "ec543696-b991-4bdc-8dc8-be84885fce1f", "Quận 3", "116bacfc-2a58-43fa-abfe-7ec2b4bd0def" },
                    { "ef419af0-ee2d-494d-89cc-8846f53121fd", "Quận Dương Kinh", "26fcc20d-7719-405b-963e-9b68fa39f239" },
                    { "f7eaff30-d110-4ebb-907e-05bf8497c5c2", "Quận Đồ Sơn", "26fcc20d-7719-405b-963e-9b68fa39f239" },
                    { "ff0a0d98-c392-4c04-ac0d-cb313f84569a", "Tất cả", "0f825303-629c-485a-b9ed-c4d209fce825" }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "a0408ef1-b79a-4bb2-b4bd-d0995e215126", "a668be26-29c9-4653-a601-5faf023b5d73" },
                    { "c2747ae0-6246-47a3-9c63-950ebd356415", "f4c6aaf7-efd3-4905-859b-cb2f33c2e476" },
                    { "e3b83463-1367-4405-8dc0-8176fb5a566b", "e0c47a58-7731-4f26-8ff9-2b899b3019bc" }
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
