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
                    { "1d89851c-d86a-4e32-a509-2ad99d8650d0", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cvlookup.sgu.2023@gmail.com", new DateTime(2023, 11, 17, 21, 12, 6, 3, DateTimeKind.Local).AddTicks(2642), "4EvS5r40usEAzXH5nw6YyjfVVpQdHt7K+e7DBWXhKPKdrduCQ6W3M3Ala03/Tw8kFhLEGxHwealuxejQLZqg0y4nsngohze7rnldfpPHQ1Y=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "fc6bec84-cfef-472d-b669-fe28985d5391", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cvlookup.sgu.2023_candidate@gmail.com", new DateTime(2023, 11, 17, 21, 12, 6, 3, DateTimeKind.Local).AddTicks(2695), "4EvS5r40usEAzXH5nw6YyjfVVpQdHt7K+e7DBWXhKPKdrduCQ6W3M3Ala03/Tw8kFhLEGxHwealuxejQLZqg0y4nsngohze7rnldfpPHQ1Y=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "fe053853-d163-48ec-98a5-aa4f4e4c8352", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cvlookup.sgu.2023_employer@gmail.com", new DateTime(2023, 11, 17, 21, 12, 6, 3, DateTimeKind.Local).AddTicks(2669), "4EvS5r40usEAzXH5nw6YyjfVVpQdHt7K+e7DBWXhKPKdrduCQ6W3M3Ala03/Tw8kFhLEGxHwealuxejQLZqg0y4nsngohze7rnldfpPHQ1Y=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Experience",
                columns: new[] { "Id", "Exp" },
                values: new object[,]
                {
                    { "2c8c337e-fe1f-4e71-bb12-499339097bcb", "Chưa có kinh nghiệm" },
                    { "3b21023a-9518-410f-99d0-397b34c2565f", "Từ 2-3 năm" },
                    { "428e3f5e-70fc-407a-b44f-c81733993ed4", "Từ 5-10 năm" },
                    { "6f669f52-6267-4940-ba83-ef7f444b56fa", "Từ 1-2 năm" },
                    { "7658afae-c7bb-4f10-906f-42cffaa6c3c3", "Dưới 1 năm" },
                    { "c7d2a9ed-49f0-49f5-a52c-2649f34d30da", "Từ 3-5 năm" },
                    { "ee521416-12ce-4d86-9cc5-be97180b8042", "Trên 10 năm" },
                    { "fd9dd30c-086a-4228-9cdc-014bb40af773", "Tất cả kinh nghiệm" }
                });

            migrationBuilder.InsertData(
                table: "JobCareer",
                columns: new[] { "Id", "Career" },
                values: new object[,]
                {
                    { "0134dc54-3efd-4c72-8bca-1d154ff3f436", "Giáo dục / Đào tạo" },
                    { "08055c1f-7317-4d11-8103-795a6c69f9cc", "Nông / Lâm / Ngư nghiệp" },
                    { "107e6e65-9eb6-466d-b1e0-485ddbfbd63d", "Hành chính / Văn phòng" },
                    { "12d0f131-5e86-4415-9bbc-ace6a749ace2", "Hàng cao cấp" },
                    { "150cd7ba-2892-44dd-b062-6fc8347710d6", "Điện / Điện tử / Điện lạnh" },
                    { "2bd4c025-3939-4cc2-8e83-1b4a7cd9ef00", "Công nghệ Ô tô" },
                    { "31ee365c-8bef-404f-8d88-eeb64fae0fb1", "Sản phẩm công nghiệp" },
                    { "3433fad5-2be2-4396-9e1a-70e03eed4b69", "NGO / Phi chính phủ / Phi lợi nhuận" },
                    { "3a554294-1b8f-44ca-a0d4-d0ea35f39429", "Dầu khí/Hóa chất" },
                    { "3bfe47ad-2029-4890-9a58-25eea528ab24", "Tổ chức sự kiện / Quà tặng" },
                    { "3e10a119-4245-41ba-bfc7-b53a1195c482", "Mỹ phẩm / Trang sức" },
                    { "3e1b1080-4dbb-4353-9d24-c00ccdd0be84", "Mỹ thuật / Nghệ thuật / Điện ảnh" },
                    { "3f53b719-d572-451a-a7a1-39f6a7d79df1", "Vận tải / Kho vận" },
                    { "4672b113-fa2e-4dac-88b4-e5f37a70ce22", "An toàn lao động" },
                    { "47e7c409-77c5-4a47-9a83-4c3d337efd08", "Ngành nghề khác" },
                    { "4b5c929a-b7e8-4919-bc50-65506685c700", "Hoá học / Sinh học" },
                    { "52d10865-d3d7-4534-9b80-a83bede36669", "Dịch vụ khách hàng" },
                    { "53b7d293-821b-4abb-92fe-248d65768086", "IT phần mềm" },
                    { "56ae3a69-31d6-43b0-98ff-b630d5bb306a", "Bưu chính - Viễn thông" },
                    { "5744d91e-6a9c-4674-a608-4c9275ab5629", "Môi trường / Xử lý chất thải" },
                    { "60ddb9a4-4227-494a-9cb9-5d95a0966e2a", "Tư vấn" },
                    { "6a500e5b-65c2-4c2f-aad3-3bc94f06f3c4", "Công nghệ thông tin" },
                    { "6c1ba701-4af8-4723-837a-cfd75dc3efe6", "Bán hàng kỹ thuật" },
                    { "6e04e54c-cbc4-4e95-96df-4c06f91bd09d", "Luật / Pháp lý" },
                    { "7282530c-fb58-465f-a05d-912010f7ba03", "Sản xuất" },
                    { "7743c7a7-e48e-4eca-9420-faf9f79eb325", "Hàng gia dụng" },
                    { "794cb65e-78b3-4e85-88dc-1695e95a9786", "Cơ khí / Chế tạo / Tự động hóa" },
                    { "7e11cb6e-298b-4bc3-90fb-9f6be1e9a17d", "Logistics" },
                    { "8241a658-3a05-414f-b9b6-d9541ffd33fa", "Hàng tiêu dùng" },
                    { "8512c4d6-513f-493a-a249-5241922e20ec", "Y tế / Dược" },
                    { "88e33555-c767-46de-bd3a-f486502d8d8b", "IT Phần cứng / Mạng" }
                });

            migrationBuilder.InsertData(
                table: "JobCareer",
                columns: new[] { "Id", "Career" },
                values: new object[,]
                {
                    { "8c08527a-db84-4d60-b15b-44b38e4f3bb2", "Kinh doanh / Bán hàng" },
                    { "8c087161-bb72-4317-95e6-d010fd6e5e91", "Bất động sản" },
                    { "8ea41153-7243-4ae8-b0e4-5ae3934e4b36", "Xuất nhập khẩu" },
                    { "919f47a3-67f3-4e08-98e1-79f9b442fec7", "In ấn / Xuất bản" },
                    { "95e4ead2-2dd0-4e67-bc3c-23bed169d5b5", "Hàng không" },
                    { "9962084f-4887-4d2f-b7f6-7edac5988738", "Hàng hải" },
                    { "a0124bd1-9592-4087-bd77-ca849d769362", "Quản lý chất lượng (QA/QC)" },
                    { "a6b5c798-5180-417b-8731-7e68bd737221", "Phi chính phủ / Phi lợi nhuận" },
                    { "aa757a81-a8d6-43af-9569-fa03e74dbfae", "Tài chính / Đầu tư" },
                    { "ab5c7dde-9bc5-49f9-b824-26cd3c21fa6d", "Kế toán / Kiểm toán" },
                    { "af2c4b0a-5719-4065-bc5b-48927dcccfb4", "Xây dựng" },
                    { "b6a795df-911b-400a-90d2-297922e8e653", "Chứng khoán / Vàng / Ngoại tệ" },
                    { "b6b4b656-f1cf-4808-b99c-c98e4d1514b0", "Thiết kế nội thất" },
                    { "c4e8cb5b-9167-4892-86ce-ab4841bddd84", "Dệt may / Da giày" },
                    { "c90bc761-6996-4a6c-89ad-2ba38ca74254", "Thiết kế đồ họa" },
                    { "c954e595-e594-494d-997a-9ef13e105f1e", "Bảo hiểm" },
                    { "d0fa68f1-1bbc-4c1d-bce3-b0204105af23", "Thư ký / Trợ lý" },
                    { "d275c1ed-c303-40e0-bb96-af8e3b272373", "Bán lẻ / bán sỉ" },
                    { "d365dc91-2129-4e8d-9947-ae1d2e0423fa", "Khách sạn / Nhà hàng" },
                    { "d3aba895-e6d0-4471-ac95-fba1409da3ec", "Thời trang" },
                    { "d453c9be-b07e-45ff-860e-165d547208a8", "Hoạch định / Dự án" },
                    { "d7ac6828-221a-455b-987b-ae1af842a2bd", "Công nghệ cao" },
                    { "e0420c48-fff1-4cfa-a05b-ce6fb38a5842", "Dược phẩm / Công nghệ sinh học" },
                    { "e0f5db3a-93c7-45d0-ae41-162155a51aa4", "Tất cả ngành nghề" },
                    { "e4a062b2-2418-4a2e-9b14-3763f3df6b80", "Spa / Làm đẹp" },
                    { "ea5bcf80-8358-41f2-ae49-57e6fc6b8e34", "Bảo trì / Sửa chữa" },
                    { "ee241116-4f79-43d6-ae29-a205db2a089d", "Du lịch" },
                    { "eed1fd13-466c-4db3-97b1-56ad9e78086f", "Biên / Phiên dịch" },
                    { "efb5178a-5539-4149-ae32-9bee14a41c98", "Quản lý điều hành" },
                    { "efbf503f-3ee6-4d31-bb9b-4fb1f810ce27", "Ngân hàng / Tài chính" },
                    { "f412a14d-f4cb-4849-9c3f-eeb77bf7007c", "Marketing / Truyền thông / Quảng cáo" },
                    { "f568f552-731c-4b4c-b31d-0e51e5f80149", "Thực phẩm / Đồ uống" },
                    { "f81f2243-7684-43c6-aafb-480bb6645e52", "Nhân sự" },
                    { "f9c4d2c3-5341-4218-bd9d-7933b3c6122d", "Kiến trúc" },
                    { "fda312db-1006-4d36-80f4-d63a7947fc0f", "Địa chất / Khoáng sản" },
                    { "fdd747bc-66f5-47ad-81a4-922a606d0bdc", "Điện tử viễn thông" },
                    { "ff389bdb-e80e-44b9-be2c-d7e2156449f9", "Báo chí / Truyền hình" }
                });

            migrationBuilder.InsertData(
                table: "JobField",
                columns: new[] { "Id", "Field" },
                values: new object[,]
                {
                    { "0cebaa06-db91-4c84-b8e4-5856f68cdae0", "Kế toán / Kiểm toán" },
                    { "0fb1ddee-8503-404f-a85c-03753b1ccff2", "Thời trang" },
                    { "153e3f0b-531a-491a-b291-bb25f2e8b6f4", "Ngân hàng" },
                    { "164c7ea1-0503-40e3-9fff-0d42f78b3af8", "Thương mại điện tử" },
                    { "1ecd9029-7f9b-49f5-99f9-b25878e7afb7", "Xuất nhập khẩu" }
                });

            migrationBuilder.InsertData(
                table: "JobField",
                columns: new[] { "Id", "Field" },
                values: new object[,]
                {
                    { "2276b5f1-18ef-4423-9dd0-49e60bb93592", "IT - Phần mềm" },
                    { "26dbaf59-e01a-46a7-bc43-138710b6354b", "Điện tử / Điện lạnh" },
                    { "2b6a33f6-cf87-465e-92fc-fb983615fa7b", "Cơ quan nhà nước" },
                    { "2ff8c492-e8a1-4771-9bf8-a0149b708c11", "Tất cả lĩnh vực" },
                    { "3006e66a-72e8-4a6d-b094-7db3be5caaed", "Tư vấn" },
                    { "30761fad-9893-4287-ad31-8388c605c42a", "Luật" },
                    { "33350251-558c-455f-8aa1-bbb09330cbfc", "Tự động hóa" },
                    { "37ed9722-3da3-43f1-85be-a531a97c2f13", "Nhà hàng / Khách sạn" },
                    { "3df2b69b-4825-4cb9-bc5d-93188b7b341f", "In ấn / Xuất bản" },
                    { "449e3883-42ef-4a88-b5fa-e5059b5070f6", "Tài chính" },
                    { "542e7f5a-e5fa-4637-b316-31cca77e4d07", "Bảo trì / Sửa chữa" },
                    { "61c8b728-0090-4696-ab0b-73c47ea322a6", "Xây dựng" },
                    { "6c7d155d-2197-44a3-8bac-457dcf289a38", "Du lịch" },
                    { "7656437c-1273-4bb0-aebb-3248bf7f0e19", "Bất động sản" },
                    { "8acee5c6-a89d-4df3-b309-12c227b26e07", "Môi trường" },
                    { "8b3240fd-348f-407a-909e-2a50a828b29f", "Logistics - Vận tải" },
                    { "9475ae66-f0df-4664-be23-8c28d67d9d10", "Năng lượng" },
                    { "95c108b7-71d4-4e33-85e2-28741a1e42c3", "Viễn thông" },
                    { "9bfa3d29-590a-4c07-bf0f-fefdf93db7dc", "Nông Lâm Ngư nghiệp" },
                    { "a071b14e-77ef-466b-a849-3dd37503ec37", "IT - Phần cứng" },
                    { "a6fdfd68-d31b-424d-a650-d8e396e0ddf7", "Agency (Marketing/Advertising)" },
                    { "a940de08-bb72-4a9a-a81e-7373ccbbc944", "Chứng khoán" },
                    { "acfd675f-d488-411a-bf1c-c103af4a022e", "Nhân sự" },
                    { "b3f61e76-9bf0-41ca-93a3-799704a2dcae", "Giáo dục / Đào tạo" },
                    { "b4b28d12-e569-41e9-9fdf-066ac1c1730b", "Giải trí" },
                    { "b4c1e2f7-3330-445e-a577-2bce122422e4", "Marketing / Truyền thông / Quảng cáo" },
                    { "bcb2454a-265b-4202-a983-2c407ca7e77b", "Thiết kế / kiến trúc" },
                    { "c3a3df53-6bcf-4046-8922-ab63dd168c2d", "Tổ chức phi lợi nhuận" },
                    { "c59c7ff4-ec71-4747-96e2-78d04f25e760", "Sản xuất" },
                    { "c7e512aa-644c-4fc4-8c22-3813a87f2d2c", "Dược phẩm / Y tế / Công nghệ sinh học" },
                    { "c83ba914-b62e-42be-a4be-2edae815a85c", "Internet / Online" },
                    { "d3be256d-7820-4836-bf13-a232d05310f1", "Bán lẻ - Hàng tiêu dùng - FMCG" },
                    { "df7177d7-d816-4255-a2e3-4ec7e5846e04", "Bảo hiểm" },
                    { "e5f8d8c4-1772-41ea-a081-0fcc9c850c5c", "Khác" },
                    { "f1dac0e5-8472-4950-8634-171a3cb938c5", "Agency (Design/Development)" },
                    { "fbbaed48-7d4b-4743-8d30-55d1fcc69f42", "Cơ khí" }
                });

            migrationBuilder.InsertData(
                table: "JobForm",
                columns: new[] { "Id", "Form" },
                values: new object[,]
                {
                    { "59932266-81fd-42a7-83c8-b7c15f73a9f8", "Bán thời gian" },
                    { "7ea526c1-a22d-4c91-9b04-0ee301723ece", "Thực tập" },
                    { "ba7c3ce3-d8df-42d4-9785-0f0550b541ff", "Tất cả hình thức" },
                    { "c87d4540-4b80-46f4-87ab-e2c3d803dd05", "Toàn thời gian" }
                });

            migrationBuilder.InsertData(
                table: "JobPosition",
                columns: new[] { "Id", "Position" },
                values: new object[,]
                {
                    { "0d602f67-5aa2-4fd5-afd9-c8f5c264f81f", "Quản lí / Giám sát" },
                    { "4e2d966c-a4f1-4080-abc1-80629f57848c", "Thực tập sinh" }
                });

            migrationBuilder.InsertData(
                table: "JobPosition",
                columns: new[] { "Id", "Position" },
                values: new object[,]
                {
                    { "55de4c9a-9bdb-49dd-b9a4-2260cbc16bcf", "Tất cả vị trí" },
                    { "77263f41-1ed2-443c-9ba4-c07e691bedbb", "Trưởng chi nhánh" },
                    { "9e685f24-312d-4108-9953-65f96d59ea76", "Trưởng / Phó phòng" },
                    { "c97e700a-ac3e-4189-9ea3-d31ca0fd7a5b", "Nhân viên" },
                    { "d543caca-1631-4cfd-9c91-70e1212a5f41", "Phó giám đốc" },
                    { "ec5015e1-c15c-43b9-8282-63f1dda08b7b", "Giám đốc" },
                    { "ff4a152c-e51f-4452-af2c-54a8ebaf5275", "Trưởng nhóm" }
                });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "095e5f16-eb99-45e0-ae5a-c850de3c6e32", "Cao Bằng" },
                    { "0a028c99-8bd7-4efa-94d8-e03056cf740b", "Nam Định" },
                    { "0bac7f0f-97d0-4d71-accf-4d6b84619389", "Đắk Nông" },
                    { "104900e9-5e48-439f-88dc-d5b7df4c2df9", "Phú Yên" },
                    { "129b9543-104a-476a-a15e-893ae458c1ee", "Đồng Nai" },
                    { "177d45cd-a1d0-4276-8ebf-8307ac5e23c3", "Lạng Sơn" },
                    { "181c206a-a2a7-4715-99fa-78301916420f", "Long An" },
                    { "1a56093a-0b85-4162-a754-f41cf7fb90ab", "Bình Phước" },
                    { "20d401fe-8a71-4a73-8bdd-0972fd0c9415", "Cần Thơ" },
                    { "20e03a2f-13c0-443f-a56d-26fec2741078", "Hải Phòng" },
                    { "21b736f3-cecc-4e95-a263-eb557f4dba3e", "Lào Cai" },
                    { "22c0e03e-15bf-47ce-8689-076fab2519d1", "Yên Bái" },
                    { "2419d6a5-5a91-4099-9585-f57a902547aa", "Lai Châu" },
                    { "287e9631-3695-44f7-968c-3e762bd89c02", "Quảng Nam" },
                    { "2cae3489-8bfd-44ae-90e6-7681a2bc2c8a", "Bắc Kạn" },
                    { "31efc8a9-9918-4d89-84d6-1c0489602d61", "Hậu Giang" },
                    { "32166562-44f7-4e76-b43f-cca23a577261", "Hải Dương" },
                    { "35953c72-fb48-4055-86cb-d9d67a613b9d", "Kon Tum" },
                    { "407939ac-713c-4c73-90c8-9412b3cc020b", "Nghệ An" },
                    { "4746e7b6-cc32-4200-b3a9-f27e74f9ea74", "Thanh Hóa" },
                    { "4bda8f41-22a5-436c-ac1c-d616361b4f91", "Bình Định" },
                    { "4d804913-2764-48f6-89db-343b210edfda", "Trà Vinh" },
                    { "4e58f5fb-0e33-4ad2-aa07-8e300e21ea6d", "Cà Mau" },
                    { "4f2ee505-6998-4ca6-8d4a-92317670b5f5", "Vĩnh Phúc" },
                    { "56303409-9c6e-418b-8c3b-a1c4d760b8e7", "Hà Giang" },
                    { "56719c79-2144-4f82-ac68-4cbe11655efe", "Bình Dương" },
                    { "5a6a4d56-b5f3-4a03-bf69-2e0a486c4dc3", "Hà Nam" },
                    { "5f21fccc-aafc-4201-98b4-79e02d76f5fd", "Tiền Giang" },
                    { "66d63582-140b-4340-b5b5-e64af46cf324", "Tây Ninh" },
                    { "68b9d1db-e435-476c-b3e3-155a20ba6f00", "Ninh Thuận" },
                    { "68cbd354-4766-4ea5-8fc3-723198fb1208", "Thái Bình" },
                    { "6cff0494-4d92-4f1a-88ba-ca27f373777b", "Lâm Đồng" },
                    { "7a4a1647-202f-48c1-90cf-c127e6f50d45", "Sóc Trăng" },
                    { "80d25b47-3c1b-41ec-850a-68519f87ac6f", "Bến Tre" },
                    { "82049bb5-1947-4df6-9caa-6b1447fd0fc6", "Sơn La" }
                });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "83e14b25-1d89-435f-9b08-c051e21519b5", "Hà Tĩnh" },
                    { "8819a462-fad8-4172-803e-546bf28ffdc6", "Quảng Trị" },
                    { "8a309d95-74c0-4b9c-9e9c-dcc7e5d592d2", "Thừa Thiên Huế" },
                    { "9806ec9a-c57e-4516-999e-9b35d2f66677", "Ninh Bình" },
                    { "a0252429-e2d9-4d64-bb69-a3daf03e2bcb", "Bình Thuận" },
                    { "a3bec344-e00c-49c2-bf2d-fdca043e65c3", "Bà Rịa-Vũng Tàu" },
                    { "adfea454-ee91-44b5-bbea-ebf5d2fd4c0f", "Phú Thọ" },
                    { "ae0e0c85-d12a-4cea-a2c6-ea2e982d5de0", "Khánh Hòa" },
                    { "af61da91-4b30-46b8-96d5-6fe09c974f8f", "Bạc Liêu" },
                    { "b45b5c7c-8a65-4fc6-87af-c3e46cf0361b", "Tuyên Quang" },
                    { "b5c08532-9f6a-4cf7-9108-888530996490", "Quảng Bình" },
                    { "b7a98019-426a-4a57-b0ee-676503c1a783", "Hưng Yên" },
                    { "b7b96ae8-751e-4013-9609-0626661048dc", "Kiên Giang" },
                    { "b95acd35-1b42-40a0-afbe-c4f9b3ee4ec5", "An Giang" },
                    { "ba54e13e-0ad2-4cc7-a2ba-4860a9ddd345", "Gia Lai" },
                    { "ba7ca28e-132f-4d80-927b-50f6b03d722f", "Hòa Bình" },
                    { "bbeb1bd6-5686-4818-a377-175244800ae3", "Quảng Ninh" },
                    { "c406fc5f-4ea5-4735-a352-3d233f1a73a0", "Đà Nẵng" },
                    { "c80c318a-5aec-4bad-88e8-4dab7c39547c", "Tất cả tỉnh thành" },
                    { "ca84bcdf-fae5-48e7-81f0-2cb7b8a0a95b", "Đồng Tháp" },
                    { "cdea3f56-a2db-4216-a3d0-ad7f639313b2", "Điện Biên" },
                    { "d58d0502-6d84-4496-9a63-5a0a0f8f860c", "Bắc Ninh" },
                    { "e7996f9e-3db5-4ca0-a577-9cdda84e9e88", "Vĩnh Long" },
                    { "e8bde5f7-e1c7-46f3-85a7-9f8a4a1987d0", "Quảng Ngãi" },
                    { "ea9950c4-e982-4c26-93fb-36ba1a763cb9", "Hà Nội" },
                    { "eaba2782-d492-4901-afdf-365a760ee28d", "Đắk Lắk" },
                    { "ec314ea8-64a6-4907-add4-835ebf40b1e8", "Bắc Giang" },
                    { "ec42d7de-defa-49f9-8861-124a5ea9fb6d", "Hồ Chí Minh" },
                    { "efe41190-f39c-4ed4-939a-8b7f73e871f7", "Thái Nguyên" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { "2a898eb4-9b5f-4d0f-a528-23cbf95c6fa1", "Employer" },
                    { "827c594d-a99f-47a7-9b40-ec07b3b439c4", "Admin" },
                    { "b9301c8c-079d-4f88-94de-cd0c6b802282", "Candidate" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Avatar", "DateOfBirth", "Discriminator", "Email", "PhoneNumber", "Username" },
                values: new object[] { "3ad5a6bd-0724-4856-8655-d8a090bf8851", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Candidate", "cvlookup.sgu.2023_candidate@gmail.com", null, "Candidate Admin" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Address", "Avatar", "Description", "Discriminator", "Email", "PhoneNumber", "Username", "Website" },
                values: new object[] { "f2a3142f-0353-4b87-a7bc-a20775bb8b19", "Admin", null, "Admin", "Employer", "cvlookup.sgu.2023_employer@gmail.com", null, "Employer Admin", null });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Avatar", "Discriminator", "Email", "PhoneNumber", "Username" },
                values: new object[] { "5adf2ee6-2f67-4847-9c6c-980f1f0500ce", null, "User", "cvlookup.sgu.2023@gmail.com", null, "General Admin" });

            migrationBuilder.InsertData(
                table: "AccountUser",
                columns: new[] { "AccountId", "UserId" },
                values: new object[,]
                {
                    { "1d89851c-d86a-4e32-a509-2ad99d8650d0", "5adf2ee6-2f67-4847-9c6c-980f1f0500ce" },
                    { "fc6bec84-cfef-472d-b669-fe28985d5391", "3ad5a6bd-0724-4856-8655-d8a090bf8851" },
                    { "fe053853-d163-48ec-98a5-aa4f4e4c8352", "f2a3142f-0353-4b87-a7bc-a20775bb8b19" }
                });

            migrationBuilder.InsertData(
                table: "District",
                columns: new[] { "Id", "Name", "ProvinceId" },
                values: new object[,]
                {
                    { "002bb4a3-7569-4336-aa26-3ff6b6f444bc", "Quận Ba Đình", "ea9950c4-e982-4c26-93fb-36ba1a763cb9" },
                    { "09fe3dae-fefa-41e9-9b9a-9d7b95c88bfc", "Quận Ninh Kiều", "20d401fe-8a71-4a73-8bdd-0972fd0c9415" },
                    { "14c52c41-9f8d-4283-a7b4-147115ac4ee7", "Quận 10", "ec42d7de-defa-49f9-8861-124a5ea9fb6d" },
                    { "18512b08-d286-4720-81d6-374574e62219", "Quận 2", "ec42d7de-defa-49f9-8861-124a5ea9fb6d" },
                    { "290b2be0-6b77-4444-bb58-c046d8ada52a", "Quận Thốt Nốt", "20d401fe-8a71-4a73-8bdd-0972fd0c9415" },
                    { "32f04554-9886-45aa-8b60-6a06f8fdab12", "Quận Liên Chiểu", "c406fc5f-4ea5-4735-a352-3d233f1a73a0" },
                    { "3a4c4e4e-dea7-4cf2-aa1c-b193f9db7d7c", "Quận Hải Châu", "c406fc5f-4ea5-4735-a352-3d233f1a73a0" },
                    { "3eb01e46-acea-4e5c-86ab-af4b2b6e9de6", "Quận Phú Nhuận", "ec42d7de-defa-49f9-8861-124a5ea9fb6d" },
                    { "466cc174-36f1-4f32-8a26-8468ec617a60", "Quận Hải An", "20e03a2f-13c0-443f-a56d-26fec2741078" },
                    { "48d16cd9-9d2e-41d1-b4c1-929fafb76ab9", "Quận 1", "ec42d7de-defa-49f9-8861-124a5ea9fb6d" },
                    { "4ba9093d-a4b5-4e1b-a7bb-43f03360357e", "Quận Thanh Khê", "c406fc5f-4ea5-4735-a352-3d233f1a73a0" },
                    { "57db896a-8de4-4256-8b7f-a0a7fd0866d2", "Quận 11", "ec42d7de-defa-49f9-8861-124a5ea9fb6d" },
                    { "5dcecb2f-2463-46fa-b734-6b664d3cbdbe", "Quận Long Biên", "ea9950c4-e982-4c26-93fb-36ba1a763cb9" },
                    { "61c2f867-f9f0-48b9-bc64-f9c582e4ce23", "Quận Đồ Sơn", "20e03a2f-13c0-443f-a56d-26fec2741078" },
                    { "62487c26-0fb5-4e6c-b1b2-115ad715ce89", "Quận Tây Hồ", "ea9950c4-e982-4c26-93fb-36ba1a763cb9" },
                    { "62b6ba14-112f-4ca9-adc6-17269a7e212f", "Quận Hoàng Mai", "ea9950c4-e982-4c26-93fb-36ba1a763cb9" },
                    { "6ba2a36a-3c96-4b18-a9de-91ad5d1a17b3", "Quận Hoàn Kiếm", "ea9950c4-e982-4c26-93fb-36ba1a763cb9" },
                    { "6e21670b-e7e0-4368-b604-d0a78f61dbbc", "Quận Tân Bình", "ec42d7de-defa-49f9-8861-124a5ea9fb6d" },
                    { "73e6bd71-ff23-4a39-84b5-cc14cf29c9cc", "Quận Kiến An", "20e03a2f-13c0-443f-a56d-26fec2741078" },
                    { "78fa2464-0cbe-49b7-bdd6-89de31d8992f", "Quận Ô Môn", "20d401fe-8a71-4a73-8bdd-0972fd0c9415" },
                    { "79ea43fb-1cf7-466a-996e-73a6b6129c6e", "Quận Lê Chân", "20e03a2f-13c0-443f-a56d-26fec2741078" },
                    { "8074e7ea-6007-402e-b8e4-90753380a283", "Quận Bình Tân", "ec42d7de-defa-49f9-8861-124a5ea9fb6d" },
                    { "830f586e-cf8f-4fbc-93f0-c3c34c2c44ad", "Quận Thủ Đức", "ec42d7de-defa-49f9-8861-124a5ea9fb6d" },
                    { "8659a73e-69c1-4094-b03f-6d7456fb29ff", "Quận 12", "ec42d7de-defa-49f9-8861-124a5ea9fb6d" },
                    { "88600eb4-125e-4791-b49f-7d2d0e2d01b9", "Quận Bắc Từ Liêm", "ea9950c4-e982-4c26-93fb-36ba1a763cb9" },
                    { "93d0dc47-89f7-43f7-8750-b28e19d81548", "Quận 8", "ec42d7de-defa-49f9-8861-124a5ea9fb6d" },
                    { "a2579e81-8e2f-4c8e-b5b9-e0e3f3322e7d", "Quận Nam Từ Liêm", "ea9950c4-e982-4c26-93fb-36ba1a763cb9" },
                    { "a574e5f7-c9dc-4a2b-8c10-3d01c65f6c45", "Quận Bình Thạnh", "ec42d7de-defa-49f9-8861-124a5ea9fb6d" },
                    { "a8193502-3ccb-42b4-8fce-1f6a627ba91b", "Quận Hai Bà Trưng", "ea9950c4-e982-4c26-93fb-36ba1a763cb9" },
                    { "a951ccd3-54c1-44f1-8280-3cbc7b44ee43", "Quận Thanh Xuân", "ea9950c4-e982-4c26-93fb-36ba1a763cb9" },
                    { "acaaabea-27a3-489a-a8b5-eb0746e17a39", "Quận Tân Phú", "ec42d7de-defa-49f9-8861-124a5ea9fb6d" },
                    { "ade5c02f-5a89-4770-aeb1-01afa3eda6c9", "Quận Bình Thuỷ", "20d401fe-8a71-4a73-8bdd-0972fd0c9415" },
                    { "b0824c83-fb94-443a-b618-80c8ba09d32c", "Quận 3", "ec42d7de-defa-49f9-8861-124a5ea9fb6d" },
                    { "b30758ec-b996-455a-a059-55137ce9f423", "Quận Ngũ Hành Sơn", "c406fc5f-4ea5-4735-a352-3d233f1a73a0" },
                    { "bba96312-24ca-4bd2-ac06-106243020791", "Quận Đống Đa", "ea9950c4-e982-4c26-93fb-36ba1a763cb9" },
                    { "bc0b870d-bfa7-48f9-b0d2-a3cc2a9c5d66", "Quận Dương Kinh", "20e03a2f-13c0-443f-a56d-26fec2741078" },
                    { "be7bc98e-1337-4cbe-9cc6-d56505605add", "Quận Cầu Giấy", "ea9950c4-e982-4c26-93fb-36ba1a763cb9" },
                    { "cb0d656f-add1-4069-9406-56ab48a57d10", "Quận 7", "ec42d7de-defa-49f9-8861-124a5ea9fb6d" },
                    { "cc390b76-34cd-4f49-975f-533185a77f62", "Quận Ngô Quyền", "20e03a2f-13c0-443f-a56d-26fec2741078" }
                });

            migrationBuilder.InsertData(
                table: "District",
                columns: new[] { "Id", "Name", "ProvinceId" },
                values: new object[,]
                {
                    { "cf2b88c8-5024-4255-9427-6e735d95ed55", "Quận Gò Vấp", "ec42d7de-defa-49f9-8861-124a5ea9fb6d" },
                    { "cf72a4a5-b4e9-4948-83d0-d2459b06e467", "Quận 9", "ec42d7de-defa-49f9-8861-124a5ea9fb6d" },
                    { "d0fe1aaa-fd42-4e8f-8ff2-2014b60adfcd", "Quận Sơn Trà", "c406fc5f-4ea5-4735-a352-3d233f1a73a0" },
                    { "d16cc476-4768-410c-931b-2e89314a4c44", "Quận 6", "ec42d7de-defa-49f9-8861-124a5ea9fb6d" },
                    { "dd0804b4-128b-487e-9eec-7cea9e8d712b", "Quận 4", "ec42d7de-defa-49f9-8861-124a5ea9fb6d" },
                    { "e05d8353-f1cf-4f37-88d9-7678ce824f7b", "Quận Hà Đông", "ea9950c4-e982-4c26-93fb-36ba1a763cb9" },
                    { "e44f67ba-d93e-45a2-8a34-eb24a1bb22bd", "Quận Cẩm Lệ", "c406fc5f-4ea5-4735-a352-3d233f1a73a0" },
                    { "ee8d0f2e-863c-4c4d-a2b6-d6b77d6ee6e2", "Quận 5", "ec42d7de-defa-49f9-8861-124a5ea9fb6d" },
                    { "fca62c61-19ee-4d16-9603-1f9b185a5115", "Quận Hồng Bàng", "20e03a2f-13c0-443f-a56d-26fec2741078" },
                    { "fd0a94bf-20da-4b15-a453-0f30c9bffe40", "Quận Cái Răng", "20d401fe-8a71-4a73-8bdd-0972fd0c9415" }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2a898eb4-9b5f-4d0f-a528-23cbf95c6fa1", "f2a3142f-0353-4b87-a7bc-a20775bb8b19" },
                    { "827c594d-a99f-47a7-9b40-ec07b3b439c4", "5adf2ee6-2f67-4847-9c6c-980f1f0500ce" },
                    { "b9301c8c-079d-4f88-94de-cd0c6b802282", "3ad5a6bd-0724-4856-8655-d8a090bf8851" }
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
