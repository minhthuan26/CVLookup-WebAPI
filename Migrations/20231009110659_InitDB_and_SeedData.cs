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
                    ProvinceId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_District", x => x.Id);
                    table.ForeignKey(
                        name: "FK_District_Province_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Province",
                        principalColumn: "Id");
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
                name: "JobAddress",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AddressDetail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinceId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DistrictId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobAddress_District_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "District",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobAddress_Province_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Province",
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
                    { "0f5a098a-5c7a-4b0b-95af-dc8a6bdba1b0", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cvlookup.sgu.2023_employer@gmail.com", new DateTime(2023, 10, 9, 18, 6, 59, 403, DateTimeKind.Local).AddTicks(1270), "4EvS5r40usEAzXH5nw6YyjfVVpQdHt7K+e7DBWXhKPKdrduCQ6W3M3Ala03/Tw8kFhLEGxHwealuxejQLZqg0y4nsngohze7rnldfpPHQ1Y=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "280e5e72-a62c-49c9-8e7e-b44842ab2acf", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cvlookup.sgu.2023_candidate@gmail.com", new DateTime(2023, 10, 9, 18, 6, 59, 403, DateTimeKind.Local).AddTicks(1275), "4EvS5r40usEAzXH5nw6YyjfVVpQdHt7K+e7DBWXhKPKdrduCQ6W3M3Ala03/Tw8kFhLEGxHwealuxejQLZqg0y4nsngohze7rnldfpPHQ1Y=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "33ba4ec9-fbbf-4d3c-a806-45c816a6fa40", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cvlookup.sgu.2023@gmail.com", new DateTime(2023, 10, 9, 18, 6, 59, 403, DateTimeKind.Local).AddTicks(1250), "4EvS5r40usEAzXH5nw6YyjfVVpQdHt7K+e7DBWXhKPKdrduCQ6W3M3Ala03/Tw8kFhLEGxHwealuxejQLZqg0y4nsngohze7rnldfpPHQ1Y=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Experience",
                columns: new[] { "Id", "Exp" },
                values: new object[,]
                {
                    { "16f95d27-e5b9-4f7c-b79a-d1f3bc208d22", "Dưới 1 năm" },
                    { "36776cf7-935e-4c3d-96e9-d76208875e15", "Tất cả kinh nghiệm" },
                    { "6e7abc90-fd1a-4bf7-b3ec-a8a95a50bad4", "Trên 10 năm" },
                    { "7a869599-f2dc-48b6-83ed-3cfde18b2603", "Chưa có kinh nghiệm" },
                    { "a0a2acf9-fbe8-45a5-a499-8ee19eb414f0", "Từ 5-10 năm" },
                    { "b8b2fa0a-271b-4030-8583-6919fa247662", "Từ 2-3 năm" },
                    { "c88a8c53-3a08-4ca9-a755-68a4e62ab221", "Từ 1-2 năm" },
                    { "f98830a1-bac9-483a-a2d8-0f097cc395c6", "Từ 3-5 năm" }
                });

            migrationBuilder.InsertData(
                table: "JobCareer",
                columns: new[] { "Id", "Career" },
                values: new object[,]
                {
                    { "0176c9be-06df-410d-a7ce-ff9d7ea8f6d3", "Điện tử viễn thông" },
                    { "04e88e82-8ad5-4d1e-9a35-a06d802a94d0", "Nhân sự" },
                    { "0808697e-dae7-4eba-9794-178ad3e01856", "Thiết kế nội thất" },
                    { "0831dca0-ca55-4c24-9ac3-ed773b8394a5", "Hàng cao cấp" },
                    { "0dc765e1-4a05-4ce4-9918-61ca15d4af75", "Xây dựng" },
                    { "0e2b135a-b963-4615-9f46-228a857d5801", "Cơ khí / Chế tạo / Tự động hóa" },
                    { "13b0fd37-8048-4a17-8c39-f5085139364a", "Hàng tiêu dùng" },
                    { "18a66050-e797-45d9-9673-478be96367e3", "Quản lý chất lượng (QA/QC)" },
                    { "1d9ea4e8-31f0-4dc7-b56d-56a85c98966a", "Sản phẩm công nghiệp" },
                    { "1f511407-d491-4539-905b-dcb8e449ed00", "Hành chính / Văn phòng" },
                    { "21a25a3f-07ba-4305-9cff-52d5d4e3947f", "Quản lý điều hành" },
                    { "23f50555-84b6-4319-821e-ebecc48a2b33", "Tư vấn" },
                    { "275e979f-2df0-49ad-89a0-34da9e2d66a0", "Bảo trì / Sửa chữa" },
                    { "289870ea-2021-4f6b-9740-e6b6f19f4bd2", "Kiến trúc" },
                    { "2a02a5a9-0b6a-4a88-92dd-952afe3fb2cf", "Giáo dục / Đào tạo" },
                    { "2a21c955-ce63-45e4-bd54-890c8ebbd7ab", "Môi trường / Xử lý chất thải" },
                    { "3e61bc18-dfac-4381-be0a-8f8c581c1dca", "Logistics" },
                    { "4c575d7a-a1c8-48ef-945b-5b298dbc9065", "Thời trang" },
                    { "52b420b7-2c6c-425b-b494-e168d7c78df6", "Phi chính phủ / Phi lợi nhuận" },
                    { "558abb40-4b8f-4e73-a70c-9edb615bdbaf", "Thực phẩm / Đồ uống" },
                    { "55a17258-1ae2-4e1c-ac9a-70a6c020a632", "Bán hàng kỹ thuật" },
                    { "581b0306-e58a-4abc-97bb-f43a4c7a5636", "Công nghệ cao" },
                    { "5896b9c4-88a9-42a2-885f-7426597447e6", "Luật / Pháp lý" },
                    { "5f7079e4-56bd-4817-a687-9e11353fd895", "Nông / Lâm / Ngư nghiệp" },
                    { "5f7557f9-cc10-4d4c-ab53-158aad162a0a", "Điện / Điện tử / Điện lạnh" },
                    { "5f76347c-d027-4f25-8b63-e3897e69f8e4", "Hoá học / Sinh học" },
                    { "62abbd5d-450c-4fb0-8f7c-814cb934a88d", "Dược phẩm / Công nghệ sinh học" },
                    { "63ab4646-f29a-4312-98f0-41e1afb0dcc9", "Dịch vụ khách hàng" },
                    { "66a7e467-2858-4419-8afe-9857a083d995", "Chứng khoán / Vàng / Ngoại tệ" },
                    { "6db37876-3cbd-405b-ac50-5e6a9daf3cd2", "Du lịch" },
                    { "6f661fb2-1e0d-4961-96eb-540d95ac139b", "Địa chất / Khoáng sản" }
                });

            migrationBuilder.InsertData(
                table: "JobCareer",
                columns: new[] { "Id", "Career" },
                values: new object[,]
                {
                    { "79622f86-923a-4025-85d7-d2effe331311", "Công nghệ Ô tô" },
                    { "7b0391ba-3d06-4a1f-9142-5ac9005bdd86", "Dầu khí/Hóa chất" },
                    { "7cdd803d-98fa-4f4c-aa0b-7fcd1659d20d", "Khách sạn / Nhà hàng" },
                    { "833a5064-3817-44ff-9ba8-d9d02fe684b9", "Thiết kế đồ họa" },
                    { "8b112e3f-3cfc-4acf-84c0-0c4e583f498a", "Bất động sản" },
                    { "8d802f05-b88d-491d-a313-4fbd43c7351d", "Bán lẻ / bán sỉ" },
                    { "93281555-5c78-4897-8f50-87697e8bd6dc", "Bảo hiểm" },
                    { "940cf5c8-3e4d-4bce-8892-4e387917827f", "Tổ chức sự kiện / Quà tặng" },
                    { "94b671d4-0be6-409a-9481-bb4c4bfa9630", "IT phần mềm" },
                    { "982bc6fd-b987-4c24-a94e-9100df11b737", "Hàng gia dụng" },
                    { "9e2cd06a-fff4-440a-84bb-734828a26143", "Tài chính / Đầu tư" },
                    { "a6b90420-cba7-45d4-bb48-e9c40f94aaea", "An toàn lao động" },
                    { "aaf1ed97-167c-46bc-b662-d220be12a60c", "Mỹ phẩm / Trang sức" },
                    { "b1e13567-5bd6-427a-b951-4de88915c688", "Marketing / Truyền thông / Quảng cáo" },
                    { "b401f385-88e6-4156-b15b-4525bcca7dcd", "Mỹ thuật / Nghệ thuật / Điện ảnh" },
                    { "ba264947-c504-4937-bee7-f7bb68b997bf", "Tất cả ngành nghề" },
                    { "bad756e7-a5f3-41a8-aa01-4791ab6244ba", "Hoạch định / Dự án" },
                    { "bfe3b6f8-c66f-4290-8a3d-90d72a955d9a", "NGO / Phi chính phủ / Phi lợi nhuận" },
                    { "c430f00a-0cab-468c-a3cc-035ccbed6852", "Ngân hàng / Tài chính" },
                    { "cbbb8b5b-41a7-4e70-aadd-5615aa7c4f52", "Ngành nghề khác" },
                    { "cbee0006-eb94-46ca-8a80-90c150543107", "Thư ký / Trợ lý" },
                    { "ce7ce54f-917a-41ab-a5ec-b5f4c630257c", "Biên / Phiên dịch" },
                    { "ce7fd462-68c9-45eb-9261-c07946691dab", "Y tế / Dược" },
                    { "d06f4cf2-3f76-486a-a80a-099ca34c179c", "Kế toán / Kiểm toán" },
                    { "d3364abd-f53e-421e-b432-9c10a432a4f1", "Bưu chính - Viễn thông" },
                    { "d827e261-2891-474b-84f6-9c4fa0e8d3af", "In ấn / Xuất bản" },
                    { "d9132219-a4e8-433a-8af2-62eca627d605", "Hàng không" },
                    { "e5e3cb14-d4b3-4f66-8c15-e881f6895430", "Xuất nhập khẩu" },
                    { "e8806ebc-e6d6-4f17-88c0-1b277eac4031", "Hàng hải" },
                    { "e8808e0b-7bd7-4f4d-b88f-a5780b9f5b30", "Công nghệ thông tin" },
                    { "ea2aeffb-9a99-4bca-9353-6902195240e2", "Spa / Làm đẹp" },
                    { "ec486182-affe-41d4-a01b-b810b4a49d9c", "IT Phần cứng / Mạng" },
                    { "eef5210b-7fd6-43ec-867e-ff207d2804fa", "Sản xuất" },
                    { "f1b7e519-24e7-4b26-bdc2-c7d3f24dcc53", "Kinh doanh / Bán hàng" },
                    { "f5146228-507a-4e8b-8935-f807f78494b9", "Dệt may / Da giày" },
                    { "f8f1d3db-2d59-41ea-ab2e-ec99d0cee089", "Vận tải / Kho vận" },
                    { "f92a41db-d020-49d9-8d64-2b453dd6d1d1", "Báo chí / Truyền hình" }
                });

            migrationBuilder.InsertData(
                table: "JobField",
                columns: new[] { "Id", "Field" },
                values: new object[,]
                {
                    { "00561e36-0ab4-4d51-a02e-6f6c7d4df039", "Du lịch" },
                    { "18061e67-d1a6-4bd8-bf0d-3f87d638e8df", "Khác" },
                    { "1ddbaf9c-9cd2-4505-994b-b89683313d2b", "Viễn thông" },
                    { "218078f2-3667-4ab7-b446-851de11bdb88", "Kế toán / Kiểm toán" },
                    { "23641674-3f54-485a-8015-4408c8c9f234", "Cơ khí" }
                });

            migrationBuilder.InsertData(
                table: "JobField",
                columns: new[] { "Id", "Field" },
                values: new object[,]
                {
                    { "30bba1f1-a7a0-4f5d-adef-02c66fcb63d7", "Luật" },
                    { "3625aef5-b62c-4f4f-b356-78b38aa46218", "IT - Phần cứng" },
                    { "36e5638f-89db-4fc5-802d-fd621a363ca0", "Marketing / Truyền thông / Quảng cáo" },
                    { "38e29d25-11f2-4d16-ace1-40e0cb3163af", "Tài chính" },
                    { "39b5acb7-455f-46a9-b640-b87f59a1d6ea", "Bảo trì / Sửa chữa" },
                    { "4e2d10ce-95cd-40f9-9c56-fb2e2242a7a5", "Thương mại điện tử" },
                    { "4ff641c7-1792-4fda-9670-bb58f9fc62ae", "Bán lẻ - Hàng tiêu dùng - FMCG" },
                    { "504a9700-0877-4278-8bf1-6ce557c9a1ba", "Cơ quan nhà nước" },
                    { "59a4a776-bc0a-4309-ba01-72f917b11222", "Tư vấn" },
                    { "5b05f04e-fe17-4fe0-86d5-af4b7022f592", "Giáo dục / Đào tạo" },
                    { "5fe0ceae-1e96-4b37-a730-e2deb04ac57e", "In ấn / Xuất bản" },
                    { "71ff2896-8da6-47cb-ad5f-a83f7e647032", "Bảo hiểm" },
                    { "766f1e1e-5a42-47a7-abbf-7df1ad309965", "Chứng khoán" },
                    { "7b56c84d-f468-4ac4-9442-47b4e0890cd6", "Môi trường" },
                    { "7dd5f3c3-c788-4bab-9325-99ad14aad5a8", "Sản xuất" },
                    { "8049a3c8-159e-4f0b-b1c3-18bf10396dcd", "Tổ chức phi lợi nhuận" },
                    { "887b25fb-0012-4113-863d-8f57e225798a", "Internet / Online" },
                    { "8ca3c201-ed61-4f72-8bc4-a47f242d8b83", "Tất cả lĩnh vực" },
                    { "93a2196d-c17e-4919-90af-2bc8200e2a9c", "Tự động hóa" },
                    { "991513af-0bc0-439e-8af6-8eb2b8011ad1", "IT - Phần mềm" },
                    { "9963c8e7-f960-4856-9991-a4a213c3cb8f", "Xây dựng" },
                    { "af06ef24-ca2d-4ee9-bb04-26030d1bc04e", "Logistics - Vận tải" },
                    { "c5fb1aa2-f040-429d-9939-b22cc49509a5", "Agency (Marketing/Advertising)" },
                    { "cf9390c1-5e33-42f0-ba70-5cfd510bf1a0", "Điện tử / Điện lạnh" },
                    { "d5843946-32d1-4f1f-afc6-cb32e050ff98", "Bất động sản" },
                    { "da06b13c-b950-4cae-97fc-416d645074df", "Agency (Design/Development)" },
                    { "ddeb0dc5-124e-44f3-ab00-1794fb39eb56", "Xuất nhập khẩu" },
                    { "e53e0ef6-0876-4f46-85c3-70a77ee34654", "Nhà hàng / Khách sạn" },
                    { "e99f2cc2-df48-46b0-a25f-20c94aff5233", "Thiết kế / kiến trúc" },
                    { "ecd658f5-bda1-415d-bc45-c54c2e10bcaf", "Nông Lâm Ngư nghiệp" },
                    { "ed2b1728-fab1-4f8b-a13b-8c5701e5f7cf", "Giải trí" },
                    { "ef25cad1-3762-4a81-acc2-b2e545204023", "Năng lượng" },
                    { "f20bc70d-2dd5-49cb-a4a4-825d7bac75de", "Dược phẩm / Y tế / Công nghệ sinh học" },
                    { "f9c507b7-78bb-4f0b-9dc9-75314359e52f", "Ngân hàng" },
                    { "fbe83070-c09a-4938-8e68-995b43c762a9", "Thời trang" },
                    { "fd0bceac-b8f5-4f36-84ec-08a80cd2f870", "Nhân sự" }
                });

            migrationBuilder.InsertData(
                table: "JobForm",
                columns: new[] { "Id", "Form" },
                values: new object[,]
                {
                    { "06bf76e3-f80e-44df-9e91-c661ec0707ce", "Bán thời gian" },
                    { "0b897c49-6b51-4a94-8372-b3251ed14034", "Toàn thời gian" },
                    { "281912d9-adff-4871-b64a-17bc6b2768e7", "Tất cả hình thức" },
                    { "d21317e2-e1f4-489c-b9da-b25a5cc1549f", "Thực tập" }
                });

            migrationBuilder.InsertData(
                table: "JobPosition",
                columns: new[] { "Id", "Position" },
                values: new object[,]
                {
                    { "13798407-04d4-4f25-ad79-6254044f9bda", "Giám đốc" },
                    { "7c5b0f9f-a4a5-4562-bcd8-c1e434b96e50", "Thực tập sinh" }
                });

            migrationBuilder.InsertData(
                table: "JobPosition",
                columns: new[] { "Id", "Position" },
                values: new object[,]
                {
                    { "95c0b1d6-d535-4172-b822-64ed6838b0fb", "Trưởng chi nhánh" },
                    { "9652fe6a-d6aa-4810-a6d9-0cf3a745724f", "Trưởng nhóm" },
                    { "a4e10d23-95d8-48e6-bdad-b7bad392f69f", "Nhân viên" },
                    { "becd4e2b-ed75-48bd-b213-44e54b1fae61", "Tất cả vị trí" },
                    { "cd57484a-d201-4712-93a5-b5ccdcc01390", "Trưởng / Phó phòng" },
                    { "d5b614e3-ffa5-41e8-bf3b-83a78f20ee7c", "Quản lí / Giám sát" },
                    { "fc354f31-97fc-4fce-a530-2a44f7b00783", "Phó giám đốc" }
                });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "04172533-2166-4a7e-8287-b9c89a2d81c1", "Ninh Thuận" },
                    { "059c9af0-2cd1-4b3a-bcdb-c75edef5fad9", "Hà Giang" },
                    { "07bc25b1-c179-45a4-b728-cc6c2d8a9df2", "Tuyên Quang" },
                    { "0937eebe-f67b-43af-9f9f-77c5cdd014b0", "Phú Thọ" },
                    { "0d239684-dc20-41ea-acc3-4f8a7f68ead6", "Hải Phòng" },
                    { "0d7ff715-8e06-45e9-8424-bdccdcfc266f", "Sóc Trăng" },
                    { "0e8e9967-8cab-4f3f-9fba-f753e4c8c958", "Cà Mau" },
                    { "16dc3a6d-902d-4b4d-a449-0199b08d2782", "Quảng Nam" },
                    { "16e240b8-aa51-40d7-bf17-2253a33d8df3", "Bắc Kạn" },
                    { "251d7a46-c39d-4489-9341-250bf72a6f4d", "Tiền Giang" },
                    { "2adab348-36d2-4b29-a157-ee493b4c6127", "Sơn La" },
                    { "2b5f295e-b576-46d5-af70-6b926175bc53", "Khánh Hòa" },
                    { "2e8feaee-6f76-4af3-816d-0ba60ab7bcfb", "Trà Vinh" },
                    { "2f3f2353-13f6-48ef-96f8-96fb9c9939be", "Tây Ninh" },
                    { "30a9912c-5c36-4c23-8145-9dfbb9ba307d", "Kiên Giang" },
                    { "35f0e62a-1c78-41e7-89aa-bd5b3b80f08d", "An Giang" },
                    { "3afe198a-d1ce-498f-ad37-b6704c68ed6f", "Hà Nội" },
                    { "3b6a128f-156d-4bc6-b2f2-0cba45905b78", "Vĩnh Long" },
                    { "3bb8c0a0-b82e-4a71-a47f-a945e029442b", "Hưng Yên" },
                    { "42361adb-d19e-4ed5-8255-706331162e74", "Bà Rịa-Vũng Tàu" },
                    { "4c17a715-7b0d-45a0-a140-271f83c1edbd", "Bạc Liêu" },
                    { "4f4c6b8a-3577-4d2e-8349-9748f0dcd07a", "Nghệ An" },
                    { "5cbb4477-d369-4afc-9af8-ead5fe4a6104", "Điện Biên" },
                    { "5d30d59d-f492-4ea4-9b37-85f43d7f73a8", "Thái Bình" },
                    { "5e6ead12-869b-48d5-864d-a13d4c96a588", "Vĩnh Phúc" },
                    { "6223ca1b-b550-4db2-bcf8-a100f3c49be1", "Thái Nguyên" },
                    { "692cc64d-b902-42e9-afed-dbfa2cd1d28f", "Quảng Trị" },
                    { "6b14ec54-14b1-4865-ad18-2a0af7837ea3", "Lai Châu" },
                    { "6c230a0d-5b3f-4a24-8d87-e6e2356cf3ae", "Nam Định" },
                    { "6cdf7c53-42b1-47f3-9ad9-3c61ee47fb3e", "Quảng Ninh" },
                    { "732049db-e4f4-49f8-927b-804fc4a16a1b", "Phú Yên" },
                    { "76f5ce8a-ea54-431c-b442-0e29f22d7180", "Yên Bái" },
                    { "7c437a52-172e-4780-9606-c44e802960f2", "Bình Dương" },
                    { "7de1a111-7c7e-4379-974c-199d94fbe5d2", "Long An" },
                    { "82505675-1bda-471d-aef4-ccf80d0c8a66", "Hải Dương" }
                });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "89f4f74b-66fb-4d56-9edd-3bb25cd67fda", "Bắc Ninh" },
                    { "8ddf76ac-ab34-443d-9241-9c9276112078", "Cần Thơ" },
                    { "916f4248-36c0-43d0-b07c-357f58de2ac9", "Bình Thuận" },
                    { "977a33ef-a1a4-481a-8a75-32d51206177e", "Thừa Thiên Huế" },
                    { "97885809-ca5f-4946-97f6-05f85a95549f", "Đồng Tháp" },
                    { "9cd166d1-1169-4839-bd98-7d4cd1e4d745", "Hậu Giang" },
                    { "9e39e4c8-43c2-4396-ba89-993e402c534e", "Kon Tum" },
                    { "a385b3d1-a3d9-487d-8dda-0931c3ed77a0", "Bến Tre" },
                    { "a5b0e62a-42f3-4845-89c1-b294ce3b0ea5", "Quảng Bình" },
                    { "b7806adc-522f-4086-9f5c-2f401bd1c90f", "Hà Tĩnh" },
                    { "b8bf4a27-7f6a-40e7-ab4b-095da9d9b170", "Lâm Đồng" },
                    { "b9f084d9-3154-4bdb-8fc4-b826a47984ea", "Đắk Lắk" },
                    { "bb430296-b41f-4e75-9086-e3bc6999addd", "Lào Cai" },
                    { "bfeb546e-77be-458f-a3a2-5c62edda231c", "Lạng Sơn" },
                    { "c2899e3d-4fa0-49e8-ad5c-0b0dc33fbe07", "Bắc Giang" },
                    { "cd5a411e-d1e1-457c-9c9a-6cbe048f771f", "Cao Bằng" },
                    { "cd898b19-d120-4cb9-9f57-508cc876b333", "Bình Định" },
                    { "cd90b2d4-e87b-4f75-bdcc-d7ed8793eebd", "Đà Nẵng" },
                    { "d0b466ed-ff73-4f78-9c8b-412228ba7efb", "Tất cả tỉnh thành" },
                    { "d297e516-cb35-480b-bf22-774a0c78ee25", "Hà Nam" },
                    { "d30ca515-a7f3-4ef6-ba36-fb55b62db0bc", "Hồ Chí Minh" },
                    { "db1566ca-010c-4a21-a56b-039812d35a21", "Đắk Nông" },
                    { "e06b6f23-8ad1-4ef4-b0d3-8dddedd2f47a", "Bình Phước" },
                    { "e3513de1-5e0c-4db0-9923-c8be8b556720", "Gia Lai" },
                    { "ee0d56d3-b315-48e4-9f4c-e009069634e9", "Thanh Hóa" },
                    { "efe98dbf-7318-409f-b72e-2e56e4f1378f", "Hòa Bình" },
                    { "f4f58cff-9859-4b91-98eb-34a14e9dfaa0", "Ninh Bình" },
                    { "f90b1642-f8b3-4996-82d9-59a9bf461702", "Quảng Ngãi" },
                    { "fec1c769-878b-4013-b1f0-8aa913599ad7", "Đồng Nai" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { "16618d2a-15fc-4908-a250-9574b22a3897", "Admin" },
                    { "1919974e-0d95-480f-926a-10399c222d22", "Candidate" },
                    { "2f90ac56-1794-4c62-b0be-a025e7e61291", "Employer" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Avatar", "DateOfBirth", "Discriminator", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { "0d580df3-6df2-4b5e-bb48-64cebbaab088", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Candidate", "cvlookup.sgu.2023_candidate@gmail.com", "Admin", "CVLookup", null });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Address", "Avatar", "Description", "Discriminator", "Email", "EmployerName", "PhoneNumber" },
                values: new object[] { "366012b5-fe92-420e-b569-fe77e6b9248e", "Admin", null, "Admin", "Employer", "cvlookup.sgu.2023_employer@gmail.com", "Admin", null });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Avatar", "Discriminator", "Email", "PhoneNumber" },
                values: new object[] { "d39bc247-3ef6-469f-849b-56646327c29c", null, "User", "cvlookup.sgu.2023@gmail.com", null });

            migrationBuilder.InsertData(
                table: "AccountUser",
                columns: new[] { "AccountId", "UserId" },
                values: new object[,]
                {
                    { "0f5a098a-5c7a-4b0b-95af-dc8a6bdba1b0", "366012b5-fe92-420e-b569-fe77e6b9248e" },
                    { "280e5e72-a62c-49c9-8e7e-b44842ab2acf", "0d580df3-6df2-4b5e-bb48-64cebbaab088" },
                    { "33ba4ec9-fbbf-4d3c-a806-45c816a6fa40", "d39bc247-3ef6-469f-849b-56646327c29c" }
                });

            migrationBuilder.InsertData(
                table: "District",
                columns: new[] { "Id", "Name", "ProvinceId" },
                values: new object[,]
                {
                    { "03dda874-3d68-4a1d-800f-97436f833d21", "Quận Hoàn Kiếm", "3afe198a-d1ce-498f-ad37-b6704c68ed6f" },
                    { "04e88202-9bfa-46fd-8f3d-0eba266234da", "Quận Bình Thuỷ", "8ddf76ac-ab34-443d-9241-9c9276112078" },
                    { "061a88dd-1b0b-4c36-b372-6073f223877a", "Quận Long Biên", "3afe198a-d1ce-498f-ad37-b6704c68ed6f" },
                    { "0d4d37a8-82ab-4d11-9ada-ad55db806faa", "Quận Sơn Trà", "cd90b2d4-e87b-4f75-bdcc-d7ed8793eebd" },
                    { "0dea90c5-a34f-42a4-bf6b-733038b11865", "Quận Đống Đa", "3afe198a-d1ce-498f-ad37-b6704c68ed6f" },
                    { "1b2be630-6a58-43d7-9ebd-f0b7fd816c69", "Quận Ngũ Hành Sơn", "cd90b2d4-e87b-4f75-bdcc-d7ed8793eebd" },
                    { "1b424a4e-2a04-409a-b278-810e52f82937", "Quận Thủ Đức", "d30ca515-a7f3-4ef6-ba36-fb55b62db0bc" },
                    { "1cbe7ac2-4953-4929-ba9e-4a1fbcf9cbb6", "Quận Dương Kinh", "0d239684-dc20-41ea-acc3-4f8a7f68ead6" },
                    { "1d78ee62-6967-43f7-a697-8f1b2a540d04", "Quận 8", "d30ca515-a7f3-4ef6-ba36-fb55b62db0bc" },
                    { "30838ca4-4651-4224-b9a5-e68a5c956c7d", "Quận Ngô Quyền", "0d239684-dc20-41ea-acc3-4f8a7f68ead6" },
                    { "3a0847d3-f598-45ae-b020-da265b9d9ba5", "Quận Hải An", "0d239684-dc20-41ea-acc3-4f8a7f68ead6" },
                    { "3d8d0ae2-52f8-4465-b65a-422576a242e6", "Quận Ba Đình", "3afe198a-d1ce-498f-ad37-b6704c68ed6f" },
                    { "401f0480-b224-4531-b002-59aa6d5f018e", "Quận Cẩm Lệ", "cd90b2d4-e87b-4f75-bdcc-d7ed8793eebd" },
                    { "4d2b068e-1bbb-41d8-aade-6fc1a2b61ee7", "Quận Bình Tân", "d30ca515-a7f3-4ef6-ba36-fb55b62db0bc" },
                    { "4d6154b1-f8e6-4051-93d2-c36d5e9bc627", "Quận Tân Phú", "d30ca515-a7f3-4ef6-ba36-fb55b62db0bc" },
                    { "4fc60447-24f3-49d9-8e2b-457f8130e04f", "Quận Bình Thạnh", "d30ca515-a7f3-4ef6-ba36-fb55b62db0bc" },
                    { "5ad2ce86-3331-4a2f-a265-bacdcb86198a", "Quận Hai Bà Trưng", "3afe198a-d1ce-498f-ad37-b6704c68ed6f" },
                    { "5f6bf0f4-c350-4330-9983-8ad0db03f66d", "Quận Hoàng Mai", "3afe198a-d1ce-498f-ad37-b6704c68ed6f" },
                    { "67eb1b5b-29ce-4977-83e3-addf7e9b96f3", "Quận Hải Châu", "cd90b2d4-e87b-4f75-bdcc-d7ed8793eebd" },
                    { "68fcd86b-66d8-4d31-bab2-f030e9eeca89", "Quận Liên Chiểu", "cd90b2d4-e87b-4f75-bdcc-d7ed8793eebd" },
                    { "80e4e198-8ff6-4c24-868e-f9ba8e492157", "Quận 5", "d30ca515-a7f3-4ef6-ba36-fb55b62db0bc" },
                    { "8609ef08-a5b2-44a5-874b-4b06593f684e", "Quận Gò Vấp", "d30ca515-a7f3-4ef6-ba36-fb55b62db0bc" },
                    { "87c12b14-e52d-40db-89ad-d14c8c1c3fba", "Quận Tân Bình", "d30ca515-a7f3-4ef6-ba36-fb55b62db0bc" },
                    { "88bba154-f30c-47f5-94b5-0175a8ad8b63", "Quận 11", "d30ca515-a7f3-4ef6-ba36-fb55b62db0bc" },
                    { "8bbe91f6-469e-412a-8845-aac8edc8d09b", "Quận Kiến An", "0d239684-dc20-41ea-acc3-4f8a7f68ead6" },
                    { "8c7b72c3-564d-4417-903a-cd2e4cb43982", "Quận Hồng Bàng", "0d239684-dc20-41ea-acc3-4f8a7f68ead6" },
                    { "92927f1a-ae2d-4734-a106-54b27a21811c", "Quận Ninh Kiều", "8ddf76ac-ab34-443d-9241-9c9276112078" },
                    { "98327593-6f37-46b3-b2d1-9dc7c26bb615", "Quận 7", "d30ca515-a7f3-4ef6-ba36-fb55b62db0bc" },
                    { "994666da-2a22-42bd-8414-32abbafde8b7", "Quận Hà Đông", "3afe198a-d1ce-498f-ad37-b6704c68ed6f" },
                    { "9bd813dc-7ebb-479f-ae7b-91a185c2336f", "Quận 9", "d30ca515-a7f3-4ef6-ba36-fb55b62db0bc" },
                    { "a2d35d7f-7ccd-41cd-a887-ae937cca4844", "Quận Đồ Sơn", "0d239684-dc20-41ea-acc3-4f8a7f68ead6" },
                    { "ade91fdc-b619-44bb-9cc6-83875b78038b", "Quận Ô Môn", "8ddf76ac-ab34-443d-9241-9c9276112078" },
                    { "b03a1406-2cfb-47a1-86a8-42f781bb6b13", "Quận Cầu Giấy", "3afe198a-d1ce-498f-ad37-b6704c68ed6f" },
                    { "b72d7e07-3c37-4ef2-a0df-f35702023e1a", "Quận Lê Chân", "0d239684-dc20-41ea-acc3-4f8a7f68ead6" },
                    { "c014c7f9-b61d-46ca-90fe-726b0f54789d", "Quận 2", "d30ca515-a7f3-4ef6-ba36-fb55b62db0bc" },
                    { "c1907af1-00a6-4624-8102-c3390a393745", "Quận Nam Từ Liêm", "3afe198a-d1ce-498f-ad37-b6704c68ed6f" },
                    { "c2f8ee2d-c239-49e7-a133-9f04998a6bea", "Quận 6", "d30ca515-a7f3-4ef6-ba36-fb55b62db0bc" },
                    { "cc26792e-0e33-4965-a574-2d0c1decd71b", "Quận 12", "d30ca515-a7f3-4ef6-ba36-fb55b62db0bc" },
                    { "d2996998-a3ec-4ee6-99c9-a7ca92a08f77", "Quận Cái Răng", "8ddf76ac-ab34-443d-9241-9c9276112078" }
                });

            migrationBuilder.InsertData(
                table: "District",
                columns: new[] { "Id", "Name", "ProvinceId" },
                values: new object[,]
                {
                    { "d48b1533-0067-4aba-9d23-f49d06293df6", "Quận Tây Hồ", "3afe198a-d1ce-498f-ad37-b6704c68ed6f" },
                    { "d8a243df-9f32-420d-ba3a-f2ad9483de9a", "Quận Thanh Khê", "cd90b2d4-e87b-4f75-bdcc-d7ed8793eebd" },
                    { "d8f38a50-7e91-455f-b3bb-0aaa6be092b4", "Quận Thanh Xuân", "3afe198a-d1ce-498f-ad37-b6704c68ed6f" },
                    { "d93f6d52-4f42-43f2-961d-b70c2ad69833", "Quận Phú Nhuận", "d30ca515-a7f3-4ef6-ba36-fb55b62db0bc" },
                    { "db1a62e1-ced1-4670-b52e-d0357b1c7de0", "Quận 1", "d30ca515-a7f3-4ef6-ba36-fb55b62db0bc" },
                    { "de7e40b5-d7cf-4289-8884-3317971d1c7b", "Quận Thốt Nốt", "8ddf76ac-ab34-443d-9241-9c9276112078" },
                    { "e91a1a4c-0b82-4d70-b093-72a1220e874b", "Quận 4", "d30ca515-a7f3-4ef6-ba36-fb55b62db0bc" },
                    { "ea4184a5-d2bd-48d2-83b3-d01ffd3cb963", "Quận 10", "d30ca515-a7f3-4ef6-ba36-fb55b62db0bc" },
                    { "f16d55e5-1cce-4035-8179-fcc57f0726c8", "Quận 3", "d30ca515-a7f3-4ef6-ba36-fb55b62db0bc" },
                    { "f87d8618-f14d-40db-89be-ab5db52bdab3", "Quận Bắc Từ Liêm", "3afe198a-d1ce-498f-ad37-b6704c68ed6f" }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "16618d2a-15fc-4908-a250-9574b22a3897", "d39bc247-3ef6-469f-849b-56646327c29c" },
                    { "1919974e-0d95-480f-926a-10399c222d22", "0d580df3-6df2-4b5e-bb48-64cebbaab088" },
                    { "2f90ac56-1794-4c62-b0be-a025e7e61291", "366012b5-fe92-420e-b569-fe77e6b9248e" }
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
                name: "IX_JobAddress_DistrictId",
                table: "JobAddress",
                column: "DistrictId");

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
                name: "District");

            migrationBuilder.DropTable(
                name: "Province");
        }
    }
}
