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
                    { "4885e3e8-1139-4709-853e-37c4485a7019", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cvlookup.sgu.2023_candidate@gmail.com", new DateTime(2023, 11, 10, 13, 57, 52, 215, DateTimeKind.Local).AddTicks(6397), "4EvS5r40usEAzXH5nw6YyjfVVpQdHt7K+e7DBWXhKPKdrduCQ6W3M3Ala03/Tw8kFhLEGxHwealuxejQLZqg0y4nsngohze7rnldfpPHQ1Y=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "50eec808-5705-422a-9113-7c2d7d453ae9", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cvlookup.sgu.2023_employer@gmail.com", new DateTime(2023, 11, 10, 13, 57, 52, 215, DateTimeKind.Local).AddTicks(6386), "4EvS5r40usEAzXH5nw6YyjfVVpQdHt7K+e7DBWXhKPKdrduCQ6W3M3Ala03/Tw8kFhLEGxHwealuxejQLZqg0y4nsngohze7rnldfpPHQ1Y=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "7f867a5c-f440-4bcf-9328-15922f2691de", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cvlookup.sgu.2023@gmail.com", new DateTime(2023, 11, 10, 13, 57, 52, 215, DateTimeKind.Local).AddTicks(6267), "4EvS5r40usEAzXH5nw6YyjfVVpQdHt7K+e7DBWXhKPKdrduCQ6W3M3Ala03/Tw8kFhLEGxHwealuxejQLZqg0y4nsngohze7rnldfpPHQ1Y=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Experience",
                columns: new[] { "Id", "Exp" },
                values: new object[,]
                {
                    { "0e91d9e1-c087-4f79-bf7b-2c7849994538", "Từ 2-3 năm" },
                    { "10847504-08b1-4ce4-8a67-90c219efbc5d", "Từ 3-5 năm" },
                    { "1bcb2ed5-ae65-4afb-b0ae-b12b9e36b549", "Từ 1-2 năm" },
                    { "587cb059-5f03-45a7-a7d0-a6ed591e3bea", "Tất cả kinh nghiệm" },
                    { "5c7c3026-0001-4747-9311-9645a71d3a26", "Dưới 1 năm" },
                    { "93d3109d-3fac-45bf-9b72-7c3984e550c5", "Chưa có kinh nghiệm" },
                    { "9de62aad-470e-4c7b-b9fe-d9a0cdaefe4b", "Trên 10 năm" },
                    { "fddcdada-0fcf-464a-b74c-46f90502fb64", "Từ 5-10 năm" }
                });

            migrationBuilder.InsertData(
                table: "JobCareer",
                columns: new[] { "Id", "Career" },
                values: new object[,]
                {
                    { "00a923a9-8e03-47d8-b96d-672dd8cbd1d0", "Bán hàng kỹ thuật" },
                    { "07539d98-4742-4b27-92aa-7b7a51acd60f", "Dệt may / Da giày" },
                    { "0869eebe-2bdb-47f7-9a42-f4aa71d309b0", "In ấn / Xuất bản" },
                    { "0934a05b-ef68-4a66-bc76-4feb7f949306", "Vận tải / Kho vận" },
                    { "0dd145e9-234b-473a-b7c9-0856bf93b7e6", "Dược phẩm / Công nghệ sinh học" },
                    { "172b123c-26e5-4f78-a2f5-ed100ebea782", "NGO / Phi chính phủ / Phi lợi nhuận" },
                    { "19aaf989-91b7-4407-b0ad-cb6ab6dfe372", "IT Phần cứng / Mạng" },
                    { "1a889bae-fb33-440b-be43-caee19c39a11", "Sản phẩm công nghiệp" },
                    { "1e7f3563-4228-40b6-aa3f-7a1229823b68", "Y tế / Dược" },
                    { "1eb1f48e-4846-41ef-a3bf-447e9303deb5", "Hành chính / Văn phòng" },
                    { "2c3f4380-622d-4fc4-a18c-baddf7e92194", "Hoá học / Sinh học" },
                    { "36951f66-fd4c-40e7-82c5-9c02516efa41", "Du lịch" },
                    { "3d674580-ac59-4c0f-92a7-962340f06c42", "Nông / Lâm / Ngư nghiệp" },
                    { "3f142084-bff8-4c87-9db7-76593491128a", "Bưu chính - Viễn thông" },
                    { "42fe5b7d-28ca-445b-8be3-619aee29d07b", "Kinh doanh / Bán hàng" },
                    { "48d85abd-9a28-48fd-89fa-95eed5bb6434", "Mỹ thuật / Nghệ thuật / Điện ảnh" },
                    { "49386e6e-00c8-4316-95cc-25bc82a88535", "Tài chính / Đầu tư" },
                    { "50b9b8a8-ba8a-4c12-b08e-96255e2a1392", "Báo chí / Truyền hình" },
                    { "5210f4e6-ee10-4bbe-b01a-e83b5a2c6784", "Hàng hải" },
                    { "55faf552-1a56-468a-864f-99ee08e86dbd", "An toàn lao động" },
                    { "5888d9c5-4d85-4f30-b0a1-55603fbae7cb", "Hàng không" },
                    { "5b8ae4b1-3649-4d87-aa47-ec42d039c50f", "Hàng cao cấp" },
                    { "5db659c2-f7fa-407c-ad8c-d29d7bccd489", "Tổ chức sự kiện / Quà tặng" },
                    { "61116aaa-dab0-4618-af0b-49c28b045eec", "Thời trang" },
                    { "666d79d6-2ef1-4e37-b2ad-fb1803e92237", "Dầu khí/Hóa chất" },
                    { "7070fc67-d397-4eae-8f90-57597bac24f7", "Ngân hàng / Tài chính" },
                    { "72f2c6f3-52e5-49f8-af22-19ed3cbd2a81", "Công nghệ cao" },
                    { "73b0ef8b-af1e-4c76-8508-d939856a7115", "Xây dựng" },
                    { "77118a28-b59e-4c8d-b709-c019ade361af", "Cơ khí / Chế tạo / Tự động hóa" },
                    { "7a103cb7-e1e2-4dc1-865e-05ff9ea96adc", "Điện / Điện tử / Điện lạnh" },
                    { "7afae3f1-82e2-43d3-8c7c-665eb0d849aa", "Biên / Phiên dịch" }
                });

            migrationBuilder.InsertData(
                table: "JobCareer",
                columns: new[] { "Id", "Career" },
                values: new object[,]
                {
                    { "7e770fd3-f145-4198-96ff-96495c245234", "Bất động sản" },
                    { "7e7d1dd8-9498-4fa2-a742-765c14244a62", "Bảo hiểm" },
                    { "83a4bf73-17f5-487f-aff5-38fabca23add", "Dịch vụ khách hàng" },
                    { "84a614bf-cba4-4448-8f39-d75df8feb7d5", "Quản lý chất lượng (QA/QC)" },
                    { "8766f06e-7669-48ff-aa14-ffd238a96a36", "Mỹ phẩm / Trang sức" },
                    { "8a919e4d-9987-46e2-9399-06d2dcc27da1", "Quản lý điều hành" },
                    { "984da5b3-f61f-4461-b455-f3c4231869eb", "Logistics" },
                    { "a1fbc2c3-a1c3-486d-a165-b742f24a518f", "Chứng khoán / Vàng / Ngoại tệ" },
                    { "a2c8398a-2eb3-4147-8e11-9d248159c38e", "Tất cả ngành nghề" },
                    { "a72b5f11-ac7c-4dc9-86e5-5769ee95c948", "Ngành nghề khác" },
                    { "a8823cec-c5de-4fdb-906c-0285bf212062", "Điện tử viễn thông" },
                    { "a9dbc6af-ba2f-49e1-86a0-ac233d44cb17", "Công nghệ Ô tô" },
                    { "aa611d5b-f128-41cb-b5c9-9de061909f6a", "Bán lẻ / bán sỉ" },
                    { "ae357a1f-021d-438d-9361-6523a4bc32b2", "Spa / Làm đẹp" },
                    { "af609568-ffb8-49a5-a944-eead1fe1bfa8", "Thực phẩm / Đồ uống" },
                    { "b032d658-56ef-427f-bfc9-1cad2610baaf", "Bảo trì / Sửa chữa" },
                    { "b3ed0b54-5b9d-4331-97aa-f5e56247cba4", "Hàng gia dụng" },
                    { "b449f756-e0e6-4cce-8399-8e22e0b0b3fc", "Phi chính phủ / Phi lợi nhuận" },
                    { "b91223ad-7117-427a-9e7d-08e4691731ed", "Sản xuất" },
                    { "c6339eb3-6edd-4eaa-81fc-4573123031d9", "IT phần mềm" },
                    { "c74b6d49-8c7d-4e44-884c-f85bf579703c", "Môi trường / Xử lý chất thải" },
                    { "d006b8d5-cb98-4eb7-ad9c-135571658f83", "Kiến trúc" },
                    { "d0b234e6-91ee-43e5-9c2d-6d3905be2499", "Công nghệ thông tin" },
                    { "d33000b9-10d8-4319-836f-e32dddeaf71f", "Thiết kế đồ họa" },
                    { "d7691a32-1c31-48df-849a-1f419569b900", "Khách sạn / Nhà hàng" },
                    { "de58a5f6-a06d-4f70-95a2-d4d385985eae", "Nhân sự" },
                    { "e07be0dd-da25-468b-b92b-515a8e484e09", "Thư ký / Trợ lý" },
                    { "ec303681-deac-4c52-b3af-bfeb0775cfff", "Hàng tiêu dùng" },
                    { "ecf88b00-eeec-45ad-87de-f9a584757606", "Hoạch định / Dự án" },
                    { "ed20dd1d-1b69-4c44-b973-3db17faa8210", "Thiết kế nội thất" },
                    { "ed7412b0-46c4-4d11-a057-1df7a597beda", "Địa chất / Khoáng sản" },
                    { "f07aa127-4758-4d50-968e-61c0af064968", "Luật / Pháp lý" },
                    { "f33f9da1-17f2-4401-8751-2a657ac2bd7c", "Tư vấn" },
                    { "f5839185-30a1-4655-b780-9eb394b93d15", "Marketing / Truyền thông / Quảng cáo" },
                    { "fcdad2e5-27c3-4db0-a8fa-e5584544f07e", "Xuất nhập khẩu" },
                    { "fe7f6bd9-540e-400d-9cb4-3d7fe0af6019", "Giáo dục / Đào tạo" },
                    { "fe9d977a-8d10-48a1-a42e-ce2025389bd3", "Kế toán / Kiểm toán" }
                });

            migrationBuilder.InsertData(
                table: "JobField",
                columns: new[] { "Id", "Field" },
                values: new object[,]
                {
                    { "05fab5f0-634f-4e90-b62a-7c8e7d01e095", "Chứng khoán" },
                    { "0f650e31-a7f1-4b8d-83d2-b884a55f232d", "Điện tử / Điện lạnh" },
                    { "14fe2fe8-4d99-4c95-b1a7-0da6e47c53e3", "Cơ quan nhà nước" },
                    { "17ce825f-695d-4db2-8078-90f44336604a", "Cơ khí" },
                    { "18647138-3b72-40ee-97d4-2c7dc604638f", "Khác" }
                });

            migrationBuilder.InsertData(
                table: "JobField",
                columns: new[] { "Id", "Field" },
                values: new object[,]
                {
                    { "1aafcb77-8656-41f7-b7a4-ec87f7296f8f", "Du lịch" },
                    { "23225735-b181-4eb0-bb60-a47f63351435", "IT - Phần cứng" },
                    { "23ff1944-afc6-4682-a38a-dde0169d06b6", "Dược phẩm / Y tế / Công nghệ sinh học" },
                    { "303e8350-5e9e-4594-bd61-52e50f43693b", "Tư vấn" },
                    { "3cba8e60-6b61-42f9-93e5-4e6c8fba12d5", "Giáo dục / Đào tạo" },
                    { "3e91e3d5-23bb-47f7-bd57-401322e2fa7c", "Môi trường" },
                    { "3f547743-bb44-4da4-8142-073539d5a226", "Nhà hàng / Khách sạn" },
                    { "3ff5f021-bb31-42c6-a7e5-858d831d182b", "Kế toán / Kiểm toán" },
                    { "46022f10-180c-448b-9c7d-6cc53a3c59ad", "Năng lượng" },
                    { "4c7a7e63-a26f-4b55-a70f-2809fa601f8f", "Sản xuất" },
                    { "4eda2374-7651-4e7b-aadc-0de249b7b804", "Bán lẻ - Hàng tiêu dùng - FMCG" },
                    { "5808cd94-029b-4274-889c-96b38598c62d", "Agency (Design/Development)" },
                    { "5b57a9e6-7ae1-47da-89f2-a49d1b35c604", "Ngân hàng" },
                    { "7214cb5e-df05-4907-b458-8a6e585ce30b", "Viễn thông" },
                    { "7576dae3-1b2b-423c-8e9a-9f18e90e66c6", "IT - Phần mềm" },
                    { "7c6b74a8-f6b9-47bf-90d7-eb431e2c0847", "Bất động sản" },
                    { "7dbaf23f-3656-438b-b469-4767db996cf7", "Thiết kế / kiến trúc" },
                    { "820fefff-45c4-48fb-9b72-de9af0a302a9", "Nhân sự" },
                    { "84c2d382-1b12-4d7b-9405-83d483b9ae88", "Luật" },
                    { "85859464-8091-41ca-88ce-e6925f95717c", "Bảo trì / Sửa chữa" },
                    { "8677845f-59f5-4778-bd6d-c2eafbfb9a03", "Xây dựng" },
                    { "8c65bb70-52fc-40cc-a04e-24c2a6035e3a", "Thời trang" },
                    { "91c13a72-89b0-4521-b3ee-7e4242f50cd5", "Internet / Online" },
                    { "9df603a0-6134-4e6c-8edf-cd2434ac8966", "Tự động hóa" },
                    { "a129bd53-499f-4302-93aa-c3197dfb20d8", "Bảo hiểm" },
                    { "a1981b77-c412-4654-8d8f-cf8215434808", "Xuất nhập khẩu" },
                    { "a45b905b-053b-46b0-a90f-f4f1e418ddc0", "Logistics - Vận tải" },
                    { "b6612808-cce8-4f89-a6d5-99729e48ebbf", "Giải trí" },
                    { "c628e8df-71bb-47d2-906f-b83fbab5a090", "Marketing / Truyền thông / Quảng cáo" },
                    { "ccc6391a-64a4-4542-88ad-fb76b0e6f30e", "Tất cả lĩnh vực" },
                    { "cfb1b4bb-beef-478c-a2cd-90080f3664e6", "Thương mại điện tử" },
                    { "cfc54eb6-648a-4a68-b992-66aa9751ecf1", "Agency (Marketing/Advertising)" },
                    { "dc525886-f012-451d-8018-a85a7ca605d1", "Tổ chức phi lợi nhuận" },
                    { "eb1515b2-6408-4596-9401-e0e71c6a9385", "In ấn / Xuất bản" },
                    { "f27f0a05-68d5-4edc-80f0-7395d6424c52", "Nông Lâm Ngư nghiệp" },
                    { "fbfb7bc5-26ce-458b-ac21-72d3fbbcd597", "Tài chính" }
                });

            migrationBuilder.InsertData(
                table: "JobForm",
                columns: new[] { "Id", "Form" },
                values: new object[,]
                {
                    { "385152e3-b70f-4c9e-bff4-90eb3fd81aa5", "Bán thời gian" },
                    { "5da050fd-3d48-41d8-8305-7d2effb994fc", "Toàn thời gian" },
                    { "babd4423-4996-48be-88e1-8c0b3b0e9918", "Thực tập" },
                    { "ee9547ae-5b05-41d7-b843-f144b2557c08", "Tất cả hình thức" }
                });

            migrationBuilder.InsertData(
                table: "JobPosition",
                columns: new[] { "Id", "Position" },
                values: new object[,]
                {
                    { "2701a2bb-d35d-4fb6-8a41-83e5335d53de", "Quản lí / Giám sát" },
                    { "40507d1f-9d64-4f36-b7f1-6028c22c4649", "Trưởng nhóm" }
                });

            migrationBuilder.InsertData(
                table: "JobPosition",
                columns: new[] { "Id", "Position" },
                values: new object[,]
                {
                    { "40b30d0e-d9c5-42f2-b22f-d1e435c88242", "Nhân viên" },
                    { "50295de4-cadf-4368-a00e-938f3f894d77", "Trưởng / Phó phòng" },
                    { "ae4bb348-81c7-4fd7-9572-5a57d130e7e1", "Giám đốc" },
                    { "b11ebd47-1bd7-4474-951b-e8fac1c296c5", "Phó giám đốc" },
                    { "d1d70423-b760-4eb2-a38f-6ffb8bc42f12", "Trưởng chi nhánh" },
                    { "f2e0a4c9-ba54-4551-9594-3ae72cc5c7ec", "Tất cả vị trí" },
                    { "f7f0672b-7017-4b00-a903-872f1575134f", "Thực tập sinh" }
                });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "00fa3c1b-0970-4ae4-859e-0e09db98783f", "Đắk Lắk" },
                    { "0124c113-a887-4acf-a00b-fc27ad717746", "Kon Tum" },
                    { "046926ab-04b9-47e2-b367-f73edadfdcbe", "Phú Thọ" },
                    { "0495b490-3f6f-4033-8661-1bc51606d68b", "Quảng Trị" },
                    { "0911494e-922d-4e61-8ec8-e88932ce3099", "Bà Rịa-Vũng Tàu" },
                    { "092b2aae-0e88-4141-919f-985602af680e", "Hà Nam" },
                    { "0a1d39c6-b687-4351-9705-78d8dc202d70", "Khánh Hòa" },
                    { "0b1dfdb4-8196-4eb2-b704-7039a88a1156", "Bắc Kạn" },
                    { "0d714174-f46c-4265-a229-e8424a1d52eb", "Bắc Ninh" },
                    { "0ecb9189-189f-48f0-aa60-2b36f96c629d", "Cao Bằng" },
                    { "1264ed1e-8c20-4657-8e60-3a3a2a0b41ca", "Bình Định" },
                    { "1709a996-15fc-4fa1-8b0c-6c4a4635cae8", "Bạc Liêu" },
                    { "1914617b-f4ec-4f72-a2a6-1b272d6df031", "Lai Châu" },
                    { "198f78d5-11c6-4106-abf4-4d042f42bd68", "Quảng Nam" },
                    { "203d3c41-81b8-436b-9bf4-658d51f15441", "Thanh Hóa" },
                    { "265fd9f5-f776-4fb9-9add-1122401e41d6", "Sóc Trăng" },
                    { "3149487b-c047-487e-ab7a-a3c3af3ed418", "Thừa Thiên Huế" },
                    { "3462e798-c015-42af-81ab-5f94614a74a5", "Tiền Giang" },
                    { "3f2331db-1d6f-4051-a439-f9686e67339f", "Ninh Thuận" },
                    { "40785bad-c94c-4d95-9b8c-3ed6c2ba049f", "Phú Yên" },
                    { "5164fbdc-b6af-4275-a6b7-ea522e909b60", "Lâm Đồng" },
                    { "52389612-4fe4-42dc-b454-48bbd80ba235", "Sơn La" },
                    { "53e52cad-3acf-478f-af7e-2c7f0303cc03", "Hòa Bình" },
                    { "540a4e8e-1860-464b-927c-7e6caf6fcde7", "Trà Vinh" },
                    { "568730ed-ba56-47ce-bc3f-0ce9d1f3e1d5", "Vĩnh Phúc" },
                    { "5bc52277-94a5-4489-aa66-90dd67503153", "Bình Dương" },
                    { "60f37494-7b1b-4387-8cd2-191f9ea66a72", "Điện Biên" },
                    { "68db9d82-ec5a-4cf6-a622-eb192ed431fd", "Hưng Yên" },
                    { "6942143e-528a-49ff-af9c-09a2213dbc18", "Tuyên Quang" },
                    { "7d28c335-76f3-4399-a636-0de55a7e782f", "Quảng Bình" },
                    { "809a1557-261f-46ee-b7d3-118447100204", "Gia Lai" },
                    { "87c405af-04af-4546-90fa-262f18b90f28", "Quảng Ninh" },
                    { "92584205-ab8e-4171-b391-6d34f5cf73d1", "Nghệ An" },
                    { "92cfd02d-b828-48c0-bedc-e8ac8569c940", "Nam Định" },
                    { "94eeacd9-3c25-4554-b9d6-9d8c436e6fc4", "Đồng Tháp" }
                });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "9e12ef53-eb49-4d5c-9d12-1e7a83d45da9", "Tất cả tỉnh thành" },
                    { "a1bc75f1-b07a-4eac-8dee-38a19b9ed2dc", "Vĩnh Long" },
                    { "a2a9bbb2-f91c-44b0-be98-315c3ba03f86", "Quảng Ngãi" },
                    { "a84d5050-ffdf-44b4-9905-7d14fcf22aeb", "Hải Dương" },
                    { "a98ea544-9212-4b77-9db7-61c3bd54e022", "Thái Bình" },
                    { "a9fd1bc1-af05-414e-afcd-4ce0e4396fd9", "Hà Tĩnh" },
                    { "ac703a85-393c-4c9f-a8cb-6baabede7ddd", "Tây Ninh" },
                    { "adbe94b2-ee97-471e-a72f-382d5ae99b15", "Long An" },
                    { "b4336cd9-dd84-4c72-9577-8f063539c4f2", "Cà Mau" },
                    { "b70ebc93-f5e4-4e5b-afe6-93f6cf19c2eb", "Đà Nẵng" },
                    { "d0c5448a-9b16-467c-a5f7-58a29fc1f2a0", "Ninh Bình" },
                    { "d0d18333-4701-4ca4-a703-eacbb91f735e", "Thái Nguyên" },
                    { "d10ca15c-67df-44e1-9fe7-de181b65957f", "Bến Tre" },
                    { "d713944c-3f83-4e21-be6a-b1bdea330f40", "Đắk Nông" },
                    { "d7b7832c-4004-4d21-b747-a553a53b6128", "Hậu Giang" },
                    { "d7d19942-3d29-43e6-bc35-4cfe4e46ada0", "Hải Phòng" },
                    { "d849d899-72f8-4561-92f4-751c51b22f27", "Lào Cai" },
                    { "d92a16b3-ae56-44a7-9716-197543e62d93", "Bắc Giang" },
                    { "dc009585-6fd0-4e61-afe9-272775861121", "Bình Thuận" },
                    { "de0abe46-7a58-4a03-813c-2ceaf3426e85", "Bình Phước" },
                    { "e08a1ba1-3dda-48de-a508-67496eca167c", "Cần Thơ" },
                    { "e2afe625-3084-4831-813f-0ec45301c978", "Hồ Chí Minh" },
                    { "e7e5f2c3-aebb-4124-b84d-dce89508e14c", "Yên Bái" },
                    { "f18c1c1d-f409-44a7-b3d5-9b7c75479366", "Hà Giang" },
                    { "f9a8b2a1-d201-4f72-929f-a9bcee225d05", "Kiên Giang" },
                    { "fbf2caa7-2935-4549-bd64-f6e7af7a8a86", "Hà Nội" },
                    { "fbf52dd2-4570-4201-bfd2-a2404b243caf", "Đồng Nai" },
                    { "fd231d78-faca-4d9d-8275-4ab9d94efa65", "An Giang" },
                    { "fddcad97-a788-4509-9c73-045d1ebebe29", "Lạng Sơn" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { "09a901a0-14b4-41dd-9de9-56cd661a5eae", "Employer" },
                    { "7fe9af2d-de01-4147-ba5a-42e3083ba967", "Candidate" },
                    { "f5c5e8fa-44f9-477b-9da9-0d1188c52afd", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Avatar", "DateOfBirth", "Discriminator", "Email", "PhoneNumber", "Username" },
                values: new object[] { "d3a38104-26ed-4bdd-b960-bc18cba20029", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Candidate", "cvlookup.sgu.2023_candidate@gmail.com", null, "Candidate Admin" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Address", "Avatar", "Description", "Discriminator", "Email", "PhoneNumber", "Username", "Website" },
                values: new object[] { "d6e41c12-4791-4697-8cca-57c49354ab78", "Admin", null, "Admin", "Employer", "cvlookup.sgu.2023_employer@gmail.com", null, "Employer Admin", null });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Avatar", "Discriminator", "Email", "PhoneNumber", "Username" },
                values: new object[] { "7307e857-0cb6-4a2d-a792-e82dd657f754", null, "User", "cvlookup.sgu.2023@gmail.com", null, "General Admin" });

            migrationBuilder.InsertData(
                table: "AccountUser",
                columns: new[] { "AccountId", "UserId" },
                values: new object[,]
                {
                    { "4885e3e8-1139-4709-853e-37c4485a7019", "d3a38104-26ed-4bdd-b960-bc18cba20029" },
                    { "50eec808-5705-422a-9113-7c2d7d453ae9", "d6e41c12-4791-4697-8cca-57c49354ab78" },
                    { "7f867a5c-f440-4bcf-9328-15922f2691de", "7307e857-0cb6-4a2d-a792-e82dd657f754" }
                });

            migrationBuilder.InsertData(
                table: "District",
                columns: new[] { "Id", "Name", "ProvinceId" },
                values: new object[,]
                {
                    { "00cf7e10-a6ca-4113-b412-395b58be762b", "Quận Thanh Khê", "b70ebc93-f5e4-4e5b-afe6-93f6cf19c2eb" },
                    { "0619e1b0-4e66-4e0e-80a8-757c5e9019d2", "Quận Thanh Xuân", "fbf2caa7-2935-4549-bd64-f6e7af7a8a86" },
                    { "0963dc79-b992-4284-9b7a-772017368a26", "Quận Dương Kinh", "d7d19942-3d29-43e6-bc35-4cfe4e46ada0" },
                    { "151f4a03-2184-42a1-941e-206f99d6b689", "Quận Gò Vấp", "e2afe625-3084-4831-813f-0ec45301c978" },
                    { "26629823-4d68-45a6-a5e5-cf91246da1e2", "Quận Tân Bình", "e2afe625-3084-4831-813f-0ec45301c978" },
                    { "2b92836e-e611-4688-9bb9-dd8d1d508315", "Quận Đống Đa", "fbf2caa7-2935-4549-bd64-f6e7af7a8a86" },
                    { "37f26c0a-4aeb-489a-844f-a6ed10081f02", "Quận 3", "e2afe625-3084-4831-813f-0ec45301c978" },
                    { "393281ca-9b16-48db-98c9-c158191bb1c2", "Quận Ninh Kiều", "e08a1ba1-3dda-48de-a508-67496eca167c" },
                    { "3d40a766-7962-40c0-8461-1f05aaeef729", "Quận Sơn Trà", "b70ebc93-f5e4-4e5b-afe6-93f6cf19c2eb" },
                    { "3e8186b8-b788-40c9-ab08-a68b3ffb0f18", "Quận Bình Tân", "e2afe625-3084-4831-813f-0ec45301c978" },
                    { "44119217-88f8-4e4c-a009-2b6669e21336", "Quận Cầu Giấy", "fbf2caa7-2935-4549-bd64-f6e7af7a8a86" },
                    { "450d558a-5222-4b0d-8685-740f03533e86", "Quận 2", "e2afe625-3084-4831-813f-0ec45301c978" },
                    { "46718e65-893a-4aec-bac9-5cb515749f9c", "Quận Bình Thạnh", "e2afe625-3084-4831-813f-0ec45301c978" },
                    { "485454dd-8249-4e58-b348-043e1fcdbc10", "Quận Đồ Sơn", "d7d19942-3d29-43e6-bc35-4cfe4e46ada0" },
                    { "4bb97ffd-92e0-4067-872d-fc29f9da781d", "Quận Hoàn Kiếm", "fbf2caa7-2935-4549-bd64-f6e7af7a8a86" },
                    { "4d19fda2-3737-466b-bb93-88b7088ca79f", "Quận 10", "e2afe625-3084-4831-813f-0ec45301c978" },
                    { "4f7485b4-2ca6-4518-a94d-ca0bda3787a2", "Quận Liên Chiểu", "b70ebc93-f5e4-4e5b-afe6-93f6cf19c2eb" },
                    { "64b5e3ca-388d-4658-88b7-f9ae70b2f76e", "Quận Ngô Quyền", "d7d19942-3d29-43e6-bc35-4cfe4e46ada0" },
                    { "65343772-840d-4c02-b679-ef7e48961176", "Quận 5", "e2afe625-3084-4831-813f-0ec45301c978" },
                    { "6fb4b59d-020b-47d4-83f0-a6f52e17606c", "Quận 7", "e2afe625-3084-4831-813f-0ec45301c978" },
                    { "73f9bec3-8840-4abf-a58c-ec1593bd4332", "Quận Hải An", "d7d19942-3d29-43e6-bc35-4cfe4e46ada0" },
                    { "79c638d5-fb68-4221-ad33-6fb751787216", "Quận Lê Chân", "d7d19942-3d29-43e6-bc35-4cfe4e46ada0" },
                    { "7d10c035-b3d9-40f7-9ad9-3265c4d808c6", "Quận 8", "e2afe625-3084-4831-813f-0ec45301c978" },
                    { "88f0e664-362c-48a8-88d1-77bf84e3337e", "Quận Tây Hồ", "fbf2caa7-2935-4549-bd64-f6e7af7a8a86" },
                    { "8af7d7b7-1ec1-437a-b118-ba9c9663f567", "Quận Hoàng Mai", "fbf2caa7-2935-4549-bd64-f6e7af7a8a86" },
                    { "8cfd56c5-4052-4716-a026-64a20e1bd0c0", "Quận 12", "e2afe625-3084-4831-813f-0ec45301c978" },
                    { "8dcc5108-5266-4da7-8722-ac17b8260580", "Quận Cái Răng", "e08a1ba1-3dda-48de-a508-67496eca167c" },
                    { "921d1cc9-7913-40fc-af5e-c077e2d0c291", "Quận 6", "e2afe625-3084-4831-813f-0ec45301c978" },
                    { "9ad813c7-a5e8-4208-842a-67fa58446580", "Quận 4", "e2afe625-3084-4831-813f-0ec45301c978" },
                    { "9ccfe55c-634e-42d6-bd70-9eadf52beb4c", "Quận Hai Bà Trưng", "fbf2caa7-2935-4549-bd64-f6e7af7a8a86" },
                    { "a400ac3b-7bdc-495d-b2ff-c198b4047091", "Quận Ba Đình", "fbf2caa7-2935-4549-bd64-f6e7af7a8a86" },
                    { "a7c21eeb-87c9-494e-9a51-3efe05990ac5", "Quận Bình Thuỷ", "e08a1ba1-3dda-48de-a508-67496eca167c" },
                    { "a971a09b-5e1b-4de5-820b-1df45ca1c146", "Quận Ngũ Hành Sơn", "b70ebc93-f5e4-4e5b-afe6-93f6cf19c2eb" },
                    { "a9a2097c-b100-45b3-b039-56ed079589c0", "Quận Cẩm Lệ", "b70ebc93-f5e4-4e5b-afe6-93f6cf19c2eb" },
                    { "ab795308-3562-4eb2-8480-df1775446a8e", "Quận Thủ Đức", "e2afe625-3084-4831-813f-0ec45301c978" },
                    { "ae545097-3d54-4454-af47-fbd83690248c", "Quận Ô Môn", "e08a1ba1-3dda-48de-a508-67496eca167c" },
                    { "af47be1b-7a4b-4c72-bac7-e1c0439e738f", "Quận Thốt Nốt", "e08a1ba1-3dda-48de-a508-67496eca167c" },
                    { "b61c675a-77fc-46ce-92e8-79d91195e870", "Quận Nam Từ Liêm", "fbf2caa7-2935-4549-bd64-f6e7af7a8a86" },
                    { "c786d54f-be0c-4c1e-938b-e13361349c5d", "Quận 9", "e2afe625-3084-4831-813f-0ec45301c978" }
                });

            migrationBuilder.InsertData(
                table: "District",
                columns: new[] { "Id", "Name", "ProvinceId" },
                values: new object[,]
                {
                    { "d00d854b-8d08-43c3-8c21-9b1fd237eb21", "Quận Hải Châu", "b70ebc93-f5e4-4e5b-afe6-93f6cf19c2eb" },
                    { "d8fd02e2-aa7b-4ce9-afc7-e3725ebc5689", "Quận 11", "e2afe625-3084-4831-813f-0ec45301c978" },
                    { "d958365c-0d39-49b3-8623-6fc1bc78d2fd", "Quận Kiến An", "d7d19942-3d29-43e6-bc35-4cfe4e46ada0" },
                    { "da2d3432-6353-4899-8513-9503a509a37b", "Quận Phú Nhuận", "e2afe625-3084-4831-813f-0ec45301c978" },
                    { "db032664-a255-4f13-98f0-87faa61cc631", "Quận Bắc Từ Liêm", "fbf2caa7-2935-4549-bd64-f6e7af7a8a86" },
                    { "dba9f7e2-aac4-4e5b-a89c-ed0583f8768a", "Quận Long Biên", "fbf2caa7-2935-4549-bd64-f6e7af7a8a86" },
                    { "dd0d34e6-7809-4931-bf54-68ac23c014b7", "Quận Hà Đông", "fbf2caa7-2935-4549-bd64-f6e7af7a8a86" },
                    { "f13b18f4-0dfd-4906-a15d-7464a1748543", "Quận 1", "e2afe625-3084-4831-813f-0ec45301c978" },
                    { "f65fcb69-03d7-4189-92a3-ba6d1a16bb2e", "Quận Tân Phú", "e2afe625-3084-4831-813f-0ec45301c978" },
                    { "f72f8b51-4dac-462d-850b-1b72d565a9c1", "Quận Hồng Bàng", "d7d19942-3d29-43e6-bc35-4cfe4e46ada0" }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "09a901a0-14b4-41dd-9de9-56cd661a5eae", "d6e41c12-4791-4697-8cca-57c49354ab78" },
                    { "7fe9af2d-de01-4147-ba5a-42e3083ba967", "d3a38104-26ed-4bdd-b960-bc18cba20029" },
                    { "f5c5e8fa-44f9-477b-9da9-0d1188c52afd", "7307e857-0cb6-4a2d-a792-e82dd657f754" }
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
