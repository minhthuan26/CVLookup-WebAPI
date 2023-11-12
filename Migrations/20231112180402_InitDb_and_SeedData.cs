using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CVLookup_WebAPI.Migrations
{
    public partial class InitDb_and_SeedData : Migration
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
                    { "89329e50-d4f7-4213-9fd7-ab003b0eb205", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cvlookup.sgu.2023@gmail.com", new DateTime(2023, 11, 13, 1, 4, 1, 594, DateTimeKind.Local).AddTicks(2189), "4EvS5r40usEAzXH5nw6YyjfVVpQdHt7K+e7DBWXhKPKdrduCQ6W3M3Ala03/Tw8kFhLEGxHwealuxejQLZqg0y4nsngohze7rnldfpPHQ1Y=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "e37b0e74-590b-490e-9cca-f3b5165f80bc", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cvlookup.sgu.2023_candidate@gmail.com", new DateTime(2023, 11, 13, 1, 4, 1, 594, DateTimeKind.Local).AddTicks(2226), "4EvS5r40usEAzXH5nw6YyjfVVpQdHt7K+e7DBWXhKPKdrduCQ6W3M3Ala03/Tw8kFhLEGxHwealuxejQLZqg0y4nsngohze7rnldfpPHQ1Y=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "efbe352e-358a-4086-bc17-3bbf6c7573f1", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cvlookup.sgu.2023_employer@gmail.com", new DateTime(2023, 11, 13, 1, 4, 1, 594, DateTimeKind.Local).AddTicks(2215), "4EvS5r40usEAzXH5nw6YyjfVVpQdHt7K+e7DBWXhKPKdrduCQ6W3M3Ala03/Tw8kFhLEGxHwealuxejQLZqg0y4nsngohze7rnldfpPHQ1Y=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Experience",
                columns: new[] { "Id", "Exp" },
                values: new object[,]
                {
                    { "54e3869e-1c25-41e8-b9e3-66d7f6538a4c", "Tất cả kinh nghiệm" },
                    { "8b71ec80-31cd-43fc-9fba-67bcae6c3ae1", "Từ 1-2 năm" },
                    { "ab4192bf-27bf-40e2-b11d-e749f4413121", "Từ 3-5 năm" },
                    { "b7215014-34a0-44e5-ba81-37ea940f5226", "Từ 2-3 năm" },
                    { "d00e4791-3dcf-4b75-8b0d-f1a28d957cad", "Chưa có kinh nghiệm" },
                    { "d518a820-d071-4ea7-9b35-d81f8d2228b7", "Từ 5-10 năm" },
                    { "dc102bd2-291c-475a-8387-1252f6818568", "Dưới 1 năm" },
                    { "f2abc6c4-96a8-47be-b9f6-46ed7a3a31df", "Trên 10 năm" }
                });

            migrationBuilder.InsertData(
                table: "JobCareer",
                columns: new[] { "Id", "Career" },
                values: new object[,]
                {
                    { "097f9f0a-3e6d-4444-b3a0-0c3ebee06180", "Bán hàng kỹ thuật" },
                    { "0b279e16-9680-47bf-a2fe-ea3a905bedd1", "Ngành nghề khác" },
                    { "0d78c5dc-c543-468e-afb4-1b3c11935faf", "Mỹ thuật / Nghệ thuật / Điện ảnh" },
                    { "1265617a-6b79-4395-8a0f-4623afb89ee8", "Logistics" },
                    { "1659dffb-7325-48f1-b125-6999c0ac13ec", "Địa chất / Khoáng sản" },
                    { "1a39611e-aa36-43b2-bfc1-8d367acefa1d", "Hàng cao cấp" },
                    { "20f0f79d-c15b-42fe-be5a-5aa94bc94f36", "Công nghệ Ô tô" },
                    { "22f297c2-4557-4a3d-bc72-7bcb4c2cbcd5", "Hoá học / Sinh học" },
                    { "268f562c-1a5f-4108-9817-26bc4ee29e5d", "Dệt may / Da giày" },
                    { "2b8d0563-e9b1-48cb-a42f-74b009554174", "Xây dựng" },
                    { "2c49eb46-a9d3-4f55-ade1-ef976e0d41f6", "Giáo dục / Đào tạo" },
                    { "3067e8de-ddc0-40f7-a4f2-3ef9b972f1ac", "NGO / Phi chính phủ / Phi lợi nhuận" },
                    { "321d9e40-f81f-4ff0-9baa-3434bfc6d421", "Hoạch định / Dự án" },
                    { "332dbeeb-3973-4058-8580-a3c16df8a51d", "Cơ khí / Chế tạo / Tự động hóa" },
                    { "3eba281d-7a0f-423e-9f9e-a06024937c49", "Ngân hàng / Tài chính" },
                    { "4304f4a1-8643-442d-b18d-fd8298de540e", "Dầu khí/Hóa chất" },
                    { "43ec5328-56de-4544-b47d-f5c8336dbec8", "Sản xuất" },
                    { "45420419-8a69-4429-adfc-b1980137a14c", "Công nghệ cao" },
                    { "4b058b33-3319-4471-8eaa-be1aa63b7105", "Thực phẩm / Đồ uống" },
                    { "4ffa3906-28f1-42a6-a03f-40961507c903", "Tổ chức sự kiện / Quà tặng" },
                    { "56945323-96d9-4868-913f-190ddd432658", "Báo chí / Truyền hình" },
                    { "5c877d72-b7b7-44f2-97a9-69e15e633a5c", "Spa / Làm đẹp" },
                    { "5dbcb5ee-d2d5-4f11-99c9-b1f18cc4b72f", "Y tế / Dược" },
                    { "61e04550-b81c-4974-9087-72792def1129", "Môi trường / Xử lý chất thải" },
                    { "63338253-e36e-4ed6-81b8-2b1dcfc33d3e", "Tài chính / Đầu tư" },
                    { "636e7c5f-0ff8-4ff3-99a6-a5df6c1f812b", "In ấn / Xuất bản" },
                    { "668e9b53-2685-43c5-97c1-36a059472473", "Hành chính / Văn phòng" },
                    { "66dd6280-c838-4f7d-b606-005e16614d10", "Chứng khoán / Vàng / Ngoại tệ" },
                    { "6e7ae9be-3f5f-4341-9d61-f1e22b7f46a8", "Thiết kế đồ họa" },
                    { "6eff5624-9dcb-4c2d-88b7-969036db4ce0", "Kế toán / Kiểm toán" },
                    { "702d192e-b778-4712-848e-7d5a25b2e3e0", "Dược phẩm / Công nghệ sinh học" }
                });

            migrationBuilder.InsertData(
                table: "JobCareer",
                columns: new[] { "Id", "Career" },
                values: new object[,]
                {
                    { "71423cb5-b76c-4111-9561-ff4199745796", "Khách sạn / Nhà hàng" },
                    { "71beb573-bfac-48ab-8922-14650282147e", "Marketing / Truyền thông / Quảng cáo" },
                    { "7475a4f3-4e08-480f-8572-0422f54955b5", "IT Phần cứng / Mạng" },
                    { "74779ffb-3551-49be-a8ab-651d43767dcb", "Tư vấn" },
                    { "7f7ee291-d5a4-45c2-a252-6b5f87f43cd7", "Bất động sản" },
                    { "8408029d-cb7d-4cd7-bad5-09fccb42c0f3", "Tất cả ngành nghề" },
                    { "843d43cf-e9dd-4aeb-b3bb-653bbd6f6d8b", "Hàng tiêu dùng" },
                    { "88e1a1d5-c90c-4e80-804e-c2167bd2b487", "An toàn lao động" },
                    { "896c5520-8628-424d-9098-68ca6b228449", "Công nghệ thông tin" },
                    { "8a795da2-6707-46b3-9cbb-eeaff86381df", "Luật / Pháp lý" },
                    { "8c7e99f1-b8b1-4314-9a35-adcc069850bb", "Bảo trì / Sửa chữa" },
                    { "8deed0b2-7853-4c16-bbe1-a1aff2e9ee73", "Vận tải / Kho vận" },
                    { "96354bcc-978f-4f5f-9cc2-043d9d63b6b0", "Bán lẻ / bán sỉ" },
                    { "9e3ae632-fbd4-463b-b436-b642f82e6588", "Sản phẩm công nghiệp" },
                    { "9f60a834-549d-4ba3-9364-259deb199cc1", "Du lịch" },
                    { "9f9e68ea-2727-47fa-b151-b5cd032cb2d3", "Hàng không" },
                    { "a1fa2548-6d49-4195-afd9-9a88a461aae4", "Điện / Điện tử / Điện lạnh" },
                    { "aba754db-f09e-4d62-a1ba-35dc36d9654b", "Nông / Lâm / Ngư nghiệp" },
                    { "af080787-ff34-4ad5-adb7-b5c29aa5adb7", "Phi chính phủ / Phi lợi nhuận" },
                    { "b2058757-ed2a-4e2f-a3f7-8308a4041239", "Xuất nhập khẩu" },
                    { "b4489070-ab01-4dbd-80cd-ca5f5dcdbd5a", "Thời trang" },
                    { "b60b445b-a537-4b70-b77f-04359b705ffe", "Bảo hiểm" },
                    { "b678c0a5-4b81-4a50-901b-484c8f23c137", "Thư ký / Trợ lý" },
                    { "b8cb0576-060f-42b0-8768-5cf990968a5e", "Hàng gia dụng" },
                    { "ba8e5d25-fc93-4250-980f-5c3ce75c7dfe", "Biên / Phiên dịch" },
                    { "bf2146a7-3fd0-478a-a9b0-a3027f5f4904", "Điện tử viễn thông" },
                    { "bfd62ce0-b1b0-43af-8d48-154191c9e31f", "Nhân sự" },
                    { "c1e7fff6-2b4b-4adb-91bd-8c4ba782b386", "Bưu chính - Viễn thông" },
                    { "c1ff9db0-2754-4387-9350-421563ce4cec", "Kinh doanh / Bán hàng" },
                    { "c44493a5-032c-4bcf-92a0-559115797d6e", "Dịch vụ khách hàng" },
                    { "c5b7dcc9-3d4e-4a5e-bb1a-5cf6d8312754", "Quản lý chất lượng (QA/QC)" },
                    { "d6329843-b2f4-4e64-914d-8e095d4f7754", "Quản lý điều hành" },
                    { "ed1543a4-aed2-4610-96a3-bad51813470e", "Thiết kế nội thất" },
                    { "f19d3fc6-ae1a-4caf-9f65-ab7ca95f5005", "Hàng hải" },
                    { "fcbe1436-6225-4e10-ad1a-88be8a8709ca", "Mỹ phẩm / Trang sức" },
                    { "fe2f3fe4-4b07-427f-9f99-5b1d64203021", "Kiến trúc" },
                    { "ff756adb-6905-45d6-b224-e94fcc9740c7", "IT phần mềm" }
                });

            migrationBuilder.InsertData(
                table: "JobField",
                columns: new[] { "Id", "Field" },
                values: new object[,]
                {
                    { "064e299c-b7b4-4530-9563-cb3bb7ce2419", "Bán lẻ - Hàng tiêu dùng - FMCG" },
                    { "0b9d98fb-120b-4090-8cb9-af1f77dcb91b", "Dược phẩm / Y tế / Công nghệ sinh học" },
                    { "0cc2abe5-ff22-42bb-9ca8-5578600bdc82", "Điện tử / Điện lạnh" },
                    { "0ef93a62-1f09-40ed-b989-3b0e360a93ab", "Nông Lâm Ngư nghiệp" },
                    { "0fc31739-5ef9-4451-b261-a16307c18396", "IT - Phần cứng" }
                });

            migrationBuilder.InsertData(
                table: "JobField",
                columns: new[] { "Id", "Field" },
                values: new object[,]
                {
                    { "111c0f1f-7ad3-469e-ad30-2fdfe5c874fd", "Agency (Marketing/Advertising)" },
                    { "2fb68ac7-749b-42b2-81ec-576c3d7da881", "Internet / Online" },
                    { "328cf12d-3c93-42fd-a9e9-17cb432e1b19", "Môi trường" },
                    { "35340c9e-3258-4072-9c5b-890abb918fc7", "Tổ chức phi lợi nhuận" },
                    { "37ab6970-7ae1-4178-9607-cb42ac86e060", "Marketing / Truyền thông / Quảng cáo" },
                    { "3d579e0c-f0e8-427b-b18a-e88b8de89cf6", "Tài chính" },
                    { "42909b36-71c6-4a69-b361-ef7d7afa442a", "Khác" },
                    { "44b9c4f6-98f3-46f7-b8d8-22e22bd0f4c9", "Xuất nhập khẩu" },
                    { "5d85b25f-a1ba-4404-a02d-4b1252786886", "Bảo trì / Sửa chữa" },
                    { "6d3cc748-9b6b-466c-a75e-3482740d8695", "Xây dựng" },
                    { "7295fb79-1534-4ee9-bd42-720ea930098f", "Luật" },
                    { "86078f1a-b511-4c43-9b05-8cb92f8ee4f0", "Tất cả lĩnh vực" },
                    { "8a08f83a-be20-4911-bb56-392f4689a492", "Ngân hàng" },
                    { "8b1db17d-2bc2-4a30-999a-cfee742a8475", "Nhà hàng / Khách sạn" },
                    { "934aa481-56a1-4fd6-af2e-dada2e1c0334", "Cơ khí" },
                    { "939e70ed-9f79-4b6e-90c1-590762eb0ad2", "Tự động hóa" },
                    { "94557b78-91d2-43e6-9234-73fd580751f1", "Du lịch" },
                    { "b014bf24-9813-4ffb-afd0-b4d2d6d92637", "Nhân sự" },
                    { "b22ec23c-75cf-4fe5-b311-a0b2ada685c1", "Bảo hiểm" },
                    { "b60d225a-d2d0-4de5-994b-74576fc7e389", "Kế toán / Kiểm toán" },
                    { "b6f51316-a223-4c8b-ad3f-20596d2af9bb", "Viễn thông" },
                    { "b82c5916-e502-4e30-89be-96f084df4cd0", "Giải trí" },
                    { "beb3540a-9f3d-4649-88e8-3e1a1ea1e537", "Thời trang" },
                    { "c106cd84-b080-4c8b-b11a-25c8bbcb48a5", "Tư vấn" },
                    { "c5d7a5d9-18ba-49b2-9089-b98d0fda2b5e", "Agency (Design/Development)" },
                    { "c73e4680-0a2c-4894-80df-0e82cf6a260b", "Bất động sản" },
                    { "ca48c348-c321-456c-af44-7a2485909b4b", "Sản xuất" },
                    { "ccfffa10-0468-4d2e-9d20-574ddf8218a6", "Năng lượng" },
                    { "cf73bb7b-7caf-41dc-9a62-a97054a01a29", "Giáo dục / Đào tạo" },
                    { "d0c3b88c-9018-4cb3-933f-53179aa1c50a", "IT - Phần mềm" },
                    { "d63944de-bc8f-4485-96c4-1a4e2419d19d", "Chứng khoán" },
                    { "dc0b5c68-1162-421e-8adc-e6fec67ee557", "In ấn / Xuất bản" },
                    { "dd63dd63-e394-4754-b491-de27d866f357", "Thiết kế / kiến trúc" },
                    { "e7446408-eafb-44bd-be7f-88ef13db2035", "Thương mại điện tử" },
                    { "fcdedd8d-df55-44c7-b6a9-e16a1650c825", "Logistics - Vận tải" },
                    { "fe2a8f8e-8cf7-4438-ab48-0d32295f47f7", "Cơ quan nhà nước" }
                });

            migrationBuilder.InsertData(
                table: "JobForm",
                columns: new[] { "Id", "Form" },
                values: new object[,]
                {
                    { "0e40697a-6f41-4235-8311-5dd14b628ef9", "Bán thời gian" },
                    { "bd403036-e5d5-4386-828a-0e0eefe6d456", "Tất cả hình thức" },
                    { "cf95f58a-b696-4a01-baaf-929072113719", "Toàn thời gian" },
                    { "da7badd2-1ec7-4732-9e8a-0ca7ff5937ef", "Thực tập" }
                });

            migrationBuilder.InsertData(
                table: "JobPosition",
                columns: new[] { "Id", "Position" },
                values: new object[,]
                {
                    { "37190f0d-c360-4039-b629-4b096fbc6057", "Trưởng chi nhánh" },
                    { "51035fce-71c9-42ff-9b80-9db27deeacb9", "Thực tập sinh" }
                });

            migrationBuilder.InsertData(
                table: "JobPosition",
                columns: new[] { "Id", "Position" },
                values: new object[,]
                {
                    { "7031f11d-cd97-4183-be21-5db3751d2b6e", "Trưởng / Phó phòng" },
                    { "7f9aa195-f13c-4e13-a2e7-d7cfbbeb24c3", "Nhân viên" },
                    { "8e8af423-0e0b-4b46-8207-6b18fc083dec", "Phó giám đốc" },
                    { "e87ef7c0-2e67-4ebe-8aea-45f8e70049d1", "Quản lí / Giám sát" },
                    { "f0d9da79-67ad-46f1-b443-80b75898846f", "Trưởng nhóm" },
                    { "f15b28bd-425f-4de4-9283-37a29bff4c94", "Giám đốc" },
                    { "f4f00204-5a8b-488e-9f0b-63061032e786", "Tất cả vị trí" }
                });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "01205c4e-0f0f-4352-83f0-afc8efbbfb53", "Bình Định" },
                    { "01e7c7b8-71ec-4d90-bfff-538d12321cd7", "Khánh Hòa" },
                    { "03fb78de-91db-41ec-b0dd-31e8edb54625", "Bắc Kạn" },
                    { "0a8f678d-7149-42f6-8e4e-4d03ea01900b", "Hải Phòng" },
                    { "11c7c0ed-28c5-4e9e-bab2-3cfaa0824dc6", "Nam Định" },
                    { "164f48cd-c0c8-4fe8-b8c0-0a0a19b8a456", "Yên Bái" },
                    { "19bdf49b-3998-41b1-bd8a-10e0ed6967fe", "Đồng Tháp" },
                    { "1f0b167c-9d29-4884-8282-f64812ad4358", "Bắc Ninh" },
                    { "25eecf9e-96e1-43da-9fa4-b11ed715d1c4", "An Giang" },
                    { "2cb3e3f4-1b43-4c31-9e5a-300f14693b82", "Quảng Bình" },
                    { "326d84cb-46aa-41fa-b543-062253285486", "Gia Lai" },
                    { "3368ceb2-fa1d-4f37-ab75-1cebca98a7fa", "Lạng Sơn" },
                    { "37355985-005e-4a37-a144-a1a0b154d353", "Lai Châu" },
                    { "39f6464e-8628-48a8-b24a-c274eb9e3282", "Tây Ninh" },
                    { "3d8a6486-cbc9-464a-89c3-dad7fd6ff44c", "Hà Nam" },
                    { "43385ca2-14a3-4a8c-978f-b88413fb61fb", "Tuyên Quang" },
                    { "4408c821-878a-46c1-bd70-938810a8218f", "Hà Giang" },
                    { "453d4717-9ad6-4b3c-818f-a732c0318adb", "Vĩnh Long" },
                    { "45620ffe-138b-4530-b1a9-56a03518d405", "Đắk Nông" },
                    { "461e80d9-4d66-43fa-af23-d3d43d560c3a", "Nghệ An" },
                    { "49d771c0-6c5d-4ccd-9a93-3f7d220e63f4", "Thừa Thiên Huế" },
                    { "4ced0126-ce3f-4bc6-8b29-b15fcf8a5690", "Điện Biên" },
                    { "52f3485c-aeae-4ffa-b63a-7d495530a0e2", "Quảng Nam" },
                    { "5370a4af-f42f-4995-8b10-488a9e718932", "Đà Nẵng" },
                    { "56f617a5-594f-46d5-ab9f-0360647d071f", "Kiên Giang" },
                    { "5d6a1a75-3903-407d-b58c-834dedb03ec0", "Đắk Lắk" },
                    { "68f1b526-5489-47d9-8593-0bc082c88922", "Thanh Hóa" },
                    { "6b2b6298-288f-4cdf-87bc-da38532c32cc", "Ninh Thuận" },
                    { "6c88ecfd-ee90-4bf9-86d2-8657b4d44122", "Cà Mau" },
                    { "705f91da-0c45-49d0-957f-ac4174415e96", "Bình Thuận" },
                    { "76be2906-144f-4352-af53-4f762db42c83", "Phú Thọ" },
                    { "791a78aa-1771-4905-9912-dc6c51f6c584", "Bình Phước" },
                    { "80265ede-48d5-47d9-8c39-0fa3cd740666", "Bắc Giang" },
                    { "8121fd2a-4e0e-4198-995a-cf36ffd9c5a9", "Quảng Ninh" },
                    { "8341a199-5ed0-48c5-83b9-7f897daadcee", "Lâm Đồng" }
                });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "843b54a2-f157-4ea0-99b8-91aa5ac22554", "Bạc Liêu" },
                    { "8574b4cb-e2b3-483b-a51b-338cefec66e7", "Vĩnh Phúc" },
                    { "8866c0b8-301d-4e5d-a322-b4c5e7d78ec8", "Thái Nguyên" },
                    { "9653896f-cc7d-422b-959b-30cda4d02ea0", "Hồ Chí Minh" },
                    { "96d9c7f4-b106-4d28-96e0-319f8c64b180", "Tiền Giang" },
                    { "97604a88-a6f3-42dd-96f2-b1ff479be6fe", "Hải Dương" },
                    { "9c867fa4-fd8e-44fc-bd74-4bc33dd63c7f", "Sơn La" },
                    { "a28f4eb5-cfa9-48e8-adc0-06581b2f4d3f", "Long An" },
                    { "a58b3b1b-7176-44fb-9ab2-f8247d677fb9", "Sóc Trăng" },
                    { "a5fcf9eb-5870-4895-8b70-35975da893cd", "Quảng Trị" },
                    { "a992a2ae-5607-4ae3-9ede-649105521de4", "Hậu Giang" },
                    { "ae1ae957-d034-415c-90e9-58e170d5dc83", "Kon Tum" },
                    { "aefbf4dd-e302-4350-bfb9-b26bb8c4bede", "Hòa Bình" },
                    { "af83d617-66af-400f-b35a-672f625e9203", "Thái Bình" },
                    { "b00eea49-8d40-4bfd-8242-c44041fde462", "Đồng Nai" },
                    { "b424bce3-7ac6-42f5-bf10-9d19b3bd2f42", "Tất cả tỉnh thành" },
                    { "bb62a093-d7cf-438a-9f39-5bce9a526b1f", "Hưng Yên" },
                    { "bc6dfcea-123c-4f30-912c-c91e4496cc0d", "Cao Bằng" },
                    { "bfac00e8-526c-4053-9c16-0799e689bb97", "Bà Rịa-Vũng Tàu" },
                    { "c91ccb53-4e3c-4e98-9c8f-f2ee8fae6cd9", "Lào Cai" },
                    { "cbb7c196-6a6e-45ce-a146-32ab7f60dbf4", "Hà Tĩnh" },
                    { "d1b40f42-3893-4fe7-8baf-8a1706a4e52f", "Bình Dương" },
                    { "d2868bb9-4dd0-45cb-b037-be1a34ccedb4", "Quảng Ngãi" },
                    { "f398027c-146d-405d-9897-64ca5a10d6e0", "Hà Nội" },
                    { "f505d3ae-a14d-473c-a751-1590bc1596e8", "Phú Yên" },
                    { "f53f2081-4553-44a9-85c7-65c59b866c85", "Bến Tre" },
                    { "f547711f-8cba-47a9-94d8-21d9d42198e7", "Trà Vinh" },
                    { "f76ad461-1b3a-4436-90d7-42716b5484cd", "Ninh Bình" },
                    { "fc28f72f-b153-44c6-8b82-b19ce9a33e27", "Cần Thơ" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { "576b50d6-a539-40a9-b6fa-1d030efcb642", "Employer" },
                    { "c888e172-1c97-47bc-8fb8-d386adce710a", "Admin" },
                    { "f8e1ec8e-54a8-4720-8f4a-7fe68d1de77c", "Candidate" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Avatar", "DateOfBirth", "Discriminator", "Email", "PhoneNumber", "Username" },
                values: new object[] { "ae178b22-9c1a-47b7-818b-db40326c770b", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Candidate", "cvlookup.sgu.2023_candidate@gmail.com", null, "Candidate Admin" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Address", "Avatar", "Description", "Discriminator", "Email", "PhoneNumber", "Username", "Website" },
                values: new object[] { "8b5e30c2-1c4e-40f5-b468-738c8a7cc4e1", "Admin", null, "Admin", "Employer", "cvlookup.sgu.2023_employer@gmail.com", null, "Employer Admin", null });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Avatar", "Discriminator", "Email", "PhoneNumber", "Username" },
                values: new object[] { "2f5ef746-7f88-47d8-8534-35fe1b30ecba", null, "User", "cvlookup.sgu.2023@gmail.com", null, "General Admin" });

            migrationBuilder.InsertData(
                table: "AccountUser",
                columns: new[] { "AccountId", "UserId" },
                values: new object[,]
                {
                    { "89329e50-d4f7-4213-9fd7-ab003b0eb205", "2f5ef746-7f88-47d8-8534-35fe1b30ecba" },
                    { "e37b0e74-590b-490e-9cca-f3b5165f80bc", "ae178b22-9c1a-47b7-818b-db40326c770b" },
                    { "efbe352e-358a-4086-bc17-3bbf6c7573f1", "8b5e30c2-1c4e-40f5-b468-738c8a7cc4e1" }
                });

            migrationBuilder.InsertData(
                table: "District",
                columns: new[] { "Id", "Name", "ProvinceId" },
                values: new object[,]
                {
                    { "019bd758-889e-41e7-b11c-9fff8fd8ffc3", "Quận Nam Từ Liêm", "f398027c-146d-405d-9897-64ca5a10d6e0" },
                    { "0267b039-11da-4397-9e9c-7a22249830a3", "Quận Thanh Xuân", "f398027c-146d-405d-9897-64ca5a10d6e0" },
                    { "0297f1d5-53b9-4a3d-9dc0-22609959398d", "Quận Bình Thạnh", "9653896f-cc7d-422b-959b-30cda4d02ea0" },
                    { "102930c3-9235-47c1-8405-ed5a233ceca5", "Quận 7", "9653896f-cc7d-422b-959b-30cda4d02ea0" },
                    { "13b414e6-abdf-4316-8a05-42846846a6f5", "Quận 6", "9653896f-cc7d-422b-959b-30cda4d02ea0" },
                    { "1a7c95d6-9ecc-4273-a573-d44755ede1d8", "Quận 8", "9653896f-cc7d-422b-959b-30cda4d02ea0" },
                    { "1b422bf6-10e0-423e-84cc-c879b0853b78", "Quận Hai Bà Trưng", "f398027c-146d-405d-9897-64ca5a10d6e0" },
                    { "203f3d13-a2ef-43a1-afd3-8b19f60f677e", "Quận 9", "9653896f-cc7d-422b-959b-30cda4d02ea0" },
                    { "256156b9-2c49-4773-8988-077663503a1a", "Quận Ninh Kiều", "fc28f72f-b153-44c6-8b82-b19ce9a33e27" },
                    { "29dc0db0-67eb-404f-b20f-fd1daf33a0a5", "Quận Hoàng Mai", "f398027c-146d-405d-9897-64ca5a10d6e0" },
                    { "2a513834-ab4a-4193-9382-1e04ed24c5d4", "Quận Thốt Nốt", "fc28f72f-b153-44c6-8b82-b19ce9a33e27" },
                    { "2ffafb85-3f31-4c90-9cee-51e3b6176b0d", "Quận Cầu Giấy", "f398027c-146d-405d-9897-64ca5a10d6e0" },
                    { "3b54810b-426a-42e2-aa14-065e10277891", "Quận Kiến An", "0a8f678d-7149-42f6-8e4e-4d03ea01900b" },
                    { "40bce067-2265-4a20-bdff-b3b040c6d9ae", "Quận Hoàn Kiếm", "f398027c-146d-405d-9897-64ca5a10d6e0" },
                    { "46f486b8-a40a-44af-823d-2f5859766d13", "Quận Bắc Từ Liêm", "f398027c-146d-405d-9897-64ca5a10d6e0" },
                    { "479992c8-ec10-4d02-9c79-5955ca13cf62", "Quận Ngũ Hành Sơn", "5370a4af-f42f-4995-8b10-488a9e718932" },
                    { "4aca9b43-6fcc-40de-a222-9d88ca79f036", "Quận Ba Đình", "f398027c-146d-405d-9897-64ca5a10d6e0" },
                    { "512e0f37-e6f8-49d8-b05e-c6a58f541af6", "Quận Sơn Trà", "5370a4af-f42f-4995-8b10-488a9e718932" },
                    { "5e1c20de-380c-47e1-93df-41e002500674", "Quận Bình Thuỷ", "fc28f72f-b153-44c6-8b82-b19ce9a33e27" },
                    { "663e9f8f-491c-4b63-b54b-48a17e1e0ab5", "Quận Long Biên", "f398027c-146d-405d-9897-64ca5a10d6e0" },
                    { "73218960-3c74-4b1d-9e04-57d52139ae31", "Quận Lê Chân", "0a8f678d-7149-42f6-8e4e-4d03ea01900b" },
                    { "77a1608b-32a3-4151-9dbf-0ea82d5b0f13", "Quận 11", "9653896f-cc7d-422b-959b-30cda4d02ea0" },
                    { "79b78f54-4744-47f4-9f89-2ab077b054d1", "Quận Đồ Sơn", "0a8f678d-7149-42f6-8e4e-4d03ea01900b" },
                    { "7fccd9e2-1cb1-4b04-b6d5-8fada81a27a9", "Quận Hải An", "0a8f678d-7149-42f6-8e4e-4d03ea01900b" },
                    { "8391ed7a-32c4-404e-8515-503ccd039d19", "Quận Tân Phú", "9653896f-cc7d-422b-959b-30cda4d02ea0" },
                    { "8543b9d4-449f-4af0-95a4-5c16ef789cdb", "Quận Hồng Bàng", "0a8f678d-7149-42f6-8e4e-4d03ea01900b" },
                    { "879693ba-8d46-4780-bbaa-114276d13717", "Quận Cẩm Lệ", "5370a4af-f42f-4995-8b10-488a9e718932" },
                    { "8da17dcc-4af7-4e3e-9f52-5e28100bf2e3", "Quận Đống Đa", "f398027c-146d-405d-9897-64ca5a10d6e0" },
                    { "a79b029f-a363-441b-93ec-c3991622a63e", "Quận Bình Tân", "9653896f-cc7d-422b-959b-30cda4d02ea0" },
                    { "a7bd8b5f-cdda-41a8-b429-b0c127ec1032", "Quận Tây Hồ", "f398027c-146d-405d-9897-64ca5a10d6e0" },
                    { "a8762387-ce40-414c-b12c-ac23931751da", "Quận Ô Môn", "fc28f72f-b153-44c6-8b82-b19ce9a33e27" },
                    { "af887a0e-09d2-45fb-8219-9cf91d584440", "Quận Gò Vấp", "9653896f-cc7d-422b-959b-30cda4d02ea0" },
                    { "b3bc88e3-1c42-4a38-9df1-1911f3edafae", "Quận Dương Kinh", "0a8f678d-7149-42f6-8e4e-4d03ea01900b" },
                    { "ba36a2f8-a327-4f8e-a6ff-2fd8a8f8c982", "Quận 1", "9653896f-cc7d-422b-959b-30cda4d02ea0" },
                    { "bae7b491-7020-43bc-b0c7-7d8d9132e812", "Quận 3", "9653896f-cc7d-422b-959b-30cda4d02ea0" },
                    { "c0c61cd5-c4fa-425e-ac91-c2c7af91814a", "Quận Thủ Đức", "9653896f-cc7d-422b-959b-30cda4d02ea0" },
                    { "c26fded1-a3a2-4e35-826e-84f1e1af4780", "Quận Liên Chiểu", "5370a4af-f42f-4995-8b10-488a9e718932" },
                    { "cd69284d-c4ba-4c61-b12b-9873f675ce68", "Quận Thanh Khê", "5370a4af-f42f-4995-8b10-488a9e718932" },
                    { "d9253a19-250d-435f-be06-37926de2fb43", "Quận Hải Châu", "5370a4af-f42f-4995-8b10-488a9e718932" }
                });

            migrationBuilder.InsertData(
                table: "District",
                columns: new[] { "Id", "Name", "ProvinceId" },
                values: new object[,]
                {
                    { "da0c2617-c02b-446e-96e2-b209f371917e", "Quận Cái Răng", "fc28f72f-b153-44c6-8b82-b19ce9a33e27" },
                    { "dafceccb-7d71-47e7-9094-02006e54ec6d", "Quận 10", "9653896f-cc7d-422b-959b-30cda4d02ea0" },
                    { "db356118-53eb-4861-87fa-5a52b76ec422", "Quận 5", "9653896f-cc7d-422b-959b-30cda4d02ea0" },
                    { "dc84efcb-67ab-40f2-a36f-546f6b1e717a", "Quận Tân Bình", "9653896f-cc7d-422b-959b-30cda4d02ea0" },
                    { "dd1d97cc-2dfa-4a2b-ad6a-eaa5fecbea09", "Quận Ngô Quyền", "0a8f678d-7149-42f6-8e4e-4d03ea01900b" },
                    { "e5df3003-aaf6-487e-8add-f76b7b7a4a66", "Quận 12", "9653896f-cc7d-422b-959b-30cda4d02ea0" },
                    { "ec50872a-009a-44f3-a4b0-247b9d30fae9", "Quận Phú Nhuận", "9653896f-cc7d-422b-959b-30cda4d02ea0" },
                    { "f16fe043-6f6c-4311-8a3e-8b59e94fd931", "Quận 2", "9653896f-cc7d-422b-959b-30cda4d02ea0" },
                    { "f76571e6-1a11-41b7-abf4-274b9c78e14f", "Quận 4", "9653896f-cc7d-422b-959b-30cda4d02ea0" },
                    { "f7aa60c7-0ec2-4b9a-83e7-da01ac745f54", "Quận Hà Đông", "f398027c-146d-405d-9897-64ca5a10d6e0" }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "576b50d6-a539-40a9-b6fa-1d030efcb642", "8b5e30c2-1c4e-40f5-b468-738c8a7cc4e1" },
                    { "c888e172-1c97-47bc-8fb8-d386adce710a", "2f5ef746-7f88-47d8-8534-35fe1b30ecba" },
                    { "f8e1ec8e-54a8-4720-8f4a-7fe68d1de77c", "ae178b22-9c1a-47b7-818b-db40326c770b" }
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
