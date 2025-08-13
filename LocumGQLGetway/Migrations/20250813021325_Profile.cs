using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LocumGQLGateway.Migrations
{
    /// <inheritdoc />
    public partial class Profile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Role = table.Column<int>(type: "int", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedById = table.Column<int>(type: "int", nullable: true),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FacilityTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedById = table.Column<int>(type: "int", nullable: true),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilityTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FacilityTypes_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacilityTypes_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "JobTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedById = table.Column<int>(type: "int", nullable: true),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobTypes_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobTypes_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LocationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedById = table.Column<int>(type: "int", nullable: true),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocationTypes_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocationTypes_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedById = table.Column<int>(type: "int", nullable: true),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profiles_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Profiles_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Profiles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ShiftTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedById = table.Column<int>(type: "int", nullable: true),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShiftTypes_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShiftTypes_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Abbreviation = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedById = table.Column<int>(type: "int", nullable: true),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                    table.ForeignKey(
                        name: "FK_States_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_States_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Preferences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProfileId = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedById = table.Column<int>(type: "int", nullable: true),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preferences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Preferences_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Preferences_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Preferences_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProfileNotificationSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProfileId = table.Column<int>(type: "int", nullable: false),
                    CertificateExpirationInApp = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CertificateExpirationEmail = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CertificateExpirationSms = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    JobMatchNotificationsInApp = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    JobMatchNotificationsEmail = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    JobMatchNotificationsSms = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CredentialingUpdatesInApp = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CredentialingUpdatesEmail = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CredentialingUpdatesSms = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    GeneralRemindersInApp = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    GeneralRemindersEmail = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    GeneralRemindersSms = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedById = table.Column<int>(type: "int", nullable: true),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileNotificationSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfileNotificationSettings_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfileNotificationSettings_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfileNotificationSettings_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Street1 = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Street2 = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    City = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StateId = table.Column<int>(type: "int", nullable: true),
                    PostalCode = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Country = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsPrimary = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ProfileId = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedById = table.Column<int>(type: "int", nullable: true),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Address_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Address_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Address_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PreferenceFacilityType",
                columns: table => new
                {
                    PreferenceId = table.Column<int>(type: "int", nullable: false),
                    FacilityTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreferenceFacilityType", x => new { x.PreferenceId, x.FacilityTypeId });
                    table.ForeignKey(
                        name: "FK_PreferenceFacilityType_FacilityTypes_FacilityTypeId",
                        column: x => x.FacilityTypeId,
                        principalTable: "FacilityTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PreferenceFacilityType_Preferences_PreferenceId",
                        column: x => x.PreferenceId,
                        principalTable: "Preferences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PreferenceJobType",
                columns: table => new
                {
                    PreferenceId = table.Column<int>(type: "int", nullable: false),
                    JobTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreferenceJobType", x => new { x.PreferenceId, x.JobTypeId });
                    table.ForeignKey(
                        name: "FK_PreferenceJobType_JobTypes_JobTypeId",
                        column: x => x.JobTypeId,
                        principalTable: "JobTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PreferenceJobType_Preferences_PreferenceId",
                        column: x => x.PreferenceId,
                        principalTable: "Preferences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PreferenceLocationType",
                columns: table => new
                {
                    PreferenceId = table.Column<int>(type: "int", nullable: false),
                    LocationTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreferenceLocationType", x => new { x.PreferenceId, x.LocationTypeId });
                    table.ForeignKey(
                        name: "FK_PreferenceLocationType_LocationTypes_LocationTypeId",
                        column: x => x.LocationTypeId,
                        principalTable: "LocationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PreferenceLocationType_Preferences_PreferenceId",
                        column: x => x.PreferenceId,
                        principalTable: "Preferences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PreferenceShiftType",
                columns: table => new
                {
                    PreferenceId = table.Column<int>(type: "int", nullable: false),
                    ShiftTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreferenceShiftType", x => new { x.PreferenceId, x.ShiftTypeId });
                    table.ForeignKey(
                        name: "FK_PreferenceShiftType_Preferences_PreferenceId",
                        column: x => x.PreferenceId,
                        principalTable: "Preferences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PreferenceShiftType_ShiftTypes_ShiftTypeId",
                        column: x => x.ShiftTypeId,
                        principalTable: "ShiftTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PreferenceState",
                columns: table => new
                {
                    PreferenceId = table.Column<int>(type: "int", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreferenceState", x => new { x.PreferenceId, x.StateId });
                    table.ForeignKey(
                        name: "FK_PreferenceState_Preferences_PreferenceId",
                        column: x => x.PreferenceId,
                        principalTable: "Preferences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PreferenceState_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "Email", "EmailConfirmed", "IsDeleted", "PasswordHash", "Role", "UpdatedAtUtc", "UpdatedById", "Username" },
                values: new object[] { 1, new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(1000), 1, "SuperAdmin@example.com", false, false, "TBD", 0, new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(1000), null, "SuperAdmin" });

            migrationBuilder.InsertData(
                table: "FacilityTypes",
                columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "Description", "IsDeleted", "Name", "UpdatedAtUtc", "UpdatedById" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(730), 1, null, false, "Hospital", new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(730), null },
                    { 2, new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(740), 1, null, false, "Clinic", new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(740), null },
                    { 3, new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(740), 1, null, false, "Urgent Care", new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(740), null },
                    { 4, new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(740), 1, null, false, "Rehabilitation Center", new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(740), null }
                });

            migrationBuilder.InsertData(
                table: "JobTypes",
                columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "Description", "IsDeleted", "Name", "UpdatedAtUtc", "UpdatedById" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(950), 1, null, false, "Full-Time", new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(950), null },
                    { 2, new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(950), 1, null, false, "Part-Time", new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(950), null },
                    { 3, new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(950), 1, null, false, "Contract", new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(950), null },
                    { 4, new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(950), 1, null, false, "Temporary", new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(950), null },
                    { 5, new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(950), 1, null, false, "Internship", new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(950), null }
                });

            migrationBuilder.InsertData(
                table: "LocationTypes",
                columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "Description", "IsDeleted", "Name", "UpdatedAtUtc", "UpdatedById" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(1040), 1, null, false, "Urban", new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(1040), null },
                    { 2, new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(1040), 1, null, false, "Suburban", new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(1040), null },
                    { 3, new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(1040), 1, null, false, "Rural", new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(1040), null },
                    { 4, new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(1040), 1, null, false, "Remote", new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(1040), null }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "FirstName", "IsDeleted", "LastName", "PhoneNumber", "UpdatedAtUtc", "UpdatedById", "UserId" },
                values: new object[] { 1, new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(1080), 1, "SuperAdmin", false, "SuperAdmin", "(555) 555-5555", new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(1080), null, 1 });

            migrationBuilder.InsertData(
                table: "ShiftTypes",
                columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "Description", "IsDeleted", "Name", "UpdatedAtUtc", "UpdatedById" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(970), 1, null, false, "Morning", new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(970), null },
                    { 2, new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(970), 1, null, false, "Afternoon", new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(970), null },
                    { 3, new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(970), 1, null, false, "Evening", new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(970), null },
                    { 4, new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(970), 1, null, false, "Night", new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(980), null },
                    { 5, new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(980), 1, null, false, "On-Call", new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(980), null }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "Abbreviation", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "UpdatedAtUtc", "UpdatedById" },
                values: new object[,]
                {
                    { 1, "AL", new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(1060), 1, false, "Alabama", new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(1060), null },
                    { 2, "AK", new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(1060), 1, false, "Alaska", new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(1060), null },
                    { 3, "AZ", new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(1060), 1, false, "Arizona", new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(1060), null },
                    { 4, "AR", new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(1060), 1, false, "Arkansas", new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(1060), null },
                    { 5, "CA", new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(1060), 1, false, "California", new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(1060), null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "Email", "EmailConfirmed", "IsDeleted", "PasswordHash", "Role", "UpdatedAtUtc", "UpdatedById", "Username" },
                values: new object[,]
                {
                    { 2, new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(1000), 1, "admin@example.com", false, false, "TBD", 4, new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(1000), null, "admin" },
                    { 3, new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(1000), 1, "Locum@example.com", false, false, "TBD", 1, new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(1000), null, "Locum" }
                });

            migrationBuilder.InsertData(
                table: "Preferences",
                columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "ProfileId", "UpdatedAtUtc", "UpdatedById" },
                values: new object[] { 1, new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(1110), 1, false, 1, new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(1110), null });

            migrationBuilder.InsertData(
                table: "ProfileNotificationSettings",
                columns: new[] { "Id", "CertificateExpirationEmail", "CertificateExpirationInApp", "CertificateExpirationSms", "CreatedAtUtc", "CreatedById", "CredentialingUpdatesEmail", "CredentialingUpdatesInApp", "CredentialingUpdatesSms", "GeneralRemindersEmail", "GeneralRemindersInApp", "GeneralRemindersSms", "IsDeleted", "JobMatchNotificationsEmail", "JobMatchNotificationsInApp", "JobMatchNotificationsSms", "ProfileId", "UpdatedAtUtc", "UpdatedById" },
                values: new object[] { 1, true, true, false, new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(1200), 1, false, false, false, false, false, true, false, false, true, false, 1, new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(1200), null });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "FirstName", "IsDeleted", "LastName", "PhoneNumber", "UpdatedAtUtc", "UpdatedById", "UserId" },
                values: new object[,]
                {
                    { 2, new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(1090), 1, "Admin", false, "Admin", "(555) 555-5555", new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(1090), null, 2 },
                    { 3, new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(1090), 1, "Locum", false, "Locum", "(999) 999-9999", new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(1090), null, 3 }
                });

            migrationBuilder.InsertData(
                table: "Preferences",
                columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "ProfileId", "UpdatedAtUtc", "UpdatedById" },
                values: new object[] { 2, new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(1110), 1, false, 2, new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(1110), null });

            migrationBuilder.InsertData(
                table: "ProfileNotificationSettings",
                columns: new[] { "Id", "CertificateExpirationEmail", "CertificateExpirationInApp", "CertificateExpirationSms", "CreatedAtUtc", "CreatedById", "CredentialingUpdatesEmail", "CredentialingUpdatesInApp", "CredentialingUpdatesSms", "GeneralRemindersEmail", "GeneralRemindersInApp", "GeneralRemindersSms", "IsDeleted", "JobMatchNotificationsEmail", "JobMatchNotificationsInApp", "JobMatchNotificationsSms", "ProfileId", "UpdatedAtUtc", "UpdatedById" },
                values: new object[] { 2, false, false, false, new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(1200), 1, false, false, false, false, false, false, false, false, false, false, 2, new DateTime(2025, 8, 13, 2, 13, 25, 402, DateTimeKind.Utc).AddTicks(1200), null });

            migrationBuilder.InsertData(
                table: "PreferenceFacilityType",
                columns: new[] { "FacilityTypeId", "PreferenceId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "PreferenceJobType",
                columns: new[] { "JobTypeId", "PreferenceId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "PreferenceLocationType",
                columns: new[] { "LocationTypeId", "PreferenceId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "PreferenceShiftType",
                columns: new[] { "PreferenceId", "ShiftTypeId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "PreferenceState",
                columns: new[] { "PreferenceId", "StateId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 2, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CreatedById",
                table: "Address",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Address_ProfileId",
                table: "Address",
                column: "ProfileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Address_StateId",
                table: "Address",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_UpdatedById",
                table: "Address",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_FacilityTypes_CreatedById",
                table: "FacilityTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_FacilityTypes_UpdatedById",
                table: "FacilityTypes",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_JobTypes_CreatedById",
                table: "JobTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_JobTypes_UpdatedById",
                table: "JobTypes",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_LocationTypes_CreatedById",
                table: "LocationTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_LocationTypes_UpdatedById",
                table: "LocationTypes",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_PreferenceFacilityType_FacilityTypeId",
                table: "PreferenceFacilityType",
                column: "FacilityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PreferenceJobType_JobTypeId",
                table: "PreferenceJobType",
                column: "JobTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PreferenceLocationType_LocationTypeId",
                table: "PreferenceLocationType",
                column: "LocationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Preferences_CreatedById",
                table: "Preferences",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Preferences_ProfileId",
                table: "Preferences",
                column: "ProfileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Preferences_UpdatedById",
                table: "Preferences",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_PreferenceShiftType_ShiftTypeId",
                table: "PreferenceShiftType",
                column: "ShiftTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PreferenceState_StateId",
                table: "PreferenceState",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileNotificationSettings_CreatedById",
                table: "ProfileNotificationSettings",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileNotificationSettings_ProfileId",
                table: "ProfileNotificationSettings",
                column: "ProfileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProfileNotificationSettings_UpdatedById",
                table: "ProfileNotificationSettings",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_CreatedById",
                table: "Profiles",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_UpdatedById",
                table: "Profiles",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_UserId",
                table: "Profiles",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShiftTypes_CreatedById",
                table: "ShiftTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftTypes_UpdatedById",
                table: "ShiftTypes",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_States_CreatedById",
                table: "States",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_States_UpdatedById",
                table: "States",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CreatedById",
                table: "Users",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UpdatedById",
                table: "Users",
                column: "UpdatedById");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "PreferenceFacilityType");

            migrationBuilder.DropTable(
                name: "PreferenceJobType");

            migrationBuilder.DropTable(
                name: "PreferenceLocationType");

            migrationBuilder.DropTable(
                name: "PreferenceShiftType");

            migrationBuilder.DropTable(
                name: "PreferenceState");

            migrationBuilder.DropTable(
                name: "ProfileNotificationSettings");

            migrationBuilder.DropTable(
                name: "FacilityTypes");

            migrationBuilder.DropTable(
                name: "JobTypes");

            migrationBuilder.DropTable(
                name: "LocationTypes");

            migrationBuilder.DropTable(
                name: "ShiftTypes");

            migrationBuilder.DropTable(
                name: "Preferences");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
