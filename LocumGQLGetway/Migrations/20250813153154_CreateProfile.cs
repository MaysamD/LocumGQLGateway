using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LocumGQLGateway.Migrations
{
    /// <inheritdoc />
    public partial class CreateProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PreferenceLocationType",
                columns: table => new
                {
                    LocationTypeId = table.Column<int>(type: "int", nullable: false),
                    PreferenceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreferenceLocationType", x => new { x.PreferenceId, x.LocationTypeId });
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PreferenceShiftType",
                columns: table => new
                {
                    ShiftTypeId = table.Column<int>(type: "int", nullable: false),
                    PreferenceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreferenceShiftType", x => new { x.PreferenceId, x.ShiftTypeId });
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PreferenceState",
                columns: table => new
                {
                    StateId = table.Column<int>(type: "int", nullable: false),
                    PreferenceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreferenceState", x => new { x.PreferenceId, x.StateId });
                })
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
                name: "FacilityTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PreferenceId = table.Column<int>(type: "int", nullable: true),
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
                        name: "FK_FacilityTypes_Preferences_PreferenceId",
                        column: x => x.PreferenceId,
                        principalTable: "Preferences",
                        principalColumn: "Id");
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
                    PreferenceId = table.Column<int>(type: "int", nullable: true),
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
                        name: "FK_JobTypes_Preferences_PreferenceId",
                        column: x => x.PreferenceId,
                        principalTable: "Preferences",
                        principalColumn: "Id");
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
                    PreferenceId = table.Column<int>(type: "int", nullable: true),
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
                        name: "FK_LocationTypes_Preferences_PreferenceId",
                        column: x => x.PreferenceId,
                        principalTable: "Preferences",
                        principalColumn: "Id");
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
                name: "ShiftTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PreferenceId = table.Column<int>(type: "int", nullable: true),
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
                        name: "FK_ShiftTypes_Preferences_PreferenceId",
                        column: x => x.PreferenceId,
                        principalTable: "Preferences",
                        principalColumn: "Id");
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
                    PreferenceId = table.Column<int>(type: "int", nullable: true),
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
                        name: "FK_States_Preferences_PreferenceId",
                        column: x => x.PreferenceId,
                        principalTable: "Preferences",
                        principalColumn: "Id");
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

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "Email", "EmailConfirmed", "IsDeleted", "PasswordHash", "Role", "UpdatedAtUtc", "UpdatedById", "Username" },
                values: new object[] { 1, new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8120), 1, "SuperAdmin@example.com", false, false, "TBD", 0, new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8120), null, "SuperAdmin" });

            migrationBuilder.InsertData(
                table: "FacilityTypes",
                columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "Description", "IsDeleted", "Name", "PreferenceId", "UpdatedAtUtc", "UpdatedById" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8330), 1, null, false, "Hospital", null, new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8330), null },
                    { 2, new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8330), 1, null, false, "Clinic", null, new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8330), null },
                    { 3, new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8330), 1, null, false, "Urgent Care", null, new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8330), null },
                    { 4, new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8330), 1, null, false, "Rehabilitation Center", null, new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8330), null }
                });

            migrationBuilder.InsertData(
                table: "JobTypes",
                columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "Description", "IsDeleted", "Name", "PreferenceId", "UpdatedAtUtc", "UpdatedById" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8380), 1, null, false, "Full-Time", null, new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8380), null },
                    { 2, new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8380), 1, null, false, "Part-Time", null, new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8380), null },
                    { 3, new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8380), 1, null, false, "Contract", null, new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8380), null },
                    { 4, new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8380), 1, null, false, "Temporary", null, new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8380), null },
                    { 5, new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8380), 1, null, false, "Internship", null, new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8380), null }
                });

            migrationBuilder.InsertData(
                table: "LocationTypes",
                columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "Description", "IsDeleted", "Name", "PreferenceId", "UpdatedAtUtc", "UpdatedById" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8530), 1, null, false, "Urban", null, new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8530), null },
                    { 2, new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8530), 1, null, false, "Suburban", null, new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8540), null },
                    { 3, new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8540), 1, null, false, "Rural", null, new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8540), null },
                    { 4, new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8540), 1, null, false, "Remote", null, new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8540), null }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "FirstName", "IsDeleted", "LastName", "PhoneNumber", "UpdatedAtUtc", "UpdatedById", "UserId" },
                values: new object[] { 1, new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8670), 1, "SuperAdmin", false, "SuperAdmin", "(555) 555-5555", new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8670), null, 1 });

            migrationBuilder.InsertData(
                table: "ShiftTypes",
                columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "Description", "IsDeleted", "Name", "PreferenceId", "UpdatedAtUtc", "UpdatedById" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8470), 1, null, false, "Morning", null, new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8470), null },
                    { 2, new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8470), 1, null, false, "Afternoon", null, new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8470), null },
                    { 3, new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8470), 1, null, false, "Evening", null, new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8470), null },
                    { 4, new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8470), 1, null, false, "Night", null, new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8470), null },
                    { 5, new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8470), 1, null, false, "On-Call", null, new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8470), null }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "Abbreviation", "CreatedAtUtc", "CreatedById", "IsDeleted", "Name", "PreferenceId", "UpdatedAtUtc", "UpdatedById" },
                values: new object[,]
                {
                    { 1, "AL", new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8610), 1, false, "Alabama", null, new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8610), null },
                    { 2, "AK", new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8610), 1, false, "Alaska", null, new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8610), null },
                    { 3, "AZ", new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8610), 1, false, "Arizona", null, new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8610), null },
                    { 4, "AR", new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8610), 1, false, "Arkansas", null, new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8610), null },
                    { 5, "CA", new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8610), 1, false, "California", null, new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8610), null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "Email", "EmailConfirmed", "IsDeleted", "PasswordHash", "Role", "UpdatedAtUtc", "UpdatedById", "Username" },
                values: new object[,]
                {
                    { 2, new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8120), 1, "admin@example.com", false, false, "TBD", 4, new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8120), null, "admin" },
                    { 3, new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8130), 1, "Locum@example.com", false, false, "TBD", 1, new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8130), null, "Locum" }
                });

            migrationBuilder.InsertData(
                table: "Preferences",
                columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "ProfileId", "UpdatedAtUtc", "UpdatedById" },
                values: new object[] { 1, new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8730), 1, false, 1, new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8730), null });

            migrationBuilder.InsertData(
                table: "ProfileNotificationSettings",
                columns: new[] { "Id", "CertificateExpirationEmail", "CertificateExpirationInApp", "CertificateExpirationSms", "CreatedAtUtc", "CreatedById", "CredentialingUpdatesEmail", "CredentialingUpdatesInApp", "CredentialingUpdatesSms", "GeneralRemindersEmail", "GeneralRemindersInApp", "GeneralRemindersSms", "IsDeleted", "JobMatchNotificationsEmail", "JobMatchNotificationsInApp", "JobMatchNotificationsSms", "ProfileId", "UpdatedAtUtc", "UpdatedById" },
                values: new object[] { 1, true, true, false, new DateTime(2025, 8, 13, 15, 31, 53, 872, DateTimeKind.Utc).AddTicks(1900), 1, false, false, false, false, false, true, false, false, true, false, 1, new DateTime(2025, 8, 13, 15, 31, 53, 872, DateTimeKind.Utc).AddTicks(1900), null });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "FirstName", "IsDeleted", "LastName", "PhoneNumber", "UpdatedAtUtc", "UpdatedById", "UserId" },
                values: new object[,]
                {
                    { 2, new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8680), 1, "Admin", false, "Admin", "(555) 555-5555", new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8680), null, 2 },
                    { 3, new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8680), 1, "Locum", false, "Locum", "(999) 999-9999", new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8680), null, 3 }
                });

            migrationBuilder.InsertData(
                table: "Preferences",
                columns: new[] { "Id", "CreatedAtUtc", "CreatedById", "IsDeleted", "ProfileId", "UpdatedAtUtc", "UpdatedById" },
                values: new object[] { 2, new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8740), 1, false, 2, new DateTime(2025, 8, 13, 15, 31, 53, 870, DateTimeKind.Utc).AddTicks(8740), null });

            migrationBuilder.InsertData(
                table: "ProfileNotificationSettings",
                columns: new[] { "Id", "CertificateExpirationEmail", "CertificateExpirationInApp", "CertificateExpirationSms", "CreatedAtUtc", "CreatedById", "CredentialingUpdatesEmail", "CredentialingUpdatesInApp", "CredentialingUpdatesSms", "GeneralRemindersEmail", "GeneralRemindersInApp", "GeneralRemindersSms", "IsDeleted", "JobMatchNotificationsEmail", "JobMatchNotificationsInApp", "JobMatchNotificationsSms", "ProfileId", "UpdatedAtUtc", "UpdatedById" },
                values: new object[] { 2, false, false, false, new DateTime(2025, 8, 13, 15, 31, 53, 872, DateTimeKind.Utc).AddTicks(1910), 1, false, false, false, false, false, false, false, false, false, false, 2, new DateTime(2025, 8, 13, 15, 31, 53, 872, DateTimeKind.Utc).AddTicks(1910), null });

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
                name: "IX_FacilityTypes_PreferenceId",
                table: "FacilityTypes",
                column: "PreferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_FacilityTypes_UpdatedById",
                table: "FacilityTypes",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_JobTypes_CreatedById",
                table: "JobTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_JobTypes_PreferenceId",
                table: "JobTypes",
                column: "PreferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_JobTypes_UpdatedById",
                table: "JobTypes",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_LocationTypes_CreatedById",
                table: "LocationTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_LocationTypes_PreferenceId",
                table: "LocationTypes",
                column: "PreferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationTypes_UpdatedById",
                table: "LocationTypes",
                column: "UpdatedById");

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
                name: "IX_ShiftTypes_PreferenceId",
                table: "ShiftTypes",
                column: "PreferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftTypes_UpdatedById",
                table: "ShiftTypes",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_States_CreatedById",
                table: "States",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_States_PreferenceId",
                table: "States",
                column: "PreferenceId");

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
                name: "FacilityTypes");

            migrationBuilder.DropTable(
                name: "JobTypes");

            migrationBuilder.DropTable(
                name: "LocationTypes");

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
                name: "ShiftTypes");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Preferences");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
