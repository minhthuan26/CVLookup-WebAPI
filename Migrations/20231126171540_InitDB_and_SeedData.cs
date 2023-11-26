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
                    { "65d8823a-500d-4fb5-a11e-74d18c1b9835", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cvlookup.sgu.2023_employer@gmail.com", new DateTime(2023, 11, 27, 0, 15, 39, 555, DateTimeKind.Local).AddTicks(5583), "4EvS5r40usEAzXH5nw6YyjfVVpQdHt7K+e7DBWXhKPKdrduCQ6W3M3Ala03/Tw8kFhLEGxHwealuxejQLZqg0y4nsngohze7rnldfpPHQ1Y=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "6950c3a7-bdaf-4707-b82e-3552e49b8873", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cvlookup.sgu.2023@gmail.com", new DateTime(2023, 11, 27, 0, 15, 39, 555, DateTimeKind.Local).AddTicks(5561), "4EvS5r40usEAzXH5nw6YyjfVVpQdHt7K+e7DBWXhKPKdrduCQ6W3M3Ala03/Tw8kFhLEGxHwealuxejQLZqg0y4nsngohze7rnldfpPHQ1Y=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "88a493ac-8476-428f-a215-4fcadc579562", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cvlookup.sgu.2023_candidate@gmail.com", new DateTime(2023, 11, 27, 0, 15, 39, 555, DateTimeKind.Local).AddTicks(5590), "4EvS5r40usEAzXH5nw6YyjfVVpQdHt7K+e7DBWXhKPKdrduCQ6W3M3Ala03/Tw8kFhLEGxHwealuxejQLZqg0y4nsngohze7rnldfpPHQ1Y=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Experience",
                columns: new[] { "Id", "Exp" },
                values: new object[,]
                {
                    { "0fb1de22-a100-4d25-86c7-b8028cb85ad6", "Từ 5-10 năm" },
                    { "1c251e95-42b9-4306-a1cc-ed27725c26e2", "Từ 1-2 năm" },
                    { "343637d0-4f65-4f9e-a1b4-bb7e1e550171", "Từ 2-3 năm" },
                    { "7412d9ac-597f-4888-8ad3-5b771f8084e0", "Từ 3-5 năm" },
                    { "81f4f99e-7e2b-4189-ac98-a14ea72991a8", "Tất cả kinh nghiệm" },
                    { "870a7f61-7c87-4a44-8d46-c314243d702b", "Dưới 1 năm" },
                    { "897083f0-ba76-41c3-b3c0-fb3246a719bd", "Chưa có kinh nghiệm" },
                    { "b9083246-a65f-4eb6-b1b7-aecd57575167", "Trên 10 năm" }
                });

            migrationBuilder.InsertData(
                table: "JobCareer",
                columns: new[] { "Id", "Career" },
                values: new object[,]
                {
                    { "058d2083-9bfc-4bb3-a9f8-a2f084434e70", "Công nghệ cao" },
                    { "0850655c-0e36-485c-a49e-5d93d776854c", "Thời trang" },
                    { "09bc6852-2b68-4a6e-af2d-964a4750bc2a", "An toàn lao động" },
                    { "0af6bad8-64d4-459b-9296-946065ed7c35", "Marketing / Truyền thông / Quảng cáo" },
                    { "1448c211-a161-4f33-bbce-0d08e75d35eb", "Địa chất / Khoáng sản" },
                    { "14b3bbcd-cfb1-45dd-af3c-5820a08c186c", "Dầu khí/Hóa chất" },
                    { "2082fcec-91f4-4f7d-ae4a-7dc06141ece5", "Dệt may / Da giày" },
                    { "24316135-243d-4dd8-b498-bf69e75c6130", "Mỹ phẩm / Trang sức" },
                    { "27081b59-b0eb-4ec3-b623-1459aa1dc4fa", "Thực phẩm / Đồ uống" },
                    { "2d06eac8-6049-4d28-ae51-caa1a62d6bd2", "Thiết kế đồ họa" },
                    { "305eeb8d-f7d7-4068-8076-9949c7aaa966", "Vận tải / Kho vận" },
                    { "33a6e107-d5c8-4a8e-9460-79207a72a6ce", "Kinh doanh / Bán hàng" },
                    { "44ab5385-37f9-4b86-b925-44d3a8c80aad", "Tổ chức sự kiện / Quà tặng" },
                    { "4504d132-3bb0-4d7e-8b5a-5888fb237ec6", "Dược phẩm / Công nghệ sinh học" },
                    { "45e9a9b5-762b-4e3c-8157-8f8b1a38dc6d", "Khách sạn / Nhà hàng" },
                    { "4b5907f5-5357-48f4-bdc5-1f5363414f7b", "Tư vấn" },
                    { "4c57a2d7-e563-419d-8209-4d2f137390d3", "Dịch vụ khách hàng" },
                    { "4d4785dc-b620-4d4a-97ff-7d9c4c37390d", "Báo chí / Truyền hình" },
                    { "4df06b41-aa07-4827-94b9-c30fe917dc75", "IT Phần cứng / Mạng" },
                    { "50316baf-8ba5-47d7-919e-1c88cc352a6f", "Hành chính / Văn phòng" },
                    { "577086af-1edd-4b33-aa9a-62e68f92790b", "In ấn / Xuất bản" },
                    { "5d448df0-58f4-40c4-9521-e7ef65c05219", "Thư ký / Trợ lý" },
                    { "5e2a4c0a-ef8d-4a8f-b5f7-5c79b7bdfc26", "Hoá học / Sinh học" },
                    { "63b4b0b7-4b10-47b0-ab8c-c90fbd391ef4", "Công nghệ thông tin" },
                    { "66621e21-9141-4320-aebd-bbbbf021d79d", "Nông / Lâm / Ngư nghiệp" },
                    { "6be2d285-531f-4c48-a419-e883c5a46d66", "Điện / Điện tử / Điện lạnh" },
                    { "6d321586-ede3-4e92-a2eb-0388b2645ecf", "Kế toán / Kiểm toán" },
                    { "76b39c84-779a-48c4-8459-a5c6567f28c7", "Logistics" },
                    { "8432c08b-30de-48bf-b77d-244f348c2940", "Spa / Làm đẹp" },
                    { "8498457c-1ec9-4917-820d-62b4a28f1ee7", "Y tế / Dược" },
                    { "8b1fec4d-6468-45cc-be15-fc0b288c11ba", "Hàng hải" }
                });

            migrationBuilder.InsertData(
                table: "JobCareer",
                columns: new[] { "Id", "Career" },
                values: new object[,]
                {
                    { "91d080bc-c1d3-4b61-944d-08dd147ef8bf", "Quản lý điều hành" },
                    { "93f35967-671f-4a5c-83a6-e29e46bcd138", "Biên / Phiên dịch" },
                    { "97fb7a1b-15d5-4046-b355-20907cfd1155", "Sản xuất" },
                    { "99767e1e-2ff2-4b81-a1f1-6e69ccb7cd12", "Điện tử viễn thông" },
                    { "9a1fc361-ce61-45a6-b5e9-d87930452aae", "Ngành nghề khác" },
                    { "9e3e33e1-d52f-486b-a690-48970ba1cd29", "Xây dựng" },
                    { "a3fb7bd7-eb1d-461c-8b6f-f0eafd458f03", "Phi chính phủ / Phi lợi nhuận" },
                    { "a5baa96b-830d-4ef3-96e4-3adf10da4680", "Công nghệ Ô tô" },
                    { "ac4c3471-2e87-4bb9-8457-deec023fff6e", "Sản phẩm công nghiệp" },
                    { "ad1d3fb6-2fc6-42c6-9a18-41b55e0d3e21", "Thiết kế nội thất" },
                    { "adb006ad-012d-4356-b05d-edce497d0db4", "Du lịch" },
                    { "aed231d4-a1fb-4cec-bb48-ed6789257b61", "Hàng không" },
                    { "b17435e1-0a07-4de5-9336-27a0aef7b820", "Bán lẻ / bán sỉ" },
                    { "b1b2c349-602b-4aec-9807-8023c2bb26b3", "Nhân sự" },
                    { "b2df99a4-31ca-4127-8c22-0de1ff75cc53", "Giáo dục / Đào tạo" },
                    { "b5786243-e462-4d16-910e-4abcd6bd7fa1", "IT phần mềm" },
                    { "b6b0e7cd-bb74-4dc7-b4b1-592821994186", "Hàng gia dụng" },
                    { "b8d53260-ab39-470c-8a77-b330a18d363b", "Tất cả ngành nghề" },
                    { "c1907d5b-c89e-40a6-8a6c-9229fb3cdb63", "Môi trường / Xử lý chất thải" },
                    { "cc56b102-5eef-41bf-af26-7010e4ddf293", "Hàng tiêu dùng" },
                    { "cf080354-21a5-4f1c-b5ea-b8417daba8bc", "Luật / Pháp lý" },
                    { "d651f203-3fb3-42e2-be0c-eb34de91ff90", "Hàng cao cấp" },
                    { "d7d45e26-2c01-41e8-bbf4-6ea0f1938603", "Ngân hàng / Tài chính" },
                    { "d7f6468e-74c7-437b-b534-ff308974acf6", "Bảo trì / Sửa chữa" },
                    { "da209b69-ab0b-468f-a567-e44343567591", "Bưu chính - Viễn thông" },
                    { "db97a057-ce15-4bba-8128-e0e18b9fef65", "Bất động sản" },
                    { "dd8fcdbd-55db-4a6a-a5cb-3aecc8234e82", "Hoạch định / Dự án" },
                    { "ddee634a-e4f6-4e21-b7de-4f460e2b7578", "Quản lý chất lượng (QA/QC)" },
                    { "e3e6508d-5844-4bbe-9adb-e2fd9fc4bab0", "Xuất nhập khẩu" },
                    { "e4a6d004-5665-48ad-8756-0cfef80574b0", "Tài chính / Đầu tư" },
                    { "e8c66dfe-9e85-4c78-8478-d373c37cfdae", "Chứng khoán / Vàng / Ngoại tệ" },
                    { "eecde4d3-d393-4829-b16c-ababfc8ba8d4", "Bảo hiểm" },
                    { "f48bd8c0-e5a4-4257-9dec-04a45cf0209b", "Cơ khí / Chế tạo / Tự động hóa" },
                    { "f8654da2-87d9-47b5-a1b3-db1451fd5381", "Kiến trúc" },
                    { "f982f596-468a-47a3-9a7f-6997a61edfed", "Bán hàng kỹ thuật" },
                    { "fe5eb19f-a401-4f32-8c71-d9b6969a1503", "Mỹ thuật / Nghệ thuật / Điện ảnh" },
                    { "ff5eedd0-c949-4e94-a877-daf39ec8a499", "NGO / Phi chính phủ / Phi lợi nhuận" }
                });

            migrationBuilder.InsertData(
                table: "JobField",
                columns: new[] { "Id", "Field" },
                values: new object[,]
                {
                    { "0b4e0b5c-5121-47fb-9e5c-221758933469", "Môi trường" },
                    { "0e0254ee-aeb4-44ec-9696-16084a0e9f53", "Xây dựng" },
                    { "16467283-5a9a-4fb6-bf0f-8fcfe4ff9070", "Bán lẻ - Hàng tiêu dùng - FMCG" },
                    { "196e0ed2-90bb-4e14-8723-cc3ee83c337f", "Ngân hàng" },
                    { "1b12ecbb-7066-4d8a-a751-51969c8f8a4c", "Chứng khoán" }
                });

            migrationBuilder.InsertData(
                table: "JobField",
                columns: new[] { "Id", "Field" },
                values: new object[,]
                {
                    { "1c39d7c0-7740-436a-8e1e-8f57992d9cf5", "Kế toán / Kiểm toán" },
                    { "2b4ae289-4253-454e-88a9-5727044c7b41", "Năng lượng" },
                    { "3097178b-9b77-40ab-a970-e669ddc21f6f", "In ấn / Xuất bản" },
                    { "3119fcb8-3f24-467b-9eb0-a4085f56c154", "Nông Lâm Ngư nghiệp" },
                    { "3a5e2827-adf7-4b78-b673-a85115faa2c5", "Internet / Online" },
                    { "3dee51e1-3935-4480-b4ca-7b387f92d68d", "IT - Phần mềm" },
                    { "403ab6c4-067f-4673-821e-132f4d125f06", "Điện tử / Điện lạnh" },
                    { "460f8b53-8df0-4942-a1df-71d64f135d49", "Du lịch" },
                    { "4d058ff1-6b0d-41d5-8394-16291c311040", "Tất cả lĩnh vực" },
                    { "6405bee6-27a6-491f-afd4-03f0b24100ae", "Agency (Design/Development)" },
                    { "6fc9c479-6a5f-4c76-8b26-ecbd00d1adb3", "Sản xuất" },
                    { "7c20fb88-257d-4836-b50d-67bb891874dd", "Dược phẩm / Y tế / Công nghệ sinh học" },
                    { "7fb0fbfb-530f-4a13-ae92-edfbb8e4c825", "Khác" },
                    { "87fb7eab-366c-4294-85bf-98add7e635b8", "Xuất nhập khẩu" },
                    { "8bbe0cdd-ae78-44de-a588-44cf47677a38", "Viễn thông" },
                    { "90968ca1-c6ea-48a5-80a3-60f4f6a9c7ae", "Agency (Marketing/Advertising)" },
                    { "97de81c1-7f33-499c-93b9-d43118de1f40", "Nhà hàng / Khách sạn" },
                    { "9ca33a99-3f6b-447e-97df-2f47341e1201", "Bất động sản" },
                    { "a4d6f66c-6a26-46c7-8cac-522b7fa06d26", "Tài chính" },
                    { "ae57eca1-be9f-45f3-84f2-7f530950180f", "Giải trí" },
                    { "c00d7080-07f0-49b7-a9aa-bb920cb109c0", "Thời trang" },
                    { "c17a6fee-efdc-4b1d-a77f-25f61e431576", "Cơ quan nhà nước" },
                    { "c8bd3541-a8c2-4ac9-94be-ea0c7fda5506", "Tư vấn" },
                    { "d4f3d15a-0731-4a66-94f6-3bf9e5497c8d", "Logistics - Vận tải" },
                    { "d88d3f40-dd30-42fd-bbfb-4cdd6fdcde23", "Bảo hiểm" },
                    { "dadd9b58-91ac-4480-bbd6-ec33e72b6d00", "Giáo dục / Đào tạo" },
                    { "dd48335b-b20b-4d95-9479-2f97eb02f9ac", "Tổ chức phi lợi nhuận" },
                    { "e2f2cb31-488f-4570-8c25-a9b4e3a26ee8", "Cơ khí" },
                    { "e4c6958b-ff28-40ac-8fdb-d851596e4dce", "IT - Phần cứng" },
                    { "e5eb003b-8ca3-48d1-8e5a-52a7576730ff", "Nhân sự" },
                    { "e851acae-842f-450b-bf6e-58df98fe6a53", "Thương mại điện tử" },
                    { "ec98a852-5580-4510-aead-84965d24a79b", "Tự động hóa" },
                    { "ecc76aaf-b2bd-4f0e-b27a-eacaebb2dcc1", "Thiết kế / kiến trúc" },
                    { "ede393d6-5cb6-4d49-be0f-9f551cc94224", "Marketing / Truyền thông / Quảng cáo" },
                    { "f5842d78-9178-461d-a834-425187a28c4f", "Luật" },
                    { "f9b3cc75-08d7-4e55-8b40-2a022d4673dc", "Bảo trì / Sửa chữa" }
                });

            migrationBuilder.InsertData(
                table: "JobForm",
                columns: new[] { "Id", "Form" },
                values: new object[,]
                {
                    { "28515a37-5a92-49cb-ae02-824f17b0f957", "Thực tập" },
                    { "35cb530f-2487-4452-b8aa-e32a0aeaaeb6", "Bán thời gian" },
                    { "435afa33-9dfe-47f6-9ac1-e97247b7d0c0", "Tất cả hình thức" },
                    { "8978049e-1228-45f4-9a41-7ed389cf2c5d", "Toàn thời gian" }
                });

            migrationBuilder.InsertData(
                table: "JobPosition",
                columns: new[] { "Id", "Position" },
                values: new object[,]
                {
                    { "2e48f89f-d149-483b-aa99-d15f91165f98", "Phó giám đốc" },
                    { "3c73c609-f04b-4aa6-bec0-80d5f7f07dc8", "Trưởng / Phó phòng" }
                });

            migrationBuilder.InsertData(
                table: "JobPosition",
                columns: new[] { "Id", "Position" },
                values: new object[,]
                {
                    { "40383783-7105-4b06-a2ba-1d712d12510b", "Quản lí / Giám sát" },
                    { "6407467b-1763-400b-98d6-90ff4391f282", "Tất cả vị trí" },
                    { "78a99036-ee33-42c8-bac4-f1c846d71d0a", "Thực tập sinh" },
                    { "8d425f14-7524-4ec9-a761-6e167b5ca445", "Trưởng nhóm" },
                    { "a5360fff-66a9-4731-874c-08387b893064", "Nhân viên" },
                    { "c873b724-f489-4e22-9135-b8b0378f8bd9", "Trưởng chi nhánh" },
                    { "e4228cfa-1a63-4bf4-8c0a-a760eb83f6fa", "Giám đốc" }
                });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "0a44d94d-5126-497a-9a15-1b9eb7ae4033", "Hải Phòng" },
                    { "0e377b15-5634-4b17-9949-5dac34527752", "Yên Bái" },
                    { "0e3f219e-0571-44d5-b310-de0911297702", "Quảng Nam" },
                    { "1614c8c7-80c7-4898-9c34-580faabefb11", "Tuyên Quang" },
                    { "18469721-1713-485c-b72b-17d59e3d5ce8", "Sơn La" },
                    { "1cf0162a-7c84-45a9-883b-40a0887f7d2b", "Quảng Ninh" },
                    { "1f779bd3-33a2-4f5d-900d-789040e9c0a8", "Điện Biên" },
                    { "295cf0d7-88bf-43b2-9e0d-00c5379d1bc6", "Đắk Lắk" },
                    { "336a8fef-8473-4cf1-aa17-b005c01a951c", "Hà Tĩnh" },
                    { "3494621d-3ffe-4176-89a0-8fe48744d743", "Bà Rịa-Vũng Tàu" },
                    { "34ab2b90-630e-49ce-8631-a9ba6dafa55c", "Kiên Giang" },
                    { "360532ba-0360-479c-8610-3fa340edd9ff", "Hà Giang" },
                    { "3666c38e-b9c3-4958-b1e0-3de2ed665acd", "Bình Dương" },
                    { "36c36160-8e85-4059-a8dc-550c4b315fad", "Đồng Tháp" },
                    { "37a37d85-dca7-4990-ae28-f126ad048f86", "Lâm Đồng" },
                    { "3be0d3b7-6ba7-4db5-b049-d83b3c950703", "Hòa Bình" },
                    { "40d97793-1280-4ff4-af42-dbaa63bbb78a", "Cần Thơ" },
                    { "4128facf-b9ef-4357-b4af-bcecfafb6f72", "Quảng Ngãi" },
                    { "4fb8b7e8-c2eb-4486-9beb-5b1c2b406211", "Tây Ninh" },
                    { "50b7248e-84b5-4940-889d-7b842149b5ca", "Lào Cai" },
                    { "57b0eeeb-16e6-4dfa-b435-6d8c51796499", "Hải Dương" },
                    { "585f1549-b5c4-4688-8465-2f319c212e7f", "Phú Yên" },
                    { "65d2392f-6f7e-4711-a741-bd6d30ff0eb3", "Quảng Trị" },
                    { "6a7ace3f-5043-4e42-95bd-d9e1ea8dc012", "Quảng Bình" },
                    { "6f41745b-b2be-4ca7-818a-fa4551d355c3", "Tất cả tỉnh thành" },
                    { "7030c390-78eb-4fb0-85e4-78f72a8a4942", "Hưng Yên" },
                    { "709eb242-f707-4599-bd61-a634fe224eb3", "Hồ Chí Minh" },
                    { "773a8556-d411-4606-9fd5-abbf1f575700", "Bình Định" },
                    { "78352aab-f2bc-4b22-aebd-78de7e183fd5", "Lai Châu" },
                    { "7ce3f655-95eb-434c-8a5f-4782f4fce8d4", "Khánh Hòa" },
                    { "7cf61ec2-4222-4bbd-86e3-88ce3309cea0", "Hậu Giang" },
                    { "7d86e9c9-50f9-4e41-8204-11324399b439", "Lạng Sơn" },
                    { "7e1a444a-495e-4c7b-a059-b1a2e5576b79", "Phú Thọ" },
                    { "804d883c-e47e-4b99-9957-28d4cf8301b5", "Kon Tum" },
                    { "84558f82-4228-40c6-95cf-8fe498e97e24", "Ninh Bình" }
                });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "845a84cd-8948-40d5-9a4b-d8dd4215032d", "Trà Vinh" },
                    { "95bb8e7b-2d8e-44ec-90ac-e3de5cad5295", "Sóc Trăng" },
                    { "9c41f9c3-c12d-4fb2-a35a-9e715dec71b9", "Nghệ An" },
                    { "9f3c6d42-5e6c-4f72-8c3f-cfbf172ff8e7", "Hà Nội" },
                    { "a5ebf213-a7c8-441b-9eea-06c66de51948", "Thừa Thiên Huế" },
                    { "a60ecf15-df05-4643-844b-dc9362807cc7", "Bạc Liêu" },
                    { "a649e66b-62c3-47e8-86e9-908a7cf7fd90", "Bình Thuận" },
                    { "b407eb9c-b5cb-457d-85b7-619c03bd990e", "Long An" },
                    { "ba58e344-4d96-4b01-ac55-01d0cd3064c8", "Đà Nẵng" },
                    { "bebd7034-5e85-4d44-9094-1e75c7ddba50", "Bắc Giang" },
                    { "c144a8da-1d8e-4380-b75b-e6e7d3b78853", "Hà Nam" },
                    { "c220a857-b2d2-45b6-9c1b-64847c076c4e", "Cà Mau" },
                    { "c2faf2dc-1c33-4fc2-afff-c1719fd92855", "Bến Tre" },
                    { "c88dddba-d1e5-4487-a295-d1836480d737", "An Giang" },
                    { "cd9fff15-971a-46a9-8bbc-e1e54512d076", "Thái Bình" },
                    { "d09f859f-f70f-4a42-87e6-0ac50119aa47", "Đắk Nông" },
                    { "d579a785-c892-432c-9b69-b13c80476b4d", "Cao Bằng" },
                    { "da65b920-0d53-469b-91c7-04dc98400f41", "Nam Định" },
                    { "db9136d2-a760-44b0-97a1-5e6f650baa18", "Vĩnh Phúc" },
                    { "e3c99ee6-d007-4557-8182-517040cc149c", "Bắc Ninh" },
                    { "e629b288-a63a-4987-bd0d-83efaaf2a273", "Vĩnh Long" },
                    { "e62d5fda-8c56-404a-b7bf-e33588dbc437", "Bắc Kạn" },
                    { "ea602b11-0724-4475-9102-92d186e1c100", "Thanh Hóa" },
                    { "ee8cd878-e9c6-45d3-b82f-0622805f0ea6", "Thái Nguyên" },
                    { "f5903892-dc9e-4130-af11-988fcbf1b1ab", "Ninh Thuận" },
                    { "f68fb9ce-dec0-4c34-8e5c-6961f4ba6390", "Bình Phước" },
                    { "f6da29e8-b36f-43d0-a5bd-3091111b6650", "Tiền Giang" },
                    { "f7442689-88c8-4e2d-b089-189bfac7d6d9", "Gia Lai" },
                    { "f8356977-7bf8-4fe5-9b07-894982e7153d", "Đồng Nai" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { "48f576de-5eef-456a-b5fe-69ac4f92554c", "Admin" },
                    { "b9cfceac-2ad8-4ec1-be6d-f918581c0fd2", "Employer" },
                    { "c9444742-e347-41e1-9ae4-8f48a6b14c57", "Candidate" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Avatar", "DateOfBirth", "Discriminator", "Email", "PhoneNumber", "Username" },
                values: new object[] { "4e7ae74e-c16a-416e-84eb-fc5e4ea56e99", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Candidate", "cvlookup.sgu.2023_candidate@gmail.com", null, "Candidate Admin" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Address", "Avatar", "Description", "Discriminator", "Email", "PhoneNumber", "Username", "Website" },
                values: new object[] { "c77e84e2-5825-4331-bcc3-ae9d07a9c936", "Admin", null, "Admin", "Employer", "cvlookup.sgu.2023_employer@gmail.com", null, "Employer Admin", null });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Avatar", "Discriminator", "Email", "PhoneNumber", "Username" },
                values: new object[] { "6d74548c-27df-47ae-a4dc-d09be267528d", null, "User", "cvlookup.sgu.2023@gmail.com", null, "General Admin" });

            migrationBuilder.InsertData(
                table: "AccountUser",
                columns: new[] { "AccountId", "UserId" },
                values: new object[,]
                {
                    { "65d8823a-500d-4fb5-a11e-74d18c1b9835", "c77e84e2-5825-4331-bcc3-ae9d07a9c936" },
                    { "6950c3a7-bdaf-4707-b82e-3552e49b8873", "6d74548c-27df-47ae-a4dc-d09be267528d" },
                    { "88a493ac-8476-428f-a215-4fcadc579562", "4e7ae74e-c16a-416e-84eb-fc5e4ea56e99" }
                });

            migrationBuilder.InsertData(
                table: "District",
                columns: new[] { "Id", "Name", "ProvinceId" },
                values: new object[,]
                {
                    { "06cbb69f-847b-4979-adf2-f85511ad1963", "Quận Hồng Bàng", "0a44d94d-5126-497a-9a15-1b9eb7ae4033" },
                    { "0ee40390-6191-4262-929e-91bd9445559c", "Quận 8", "709eb242-f707-4599-bd61-a634fe224eb3" },
                    { "1274daca-4414-4e9f-88fe-c2e6f8014bc3", "Quận Nam Từ Liêm", "9f3c6d42-5e6c-4f72-8c3f-cfbf172ff8e7" },
                    { "1662b0cf-4b29-44c7-b856-57ff183db8cc", "Quận Cẩm Lệ", "ba58e344-4d96-4b01-ac55-01d0cd3064c8" },
                    { "172973d3-5fca-46a3-82a1-e1019a79520b", "Quận Tân Phú", "709eb242-f707-4599-bd61-a634fe224eb3" },
                    { "187795cd-7117-44fe-ae9e-afa3b5089bcf", "Quận Ngô Quyền", "0a44d94d-5126-497a-9a15-1b9eb7ae4033" },
                    { "25106b52-cdc0-43d7-8f91-07f94ad6b887", "Quận 11", "709eb242-f707-4599-bd61-a634fe224eb3" },
                    { "2d82c9ae-f102-427a-a898-af7e75b023e4", "Quận Hoàng Mai", "9f3c6d42-5e6c-4f72-8c3f-cfbf172ff8e7" },
                    { "33b2f8c5-e593-4f05-9e2f-40ad12c468d8", "Quận Đống Đa", "9f3c6d42-5e6c-4f72-8c3f-cfbf172ff8e7" },
                    { "35941f6e-230a-4f34-9e36-45ef26be30d6", "Quận Cầu Giấy", "9f3c6d42-5e6c-4f72-8c3f-cfbf172ff8e7" },
                    { "3a28c0f1-3854-416d-a41d-1fa1276e0aa8", "Quận Ba Đình", "9f3c6d42-5e6c-4f72-8c3f-cfbf172ff8e7" },
                    { "3e419b48-2e64-4516-a088-966d183e8ddf", "Quận Liên Chiểu", "ba58e344-4d96-4b01-ac55-01d0cd3064c8" },
                    { "424b6f28-9f94-49dc-9908-9fe52d86680a", "Quận Phú Nhuận", "709eb242-f707-4599-bd61-a634fe224eb3" },
                    { "47830223-36e0-4999-9a36-ebd2eec959ec", "Quận Tây Hồ", "9f3c6d42-5e6c-4f72-8c3f-cfbf172ff8e7" },
                    { "4b3173b1-a58a-42c4-bffc-1539a174c49e", "Quận Sơn Trà", "ba58e344-4d96-4b01-ac55-01d0cd3064c8" },
                    { "4cce3222-b952-4775-8ff9-961742e9b5a3", "Quận 1", "709eb242-f707-4599-bd61-a634fe224eb3" },
                    { "52d62e00-fdbc-4164-a012-368aa53db41d", "Quận Thanh Khê", "ba58e344-4d96-4b01-ac55-01d0cd3064c8" },
                    { "573245d4-ce6f-446e-87e7-3fb3bfd102ac", "Quận 6", "709eb242-f707-4599-bd61-a634fe224eb3" },
                    { "598f78a0-f41a-4b37-a78c-45443942f3e9", "Quận Ô Môn", "40d97793-1280-4ff4-af42-dbaa63bbb78a" },
                    { "60e1acae-918d-42d3-91a4-2e6a02345ff2", "Quận Đồ Sơn", "0a44d94d-5126-497a-9a15-1b9eb7ae4033" },
                    { "6f0a8319-667b-46fc-8fc2-551b383812d8", "Quận Hoàn Kiếm", "9f3c6d42-5e6c-4f72-8c3f-cfbf172ff8e7" },
                    { "76557cb9-7512-4f6a-8a4b-46abe9a8b9ed", "Quận Thốt Nốt", "40d97793-1280-4ff4-af42-dbaa63bbb78a" },
                    { "84d3dc8e-d792-4b36-a633-9eb3c752afa3", "Quận Dương Kinh", "0a44d94d-5126-497a-9a15-1b9eb7ae4033" },
                    { "944094a6-09ae-4513-822b-77888d462b32", "Quận 12", "709eb242-f707-4599-bd61-a634fe224eb3" },
                    { "99ebdbfc-4d00-4266-9105-2250258b9f44", "Quận Hải Châu", "ba58e344-4d96-4b01-ac55-01d0cd3064c8" },
                    { "a2818a80-d0f6-4ce8-8b9c-4802792da894", "Quận Ngũ Hành Sơn", "ba58e344-4d96-4b01-ac55-01d0cd3064c8" },
                    { "a84e2384-b60f-4459-b879-9738f0a5c1dd", "Quận 5", "709eb242-f707-4599-bd61-a634fe224eb3" },
                    { "a905ae7c-d447-448e-8994-cd0c181dfeb0", "Quận Hai Bà Trưng", "9f3c6d42-5e6c-4f72-8c3f-cfbf172ff8e7" },
                    { "aa84de82-69d1-4110-9f31-3aca2ea7fa20", "Quận 4", "709eb242-f707-4599-bd61-a634fe224eb3" },
                    { "ae05b599-0a86-42f5-a5d8-7eedda10996f", "Quận 2", "709eb242-f707-4599-bd61-a634fe224eb3" },
                    { "b1b208d9-25e2-4590-8b46-2959f610543d", "Quận Kiến An", "0a44d94d-5126-497a-9a15-1b9eb7ae4033" },
                    { "b4c9b166-8e4a-47f3-91af-67a188ac72e5", "Quận Hà Đông", "9f3c6d42-5e6c-4f72-8c3f-cfbf172ff8e7" },
                    { "b6ef886e-c1de-4d72-a2c8-589f38c70cf2", "Quận Thủ Đức", "709eb242-f707-4599-bd61-a634fe224eb3" },
                    { "bc671699-552d-4993-8ee6-1502fc7d194a", "Quận Tân Bình", "709eb242-f707-4599-bd61-a634fe224eb3" },
                    { "bf2cb4b2-0849-437d-a4b5-9279e8c39c17", "Quận 9", "709eb242-f707-4599-bd61-a634fe224eb3" },
                    { "bf5f3ac9-c1c9-417b-ab55-796ca667da50", "Quận Lê Chân", "0a44d94d-5126-497a-9a15-1b9eb7ae4033" },
                    { "c0c9f5e2-065a-430d-8828-a2db70374b8e", "Quận Bắc Từ Liêm", "9f3c6d42-5e6c-4f72-8c3f-cfbf172ff8e7" },
                    { "c21c5301-aeac-4972-9f83-95fbfd517f5c", "Quận Bình Thạnh", "709eb242-f707-4599-bd61-a634fe224eb3" },
                    { "c3abdd90-5ede-4c7b-9443-033be674e156", "Quận Cái Răng", "40d97793-1280-4ff4-af42-dbaa63bbb78a" }
                });

            migrationBuilder.InsertData(
                table: "District",
                columns: new[] { "Id", "Name", "ProvinceId" },
                values: new object[,]
                {
                    { "c4c23c39-f67c-4e0d-9d37-3907f78bdeb9", "Quận Long Biên", "9f3c6d42-5e6c-4f72-8c3f-cfbf172ff8e7" },
                    { "c9f4e662-217f-4b65-b5e7-8b96497bd4c3", "Quận Bình Tân", "709eb242-f707-4599-bd61-a634fe224eb3" },
                    { "cd64d2d7-3614-4739-a699-b52d718e890b", "Quận 7", "709eb242-f707-4599-bd61-a634fe224eb3" },
                    { "d895c801-3950-4ef6-ac68-83bfae778227", "Quận Gò Vấp", "709eb242-f707-4599-bd61-a634fe224eb3" },
                    { "e53d7fd2-8ac5-4101-b3fc-c23631e23632", "Quận Thanh Xuân", "9f3c6d42-5e6c-4f72-8c3f-cfbf172ff8e7" },
                    { "e8e9c40b-c646-4976-8786-ec7751d5b250", "Quận 3", "709eb242-f707-4599-bd61-a634fe224eb3" },
                    { "ea6dad65-26cf-4972-9f1a-cc0e8e204723", "Quận Ninh Kiều", "40d97793-1280-4ff4-af42-dbaa63bbb78a" },
                    { "ebc3a288-92a7-4338-aa6e-5d8a0736ce1b", "Quận Bình Thuỷ", "40d97793-1280-4ff4-af42-dbaa63bbb78a" },
                    { "f08968ca-979d-48c6-bf29-8c381bbf1a07", "Quận 10", "709eb242-f707-4599-bd61-a634fe224eb3" },
                    { "fa0454dd-1bd2-4a5a-95b2-b72d809b4fb2", "Quận Hải An", "0a44d94d-5126-497a-9a15-1b9eb7ae4033" }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "48f576de-5eef-456a-b5fe-69ac4f92554c", "6d74548c-27df-47ae-a4dc-d09be267528d" },
                    { "b9cfceac-2ad8-4ec1-be6d-f918581c0fd2", "c77e84e2-5825-4331-bcc3-ae9d07a9c936" },
                    { "c9444742-e347-41e1-9ae4-8f48a6b14c57", "4e7ae74e-c16a-416e-84eb-fc5e4ea56e99" }
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
