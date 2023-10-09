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
                name: "JobAddress",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                values: new object[] { "a0f8ae06-2015-483f-a965-bae8076cdc5b", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cvlookup.sgu.2023@gmail.com", new DateTime(2023, 10, 9, 16, 20, 17, 489, DateTimeKind.Local).AddTicks(7426), "4EvS5r40usEAzXH5nw6YyjfVVpQdHt7K+e7DBWXhKPKdrduCQ6W3M3Ala03/Tw8kFhLEGxHwealuxejQLZqg0y4nsngohze7rnldfpPHQ1Y=", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "02a45a51-218a-4b4e-b385-dca7e6ed40bb", "Bình Phước" },
                    { "094e5d8d-094a-4c51-b96e-533a9f838f38", "Đồng Nai" },
                    { "10a9b650-8579-4f99-b475-4108e37bbf41", "Thanh Hóa" },
                    { "156bf526-c7fd-4f6c-85ed-3a00c06bac6a", "Hà Nội" },
                    { "1c7cd154-a48a-4182-af13-3369a0753cfd", "Tiền Giang" },
                    { "234a1897-fdef-485e-8d2e-f2129a860347", "Bình Định" },
                    { "2ab616c5-a907-4a71-a37b-9e6402213133", "Thái Nguyên" },
                    { "32f727cd-8de5-4a9c-a48a-b176296166e6", "Cao Bằng" },
                    { "37449aae-cf7d-4fc5-85d2-15559b338df6", "Bà Rịa-Vũng Tàu" },
                    { "40e66034-1153-4b9f-bbf7-0a50b15d6773", "Ninh Thuận" },
                    { "41afe4f1-b3a3-49e2-963f-9ec12d4de6a0", "Cà Mau" },
                    { "44394de2-ec56-43ee-899b-c8fd6209fbe0", "Lai Châu" },
                    { "46b30254-8722-4e4d-a796-3f710bbf03fd", "Tây Ninh" },
                    { "51f601cf-4bb0-46fe-9775-b81b3a1902d7", "Bình Thuận" },
                    { "522131f2-e6a5-4be6-b74d-90cbcbc8e4b1", "Điện Biên" },
                    { "5ca5e764-4e7b-4a3a-8bde-b124b0cec69f", "Bình Dương" },
                    { "5d0a7442-0a0e-44f2-9380-e8e67b49c73f", "Lâm Đồng" },
                    { "5d9b15db-1559-4c46-8479-121ae48af07c", "Thái Bình" },
                    { "5ede644e-9510-416f-922b-9104bdcaf5b2", "Hòa Bình" },
                    { "5f2aed7a-03bb-4516-8284-d627d085fef5", "Quảng Trị" },
                    { "5f728aa4-1d6e-4207-aeb4-fa6ae207e29a", "Hậu Giang" },
                    { "63b03b3f-8fbb-4549-876d-9e4263defa5d", "Phú Yên" },
                    { "6c5b10d1-0a87-4e87-8f66-bef01e2ae256", "Hồ Chí Minh" },
                    { "76f3ce0c-4656-486d-8fe4-79ab54304122", "Bắc Kạn" },
                    { "7a137f81-3b56-46f5-8ebd-d143d1db4bb6", "Kon Tum" },
                    { "7cf4296c-4aef-4cf3-ae80-f1b533986e89", "Hà Nam" },
                    { "7fd6a237-f21b-4c69-b6fb-b6a5459e319c", "An Giang" },
                    { "866b6804-191f-462f-8f92-5d0b04b7d221", "Quảng Bình" },
                    { "9264efcf-c8b8-4e68-a9db-55e46c92ae17", "Hà Tĩnh" },
                    { "93fffbbe-e76f-4c25-b829-f90da5590bca", "Hà Giang" },
                    { "9a2a06fb-6658-4279-a617-7ed95881b00c", "Bắc Giang" },
                    { "9b2f6139-db1e-420e-9e16-5797b56f1ac7", "Kiên Giang" },
                    { "9b92f26d-6d19-4957-b571-9b761ca0d9fe", "Lào Cai" },
                    { "9c739e24-0b8c-48ad-b0f7-ccef8618d0de", "Sóc Trăng" },
                    { "9d27774b-9539-47c5-b974-02836234287a", "Lạng Sơn" },
                    { "9ff82575-ed30-483e-a414-50f1c6424772", "Vĩnh Phúc" },
                    { "a01b6331-d3f9-46b5-bfc4-e8fc6a234999", "Phú Thọ" },
                    { "a1cd2457-ae55-463b-a0e3-302e6633246a", "Cần Thơ" },
                    { "a31c8358-626e-4a41-9bf0-c5a1e444161c", "Long An" },
                    { "ad9249fb-ad5c-43ea-b742-12ea91393081", "Quảng Ninh" },
                    { "b0416280-ccd5-41c7-9c92-766352985bf3", "Đà Nẵng" }
                });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "b1d599d4-3f6f-4023-a482-ac04a442c6bb", "Thừa Thiên Huế" },
                    { "b552d3bd-ff04-4aa8-bb17-f47777da7df6", "Đắk Lắk" },
                    { "b646ee01-3baf-46b7-beba-b81862ff8043", "Hải Phòng" },
                    { "b6496e85-c61c-4ca9-8ab6-0a8fb13cc360", "Sơn La" },
                    { "c116ac20-93d9-474d-ba26-5a4ecf2fada0", "Hải Dương" },
                    { "c26f3b28-3e54-46d3-b5f9-87e20128d6e1", "Khánh Hòa" },
                    { "c341b246-7999-4859-8c2e-75fd72dacbed", "Nghệ An" },
                    { "c3897813-c729-49b1-bcdb-58f8627aa0f0", "Trà Vinh" },
                    { "c423b79a-eda3-4f94-9aad-2e624bf81f06", "Ninh Bình" },
                    { "c8913797-c162-4fba-8ffc-34d808f47135", "Hưng Yên" },
                    { "ceace927-454b-4eb5-badf-17b20959cc6a", "Tuyên Quang" },
                    { "d97f9507-4c77-4406-92c0-7598cce241ef", "Bạc Liêu" },
                    { "e1747a1e-0c11-492a-b209-f6e595f17fd3", "Nam Định" },
                    { "e3a8d558-6f5e-455b-877b-8dfbd1aa6fcb", "Quảng Ngãi" },
                    { "ed3e7f70-53ae-41b0-adb3-9539e1b0533e", "Vĩnh Long" },
                    { "ed77dd5b-df3b-40e0-8086-56adb1515cd5", "Đắk Nông" },
                    { "edad33c0-c7b6-42fd-9351-ba6983a64b43", "Quảng Nam" },
                    { "f1646799-d21a-490e-8388-d8d21bf00dfb", "Bến Tre" },
                    { "f18a6860-9ed5-419a-afac-488ab6154e05", "Bắc Ninh" },
                    { "f501ad4c-552e-4bf2-a21c-3a2a0d965a43", "Đồng Tháp" },
                    { "f7f0b01d-4490-4e78-9492-2fd1fccb3dc8", "Yên Bái" },
                    { "fbc1bdc7-65e2-46ad-88be-39018603d9fd", "Gia Lai" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { "01234fa9-5cde-43ba-be45-07429bfbee40", "Candidate" },
                    { "8877c75f-8aef-453c-847c-604eaff53e29", "Employer" },
                    { "a0305f87-441d-482b-9f94-6192fadf48eb", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Avatar", "Discriminator", "Email", "PhoneNumber" },
                values: new object[] { "f00739eb-9e82-4c73-bea4-4c54f14f2832", null, "User", "cvlookup.sgu.2023@gmail.com", null });

            migrationBuilder.InsertData(
                table: "AccountUser",
                columns: new[] { "AccountId", "UserId" },
                values: new object[] { "a0f8ae06-2015-483f-a965-bae8076cdc5b", "f00739eb-9e82-4c73-bea4-4c54f14f2832" });

            migrationBuilder.InsertData(
                table: "District",
                columns: new[] { "Id", "Name", "ProvinceId" },
                values: new object[,]
                {
                    { "027a1137-d53c-42b5-bf79-0c266e09e44d", "Quận Nam Từ Liêm", "156bf526-c7fd-4f6c-85ed-3a00c06bac6a" },
                    { "05868934-4128-484f-82cd-4c3c4a422122", "Quận Tân Bình", "6c5b10d1-0a87-4e87-8f66-bef01e2ae256" },
                    { "060b5f05-bc79-44aa-8bbd-d9a99414ab05", "Quận Tây Hồ", "156bf526-c7fd-4f6c-85ed-3a00c06bac6a" },
                    { "0802a493-a047-447f-9b18-185cb9f6c446", "Quận 2", "6c5b10d1-0a87-4e87-8f66-bef01e2ae256" },
                    { "09f9764b-0933-401c-bcfc-3cf82952330b", "Quận Phú Nhuận", "6c5b10d1-0a87-4e87-8f66-bef01e2ae256" },
                    { "0ff370af-7401-48f5-8a0e-69749c73d827", "Quận Cẩm Lệ", "b0416280-ccd5-41c7-9c92-766352985bf3" },
                    { "100f24ae-eb8f-4dcb-b53e-9f229fe13982", "Quận Tân Phú", "6c5b10d1-0a87-4e87-8f66-bef01e2ae256" },
                    { "10e1c3d4-0b27-4820-8f44-9a494fc8ef12", "Quận Đồ Sơn", "b646ee01-3baf-46b7-beba-b81862ff8043" },
                    { "11a31e5f-1e19-474a-badf-7b1f5915a23e", "Quận Ngũ Hành Sơn", "b0416280-ccd5-41c7-9c92-766352985bf3" },
                    { "12e39fee-ef45-4b12-879a-513761d0b5ca", "Quận Hồng Bàng", "b646ee01-3baf-46b7-beba-b81862ff8043" },
                    { "17eef594-a5ad-413c-a331-4679d9f5eff0", "Quận Dương Kinh", "b646ee01-3baf-46b7-beba-b81862ff8043" },
                    { "1dcc213b-0f65-4c44-b82b-d7b2d294f65d", "Quận 9", "6c5b10d1-0a87-4e87-8f66-bef01e2ae256" },
                    { "227d4752-9473-41a4-bc36-793406e09f67", "Quận Kiến An", "b646ee01-3baf-46b7-beba-b81862ff8043" },
                    { "23bdf9dd-627f-417d-b3f1-b24fef07131d", "Quận Ninh Kiều", "a1cd2457-ae55-463b-a0e3-302e6633246a" },
                    { "2acc3a27-1d41-4811-9fa0-80262b4a508b", "Quận Long Biên", "156bf526-c7fd-4f6c-85ed-3a00c06bac6a" },
                    { "3fd9f224-c0b0-4371-aaaf-81e15f3d035a", "Quận Bình Thạnh", "6c5b10d1-0a87-4e87-8f66-bef01e2ae256" },
                    { "401c4ede-60e6-4a52-b879-804747d144fe", "Quận Đống Đa", "156bf526-c7fd-4f6c-85ed-3a00c06bac6a" },
                    { "47a65f7c-bee4-439b-805f-e7b1c3020ae2", "Quận Hoàn Kiếm", "156bf526-c7fd-4f6c-85ed-3a00c06bac6a" },
                    { "4c3a1e5e-e2b9-40a7-a396-5716880a2510", "Quận Lê Chân", "b646ee01-3baf-46b7-beba-b81862ff8043" },
                    { "50008f39-a70f-4e57-a872-d1a5c1880339", "Quận 4", "6c5b10d1-0a87-4e87-8f66-bef01e2ae256" },
                    { "546c4fa6-b622-411d-a62e-0d2444da25ee", "Quận Hải An", "b646ee01-3baf-46b7-beba-b81862ff8043" },
                    { "57549019-6278-445c-b5a8-48a9c23deafb", "Quận Thủ Đức", "6c5b10d1-0a87-4e87-8f66-bef01e2ae256" },
                    { "6a5a43fd-b697-4153-aa88-b7cde67474ed", "Quận 7", "6c5b10d1-0a87-4e87-8f66-bef01e2ae256" },
                    { "75554002-6396-41a9-881d-72fe593ab1e0", "Quận Ba Đình", "156bf526-c7fd-4f6c-85ed-3a00c06bac6a" },
                    { "7585e982-3eae-4ab7-8bed-305af00f3be2", "Quận Bắc Từ Liêm", "156bf526-c7fd-4f6c-85ed-3a00c06bac6a" },
                    { "8cf1aaa8-8ad4-4e05-ae6c-4e6e33b956e0", "Quận Thốt Nốt", "a1cd2457-ae55-463b-a0e3-302e6633246a" },
                    { "8da8826a-6ec1-48e4-aa21-b96ba23eab47", "Quận Cái Răng", "a1cd2457-ae55-463b-a0e3-302e6633246a" },
                    { "925645de-bb3b-47c3-8026-2ef2d17db58f", "Quận Thanh Khê", "b0416280-ccd5-41c7-9c92-766352985bf3" },
                    { "97ab1b11-1393-45fd-87f3-e8a27724af01", "Quận Sơn Trà", "b0416280-ccd5-41c7-9c92-766352985bf3" },
                    { "a35b11ed-06c0-47ed-af91-169d111fc755", "Quận Ngô Quyền", "b646ee01-3baf-46b7-beba-b81862ff8043" },
                    { "a60171e3-5f7a-4245-84ce-b10d85223992", "Quận Cầu Giấy", "156bf526-c7fd-4f6c-85ed-3a00c06bac6a" },
                    { "ab1e18d7-9ef1-458a-a857-b6dd432bf577", "Quận Hoàng Mai", "156bf526-c7fd-4f6c-85ed-3a00c06bac6a" },
                    { "b5208ce7-cecb-469d-9c69-8830d30fd097", "Quận 12", "6c5b10d1-0a87-4e87-8f66-bef01e2ae256" },
                    { "b752ed59-862c-4475-9180-fcdc5bbace7c", "Quận Thanh Xuân", "156bf526-c7fd-4f6c-85ed-3a00c06bac6a" },
                    { "c521e33f-9176-4f26-9d07-214ef85ecbcb", "Quận 10", "6c5b10d1-0a87-4e87-8f66-bef01e2ae256" },
                    { "c7bb94c9-0567-410c-9d21-95d9add85dde", "Quận 5", "6c5b10d1-0a87-4e87-8f66-bef01e2ae256" },
                    { "c96a5d09-86f2-416b-86aa-8dddd73cbd44", "Quận 8", "6c5b10d1-0a87-4e87-8f66-bef01e2ae256" },
                    { "d4212941-eee4-4430-a3ac-75c1a9090902", "Quận Gò Vấp", "6c5b10d1-0a87-4e87-8f66-bef01e2ae256" },
                    { "d4760497-b8a6-435d-9227-dfaf1f5758ad", "Quận 1", "6c5b10d1-0a87-4e87-8f66-bef01e2ae256" },
                    { "d79f3392-e23e-43f3-b379-a4bc849b9fe9", "Quận 3", "6c5b10d1-0a87-4e87-8f66-bef01e2ae256" },
                    { "df26399f-45a6-46c0-ac7b-dcf69a75fa20", "Quận Bình Tân", "6c5b10d1-0a87-4e87-8f66-bef01e2ae256" }
                });

            migrationBuilder.InsertData(
                table: "District",
                columns: new[] { "Id", "Name", "ProvinceId" },
                values: new object[,]
                {
                    { "e2760e77-3d84-435f-8ab9-268fc7103dd0", "Quận Bình Thuỷ", "a1cd2457-ae55-463b-a0e3-302e6633246a" },
                    { "e554d438-7c8d-405a-aadb-0bfed9d2b261", "Quận Hai Bà Trưng", "156bf526-c7fd-4f6c-85ed-3a00c06bac6a" },
                    { "e6407102-aa20-44cb-8ba8-c110d644b3f1", "Quận 6", "6c5b10d1-0a87-4e87-8f66-bef01e2ae256" },
                    { "e83eee76-96bc-4d44-a3a0-f545a4c2d5e4", "Quận Liên Chiểu", "b0416280-ccd5-41c7-9c92-766352985bf3" },
                    { "f53805b8-d749-4fbc-ada2-8d7423e37b89", "Quận 11", "6c5b10d1-0a87-4e87-8f66-bef01e2ae256" },
                    { "f683b092-0766-4dd2-be3f-a5ee4238faa2", "Quận Ô Môn", "a1cd2457-ae55-463b-a0e3-302e6633246a" },
                    { "fee405d3-29b7-48b3-b061-326c010cfaf9", "Quận Hải Châu", "b0416280-ccd5-41c7-9c92-766352985bf3" },
                    { "ffcfd0a0-67cb-4314-baa2-3178eb8e08a7", "Quận Hà Đông", "156bf526-c7fd-4f6c-85ed-3a00c06bac6a" }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a0305f87-441d-482b-9f94-6192fadf48eb", "f00739eb-9e82-4c73-bea4-4c54f14f2832" });

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
