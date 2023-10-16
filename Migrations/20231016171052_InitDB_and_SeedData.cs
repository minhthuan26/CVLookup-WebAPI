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
                    { "442e5617-c6c8-4eaa-b1b8-a4616c22e2a6", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cvlookup.sgu.2023_candidate@gmail.com", new DateTime(2023, 10, 17, 0, 10, 51, 319, DateTimeKind.Local).AddTicks(5833), "4EvS5r40usEAzXH5nw6YyjfVVpQdHt7K+e7DBWXhKPKdrduCQ6W3M3Ala03/Tw8kFhLEGxHwealuxejQLZqg0y4nsngohze7rnldfpPHQ1Y=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "60260b18-eeb7-4b4b-9c32-8a5c9224c012", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cvlookup.sgu.2023@gmail.com", new DateTime(2023, 10, 17, 0, 10, 51, 319, DateTimeKind.Local).AddTicks(5802), "4EvS5r40usEAzXH5nw6YyjfVVpQdHt7K+e7DBWXhKPKdrduCQ6W3M3Ala03/Tw8kFhLEGxHwealuxejQLZqg0y4nsngohze7rnldfpPHQ1Y=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "c3eb39da-0ea6-420d-bdb8-ade41756a51e", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cvlookup.sgu.2023_employer@gmail.com", new DateTime(2023, 10, 17, 0, 10, 51, 319, DateTimeKind.Local).AddTicks(5825), "4EvS5r40usEAzXH5nw6YyjfVVpQdHt7K+e7DBWXhKPKdrduCQ6W3M3Ala03/Tw8kFhLEGxHwealuxejQLZqg0y4nsngohze7rnldfpPHQ1Y=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Experience",
                columns: new[] { "Id", "Exp" },
                values: new object[,]
                {
                    { "4a934cf9-4301-4c21-aa26-9f657ebcc19d", "Tất cả kinh nghiệm" },
                    { "4c074293-85de-4b2e-855a-e433fb4fea49", "Từ 5-10 năm" },
                    { "80952b10-ad48-43b5-ba56-c0cc5adfc9b0", "Từ 3-5 năm" },
                    { "a29b48a7-a80e-481b-8ac6-e39b36545640", "Từ 2-3 năm" },
                    { "aa77a84a-a221-4b70-918c-88e3fe752f9f", "Dưới 1 năm" },
                    { "ba58a13e-59b1-4fc9-9878-6b988be97729", "Trên 10 năm" },
                    { "c0959724-d417-46cc-97e6-4e4c1caf175c", "Từ 1-2 năm" },
                    { "e638f106-bcbf-4d93-bf67-777d847d40c0", "Chưa có kinh nghiệm" }
                });

            migrationBuilder.InsertData(
                table: "JobCareer",
                columns: new[] { "Id", "Career" },
                values: new object[,]
                {
                    { "07b84e67-6991-4c0b-bd18-99a34acb8655", "Luật / Pháp lý" },
                    { "151badea-9d75-47d7-aeee-385d66d0a167", "Y tế / Dược" },
                    { "15cdcadf-63fc-41f3-b3ce-68fc02dbebb6", "Khách sạn / Nhà hàng" },
                    { "18ddb749-5c41-4b93-9f5d-cea76962acee", "Ngân hàng / Tài chính" },
                    { "1a303880-eee9-4d70-b993-64f99027e4d4", "In ấn / Xuất bản" },
                    { "1d9e2085-436c-4547-a1de-e2d4c9806f21", "Bảo trì / Sửa chữa" },
                    { "1e8afab9-aeed-4419-bc70-057d9a27c721", "Tư vấn" },
                    { "1f28cc74-9c1c-402f-bee7-91c36dd0e4a9", "An toàn lao động" },
                    { "20272de9-cd5f-4f8b-b868-d3093fd5be27", "Vận tải / Kho vận" },
                    { "20c63f0c-56f8-4615-b52f-549fd61d7d76", "Sản xuất" },
                    { "21a9f9bb-b938-4d2e-8287-53ae9b4ada37", "Dệt may / Da giày" },
                    { "235956fc-05b0-4c60-ac37-644d40d41746", "Phi chính phủ / Phi lợi nhuận" },
                    { "25c786ea-1b76-427e-adcf-c442cf7502ed", "Bảo hiểm" },
                    { "2bee95ce-9028-4aee-875d-5563e0b2ff9a", "Mỹ phẩm / Trang sức" },
                    { "30631bea-6968-40fc-8b1c-7e458891d9de", "Kế toán / Kiểm toán" },
                    { "33802c7c-f1a2-416f-8c06-84949a9d38da", "Nông / Lâm / Ngư nghiệp" },
                    { "36ab5c75-0f68-4839-bc84-6f4320a19279", "Ngành nghề khác" },
                    { "3e96abef-e336-4ad8-b7b1-640a67524655", "Chứng khoán / Vàng / Ngoại tệ" },
                    { "41b2ae9a-8af9-4a98-a6c7-116094ca61a4", "Hàng gia dụng" },
                    { "49607e80-6b68-4af1-af11-5e6c3dcbf15e", "Xuất nhập khẩu" },
                    { "4dd09f7b-ac4b-4086-9197-d3f50e20bc40", "Điện / Điện tử / Điện lạnh" },
                    { "515d8e01-9e0b-4318-b9f6-a0f6a4b337fc", "Công nghệ Ô tô" },
                    { "54402148-9c84-468d-97e4-423e0014c341", "NGO / Phi chính phủ / Phi lợi nhuận" },
                    { "5d6f417c-f640-41af-b591-aad3e283bcf5", "Thư ký / Trợ lý" },
                    { "5e95a20c-15de-45f9-b26c-3652f0658941", "Kinh doanh / Bán hàng" },
                    { "630bfe5b-6d33-4404-b25c-182864628be3", "Dịch vụ khách hàng" },
                    { "63503b5f-7069-4843-8a50-9ae8c5c32d94", "Tổ chức sự kiện / Quà tặng" },
                    { "65d1b0d5-17dc-4997-b243-2f97ab97c2ec", "Công nghệ cao" },
                    { "66c9f608-ab0e-4890-8bc2-60e536225a1a", "Biên / Phiên dịch" },
                    { "6e3095ac-1ee7-4d89-a8ab-91eddf2a28f3", "Spa / Làm đẹp" },
                    { "6e74ba60-8318-4cac-9b69-6e3220a86978", "Hàng hải" }
                });

            migrationBuilder.InsertData(
                table: "JobCareer",
                columns: new[] { "Id", "Career" },
                values: new object[,]
                {
                    { "74976a4a-e902-4214-a45d-5a42ffca1943", "Bưu chính - Viễn thông" },
                    { "77bd7b79-3ec0-4765-bc88-1dd5a781cf7b", "Tất cả ngành nghề" },
                    { "827be9d9-2066-47ef-88cd-11c22463cd58", "IT Phần cứng / Mạng" },
                    { "8560b543-204f-4e0d-a582-7e361db9e948", "Sản phẩm công nghiệp" },
                    { "85af2494-559c-4c4b-a60a-b26b57d6e714", "Hoá học / Sinh học" },
                    { "86b36389-e8aa-42a7-a465-5a8c76e02de6", "Thiết kế đồ họa" },
                    { "873b8fae-61f8-4912-98a0-3c08f317762b", "Hàng tiêu dùng" },
                    { "8cbd8aea-d071-4cf1-87c4-1c5ea1249549", "IT phần mềm" },
                    { "8f626e7c-19ca-4196-a96e-45289e88c6da", "Tài chính / Đầu tư" },
                    { "91119c09-6982-4407-953d-41740f6ef5ff", "Kiến trúc" },
                    { "951ff3f0-c104-4540-a5be-3136977bcd44", "Bán hàng kỹ thuật" },
                    { "9cef199a-c28a-476a-8d3c-bce36f84cef7", "Marketing / Truyền thông / Quảng cáo" },
                    { "a89d7ae4-00b1-4d83-8ed0-2831a37cb93b", "Môi trường / Xử lý chất thải" },
                    { "aba15019-c215-47cb-889c-1591e7c66227", "Quản lý điều hành" },
                    { "abdff92d-1f87-43e2-b699-e5fc1bb4b7bb", "Địa chất / Khoáng sản" },
                    { "ae43443e-0115-4f0f-8fb1-647d0480a07d", "Mỹ thuật / Nghệ thuật / Điện ảnh" },
                    { "b8fb5344-c767-45a5-be95-dba3f47886a6", "Du lịch" },
                    { "b9891e8d-41e6-437d-ae19-7e507998e788", "Dầu khí/Hóa chất" },
                    { "bcfe4aff-308d-4bbb-b006-926cd287680d", "Nhân sự" },
                    { "bf71bf87-76a0-4949-b7e5-8a6a4e844373", "Hoạch định / Dự án" },
                    { "c05c983a-c875-485e-9f76-f5f502ef2d23", "Bất động sản" },
                    { "c306fee5-90b2-456f-945d-dfcbd107fe5a", "Báo chí / Truyền hình" },
                    { "c642978e-a0a3-46e7-884e-e5232dc41ee2", "Bán lẻ / bán sỉ" },
                    { "ceb452c4-1017-4023-9d84-903f927965aa", "Hành chính / Văn phòng" },
                    { "cfb5b010-b4ba-4de0-8754-11e7818e5ea4", "Hàng không" },
                    { "d0d3a1b4-8734-42af-8894-880a256224ee", "Quản lý chất lượng (QA/QC)" },
                    { "d82102bb-2a63-44be-aaf8-477cb4303037", "Điện tử viễn thông" },
                    { "d95cdf3b-d7d5-4134-b50f-41457b723ea6", "Thiết kế nội thất" },
                    { "dc28b3be-96c9-4a71-b7fd-5b162e95fa69", "Công nghệ thông tin" },
                    { "e058354a-e48b-4a0f-89d6-cf9cb15ead21", "Xây dựng" },
                    { "e334fc82-6dde-4f72-8343-c37fd06f6741", "Giáo dục / Đào tạo" },
                    { "ed03cfc7-ee45-40fe-9e0f-4e0015c09ec4", "Thực phẩm / Đồ uống" },
                    { "ed66088d-b555-4c68-b875-e83f35bba49f", "Logistics" },
                    { "ef7baec9-1c2c-44da-b027-45ae8525a68f", "Cơ khí / Chế tạo / Tự động hóa" },
                    { "f058359d-c244-4be4-ada2-71bfa46b7252", "Dược phẩm / Công nghệ sinh học" },
                    { "f2271918-f04c-41c4-b9df-c0e0f7564c36", "Thời trang" },
                    { "ff801988-222e-4d34-ae9d-cd35bfbdfeed", "Hàng cao cấp" }
                });

            migrationBuilder.InsertData(
                table: "JobField",
                columns: new[] { "Id", "Field" },
                values: new object[,]
                {
                    { "0093c160-93bb-4341-88a7-2f72b63c30c0", "Du lịch" },
                    { "0344bf40-0505-40de-b48c-43ad6dcddfbb", "Nhân sự" },
                    { "1e1b40e4-2a85-4ecc-a8ac-5ba017a54e3e", "Giải trí" },
                    { "1e23d8c2-b8a6-401c-beb7-e0aaba02167d", "Bảo trì / Sửa chữa" },
                    { "208dd62a-bb0a-456e-b59a-cc1f34fe0967", "Giáo dục / Đào tạo" }
                });

            migrationBuilder.InsertData(
                table: "JobField",
                columns: new[] { "Id", "Field" },
                values: new object[,]
                {
                    { "26506285-9564-45ec-a045-fcf23d61acef", "Agency (Marketing/Advertising)" },
                    { "2843c43a-372b-4b36-b0a3-3f09f7bd4cfe", "Bảo hiểm" },
                    { "2e15fdc4-545a-45be-b3d3-e57887627081", "Năng lượng" },
                    { "30627efb-038e-44ae-8a8b-33c74b4bae0c", "Viễn thông" },
                    { "351ba2d1-0642-4738-a597-995b7dbbceff", "Khác" },
                    { "3baef811-4394-4df7-a24b-3de37b31a7e7", "Ngân hàng" },
                    { "4173900a-80af-4274-8572-c19707a5195c", "Sản xuất" },
                    { "4ba8c954-c29f-4ce9-ac38-3e16334f957e", "Dược phẩm / Y tế / Công nghệ sinh học" },
                    { "4fbf23b6-3db5-4a8d-8873-e36b905b9f22", "Thời trang" },
                    { "50f35a5d-99d4-41ff-9343-0452c090afc0", "Môi trường" },
                    { "51bfeed4-9661-4489-871c-4eacda96b679", "Luật" },
                    { "5e996ece-8474-4672-abdd-40ddef2ba753", "Tài chính" },
                    { "63bf6232-e981-4f13-a341-2c1aa1463c47", "Chứng khoán" },
                    { "6cd723ed-a194-427e-ac8a-65fd6862afdc", "Bất động sản" },
                    { "7b278d85-2ac1-4fc2-bd44-13fb8da5fce8", "Xây dựng" },
                    { "83be5df1-ca8f-4f90-800c-d93a0c42e9e7", "IT - Phần mềm" },
                    { "876553ec-6ef2-4364-afab-267680409578", "Tự động hóa" },
                    { "8d302cc7-8269-405b-af4b-25bca78ebbf1", "In ấn / Xuất bản" },
                    { "980c8921-6104-4759-bfd1-b1a91c81c95b", "Cơ khí" },
                    { "995baff9-277f-49f8-b345-eaafdb560049", "Kế toán / Kiểm toán" },
                    { "9b24913a-2243-4de0-9af0-651169a8eaf4", "Agency (Design/Development)" },
                    { "a00fdbe6-7080-4659-b874-c637cc4eeaaa", "Tổ chức phi lợi nhuận" },
                    { "a4297576-2e65-47e9-a8cd-d005de4b3548", "Logistics - Vận tải" },
                    { "a8123c0c-6d24-4050-9b37-735a395d6ccb", "Tất cả lĩnh vực" },
                    { "bf6d7957-86da-4636-86bc-a181dddafcaa", "Xuất nhập khẩu" },
                    { "c76d7767-efa9-4432-824d-f2bd8b9074cc", "Nhà hàng / Khách sạn" },
                    { "c842584c-2a83-44ff-bf03-b39d441dff4b", "Nông Lâm Ngư nghiệp" },
                    { "cd38c505-da75-45de-856b-c9c1dec34f24", "Internet / Online" },
                    { "d6a7404c-f594-4fea-9b72-2b0151e0c3e6", "Bán lẻ - Hàng tiêu dùng - FMCG" },
                    { "da1c2fea-bce1-4a18-95f2-fc16c979fe08", "IT - Phần cứng" },
                    { "dbab7baf-18de-48c2-8a66-0496c2a4d247", "Cơ quan nhà nước" },
                    { "ddb85976-99c9-4716-afc7-6b9cb3a0df76", "Marketing / Truyền thông / Quảng cáo" },
                    { "dfbc9b72-424b-4988-89a2-360a146aece3", "Điện tử / Điện lạnh" },
                    { "e1ff8d91-6331-4798-b2b2-29263768a2fa", "Tư vấn" },
                    { "f71a90e8-6823-499a-a958-399a984d3108", "Thiết kế / kiến trúc" },
                    { "f7d9b9f1-4925-427f-9ea7-8a65a69ef9ee", "Thương mại điện tử" }
                });

            migrationBuilder.InsertData(
                table: "JobForm",
                columns: new[] { "Id", "Form" },
                values: new object[,]
                {
                    { "0cffb2bd-d7cc-4ac0-9273-968571147806", "Thực tập" },
                    { "31cdcf75-89b6-43c6-9b2d-5ef8b831538c", "Toàn thời gian" },
                    { "f414c201-eb36-40f3-89fb-b8d1f1719017", "Bán thời gian" },
                    { "fbbe9be4-f3bf-4869-aa23-87bd0712201e", "Tất cả hình thức" }
                });

            migrationBuilder.InsertData(
                table: "JobPosition",
                columns: new[] { "Id", "Position" },
                values: new object[,]
                {
                    { "029fa2ea-0588-4135-b88b-a65bb041dfb6", "Trưởng chi nhánh" },
                    { "1a0e4929-d563-4386-a9b0-04539e17cb1e", "Tất cả vị trí" }
                });

            migrationBuilder.InsertData(
                table: "JobPosition",
                columns: new[] { "Id", "Position" },
                values: new object[,]
                {
                    { "312f5c8b-6f0c-4fa0-9144-068a5e5359a4", "Nhân viên" },
                    { "3678d822-6a27-4640-a000-f1107945ac18", "Thực tập sinh" },
                    { "3d4f0420-5073-4dec-b065-ad526acebdb6", "Quản lí / Giám sát" },
                    { "55911c00-339b-49c7-b5de-e8d850dac88c", "Trưởng nhóm" },
                    { "e29e5e8a-be99-42b5-ac4c-26b76b7e893a", "Giám đốc" },
                    { "eb743096-904d-4010-b63a-587089115203", "Phó giám đốc" },
                    { "ec1418eb-3cbf-482f-a76d-305d793f5e5b", "Trưởng / Phó phòng" }
                });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "04f76fea-8dd8-49fc-aafb-29aeacd38848", "Bình Định" },
                    { "0cc07c6a-e8a1-417a-a16f-18a2b9ba25a0", "Hòa Bình" },
                    { "0f304949-e662-4e4c-96d9-3e2d0219e98c", "Yên Bái" },
                    { "0fe59878-bc71-4373-b801-2c5e61c81903", "Hà Nội" },
                    { "10703521-d9d6-470f-932a-3f123fd4c10d", "Sơn La" },
                    { "170b7c31-6041-4ffa-b41b-dc2506f1777d", "Lào Cai" },
                    { "186dc352-677a-40a2-827e-d7f5a8718b51", "Cao Bằng" },
                    { "1add6100-e32b-4a9d-87bb-4c370447d9d3", "Hà Nam" },
                    { "1ef531c8-4fc5-4579-b381-6e6d92c1561e", "Bình Dương" },
                    { "214767f6-867f-427f-a35c-c0ccd0e719e0", "Lai Châu" },
                    { "26284428-dd17-4b1e-b9ed-9df12df9bae0", "Đồng Nai" },
                    { "27ea5c3f-64ed-4efd-8bb4-f9fafca3f4c1", "Hải Dương" },
                    { "2c141aba-999e-4f83-a567-de9c81d3fca0", "Cần Thơ" },
                    { "2d000809-d551-4715-919e-ece28c387213", "Thanh Hóa" },
                    { "2d14a3c3-3a94-4af6-8ea1-3736690eea66", "Tây Ninh" },
                    { "2f3b507e-a04b-4d40-8adf-f9bac4776f2e", "Cà Mau" },
                    { "3816cf0d-ffa6-4033-8ec8-e8d23aa6307d", "Hà Giang" },
                    { "3938185b-9b2f-4c4a-8151-42a89d636290", "Quảng Ninh" },
                    { "3a23c7ff-78b0-4eea-99e1-0a06cd06b583", "Kiên Giang" },
                    { "428faee7-e262-41d5-b8e1-f35ab9b315b8", "Đắk Lắk" },
                    { "4445c0b7-68c0-45ce-bcc1-88f9e0933c39", "Ninh Bình" },
                    { "4ea24143-5e9a-4f83-aa5b-7da11164595a", "Đồng Tháp" },
                    { "560755df-da99-4fa8-9260-1544c8367469", "Bình Thuận" },
                    { "57d98f22-73cb-4dd1-a71c-078f9103071a", "Hải Phòng" },
                    { "5a198212-b45e-4035-954a-31e5ab3b7f19", "Bình Phước" },
                    { "5babbdf8-3f41-4e54-abbf-5dc3368874aa", "Nam Định" },
                    { "5d4183aa-0659-4fc3-b3fd-99d2c792c59b", "Phú Yên" },
                    { "66fa3a6a-2848-47b0-8cd9-e7d177d8982c", "Hà Tĩnh" },
                    { "6766a5a3-218e-4c2a-a438-a4f04ffc6e11", "Thái Bình" },
                    { "6c7e6368-ae50-4b33-a813-cfa6d83c9581", "Trà Vinh" },
                    { "71066e47-62bc-4ac6-997a-539d65e0e22f", "Bắc Giang" },
                    { "75ec84d8-a078-4025-a165-64af14b27e11", "Quảng Ngãi" },
                    { "7a027dd0-11d6-4aec-a9b2-36b2a8ddbed5", "Hưng Yên" },
                    { "7cd6ce71-c9f6-4d82-b579-a2355b25ecdb", "Nghệ An" },
                    { "7f0fe692-3f29-4b80-a3b6-63389037def7", "Quảng Bình" }
                });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "7f1887c7-bb58-4119-acb8-6aae020b8b5b", "Bạc Liêu" },
                    { "806e5673-3cbb-44e1-8efc-b075133528c3", "Thừa Thiên Huế" },
                    { "8251ac06-e218-44f4-8515-cfa1dde35cf5", "Vĩnh Long" },
                    { "88976b7f-1504-4a39-ae06-bd6c6e0a1237", "Thái Nguyên" },
                    { "88dbdce8-afcc-4994-8cc1-1040dcf95bde", "Tiền Giang" },
                    { "8acb81df-c596-4637-a4f5-cb5762ee5503", "Lạng Sơn" },
                    { "8c2fdd85-8f67-4e28-9f00-ed24266357dc", "Bắc Ninh" },
                    { "999656a2-17a5-4800-b3bd-79993e70ab58", "Đắk Nông" },
                    { "9afc2d05-80f1-4a1a-8d62-c0fe8dd7b8ed", "An Giang" },
                    { "a61b4d79-ff70-4de4-b7f9-69e1f8d6f2a9", "Tuyên Quang" },
                    { "a72daa5a-fbad-48bd-a3e2-5f81a35c0f12", "Hồ Chí Minh" },
                    { "a8691018-335c-466a-8edc-94d15d2d1b77", "Hậu Giang" },
                    { "af20489f-fabb-414c-914d-7ea28f3c0d52", "Bắc Kạn" },
                    { "ba8f0083-5b74-43f4-9d4e-71aabaa262aa", "Vĩnh Phúc" },
                    { "bb7e4128-e55f-4fbd-ae03-7bc7bd624d95", "Bà Rịa-Vũng Tàu" },
                    { "c00a4267-72ce-44d2-98cf-27786f34199a", "Long An" },
                    { "c9b4766d-ecf5-4c1e-b1b8-bb1b3629d2fe", "Tất cả tỉnh thành" },
                    { "d9344f84-28f7-4cb7-81e2-222532e5a682", "Gia Lai" },
                    { "dd6068fe-46aa-48ce-ac7e-8301fb3e5eeb", "Điện Biên" },
                    { "de1318fe-ca09-4efa-bcf2-55a0fbd1737b", "Quảng Trị" },
                    { "e4ba0518-6433-4988-a5b2-064556be4526", "Bến Tre" },
                    { "e75e5dcd-559c-4069-a437-55f7caf7a61a", "Khánh Hòa" },
                    { "e7b63ff2-f05f-4d6c-ac8b-b10f617d889e", "Kon Tum" },
                    { "e9e3bf42-544a-4e4d-8ba2-01f0d73df9d6", "Đà Nẵng" },
                    { "eb3399cb-e21d-4992-86ee-ffd2f4f5c36b", "Quảng Nam" },
                    { "f3f62e43-9f04-4790-978a-6b7266fa5bd1", "Ninh Thuận" },
                    { "f58409db-17a8-4f62-b44a-4f1f3f6c1ab6", "Phú Thọ" },
                    { "f5ca393e-1f7e-45ed-bf76-d0062d09d16f", "Lâm Đồng" },
                    { "fe2a2483-198a-476b-9401-f81734a978dc", "Sóc Trăng" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { "06aa6708-e946-4505-8ac6-e581eaf1e9b0", "Employer" },
                    { "1380e3ef-45d9-4e41-858c-e2de80f113b6", "Admin" },
                    { "f53bc26d-ddbb-48b5-81f1-fc301df0f90d", "Candidate" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Avatar", "DateOfBirth", "Discriminator", "Email", "PhoneNumber", "Username" },
                values: new object[] { "889fcedb-d7ac-422d-aba2-bc11d988717c", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Candidate", "cvlookup.sgu.2023_candidate@gmail.com", null, "Candidate Admin" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Address", "Avatar", "Description", "Discriminator", "Email", "PhoneNumber", "Username" },
                values: new object[] { "3529b065-285d-46a9-955d-8fc075f86bc1", "Admin", null, "Admin", "Employer", "cvlookup.sgu.2023_employer@gmail.com", null, "Employer Admin" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Avatar", "Discriminator", "Email", "PhoneNumber", "Username" },
                values: new object[] { "467dad13-d542-44dd-a7cc-085cb8d4bcdf", null, "User", "cvlookup.sgu.2023@gmail.com", null, "General Admin" });

            migrationBuilder.InsertData(
                table: "AccountUser",
                columns: new[] { "AccountId", "UserId" },
                values: new object[,]
                {
                    { "442e5617-c6c8-4eaa-b1b8-a4616c22e2a6", "889fcedb-d7ac-422d-aba2-bc11d988717c" },
                    { "60260b18-eeb7-4b4b-9c32-8a5c9224c012", "467dad13-d542-44dd-a7cc-085cb8d4bcdf" },
                    { "c3eb39da-0ea6-420d-bdb8-ade41756a51e", "3529b065-285d-46a9-955d-8fc075f86bc1" }
                });

            migrationBuilder.InsertData(
                table: "District",
                columns: new[] { "Id", "Name", "ProvinceId" },
                values: new object[,]
                {
                    { "00f41d37-5144-4124-bbf2-de96123b70ca", "Quận Ô Môn", "2c141aba-999e-4f83-a567-de9c81d3fca0" },
                    { "01ddbe60-7e88-4e1b-aba3-e812d7426f6e", "Quận Sơn Trà", "e9e3bf42-544a-4e4d-8ba2-01f0d73df9d6" },
                    { "01fb65bf-f7af-442c-89be-28466b462613", "Quận 2", "a72daa5a-fbad-48bd-a3e2-5f81a35c0f12" },
                    { "0286bb5e-6b32-493b-877d-a948fc639f99", "Quận 3", "a72daa5a-fbad-48bd-a3e2-5f81a35c0f12" },
                    { "131584f7-90ca-41ee-a6f7-a0240e5026e9", "Quận 7", "a72daa5a-fbad-48bd-a3e2-5f81a35c0f12" },
                    { "1614cd55-e59d-42ad-9fc0-b4e1ab7673da", "Quận Đồ Sơn", "57d98f22-73cb-4dd1-a71c-078f9103071a" },
                    { "1800bc1d-d447-470b-afc8-2a895b374c83", "Quận Thủ Đức", "a72daa5a-fbad-48bd-a3e2-5f81a35c0f12" },
                    { "221a1885-5366-483a-9cf2-a8c03b4ec26e", "Quận Ninh Kiều", "2c141aba-999e-4f83-a567-de9c81d3fca0" },
                    { "255bbe9e-2364-4c59-a7bc-49515bbbdc7f", "Quận Bình Thạnh", "a72daa5a-fbad-48bd-a3e2-5f81a35c0f12" },
                    { "25d1fa8c-19dc-47a6-8cfe-46c59dda449d", "Quận 5", "a72daa5a-fbad-48bd-a3e2-5f81a35c0f12" },
                    { "2bb2f5d6-791c-4f96-a27d-c238dad25f07", "Quận 12", "a72daa5a-fbad-48bd-a3e2-5f81a35c0f12" },
                    { "2bbf9044-c010-488f-9f11-6c9d6fd4e9a6", "Quận Hoàng Mai", "0fe59878-bc71-4373-b801-2c5e61c81903" },
                    { "2d65c25b-15f3-4909-90f5-c69a4601bda6", "Quận Bình Thuỷ", "2c141aba-999e-4f83-a567-de9c81d3fca0" },
                    { "31c7ff6b-0385-4340-9725-923fe0e3f06c", "Quận Phú Nhuận", "a72daa5a-fbad-48bd-a3e2-5f81a35c0f12" },
                    { "361a1914-64ce-48fc-b00e-d8fe9d71f470", "Quận 8", "a72daa5a-fbad-48bd-a3e2-5f81a35c0f12" },
                    { "3963bddb-66d9-4291-9708-751721019069", "Quận Tân Bình", "a72daa5a-fbad-48bd-a3e2-5f81a35c0f12" },
                    { "483a27bd-f494-423f-8c28-81167d658424", "Quận Thanh Khê", "e9e3bf42-544a-4e4d-8ba2-01f0d73df9d6" },
                    { "4e537163-8cf8-4d92-a526-145cfccb6243", "Quận Cẩm Lệ", "e9e3bf42-544a-4e4d-8ba2-01f0d73df9d6" },
                    { "4f6f29d2-522c-48fc-be41-6475e2759b3e", "Quận Ngô Quyền", "57d98f22-73cb-4dd1-a71c-078f9103071a" },
                    { "4fa52a70-5da6-40e2-a8c9-1cf8f148de8f", "Quận Ba Đình", "0fe59878-bc71-4373-b801-2c5e61c81903" },
                    { "55db2042-f1b9-4440-9006-1a09aaa5d2d0", "Quận Hồng Bàng", "57d98f22-73cb-4dd1-a71c-078f9103071a" },
                    { "567d8d3a-3288-41d1-9bd8-5f2f1c7fa33a", "Quận Hai Bà Trưng", "0fe59878-bc71-4373-b801-2c5e61c81903" },
                    { "5cbf209d-d207-4c0a-bf13-f912542db914", "Quận Tân Phú", "a72daa5a-fbad-48bd-a3e2-5f81a35c0f12" },
                    { "62961086-7e45-43ef-9942-a8920822cc0f", "Quận Cái Răng", "2c141aba-999e-4f83-a567-de9c81d3fca0" },
                    { "65fb8ee7-2649-4057-8c7b-d4cd294b6875", "Quận Hải Châu", "e9e3bf42-544a-4e4d-8ba2-01f0d73df9d6" },
                    { "675b1d7e-d648-4b00-89f4-5f5e9be81844", "Quận Hoàn Kiếm", "0fe59878-bc71-4373-b801-2c5e61c81903" },
                    { "6c5b64db-4233-44d0-b390-ef242fb63540", "Quận Thanh Xuân", "0fe59878-bc71-4373-b801-2c5e61c81903" },
                    { "6f1c062e-dc67-4f37-abdf-0a7b0c6cdd3f", "Quận Kiến An", "57d98f22-73cb-4dd1-a71c-078f9103071a" },
                    { "6f420f06-c85c-4529-a940-3bd07752e6f1", "Quận 4", "a72daa5a-fbad-48bd-a3e2-5f81a35c0f12" },
                    { "72fafe92-e0a7-494d-aa53-05c894fcb981", "Quận Dương Kinh", "57d98f22-73cb-4dd1-a71c-078f9103071a" },
                    { "73274d7b-724c-4af0-a1fe-1f4416adef9e", "Quận Hà Đông", "0fe59878-bc71-4373-b801-2c5e61c81903" },
                    { "7b68936f-2826-418c-aad3-a4c8bfed3f24", "Quận Hải An", "57d98f22-73cb-4dd1-a71c-078f9103071a" },
                    { "8c97d58e-4f5d-4fc2-8530-3b87ff780f37", "Quận Nam Từ Liêm", "0fe59878-bc71-4373-b801-2c5e61c81903" },
                    { "91fc7185-d7aa-4021-9ee2-262b7edeece0", "Quận 9", "a72daa5a-fbad-48bd-a3e2-5f81a35c0f12" },
                    { "9ed3c324-6495-47dc-b857-9ecba668f7da", "Quận Đống Đa", "0fe59878-bc71-4373-b801-2c5e61c81903" },
                    { "abf3bc1f-0e21-4c4c-a88e-507678840e85", "Quận Tây Hồ", "0fe59878-bc71-4373-b801-2c5e61c81903" },
                    { "b0758377-bc95-4b20-83f4-39f2a9fe8c20", "Quận Cầu Giấy", "0fe59878-bc71-4373-b801-2c5e61c81903" },
                    { "bdd7a52b-bb4c-4543-b6e0-b71afe6e3dec", "Quận Thốt Nốt", "2c141aba-999e-4f83-a567-de9c81d3fca0" },
                    { "bfcd5c27-e89d-4faa-aeaa-02639c50a2f5", "Quận Ngũ Hành Sơn", "e9e3bf42-544a-4e4d-8ba2-01f0d73df9d6" }
                });

            migrationBuilder.InsertData(
                table: "District",
                columns: new[] { "Id", "Name", "ProvinceId" },
                values: new object[,]
                {
                    { "c939c08f-f8a4-4e09-bdc6-035675612e1b", "Quận 1", "a72daa5a-fbad-48bd-a3e2-5f81a35c0f12" },
                    { "d692d4b1-217c-4812-afb8-f5a95efeae76", "Quận 10", "a72daa5a-fbad-48bd-a3e2-5f81a35c0f12" },
                    { "d949c018-26fa-41a1-9a4e-b09385cbd4ed", "Quận Liên Chiểu", "e9e3bf42-544a-4e4d-8ba2-01f0d73df9d6" },
                    { "d9706b25-7a48-4a14-9fb9-3b0ddea4b5e7", "Quận Bình Tân", "a72daa5a-fbad-48bd-a3e2-5f81a35c0f12" },
                    { "daf4f99b-d187-48bd-bd88-88cb104cd9cf", "Quận Gò Vấp", "a72daa5a-fbad-48bd-a3e2-5f81a35c0f12" },
                    { "df104f9b-3d54-4be0-a45d-6b2ed3b69c48", "Quận Long Biên", "0fe59878-bc71-4373-b801-2c5e61c81903" },
                    { "ecc30c0d-8519-47e7-a3f2-b1995049076a", "Quận Bắc Từ Liêm", "0fe59878-bc71-4373-b801-2c5e61c81903" },
                    { "f12d404d-86b5-41c1-bbec-faaaafd69159", "Quận 6", "a72daa5a-fbad-48bd-a3e2-5f81a35c0f12" },
                    { "fda2cfff-3011-4111-8623-f11a573780ab", "Quận 11", "a72daa5a-fbad-48bd-a3e2-5f81a35c0f12" },
                    { "fece78a5-db60-43a9-8310-5edcaf3ec5cb", "Quận Lê Chân", "57d98f22-73cb-4dd1-a71c-078f9103071a" }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "06aa6708-e946-4505-8ac6-e581eaf1e9b0", "3529b065-285d-46a9-955d-8fc075f86bc1" },
                    { "1380e3ef-45d9-4e41-858c-e2de80f113b6", "467dad13-d542-44dd-a7cc-085cb8d4bcdf" },
                    { "f53bc26d-ddbb-48b5-81f1-fc301df0f90d", "889fcedb-d7ac-422d-aba2-bc11d988717c" }
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
