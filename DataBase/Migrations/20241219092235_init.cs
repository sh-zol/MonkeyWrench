using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataBase.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    AboutMe = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false),
                    FileLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admins_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    AboutMe = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false),
                    FileLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Experts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    AboutMe = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false),
                    FileLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Experts_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExpertSkills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    ExpertId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpertSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpertSkills_Experts_ExpertId",
                        column: x => x.ExpertId,
                        principalTable: "Experts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExpertSkills_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FileLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeadLine = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeadLineFa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateFa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ExpertId = table.Column<int>(type: "int", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requests_Experts_ExpertId",
                        column: x => x.ExpertId,
                        principalTable: "Experts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Requests_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bids",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    DeadLine = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<int>(type: "int", maxLength: 12, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDateFa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeadLineFa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpertId = table.Column<int>(type: "int", nullable: false),
                    IsAccepted = table.Column<bool>(type: "bit", nullable: false),
                    RequestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bids", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bids_Experts_ExpertId",
                        column: x => x.ExpertId,
                        principalTable: "Experts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bids_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    RequestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Massage = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    RequestId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Statuses_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, null, "Admin", "ADMIN" },
                    { 2, null, "Customer", "CUSTOMER" },
                    { 3, null, "Expert", "EXPERT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "b6271f8a-3dcf-4cca-a52d-32a9be4c30ae", "zolghadrisahin@ymail.com", false, false, null, "ZOLGHADRISAHIN@YMAIL.COM", "ZOLGHADRISAHIN@YMAIL.COM", "AQAAAAIAAYagAAAAENfZjMGitjpkjyQEK0IR4rhMYpsgtC+LQtNK2tLSYKIPD5ph5beoYOL3nYbgaRL2/Q==", "09193017184", false, "d11bb794-cfdf-4bc8-a673-748e4e3e4557", false, "zolghadrisahin@ymail.com" },
                    { 2, 0, "e79977e4-6ce1-4a9e-8528-154d5383ce6a", "shakibzolghadri@gmail.com", false, false, null, "SHAKIBZOLGHADRI@GMAIL.COM", "SHAKIBZOLGHADRI@GMAIL.COM", "AQAAAAIAAYagAAAAEAe83+Fz5rtSNKzI2wxbLtL4kG7CQNa4Th+/NrqVag7bY7wZtuqFB84+22hpMXWWvw==", "09106265176", false, "3a6ecc5a-deba-4dd2-bfa7-997ebd45b9c8", false, "shakibzolghadri@gmail.com" },
                    { 3, 0, "a2749eba-bf8b-41f5-a4e3-a4045b8b10c5", "amirfarshad@gmail.com", false, false, null, "AMIRFARSHAD@GMAIL.COM", "AMIRFARSHAD@GMAIL.COM", "AQAAAAIAAYagAAAAEJ3l7Ffw+YIQjjDZtYbAP6eeIK8mT+4lueTpGSYpVJMzciRYyzaq1IW1us3SznH3tw==", "09125254199", false, "e803e1a6-4760-4925-a0e4-494545c1596e", false, "amirfarshad@gmail.com" },
                    { 4, 0, "a286fbbd-3430-4e84-aa32-d7a2f2c8af83", "arshiahp@gmail.com", false, false, null, "ARSHIAHP@GMAIL.COM", "ARSHIAHP@GMAIL.COM", "AQAAAAIAAYagAAAAEKQjCxOl/omvJH6YyIaYPKBhZEQT6gtMJ6NqYWkPk7gAFpUaCLaq5v49nfG8MAdKIg==", "09331476832", false, "c1a1b76b-a7f2-4bf6-944f-7e533c8c5273", false, "arshiahp@gmail.com" },
                    { 5, 0, "bffa4464-986a-4836-9cb9-146917f05df8", "sadradn@gmail.com", false, false, null, "SADRADN@GMAIL.COM", "SADRADN@GMAIL.COM", "AQAAAAIAAYagAAAAENdaokPPdhxj76MP9USWMMAJJ9/TfGbwzduU59mNRFfW/u5stBbPW/LZFJF1uEZaZQ==", "09127518144", false, "ccbc5306-77a1-4a18-ad86-c7ab3292ee5f", false, "sadradn@gmail.com" },
                    { 6, 0, "fef4dfb0-4a9d-424e-a2e7-ce6dd9a6489d", "soheilj@gmail.com", false, false, null, "SOHEILJ@GMAIL.COM", "SOHEILJ@GMAIL.COM", "AQAAAAIAAYagAAAAEC8i4V3hoDn7FDYZjkfq/dyi8ua5a+iQV7VP5beN0Bsgmp9OBM6hvQeR9QbblBbc2A==", "09104029183", false, "dca971cf-35d2-438e-95ea-a01de161b5f5", false, "soheilj@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "IsActive", "Title" },
                values: new object[,]
                {
                    { 1, true, "کولر آبی" },
                    { 2, true, "کولر گازی" },
                    { 3, true, "کامپیوتر و سخت افزار" },
                    { 4, true, "وسایل نمایشی" },
                    { 5, true, "وسایل آشپزخانه" },
                    { 6, true, "مکانیک" },
                    { 7, true, "ساختمان" }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Massage", "RequestId" },
                values: new object[,]
                {
                    { 1, "درخواست ایجاد شد و در انتظار پیشنهاد متخصصان", null },
                    { 2, "پیشنهاد متخصص قبول شد", null },
                    { 3, "متخصص به محل رسید و شروع به انجام کار است", null },
                    { 4, "کار متخصص به پایان رسید و در انتظار پرداخت", null },
                    { 5, "پرداخت انجام شد و درخواست به پایان رسید", null }
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "AboutMe", "Address", "AppUserId", "Email", "FileLocation", "FullName", "Password", "PhoneNumber", "Role" },
                values: new object[] { 1, "i'm admin", "Tehran marzdaran", 1, "zolghadrisahin@ymail.com", null, "شاهین ذوالقدری", "sh19451960", "09193017184", 1 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 3, 5 },
                    { 3, 6 }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "AboutMe", "Address", "AppUserId", "Email", "FileLocation", "FullName", "Password", "PhoneNumber", "Role" },
                values: new object[,]
                {
                    { 1, "مشتری هستم", "تهران", 2, "shakibzolghadri@gmail.com", null, "شکیب ذوالقدری", "sh19451960", "09106265176", 1 },
                    { 2, null, null, 3, "amirfarshad@gmail.com", null, "امیر فرشاد", "sh19451960", "09125254199", 1 },
                    { 3, null, null, 4, "arshiahp@gmail.com", null, "عرشیا حسن‌پور", "sh19451960", "09331476832", 1 }
                });

            migrationBuilder.InsertData(
                table: "Experts",
                columns: new[] { "Id", "AboutMe", "Address", "AppUserId", "Email", "FileLocation", "FullName", "Password", "PhoneNumber", "Role" },
                values: new object[,]
                {
                    { 1, null, null, 5, "sadradn@gmail.com", null, "صدرا دویران", "sh19451960", "09127518144", 3 },
                    { 2, null, null, 6, "soheilj@gmail.com", null, "سهیل جیبویی", "sh19451960", "09104029183", 3 }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CategoryId", "Description", "IsActive", "Title" },
                values: new object[,]
                {
                    { 1, 1, null, true, "راه اندازی کولر آبی" },
                    { 2, 1, null, true, "تعمیرات کولر آبی" },
                    { 3, 2, null, true, "تعمیرات کولر گازی" },
                    { 4, 2, null, true, "راه اندازی کولر گازی" },
                    { 5, 3, null, true, "تعمیر کیس" },
                    { 6, 3, null, true, "تعمیر مادربرد و بایوس" },
                    { 7, 4, null, true, "تعمیر تلویزیون" },
                    { 8, 4, null, true, "تعمیر مانیتور" },
                    { 9, 5, null, true, "تعمیر یخچال" },
                    { 10, 5, null, true, "تعمیر اجاق و فر" },
                    { 11, 5, null, true, "تعمیر ماشین لباسشویی" },
                    { 12, 5, null, true, "تعمیر ماشین ظرف‌شویی" },
                    { 13, 6, null, true, "تعمیر موتور خودرو" },
                    { 14, 6, null, true, "تعمیر موتور سیکلت" },
                    { 15, 6, null, true, "تعویض روغن موتور" },
                    { 16, 7, null, true, "سیم‌کشی ساختمان" },
                    { 17, 7, null, true, "لوله کشی ساختمان" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_AppUserId",
                table: "Admins",
                column: "AppUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_ExpertId",
                table: "Bids",
                column: "ExpertId");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_RequestId",
                table: "Bids",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CustomerId",
                table: "Comments",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_RequestId",
                table: "Comments",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ServiceId",
                table: "Comments",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AppUserId",
                table: "Customers",
                column: "AppUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Experts_AppUserId",
                table: "Experts",
                column: "AppUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExpertSkills_ExpertId",
                table: "ExpertSkills",
                column: "ExpertId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpertSkills_ServiceId",
                table: "ExpertSkills",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_CustomerId",
                table: "Requests",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ExpertId",
                table: "Requests",
                column: "ExpertId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ServiceId",
                table: "Requests",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_CategoryId",
                table: "Services",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Statuses_RequestId",
                table: "Statuses",
                column: "RequestId",
                unique: true,
                filter: "[RequestId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Bids");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "ExpertSkills");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Experts");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
