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
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmployerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    DistrictId = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    CurriculumVitaeId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "Actived", "ActivedAt", "Email", "IssuedAt", "Password", "UpdatedAt" },
                values: new object[,]
                {
                    { "4d389fd9-8fc5-48de-9ccb-f03349c01387", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cvlookup.sgu.2023_employer@gmail.com", new DateTime(2023, 10, 15, 22, 16, 34, 623, DateTimeKind.Local).AddTicks(1123), "4EvS5r40usEAzXH5nw6YyjfVVpQdHt7K+e7DBWXhKPKdrduCQ6W3M3Ala03/Tw8kFhLEGxHwealuxejQLZqg0y4nsngohze7rnldfpPHQ1Y=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "8b13468c-296c-4866-9497-275806874d0c", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cvlookup.sgu.2023@gmail.com", new DateTime(2023, 10, 15, 22, 16, 34, 623, DateTimeKind.Local).AddTicks(1104), "4EvS5r40usEAzXH5nw6YyjfVVpQdHt7K+e7DBWXhKPKdrduCQ6W3M3Ala03/Tw8kFhLEGxHwealuxejQLZqg0y4nsngohze7rnldfpPHQ1Y=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "cf6b30f3-7e26-494f-8451-66463024d6c7", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cvlookup.sgu.2023_candidate@gmail.com", new DateTime(2023, 10, 15, 22, 16, 34, 623, DateTimeKind.Local).AddTicks(1128), "4EvS5r40usEAzXH5nw6YyjfVVpQdHt7K+e7DBWXhKPKdrduCQ6W3M3Ala03/Tw8kFhLEGxHwealuxejQLZqg0y4nsngohze7rnldfpPHQ1Y=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Experience",
                columns: new[] { "Id", "Exp" },
                values: new object[,]
                {
                    { "52a36559-5f14-4aa5-91cb-656f299dd766", "Dưới 1 năm" },
                    { "7a304dfb-f379-4487-8fa6-22bfaeab1111", "Trên 10 năm" },
                    { "81cd27f3-7064-4503-9295-7524b5841cf0", "Chưa có kinh nghiệm" },
                    { "9b4b69e6-c3cf-4534-95d4-a6b724a7a879", "Từ 1-2 năm" },
                    { "af5d8556-a678-49eb-9d53-df39b79a9285", "Từ 2-3 năm" },
                    { "bcb54533-8b59-4107-8c0c-ce819f3fae27", "Tất cả kinh nghiệm" },
                    { "c88fbd2e-5be9-40d6-9d09-36f7b5900a68", "Từ 5-10 năm" },
                    { "eeceebe6-64ac-449f-8279-3664521e1954", "Từ 3-5 năm" }
                });

            migrationBuilder.InsertData(
                table: "JobCareer",
                columns: new[] { "Id", "Career" },
                values: new object[,]
                {
                    { "0001b84c-f06d-4b32-bd19-db2fab1ebca8", "Địa chất / Khoáng sản" },
                    { "01da0352-0a42-4dee-9b74-28e1fc8491fa", "Bưu chính - Viễn thông" },
                    { "06c56e77-b7a5-4cf9-92b7-b875106ad92f", "Hàng không" },
                    { "0a09c865-ca4d-4dde-8187-ea5b76634251", "Ngành nghề khác" },
                    { "0c0851ba-dfa6-472c-8f3e-d9c6439a011f", "Hoá học / Sinh học" },
                    { "1c2ae418-8971-477f-81c7-09d3b217a72e", "Chứng khoán / Vàng / Ngoại tệ" },
                    { "21d975d8-ffd0-4a17-8677-6bc467268d4e", "Nông / Lâm / Ngư nghiệp" },
                    { "24d8b988-1f4e-48c9-91f1-ea2b5c26865b", "Spa / Làm đẹp" },
                    { "25918dde-e8f0-4198-846d-fc04bb5cb671", "Thời trang" },
                    { "2c5c5ce2-5cfe-4d41-b248-8b2236800219", "Bảo trì / Sửa chữa" },
                    { "2fdbd94b-d024-4267-96f0-77ec8f7a46b6", "Bán hàng kỹ thuật" },
                    { "32ef00ff-de79-4937-81b3-9351b60f1681", "Kinh doanh / Bán hàng" },
                    { "3400a740-d18a-4ae9-8e95-548b755d4348", "Tất cả ngành nghề" },
                    { "3ae6b1ca-f31c-44bb-b7be-68a231b2570a", "Y tế / Dược" },
                    { "459b949d-5367-48a8-9dfa-21c4e033c650", "Dệt may / Da giày" },
                    { "4e2fc231-8671-4f01-8430-b82bf112d555", "Quản lý chất lượng (QA/QC)" },
                    { "50814c22-13e3-4a2f-aaff-95f15a63ffc3", "Biên / Phiên dịch" },
                    { "536e49dc-d1e5-4779-8c38-51545edb494b", "IT phần mềm" },
                    { "55b565cb-524c-4789-8f5c-c4b6a5fd26bf", "Tổ chức sự kiện / Quà tặng" },
                    { "5994b831-7d48-419b-a678-7d477b0a952e", "Hàng tiêu dùng" },
                    { "5ad9daff-8281-4a41-82fc-2c3b569586f8", "Dầu khí/Hóa chất" },
                    { "5b79695f-0957-46af-a2dd-7eab2657bbe7", "Xuất nhập khẩu" },
                    { "6c00df85-a9c6-47ba-97ee-62f7567db92e", "Điện tử viễn thông" },
                    { "6cc59307-d788-4832-8d23-7b9b2e05679b", "Logistics" },
                    { "6d48ea9c-455d-4c6f-9e61-6aefe727a8d8", "In ấn / Xuất bản" },
                    { "7216ad98-6011-4314-8473-44c2971bb572", "Ngân hàng / Tài chính" },
                    { "76da2cdf-13d4-4f9c-aba6-9836a9da46eb", "Hàng gia dụng" },
                    { "7b5ee70a-aa06-4920-a552-e8c268c5c516", "Bất động sản" },
                    { "7cb12cf1-0d80-411e-af63-4216bc93342f", "Hoạch định / Dự án" },
                    { "7d7f3e5f-2032-4147-96a1-b5ce2e62ff21", "Du lịch" },
                    { "816e0dbe-3bd7-4cb2-924e-e96d3b10b07d", "Công nghệ Ô tô" }
                });

            migrationBuilder.InsertData(
                table: "JobCareer",
                columns: new[] { "Id", "Career" },
                values: new object[,]
                {
                    { "82153ad9-babd-498e-a72a-a7bbb2df1030", "Khách sạn / Nhà hàng" },
                    { "85a0ef23-6b5e-47b0-9990-11040b6c5ead", "Kiến trúc" },
                    { "89f4c228-d114-4d8b-9ea7-64882db95ced", "Kế toán / Kiểm toán" },
                    { "8af47171-3fce-4c2c-b4a2-7e0afd50789d", "Báo chí / Truyền hình" },
                    { "91431b84-d1a0-4858-a161-bb0564ddb251", "Dịch vụ khách hàng" },
                    { "9281eeec-d2b0-42e2-9444-501caa1eeb97", "Marketing / Truyền thông / Quảng cáo" },
                    { "9451bea8-5638-4139-b51d-4207001440e6", "Cơ khí / Chế tạo / Tự động hóa" },
                    { "95a11503-7e30-4198-bed0-a8764465ade9", "Thực phẩm / Đồ uống" },
                    { "95ed52ac-73e7-48a2-88ae-3577a73b9812", "Sản xuất" },
                    { "99df60da-74f5-4ef0-89b2-0db1fa5a12ff", "NGO / Phi chính phủ / Phi lợi nhuận" },
                    { "9d584ed0-fcc7-47f5-b8cf-0c13a62969ee", "Mỹ thuật / Nghệ thuật / Điện ảnh" },
                    { "a115165a-8c74-431c-b00b-5cd4aaafce5c", "Môi trường / Xử lý chất thải" },
                    { "a32f362c-4a0e-4a0a-bf75-f84f4b1f0f7b", "Phi chính phủ / Phi lợi nhuận" },
                    { "a54ebdf2-5662-4bab-9677-9611f6521408", "Tài chính / Đầu tư" },
                    { "a83119df-906d-4c8e-8ac0-9a04a5e14590", "Hành chính / Văn phòng" },
                    { "a9a59274-e583-40e7-a3f7-ab118f2e837f", "Mỹ phẩm / Trang sức" },
                    { "b1c2070d-134f-47ed-936a-006da4bc4ea3", "IT Phần cứng / Mạng" },
                    { "b3e1ad25-543b-4a4a-8909-b95d5256f4b3", "Bán lẻ / bán sỉ" },
                    { "c3eff729-8473-4bb6-9626-f63cf76eb8e2", "Công nghệ thông tin" },
                    { "c6a6135f-556b-4d56-8ef7-9991cb40dca4", "Quản lý điều hành" },
                    { "ce6153a6-3449-484a-9b49-e01e64c07db6", "Sản phẩm công nghiệp" },
                    { "ced4558b-82ab-494b-bdd2-05ea8707141e", "Hàng hải" },
                    { "d1d455d4-ad97-452c-bcc2-2b0b6a303b8f", "Bảo hiểm" },
                    { "ded76eae-5f5e-4ea2-b790-8895b1b065d2", "Hàng cao cấp" },
                    { "e10755b2-c085-4e62-a3e0-7d7fc70b2009", "Vận tải / Kho vận" },
                    { "e4166f14-84e0-4cc3-bbfa-3047ddc80c21", "Nhân sự" },
                    { "e80d13cf-aee8-452f-94a1-e8e562a6c8e4", "Tư vấn" },
                    { "eba09e6d-9ec8-4a12-8c85-949c07d6020e", "Thư ký / Trợ lý" },
                    { "ebbfc932-eceb-46a7-9c91-7c269f04ca5d", "Xây dựng" },
                    { "f0942319-eb0e-4e64-b887-ff4bcaadb606", "An toàn lao động" },
                    { "f3a45963-6d12-495d-b67d-9cfe84684f13", "Công nghệ cao" },
                    { "f9a76cd3-0ffb-4620-9b4f-2d32e5f172f3", "Thiết kế đồ họa" },
                    { "fac4d101-34b1-46ec-a241-9bcbfe95c794", "Điện / Điện tử / Điện lạnh" },
                    { "fbca22af-0675-4826-aeff-d426b471db76", "Giáo dục / Đào tạo" },
                    { "fbf00a0a-bad7-4977-b5de-b61e1e0049f7", "Dược phẩm / Công nghệ sinh học" },
                    { "fc867a00-d903-413c-9320-f09f908f30ee", "Thiết kế nội thất" },
                    { "fc90447b-8c9b-4f5c-8785-427052a3fd63", "Luật / Pháp lý" }
                });

            migrationBuilder.InsertData(
                table: "JobField",
                columns: new[] { "Id", "Field" },
                values: new object[,]
                {
                    { "0218140c-cc73-446b-bc99-a6dd9da54ef4", "Xây dựng" },
                    { "19a3077e-38d3-4420-90ae-674bde7d9e93", "In ấn / Xuất bản" },
                    { "19c59deb-ca53-4260-b89c-6519edbfbe95", "Bảo hiểm" },
                    { "27605e31-3c29-4526-b6f3-769d9493d226", "Giáo dục / Đào tạo" },
                    { "27c59d4b-031f-4383-860a-e060bb72c751", "Ngân hàng" }
                });

            migrationBuilder.InsertData(
                table: "JobField",
                columns: new[] { "Id", "Field" },
                values: new object[,]
                {
                    { "2a4e0d7b-0be8-40be-83ee-af0812185811", "Cơ khí" },
                    { "307c954e-a440-4411-9ca6-87870730691e", "Agency (Marketing/Advertising)" },
                    { "33606a80-c9d1-43b4-aef4-24e345fd1282", "Du lịch" },
                    { "350039d0-7936-4a91-b02c-00535bf810bd", "Tư vấn" },
                    { "35437bf8-930a-49bf-ac83-3d6665e12818", "Tất cả lĩnh vực" },
                    { "383fb8d2-864b-447a-af29-cec1f7ef2335", "Thời trang" },
                    { "3c53147e-978f-4bcd-8d01-3bc79a82be7a", "Khác" },
                    { "3fca78bd-8a29-4b24-a05c-1ff1c22f8f30", "Logistics - Vận tải" },
                    { "48af0c05-2d8b-4e69-8831-451fda2074a6", "Internet / Online" },
                    { "4fb45c32-06bb-41b6-a23a-918e1a4476ed", "Môi trường" },
                    { "529d3fb7-a8f6-4934-b0a7-ac5279e6f6d9", "Nhà hàng / Khách sạn" },
                    { "55097fa7-37dc-4543-89d9-71163b9925b7", "Tổ chức phi lợi nhuận" },
                    { "579349bc-1c68-4d97-865c-1c031ea28b5e", "Agency (Design/Development)" },
                    { "61cfb329-89dd-4478-a598-5d9cba6463ef", "Bán lẻ - Hàng tiêu dùng - FMCG" },
                    { "634068de-5520-4275-a9e6-59133ba7752b", "Bảo trì / Sửa chữa" },
                    { "635671d8-90fb-484c-933f-62e379d1b785", "Marketing / Truyền thông / Quảng cáo" },
                    { "66b6f872-f160-4940-a909-bd40abb7e26b", "Giải trí" },
                    { "68e3e663-b191-4153-8af5-d4ab818c77a9", "Sản xuất" },
                    { "6e0095f4-9362-4811-a060-b514ae7326f1", "Thiết kế / kiến trúc" },
                    { "7cf93f3b-09d3-4ef4-8b2f-1a173eb373a8", "Kế toán / Kiểm toán" },
                    { "8c4b6de5-9517-45da-be11-15f4803f05f9", "Nhân sự" },
                    { "8cf6b451-5de3-4554-bdd7-1d7bec9950fe", "Tài chính" },
                    { "8e006e30-0d8f-41e6-b4fe-1648a384b31d", "Thương mại điện tử" },
                    { "90f41f43-7ed5-40e0-b45d-4d4054340174", "Tự động hóa" },
                    { "959382b7-b16a-4fa0-895b-8d0afc28f7aa", "Viễn thông" },
                    { "9669a09a-b7fc-4d79-a49e-285447a9453d", "Năng lượng" },
                    { "98fa1870-b498-4108-8874-72a774ec819e", "Nông Lâm Ngư nghiệp" },
                    { "993973b9-f3a4-41bc-8461-e972b7908b15", "Cơ quan nhà nước" },
                    { "9ca23b7a-1d47-4302-984a-bd006f20bdde", "Bất động sản" },
                    { "a0830159-428d-4afb-9077-a3a6182ed5d7", "Luật" },
                    { "a46e13ee-79f2-4139-8b89-c4c735d1d26b", "Điện tử / Điện lạnh" },
                    { "bfc38323-d3ea-4e70-8227-85680d857148", "Chứng khoán" },
                    { "dd47f0b0-1f36-453b-8002-b46c52bd42ac", "Xuất nhập khẩu" },
                    { "e36b81ec-133a-4266-a361-5be9c966deb1", "Dược phẩm / Y tế / Công nghệ sinh học" },
                    { "f644f6bc-8839-427c-ad8f-c54e41677673", "IT - Phần mềm" },
                    { "f75b98a6-d0f8-4792-8170-285a346f6c97", "IT - Phần cứng" }
                });

            migrationBuilder.InsertData(
                table: "JobForm",
                columns: new[] { "Id", "Form" },
                values: new object[,]
                {
                    { "07d770fc-78f4-45b9-8eb9-bc15b17368ba", "Toàn thời gian" },
                    { "3450b758-5088-47c8-b76c-ed7ba7102855", "Bán thời gian" },
                    { "59fe992d-73a8-4bd3-9d41-f61b86eb6841", "Tất cả hình thức" },
                    { "63fda7c2-208f-4b8d-8772-50c96f5b472b", "Thực tập" }
                });

            migrationBuilder.InsertData(
                table: "JobPosition",
                columns: new[] { "Id", "Position" },
                values: new object[,]
                {
                    { "23bb90c5-6299-4b82-8407-47f69cbe5b5f", "Tất cả vị trí" },
                    { "397bc036-c640-42a3-b1a6-23a7826ce4d6", "Trưởng chi nhánh" }
                });

            migrationBuilder.InsertData(
                table: "JobPosition",
                columns: new[] { "Id", "Position" },
                values: new object[,]
                {
                    { "69719a85-b144-4a20-81c8-eb8f8bfc55c0", "Giám đốc" },
                    { "84623099-ba62-422f-abdd-d6d67cee2202", "Thực tập sinh" },
                    { "ac4070ad-1674-47c3-9647-3193299169ec", "Trưởng / Phó phòng" },
                    { "b55dad99-e7ab-406a-9832-c2815021151e", "Nhân viên" },
                    { "c56d8e4f-c485-4371-8d3c-23cc5a798732", "Trưởng nhóm" },
                    { "e17f6107-a2d2-43f4-a21e-9b5c18e1f72a", "Quản lí / Giám sát" },
                    { "f6a82bf8-950a-45ca-b8a6-097732514c97", "Phó giám đốc" }
                });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "03a4ca12-1c82-4cf9-9550-55b0a15c9b0f", "Điện Biên" },
                    { "047ebc49-bc1e-46e8-a9c7-7437ae978be5", "Lào Cai" },
                    { "0cb01ac3-2b66-44d9-b15d-5043e894a12a", "Quảng Ngãi" },
                    { "0f77d850-9b56-445d-8241-fd515d46fe2a", "Sóc Trăng" },
                    { "137236a9-127b-4278-bf14-3290608dda4d", "Bình Thuận" },
                    { "150a649c-1989-4f54-aa05-76c717e865c7", "Quảng Trị" },
                    { "1716dd0b-bc3f-401b-ba29-84ce5d723c4a", "Đắk Nông" },
                    { "19778baf-a945-4557-b1bb-4fa9c812218d", "Nghệ An" },
                    { "1c3f69e9-b066-4d8c-964c-c1cf1a1d6aad", "Khánh Hòa" },
                    { "1d7118c8-bf1c-4f97-b76f-6cde6239f746", "Hậu Giang" },
                    { "2105b854-b816-43b0-8927-b499838f881c", "Thanh Hóa" },
                    { "2bd79b99-97c4-4087-a764-5844d1c4c5f1", "Quảng Bình" },
                    { "2fa49c23-2c0c-4d59-82f0-184adca874d5", "Hà Tĩnh" },
                    { "357bc9d9-93fe-4ea7-be5a-6bd95607b619", "Đắk Lắk" },
                    { "3926fe84-684d-42e7-8a14-716ca3de1cd6", "Cao Bằng" },
                    { "3af14e73-d5b5-4c49-85b4-8bef7bc2fb62", "Trà Vinh" },
                    { "3efcf44a-c8f6-49a9-85ba-48133b18f548", "Tất cả tỉnh thành" },
                    { "483eef89-c48f-40ee-b8d2-342a4fbd8bca", "Hồ Chí Minh" },
                    { "4cb2d706-6cd6-44cc-83a3-4977dae2b804", "Hưng Yên" },
                    { "5d1607f6-b336-412e-a5e9-c00bbe88c75a", "Lai Châu" },
                    { "63b7f601-15ec-4e5b-81bf-b5b8c6ebb6f7", "Ninh Thuận" },
                    { "641a9f5e-768c-4986-9663-d5f942ce83d6", "Hà Nam" },
                    { "6e373976-e714-42b8-9c94-82557a6737db", "Bắc Kạn" },
                    { "73857c60-bdd3-477f-8af8-e5d672cf58cf", "Tây Ninh" },
                    { "7425aa25-cb81-4a2c-abbd-a8d9b81d86bc", "Ninh Bình" },
                    { "768e6c76-aebc-444a-91c6-c912114d89df", "Phú Thọ" },
                    { "79d4dce5-71a8-426e-b0ee-276322a8d0ab", "Bình Phước" },
                    { "7bfcadfd-70b5-4a17-bf55-43c170eddaf1", "Bà Rịa-Vũng Tàu" },
                    { "7c8b9acf-5e6a-4fec-a781-c7e7f8fe2080", "Quảng Ninh" },
                    { "7d6215b4-23dd-436a-b971-65734bd74858", "Bến Tre" },
                    { "8557b516-9216-4701-ad25-2a78aa97cd8e", "Yên Bái" },
                    { "8557d0d1-1e9b-430d-a098-1820a10c4ac4", "Tiền Giang" },
                    { "8a8c80c4-7c90-4938-ad07-9043b4ca08e5", "Cần Thơ" },
                    { "8a97e72f-212c-4738-aae7-3003071f1b52", "Đồng Nai" },
                    { "9409bec3-477f-4f5f-ba3b-799ee3ac4146", "Hòa Bình" }
                });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "a3beca12-0e7e-496d-b346-ea782e2fcb9e", "Cà Mau" },
                    { "a44223aa-8400-4cb2-9e4b-dc4db06cd19a", "An Giang" },
                    { "a5d7a494-5e60-43e5-a71d-46e0096b6172", "Vĩnh Long" },
                    { "a63c8561-40c6-424d-b692-ab29004c6a09", "Đà Nẵng" },
                    { "aad518d9-189b-498d-a9b6-a87dd4f3bfce", "Bình Định" },
                    { "aaea1bac-2496-4701-a885-60d440189459", "Thừa Thiên Huế" },
                    { "b9432b9c-8f1d-422b-a480-57bfe4ce7f0f", "Kon Tum" },
                    { "bca985d6-9dfb-4c04-b40f-7dd550c5409a", "Bắc Giang" },
                    { "bcb898a0-4303-4f4c-92bc-9f68ea5f3236", "Gia Lai" },
                    { "c13cf10e-9edf-4a72-a8bd-8b1a8d8d29b3", "Bạc Liêu" },
                    { "c1c19577-8361-43fd-9fb1-5aca00b3eeb1", "Nam Định" },
                    { "c2d26d1f-b79a-4781-ad9f-6eb8ec1c0e95", "Kiên Giang" },
                    { "c34a104a-7ce0-4d87-9113-edaf3645ae11", "Thái Bình" },
                    { "c9883530-28d5-46fc-b0aa-685d4b7cabc1", "Hải Dương" },
                    { "cd24b299-505b-4c28-b9e7-5f705e1619e9", "Bình Dương" },
                    { "cdfa11da-e819-485f-8bb5-e6ac9c8a0f7a", "Đồng Tháp" },
                    { "cfc05193-19dc-44fd-a9ab-e15308cf5961", "Hải Phòng" },
                    { "d08e6151-1d39-4688-8c34-4700c3dc3769", "Thái Nguyên" },
                    { "d1b382e8-8392-4b96-bf87-ba76ee6f45b2", "Lâm Đồng" },
                    { "d24eba48-3454-414e-9b8c-9a3da5ed4030", "Hà Nội" },
                    { "d463bdb5-065e-4f52-97bf-0a7d44f36f88", "Phú Yên" },
                    { "d8c3a7fc-5fc7-46e8-bc9d-ba0062ba0dea", "Hà Giang" },
                    { "dbdce3d4-498e-4094-b3d7-36ff8889d361", "Lạng Sơn" },
                    { "dbebcea2-0444-4268-bc93-308bca4b2321", "Bắc Ninh" },
                    { "ea01ea20-edc6-4538-baee-e14813d17c7b", "Long An" },
                    { "ef2d715a-62ff-464d-a75f-3a21a1be2e7b", "Tuyên Quang" },
                    { "f2f21880-ca59-4da1-9bdf-ecc0b6a256a8", "Vĩnh Phúc" },
                    { "f4cfd558-8750-407a-a03f-0f1f85437e85", "Quảng Nam" },
                    { "f9f107c6-31fc-4eb0-86fb-86e89882ed7a", "Sơn La" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { "70d8029e-8712-4c27-bfac-48a782d48e89", "Employer" },
                    { "aa056cb6-b09a-4b54-baa7-d521e960f680", "Candidate" },
                    { "c3f29154-4fa9-4599-8f6e-01929e08f88d", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Avatar", "DateOfBirth", "Discriminator", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { "500d6cf7-c6e3-486a-80c8-ccfb127110e5", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Candidate", "cvlookup.sgu.2023_candidate@gmail.com", "Admin", "CVLookup", null });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Address", "Avatar", "Description", "Discriminator", "Email", "EmployerName", "PhoneNumber" },
                values: new object[] { "76a4ff35-1c25-42f9-a1d3-aceaaaef9702", "Admin", null, "Admin", "Employer", "cvlookup.sgu.2023_employer@gmail.com", "Admin", null });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Avatar", "Discriminator", "Email", "PhoneNumber" },
                values: new object[] { "4b1fe8df-b822-4027-8d5b-3a8dc0cdc9d2", null, "User", "cvlookup.sgu.2023@gmail.com", null });

            migrationBuilder.InsertData(
                table: "AccountUser",
                columns: new[] { "AccountId", "UserId" },
                values: new object[,]
                {
                    { "4d389fd9-8fc5-48de-9ccb-f03349c01387", "76a4ff35-1c25-42f9-a1d3-aceaaaef9702" },
                    { "8b13468c-296c-4866-9497-275806874d0c", "4b1fe8df-b822-4027-8d5b-3a8dc0cdc9d2" },
                    { "cf6b30f3-7e26-494f-8451-66463024d6c7", "500d6cf7-c6e3-486a-80c8-ccfb127110e5" }
                });

            migrationBuilder.InsertData(
                table: "District",
                columns: new[] { "Id", "Name", "ProvinceId" },
                values: new object[,]
                {
                    { "04dae6b3-d55a-43b9-8d71-2128c9089d09", "Quận Ngô Quyền", "cfc05193-19dc-44fd-a9ab-e15308cf5961" },
                    { "091a5db6-68d3-48c8-b662-a553c9a8aeb6", "Quận Nam Từ Liêm", "d24eba48-3454-414e-9b8c-9a3da5ed4030" },
                    { "1876e40d-fc2e-4bb0-b36c-472a5d06aa39", "Quận 6", "483eef89-c48f-40ee-b8d2-342a4fbd8bca" },
                    { "19a1785b-25a3-482e-87b4-1409a66faf35", "Quận 12", "483eef89-c48f-40ee-b8d2-342a4fbd8bca" },
                    { "1c6c5440-80f2-42af-86ae-507c1c7d4654", "Quận 4", "483eef89-c48f-40ee-b8d2-342a4fbd8bca" },
                    { "222f82f3-44d3-4dae-94c7-eb3200328134", "Quận Bắc Từ Liêm", "d24eba48-3454-414e-9b8c-9a3da5ed4030" },
                    { "250945e0-7bc2-4498-ac39-f0d561e47991", "Quận Kiến An", "cfc05193-19dc-44fd-a9ab-e15308cf5961" },
                    { "33258369-3b43-4446-9af7-069b8f11c784", "Quận Tân Phú", "483eef89-c48f-40ee-b8d2-342a4fbd8bca" },
                    { "39ef0e44-ad70-4987-a02c-c63388cf85d4", "Quận Thanh Khê", "a63c8561-40c6-424d-b692-ab29004c6a09" },
                    { "3d860825-fb3c-41e5-afb3-74da915d7bf7", "Quận 8", "483eef89-c48f-40ee-b8d2-342a4fbd8bca" },
                    { "3e1a6812-dc3e-4fa9-980c-4647e212233f", "Quận Ngũ Hành Sơn", "a63c8561-40c6-424d-b692-ab29004c6a09" },
                    { "44adacce-4b97-444f-bb6e-c852e0f0b968", "Quận Bình Tân", "483eef89-c48f-40ee-b8d2-342a4fbd8bca" },
                    { "4963219e-e36e-42e5-889d-b7715cd5ada5", "Quận 9", "483eef89-c48f-40ee-b8d2-342a4fbd8bca" },
                    { "4a304c7e-ecf4-4728-9595-7d73fe2f0b59", "Quận Liên Chiểu", "a63c8561-40c6-424d-b692-ab29004c6a09" },
                    { "53d6aa59-580b-4db8-9522-b1391d95c9be", "Quận Ô Môn", "8a8c80c4-7c90-4938-ad07-9043b4ca08e5" },
                    { "5630e935-2e66-448c-bed9-fa5b083dc1c2", "Quận Bình Thạnh", "483eef89-c48f-40ee-b8d2-342a4fbd8bca" },
                    { "5a17b5b5-9fa4-4e67-9b07-c098ae575cf4", "Quận Hai Bà Trưng", "d24eba48-3454-414e-9b8c-9a3da5ed4030" },
                    { "5a69000c-8530-4ee6-a5f1-9d6ebbc0036c", "Quận Lê Chân", "cfc05193-19dc-44fd-a9ab-e15308cf5961" },
                    { "5bf2a5ae-d9e6-4584-bf3e-2958bd9b2ae7", "Quận Hoàng Mai", "d24eba48-3454-414e-9b8c-9a3da5ed4030" },
                    { "608676ed-b570-4c2f-93fc-25519d1604af", "Quận Ba Đình", "d24eba48-3454-414e-9b8c-9a3da5ed4030" },
                    { "66b9d244-a767-4c81-a576-ead3719053eb", "Quận Phú Nhuận", "483eef89-c48f-40ee-b8d2-342a4fbd8bca" },
                    { "78b7939d-ee36-4bf6-86ff-e243a9531a45", "Quận Hà Đông", "d24eba48-3454-414e-9b8c-9a3da5ed4030" },
                    { "7969cda7-250d-49ab-b70c-3e1eb167c049", "Quận 11", "483eef89-c48f-40ee-b8d2-342a4fbd8bca" },
                    { "7f6a3d29-5516-45cb-ab81-c1233055757c", "Quận Gò Vấp", "483eef89-c48f-40ee-b8d2-342a4fbd8bca" },
                    { "80bd08e8-f0fd-4a35-a53f-ed3cb1ee8548", "Quận Tân Bình", "483eef89-c48f-40ee-b8d2-342a4fbd8bca" },
                    { "83cdb61e-f89b-43e4-b3c4-1c09235d109a", "Quận Hồng Bàng", "cfc05193-19dc-44fd-a9ab-e15308cf5961" },
                    { "8518bd0e-0c38-4f8b-905f-23c6b1661720", "Quận 7", "483eef89-c48f-40ee-b8d2-342a4fbd8bca" },
                    { "95808b51-c979-450c-b68d-00bbe69161db", "Quận Cẩm Lệ", "a63c8561-40c6-424d-b692-ab29004c6a09" },
                    { "9be4b1e5-8a8b-411a-9e74-8090e60137e9", "Quận Ninh Kiều", "8a8c80c4-7c90-4938-ad07-9043b4ca08e5" },
                    { "9f74651c-1861-4881-b150-986a26ffa479", "Quận Thủ Đức", "483eef89-c48f-40ee-b8d2-342a4fbd8bca" },
                    { "a2446493-5bdc-4bee-9a0f-eab9e5c33e76", "Quận Cầu Giấy", "d24eba48-3454-414e-9b8c-9a3da5ed4030" },
                    { "a31ba144-ecd4-46a5-9308-526d462ef585", "Quận Tây Hồ", "d24eba48-3454-414e-9b8c-9a3da5ed4030" },
                    { "a5f8affa-7c03-482f-910a-76bc0d862e9a", "Quận Cái Răng", "8a8c80c4-7c90-4938-ad07-9043b4ca08e5" },
                    { "a69385d9-68d4-48f0-86d0-452fa45dc7ae", "Quận Đồ Sơn", "cfc05193-19dc-44fd-a9ab-e15308cf5961" },
                    { "a9411e73-dd2f-4b76-9c2f-7243ef7ad913", "Quận Dương Kinh", "cfc05193-19dc-44fd-a9ab-e15308cf5961" },
                    { "ac39f704-5b85-4732-8fcb-5038fefc73f1", "Quận Long Biên", "d24eba48-3454-414e-9b8c-9a3da5ed4030" },
                    { "bace4f52-494e-4ce5-8df0-ae1f98e633a8", "Quận Bình Thuỷ", "8a8c80c4-7c90-4938-ad07-9043b4ca08e5" },
                    { "bd1e8255-d611-424c-8bbf-a7f679867456", "Quận Hoàn Kiếm", "d24eba48-3454-414e-9b8c-9a3da5ed4030" },
                    { "cda16552-d099-455c-bdbe-301f02a4b27a", "Quận Thốt Nốt", "8a8c80c4-7c90-4938-ad07-9043b4ca08e5" }
                });

            migrationBuilder.InsertData(
                table: "District",
                columns: new[] { "Id", "Name", "ProvinceId" },
                values: new object[,]
                {
                    { "ce254d5f-8ba9-400b-8a79-b7eeec55bfb9", "Quận 10", "483eef89-c48f-40ee-b8d2-342a4fbd8bca" },
                    { "cfba9a0b-2ef0-448c-98ce-89ccfd4da93f", "Quận Sơn Trà", "a63c8561-40c6-424d-b692-ab29004c6a09" },
                    { "da632b08-cd76-4214-b734-c390e6d15302", "Quận Đống Đa", "d24eba48-3454-414e-9b8c-9a3da5ed4030" },
                    { "daa901b8-532f-4114-9e2e-403da6e543e0", "Quận 2", "483eef89-c48f-40ee-b8d2-342a4fbd8bca" },
                    { "dbd866b0-2350-4fa1-b5ab-2979139af7e8", "Quận Hải Châu", "a63c8561-40c6-424d-b692-ab29004c6a09" },
                    { "dc976aa4-b702-4332-b709-6050eacbb9c8", "Quận Thanh Xuân", "d24eba48-3454-414e-9b8c-9a3da5ed4030" },
                    { "e23fa99a-25cf-4d6e-94dd-45627774405c", "Quận 5", "483eef89-c48f-40ee-b8d2-342a4fbd8bca" },
                    { "e5dd1cc6-b360-4527-8428-4b5e371ccb49", "Quận 3", "483eef89-c48f-40ee-b8d2-342a4fbd8bca" },
                    { "e7b71d96-826b-400f-a393-e5080c96f28b", "Quận Hải An", "cfc05193-19dc-44fd-a9ab-e15308cf5961" },
                    { "fbe3abdb-e1bb-4acf-a88b-c8fcfea3de6e", "Quận 1", "483eef89-c48f-40ee-b8d2-342a4fbd8bca" }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "70d8029e-8712-4c27-bfac-48a782d48e89", "76a4ff35-1c25-42f9-a1d3-aceaaaef9702" },
                    { "aa056cb6-b09a-4b54-baa7-d521e960f680", "500d6cf7-c6e3-486a-80c8-ccfb127110e5" },
                    { "c3f29154-4fa9-4599-8f6e-01929e08f88d", "4b1fe8df-b822-4027-8d5b-3a8dc0cdc9d2" }
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
                name: "RecruitmentCV");

            migrationBuilder.DropTable(
                name: "Token");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "CurriculumVitae");

            migrationBuilder.DropTable(
                name: "Recruitment");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Role");

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
