using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LocumGQLGateway.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    slug = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_by_id = table.Column<int>(type: "int", nullable: false),
                    created_at_utc = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_by_id = table.Column<int>(type: "int", nullable: true),
                    updated_at_utc = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    is_deleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "facility_types",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_by_id = table.Column<int>(type: "int", nullable: false),
                    created_at_utc = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_by_id = table.Column<int>(type: "int", nullable: true),
                    updated_at_utc = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    is_deleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_facility_types", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "forms",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    slug = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    is_active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    created_by_id = table.Column<int>(type: "int", nullable: false),
                    created_at_utc = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_by_id = table.Column<int>(type: "int", nullable: true),
                    updated_at_utc = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    is_deleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_forms", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "job_types",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_by_id = table.Column<int>(type: "int", nullable: false),
                    created_at_utc = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_by_id = table.Column<int>(type: "int", nullable: true),
                    updated_at_utc = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    is_deleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_job_types", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "location_types",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_by_id = table.Column<int>(type: "int", nullable: false),
                    created_at_utc = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_by_id = table.Column<int>(type: "int", nullable: true),
                    updated_at_utc = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    is_deleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_location_types", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "shift_types",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_by_id = table.Column<int>(type: "int", nullable: false),
                    created_at_utc = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_by_id = table.Column<int>(type: "int", nullable: true),
                    updated_at_utc = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    is_deleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shift_types", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "states",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    abbreviation = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_by_id = table.Column<int>(type: "int", nullable: false),
                    created_at_utc = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_by_id = table.Column<int>(type: "int", nullable: true),
                    updated_at_utc = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    is_deleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_states", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email_confirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    password_hash = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Role = table.Column<int>(type: "int", nullable: true),
                    created_by_id = table.Column<int>(type: "int", nullable: false),
                    created_at_utc = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_by_id = table.Column<int>(type: "int", nullable: true),
                    updated_at_utc = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    is_deleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "questions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    category_id = table.Column<int>(type: "int", nullable: false),
                    text = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    help_text = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    data_type = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    sort_order = table.Column<int>(type: "int", nullable: false),
                    RegexValidation = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_by_id = table.Column<int>(type: "int", nullable: false),
                    created_at_utc = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_by_id = table.Column<int>(type: "int", nullable: true),
                    updated_at_utc = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    is_deleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_questions", x => x.id);
                    table.ForeignKey(
                        name: "FK_questions_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "form_category",
                columns: table => new
                {
                    form_id = table.Column<int>(type: "int", nullable: false),
                    category_id = table.Column<int>(type: "int", nullable: false),
                    sort_order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_form_category", x => new { x.form_id, x.category_id });
                    table.ForeignKey(
                        name: "FK_form_category_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_form_category_forms_form_id",
                        column: x => x.form_id,
                        principalTable: "forms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "profiles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    first_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    last_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    phone_number = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_by_id = table.Column<int>(type: "int", nullable: false),
                    created_at_utc = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_by_id = table.Column<int>(type: "int", nullable: true),
                    updated_at_utc = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    is_deleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profiles", x => x.id);
                    table.ForeignKey(
                        name: "FK_profiles_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "category_question",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    form_id = table.Column<int>(type: "int", nullable: false),
                    question_id = table.Column<int>(type: "int", nullable: false),
                    sort_order = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category_question", x => new { x.id, x.form_id, x.question_id });
                    table.ForeignKey(
                        name: "FK_category_question_categories_form_id",
                        column: x => x.form_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_category_question_questions_question_id",
                        column: x => x.question_id,
                        principalTable: "questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "question_options",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    question_id = table.Column<int>(type: "int", nullable: false),
                    value = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    display_text = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    sort_order = table.Column<int>(type: "int", nullable: false),
                    created_by_id = table.Column<int>(type: "int", nullable: false),
                    created_at_utc = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_by_id = table.Column<int>(type: "int", nullable: true),
                    updated_at_utc = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    is_deleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_question_options", x => x.id);
                    table.ForeignKey(
                        name: "FK_question_options_questions_question_id",
                        column: x => x.question_id,
                        principalTable: "questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Street1 = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Street2 = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    City = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StateId = table.Column<int>(type: "int", nullable: true),
                    postal_code = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Country = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    is_primary = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    profile_id = table.Column<int>(type: "int", nullable: false),
                    created_by_id = table.Column<int>(type: "int", nullable: false),
                    created_at_utc = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_by_id = table.Column<int>(type: "int", nullable: true),
                    updated_at_utc = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    is_deleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.id);
                    table.ForeignKey(
                        name: "FK_Address_profiles_profile_id",
                        column: x => x.profile_id,
                        principalTable: "profiles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Address_states_StateId",
                        column: x => x.StateId,
                        principalTable: "states",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "preferences",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    profile_id = table.Column<int>(type: "int", nullable: false),
                    created_by_id = table.Column<int>(type: "int", nullable: false),
                    created_at_utc = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_by_id = table.Column<int>(type: "int", nullable: true),
                    updated_at_utc = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    is_deleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_preferences", x => x.id);
                    table.ForeignKey(
                        name: "FK_preferences_profiles_profile_id",
                        column: x => x.profile_id,
                        principalTable: "profiles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "profile_notification_settings",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    profile_id = table.Column<int>(type: "int", nullable: false),
                    certificate_expiration_in_app = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    certificate_expiration_email = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    certificate_expiration_sms = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    job_match_notifications_in_app = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    job_match_notifications_email = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    job_match_notifications_sms = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    credentialing_updates_in_app = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    credentialing_updates_email = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    credentialing_updates_sms = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    general_reminders_in_app = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    general_reminders_email = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    general_reminders_sms = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    created_by_id = table.Column<int>(type: "int", nullable: false),
                    created_at_utc = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_by_id = table.Column<int>(type: "int", nullable: true),
                    updated_at_utc = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    is_deleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profile_notification_settings", x => x.id);
                    table.ForeignKey(
                        name: "FK_profile_notification_settings_profiles_profile_id",
                        column: x => x.profile_id,
                        principalTable: "profiles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user_credentials",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    question_id = table.Column<int>(type: "int", nullable: false),
                    answer_text = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    selected_option_id = table.Column<int>(type: "int", nullable: true),
                    is_validated = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    validation_method = table.Column<int>(type: "int", nullable: false),
                    validated_at_utc = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    validated_by_id = table.Column<int>(type: "int", nullable: true),
                    validation_notes = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    expiration_date_utc = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    file_path = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_by_id = table.Column<int>(type: "int", nullable: false),
                    created_at_utc = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_by_id = table.Column<int>(type: "int", nullable: true),
                    updated_at_utc = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    is_deleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_credentials", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_credentials_Users_validated_by_id",
                        column: x => x.validated_by_id,
                        principalTable: "Users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_user_credentials_question_options_selected_option_id",
                        column: x => x.selected_option_id,
                        principalTable: "question_options",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_user_credentials_questions_question_id",
                        column: x => x.question_id,
                        principalTable: "questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "preference_facility_type",
                columns: table => new
                {
                    facility_type_id = table.Column<int>(type: "int", nullable: false),
                    preference_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_preference_facility_type", x => new { x.facility_type_id, x.preference_id });
                    table.ForeignKey(
                        name: "FK_preference_facility_type_facility_types_facility_type_id",
                        column: x => x.facility_type_id,
                        principalTable: "facility_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_preference_facility_type_preferences_preference_id",
                        column: x => x.preference_id,
                        principalTable: "preferences",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "preference_job_type",
                columns: table => new
                {
                    job_type_id = table.Column<int>(type: "int", nullable: false),
                    preference_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_preference_job_type", x => new { x.job_type_id, x.preference_id });
                    table.ForeignKey(
                        name: "FK_preference_job_type_job_types_job_type_id",
                        column: x => x.job_type_id,
                        principalTable: "job_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_preference_job_type_preferences_preference_id",
                        column: x => x.preference_id,
                        principalTable: "preferences",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "preference_location_type",
                columns: table => new
                {
                    location_type_id = table.Column<int>(type: "int", nullable: false),
                    preference_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_preference_location_type", x => new { x.location_type_id, x.preference_id });
                    table.ForeignKey(
                        name: "FK_preference_location_type_location_types_location_type_id",
                        column: x => x.location_type_id,
                        principalTable: "location_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_preference_location_type_preferences_preference_id",
                        column: x => x.preference_id,
                        principalTable: "preferences",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "preference_shift_type",
                columns: table => new
                {
                    shift_type_id = table.Column<int>(type: "int", nullable: false),
                    preference_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_preference_shift_type", x => new { x.shift_type_id, x.preference_id });
                    table.ForeignKey(
                        name: "FK_preference_shift_type_preferences_preference_id",
                        column: x => x.preference_id,
                        principalTable: "preferences",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_preference_shift_type_shift_types_shift_type_id",
                        column: x => x.shift_type_id,
                        principalTable: "shift_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "preference_state",
                columns: table => new
                {
                    state_id = table.Column<int>(type: "int", nullable: false),
                    preference_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_preference_state", x => new { x.state_id, x.preference_id });
                    table.ForeignKey(
                        name: "FK_preference_state_preferences_preference_id",
                        column: x => x.preference_id,
                        principalTable: "preferences",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_preference_state_states_state_id",
                        column: x => x.state_id,
                        principalTable: "states",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "created_by_id", "Email", "email_confirmed", "is_deleted", "password_hash", "Role", "updated_by_id", "Username" },
                values: new object[,]
                {
                    { 1, 1, "SuperAdmin@example.com", false, false, "TBD", 0, null, "SuperAdmin" },
                    { 2, 1, "admin@example.com", false, false, "TBD", 4, null, "admin" },
                    { 3, 1, "Locum@example.com", false, false, "TBD", 1, null, "Locum" }
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "id", "created_by_id", "description", "is_deleted", "name", "slug", "updated_by_id" },
                values: new object[,]
                {
                    { 1, 1, "Basic personal details and identification info", false, "Personal Information", "personal-information", null },
                    { 2, 1, "Information about your education background and training", false, "Education & Training", "education-training", null },
                    { 3, 1, "All professional licenses and certifications", false, "Licenses & Certifications", "licenses-certifications", null },
                    { 4, 1, "Details about your practice locations and affiliations", false, "Practice & Affiliation", "practice-affiliation", null },
                    { 5, 1, "Previous work history and professional references", false, "Work History & References", "work-history-references", null },
                    { 6, 1, "Claims history and disclosures", false, "Claims & Disclosures", "claims-disclosures", null },
                    { 7, 1, "Health and legal background information", false, "Health & Legal History", "health-legal-history", null }
                });

            migrationBuilder.InsertData(
                table: "facility_types",
                columns: new[] { "id", "created_by_id", "description", "is_deleted", "name", "updated_by_id" },
                values: new object[,]
                {
                    { 1, 1, null, false, "Hospital", null },
                    { 2, 1, null, false, "Clinic", null },
                    { 3, 1, null, false, "Urgent Care", null },
                    { 4, 1, null, false, "Rehabilitation Center", null }
                });

            migrationBuilder.InsertData(
                table: "forms",
                columns: new[] { "id", "created_by_id", "description", "is_active", "is_deleted", "name", "slug", "updated_by_id" },
                values: new object[] { 1, 1, "Collects physician personal details, credentials, and licenses for credentialing purposes.", true, false, "Standard Credentialing Form", "physician-credentialing", null });

            migrationBuilder.InsertData(
                table: "job_types",
                columns: new[] { "id", "created_by_id", "description", "is_deleted", "name", "updated_by_id" },
                values: new object[,]
                {
                    { 1, 1, null, false, "Full-Time", null },
                    { 2, 1, null, false, "Part-Time", null },
                    { 3, 1, null, false, "Contract", null },
                    { 4, 1, null, false, "Temporary", null },
                    { 5, 1, null, false, "Internship", null }
                });

            migrationBuilder.InsertData(
                table: "location_types",
                columns: new[] { "id", "created_by_id", "description", "is_deleted", "name", "updated_by_id" },
                values: new object[,]
                {
                    { 1, 1, null, false, "Urban", null },
                    { 2, 1, null, false, "Suburban", null },
                    { 3, 1, null, false, "Rural", null },
                    { 4, 1, null, false, "Remote", null }
                });

            migrationBuilder.InsertData(
                table: "shift_types",
                columns: new[] { "id", "created_by_id", "description", "is_deleted", "name", "updated_by_id" },
                values: new object[,]
                {
                    { 1, 1, null, false, "Morning", null },
                    { 2, 1, null, false, "Afternoon", null },
                    { 3, 1, null, false, "Evening", null },
                    { 4, 1, null, false, "Night", null },
                    { 5, 1, null, false, "On-Call", null }
                });

            migrationBuilder.InsertData(
                table: "states",
                columns: new[] { "id", "abbreviation", "created_by_id", "is_deleted", "name", "updated_by_id" },
                values: new object[,]
                {
                    { 1, "AL", 1, false, "Alabama", null },
                    { 2, "AK", 1, false, "Alaska", null },
                    { 3, "AZ", 1, false, "Arizona", null },
                    { 4, "AR", 1, false, "Arkansas", null },
                    { 5, "CA", 1, false, "California", null }
                });

            migrationBuilder.InsertData(
                table: "form_category",
                columns: new[] { "category_id", "form_id", "sort_order" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 1, 3 },
                    { 4, 1, 4 },
                    { 5, 1, 5 }
                });

            migrationBuilder.InsertData(
                table: "profiles",
                columns: new[] { "id", "created_by_id", "first_name", "is_deleted", "last_name", "phone_number", "updated_by_id", "user_id" },
                values: new object[,]
                {
                    { 1, 1, "SuperAdmin", false, "SuperAdmin", "(555) 555-5555", null, 1 },
                    { 2, 1, "Admin", false, "Admin", "(555) 555-5555", null, 2 },
                    { 3, 1, "Locum", false, "Locum", "(999) 999-9999", null, 3 }
                });

            migrationBuilder.InsertData(
                table: "questions",
                columns: new[] { "id", "category_id", "created_by_id", "data_type", "help_text", "is_deleted", "RegexValidation", "sort_order", "text", "updated_by_id" },
                values: new object[,]
                {
                    { 1, 1, 1, 0, "Enter your 10-digit National Provider Identifier (NPI).", false, "^\\d{3}[- ]?\\d{3}[- ]?\\d{4}$\n", 1, "NPI", null },
                    { 2, 1, 1, 0, "Enter your 9-digit Social Security Number (format: XXX-XX-XXXX).", false, "^(?!000|666|9\\d{2})\\d{3}-(?!00)\\d{2}-(?!0000)\\d{4}$\n", 2, "SSN", null },
                    { 3, 2, 1, 3, "Required to determine eligibility for job opportunities.", false, null, 1, "Are you authorized to work in the U.S.?", null },
                    { 4, 2, 1, 0, "Enter the name of the medical school from which you graduated.", false, null, 2, "Medical School Name", null },
                    { 5, 2, 1, 0, "Enter the city where your medical school is located.", false, null, 3, "City", null },
                    { 6, 2, 1, 4, "Select the state where your medical school is located or where you are licensed to practice.", false, null, 4, "State", null }
                });

            migrationBuilder.InsertData(
                table: "category_question",
                columns: new[] { "form_id", "id", "question_id", "sort_order" },
                values: new object[,]
                {
                    { 1, 2, 1, null },
                    { 1, 2, 2, null }
                });

            migrationBuilder.InsertData(
                table: "preferences",
                columns: new[] { "id", "created_by_id", "is_deleted", "profile_id", "updated_by_id" },
                values: new object[,]
                {
                    { 1, 1, false, 1, null },
                    { 2, 1, false, 2, null }
                });

            migrationBuilder.InsertData(
                table: "profile_notification_settings",
                columns: new[] { "id", "certificate_expiration_email", "certificate_expiration_in_app", "certificate_expiration_sms", "created_by_id", "credentialing_updates_email", "credentialing_updates_in_app", "credentialing_updates_sms", "general_reminders_email", "general_reminders_in_app", "general_reminders_sms", "is_deleted", "job_match_notifications_email", "job_match_notifications_in_app", "job_match_notifications_sms", "profile_id", "updated_by_id" },
                values: new object[,]
                {
                    { 1, true, true, false, 1, false, false, false, false, false, true, false, false, true, false, 1, null },
                    { 2, false, false, false, 1, false, false, false, false, false, false, false, false, false, false, 2, null }
                });

            migrationBuilder.InsertData(
                table: "preference_facility_type",
                columns: new[] { "facility_type_id", "preference_id" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "preference_job_type",
                columns: new[] { "job_type_id", "preference_id" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "preference_location_type",
                columns: new[] { "location_type_id", "preference_id" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "preference_shift_type",
                columns: new[] { "preference_id", "shift_type_id" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "preference_state",
                columns: new[] { "preference_id", "state_id" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_profile_id",
                table: "Address",
                column: "profile_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Address_StateId",
                table: "Address",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_category_question_form_id",
                table: "category_question",
                column: "form_id");

            migrationBuilder.CreateIndex(
                name: "IX_category_question_question_id",
                table: "category_question",
                column: "question_id");

            migrationBuilder.CreateIndex(
                name: "IX_form_category_category_id",
                table: "form_category",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_preference_facility_type_preference_id",
                table: "preference_facility_type",
                column: "preference_id");

            migrationBuilder.CreateIndex(
                name: "IX_preference_job_type_preference_id",
                table: "preference_job_type",
                column: "preference_id");

            migrationBuilder.CreateIndex(
                name: "IX_preference_location_type_preference_id",
                table: "preference_location_type",
                column: "preference_id");

            migrationBuilder.CreateIndex(
                name: "IX_preference_shift_type_preference_id",
                table: "preference_shift_type",
                column: "preference_id");

            migrationBuilder.CreateIndex(
                name: "IX_preference_state_preference_id",
                table: "preference_state",
                column: "preference_id");

            migrationBuilder.CreateIndex(
                name: "IX_preferences_profile_id",
                table: "preferences",
                column: "profile_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_profile_notification_settings_profile_id",
                table: "profile_notification_settings",
                column: "profile_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_profiles_user_id",
                table: "profiles",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_question_options_question_id",
                table: "question_options",
                column: "question_id");

            migrationBuilder.CreateIndex(
                name: "IX_questions_category_id",
                table: "questions",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_credentials_question_id",
                table: "user_credentials",
                column: "question_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_credentials_selected_option_id",
                table: "user_credentials",
                column: "selected_option_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_credentials_validated_by_id",
                table: "user_credentials",
                column: "validated_by_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "category_question");

            migrationBuilder.DropTable(
                name: "form_category");

            migrationBuilder.DropTable(
                name: "preference_facility_type");

            migrationBuilder.DropTable(
                name: "preference_job_type");

            migrationBuilder.DropTable(
                name: "preference_location_type");

            migrationBuilder.DropTable(
                name: "preference_shift_type");

            migrationBuilder.DropTable(
                name: "preference_state");

            migrationBuilder.DropTable(
                name: "profile_notification_settings");

            migrationBuilder.DropTable(
                name: "user_credentials");

            migrationBuilder.DropTable(
                name: "forms");

            migrationBuilder.DropTable(
                name: "facility_types");

            migrationBuilder.DropTable(
                name: "job_types");

            migrationBuilder.DropTable(
                name: "location_types");

            migrationBuilder.DropTable(
                name: "shift_types");

            migrationBuilder.DropTable(
                name: "preferences");

            migrationBuilder.DropTable(
                name: "states");

            migrationBuilder.DropTable(
                name: "question_options");

            migrationBuilder.DropTable(
                name: "profiles");

            migrationBuilder.DropTable(
                name: "questions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
