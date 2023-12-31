﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ADLTracker.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssistTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Simple = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssistTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CodeStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactPrecautions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Diagram = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactPrecautions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Simple = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
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
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
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
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
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
                name: "Providers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdentityUserId = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Providers_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    DOB = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    GenderId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientId = table.Column<int>(type: "integer", nullable: false),
                    AssistTypeId = table.Column<int>(type: "integer", nullable: false),
                    CodeStatusId = table.Column<int>(type: "integer", nullable: false),
                    ContactPrecautionId = table.Column<int>(type: "integer", nullable: false),
                    Diagnosis = table.Column<string>(type: "text", nullable: false),
                    RoomNumber = table.Column<int>(type: "integer", nullable: false),
                    Height = table.Column<int>(type: "integer", nullable: false),
                    Weight = table.Column<decimal>(type: "numeric", nullable: false),
                    AdmissionDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastBath = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastBM = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Telemetry = table.Column<bool>(type: "boolean", nullable: false),
                    TelemetryNumber = table.Column<int>(type: "integer", nullable: true),
                    Discharged = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientProfiles_AssistTypes_AssistTypeId",
                        column: x => x.AssistTypeId,
                        principalTable: "AssistTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientProfiles_CodeStatuses_CodeStatusId",
                        column: x => x.CodeStatusId,
                        principalTable: "CodeStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientProfiles_ContactPrecautions_ContactPrecautionId",
                        column: x => x.ContactPrecautionId,
                        principalTable: "ContactPrecautions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientProfiles_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Intakes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientProfileId = table.Column<int>(type: "integer", nullable: false),
                    ProviderId = table.Column<int>(type: "integer", nullable: false),
                    IntakeAmount = table.Column<int>(type: "integer", nullable: false),
                    TimeRecorded = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intakes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Intakes_PatientProfiles_PatientProfileId",
                        column: x => x.PatientProfileId,
                        principalTable: "PatientProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Outputs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientProfileId = table.Column<int>(type: "integer", nullable: false),
                    ProviderId = table.Column<int>(type: "integer", nullable: false),
                    OutputAmount = table.Column<int>(type: "integer", nullable: false),
                    TimeRecorded = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Outputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Outputs_PatientProfiles_PatientProfileId",
                        column: x => x.PatientProfileId,
                        principalTable: "PatientProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientProviders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientProfileId = table.Column<int>(type: "integer", nullable: false),
                    ProviderId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientProviders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientProviders_PatientProfiles_PatientProfileId",
                        column: x => x.PatientProfileId,
                        principalTable: "PatientProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientProviders_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "80cf5697-c2b9-4960-a0aa-e22d959573a1", null, "Tech", "tech" },
                    { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", null, "Nurse", "nurse" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "555401a5-2862-4e4c-89db-b462bc2d2e1c", 0, "126e9e38-8b21-4789-a9b2-3f6cbcccd68f", "bad@tech.comx", false, false, null, null, null, "AQAAAAIAAYagAAAAEE3KIxfyfDF6YnkAJixdn5U5kI0Kdd9Xe7ULvfVX+RjXdfXbYxWvAlqubsLXmqb6zA==", null, false, "39bf15c1-c33d-41cc-8bbe-d52277d7c9fd", false, null },
                    { "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", 0, "66859960-c512-424f-98ae-79a4d3c89985", "good@nurse.comx", false, false, null, null, null, "AQAAAAIAAYagAAAAEDDSOYvilavMA1nneFrspiGuWF4n786NJVvuKl0aI+p+a6VM4k/Gfqgy4B4MFBO+mw==", null, false, "d30f16e4-0f22-434a-acd0-292461ca264d", false, null },
                    { "ef18a47a-3a66-4ced-a1a2-75c6acf0b060", 0, "dcbab922-229b-418c-acba-0482a00d9489", "mid@tech.comx", false, false, null, null, null, "AQAAAAIAAYagAAAAEOtGsyw1vJj7Obw5Nd/I/3dEuhkAv5wNxKUKfGreBHqWbB9v6B4nEQ9+cflSp+wZSg==", null, false, "f6704ba8-4234-4c4b-bbe4-ac57e4e559ea", false, null },
                    { "f575a7b0-384c-4c94-abe1-945ec9d041a0", 0, "25b718b0-ccdc-41ba-9b38-15c63488805b", "good@tech.comx", false, false, null, null, null, "AQAAAAIAAYagAAAAEDc1UG7Uj9outAcSUCimDPmoyyv0oqf6ei7tV2KTGIRq7ebMFw4mQspkxevFseK6pQ==", null, false, "579a5d7f-9909-4df3-a526-6c62207612fb", false, null }
                });

            migrationBuilder.InsertData(
                table: "AssistTypes",
                columns: new[] { "Id", "Simple", "Type" },
                values: new object[,]
                {
                    { 1, "IND", "Independent" },
                    { 2, "SBA", "Stand-by Assist" },
                    { 3, "x1", "1 Assist" },
                    { 4, "x2+", "Total Assist" }
                });

            migrationBuilder.InsertData(
                table: "CodeStatuses",
                columns: new[] { "Id", "Description", "Type" },
                values: new object[,]
                {
                    { 1, "Full Code", "Full Code" },
                    { 2, "Do Not Resuscitate", "DNR" }
                });

            migrationBuilder.InsertData(
                table: "ContactPrecautions",
                columns: new[] { "Id", "Diagram", "Type" },
                values: new object[,]
                {
                    { 1, "https://t3.gstatic.com/images?q=tbn:ANd9GcR2bxhfh2iWTct175RQ46-j_FqSzICUro3Oznj9n2P0ZPPfSgmo", "Standard" },
                    { 2, "https://www.brevis.com/image/lg/cpr7r2.jpg", "Contact" },
                    { 3, "https://brevis.com/images/cprmdro.jpg", "Contact+" },
                    { 4, "https://brevis.com/images/dpr14.jpg", "Droplet" },
                    { 5, "https://www.brevis.com/image/lg/apr20.jpg", "Airborne" }
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Simple", "Type" },
                values: new object[,]
                {
                    { 1, "M", "Male" },
                    { 2, "F", "Female" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "80cf5697-c2b9-4960-a0aa-e22d959573a1", "555401a5-2862-4e4c-89db-b462bc2d2e1c" },
                    { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f" },
                    { "80cf5697-c2b9-4960-a0aa-e22d959573a1", "ef18a47a-3a66-4ced-a1a2-75c6acf0b060" },
                    { "80cf5697-c2b9-4960-a0aa-e22d959573a1", "f575a7b0-384c-4c94-abe1-945ec9d041a0" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "DOB", "FirstName", "GenderId", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(1977, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bryanty", 1, "Luckett" },
                    { 2, new DateTime(1986, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alanson", 2, "Surpliss" },
                    { 3, new DateTime(1961, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marquita", 2, "Gabbotts" },
                    { 4, new DateTime(1959, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ashlie", 2, "Bertouloume" },
                    { 5, new DateTime(1999, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Matias", 1, "Jannings" },
                    { 6, new DateTime(1949, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harley", 1, "Dreger" },
                    { 7, new DateTime(1986, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marlin", 1, "Briddock" },
                    { 8, new DateTime(1982, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sheffy", 2, "McVeighty" },
                    { 9, new DateTime(1947, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nata", 2, "Attle" },
                    { 10, new DateTime(1970, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hodge", 1, "Pilkinton" },
                    { 11, new DateTime(1972, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Terrance", 1, "Barthram" },
                    { 12, new DateTime(1942, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Monti", 2, "Rominov" },
                    { 13, new DateTime(1950, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gerik", 1, "Street" },
                    { 14, new DateTime(1952, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cassaundra", 2, "McKmurrie" },
                    { 15, new DateTime(1945, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Panther", 2, "Moons" }
                });

            migrationBuilder.InsertData(
                table: "Providers",
                columns: new[] { "Id", "FirstName", "IdentityUserId", "LastName" },
                values: new object[,]
                {
                    { 1, "Bryan", "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", "Sadman" },
                    { 2, "James", "f575a7b0-384c-4c94-abe1-945ec9d041a0", "Luck" },
                    { 3, "Tiffany", "ef18a47a-3a66-4ced-a1a2-75c6acf0b060", "Eversnow" },
                    { 4, "Holly", "555401a5-2862-4e4c-89db-b462bc2d2e1c", "Beaver" }
                });

            migrationBuilder.InsertData(
                table: "PatientProfiles",
                columns: new[] { "Id", "AdmissionDate", "AssistTypeId", "CodeStatusId", "ContactPrecautionId", "Diagnosis", "Discharged", "Height", "LastBM", "LastBath", "PatientId", "RoomNumber", "Telemetry", "TelemetryNumber", "Weight" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 5, 10, 49, 43, 0, DateTimeKind.Unspecified), 2, 1, 1, "Diabetes Mellitus", false, 77, new DateTime(2023, 10, 16, 7, 19, 10, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 16, 8, 51, 55, 0, DateTimeKind.Unspecified), 1, 1000, false, null, 44.5m },
                    { 2, new DateTime(2023, 10, 12, 6, 43, 24, 0, DateTimeKind.Unspecified), 3, 1, 1, "Hypertensive Crisis", false, 65, new DateTime(2023, 10, 15, 4, 39, 32, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 16, 7, 6, 2, 0, DateTimeKind.Unspecified), 2, 1001, false, null, 77.3m },
                    { 3, new DateTime(2023, 10, 7, 22, 58, 47, 0, DateTimeKind.Unspecified), 3, 2, 1, "SOB Asthma", true, 61, new DateTime(2023, 10, 16, 22, 38, 27, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 16, 9, 1, 1, 0, DateTimeKind.Unspecified), 3, 1002, true, 345, 78.0m },
                    { 4, new DateTime(2023, 10, 12, 19, 10, 5, 0, DateTimeKind.Unspecified), 4, 2, 1, "Headache/ L Side Weakness", false, 72, new DateTime(2023, 10, 15, 5, 27, 11, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 16, 17, 0, 37, 0, DateTimeKind.Unspecified), 4, 1004, true, 123, 58.8m },
                    { 5, new DateTime(2023, 10, 8, 23, 6, 18, 0, DateTimeKind.Unspecified), 4, 1, 1, "Fatigue", true, 50, new DateTime(2023, 10, 16, 18, 28, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 16, 15, 28, 47, 0, DateTimeKind.Unspecified), 5, 1005, false, null, 46.1m },
                    { 6, new DateTime(2023, 10, 3, 11, 53, 50, 0, DateTimeKind.Unspecified), 2, 1, 3, "Clostridium difficile", false, 73, new DateTime(2023, 10, 15, 16, 15, 3, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 16, 12, 51, 49, 0, DateTimeKind.Unspecified), 6, 1006, true, 108, 75.2m },
                    { 7, new DateTime(2023, 10, 6, 11, 59, 57, 0, DateTimeKind.Unspecified), 3, 1, 1, "Fatigue", false, 71, new DateTime(2023, 10, 16, 11, 33, 58, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 16, 16, 39, 29, 0, DateTimeKind.Unspecified), 7, 1007, true, 499, 46.7m },
                    { 8, new DateTime(2023, 10, 9, 5, 4, 46, 0, DateTimeKind.Unspecified), 2, 1, 1, "CHF Exacerbation", false, 68, new DateTime(2023, 10, 15, 14, 36, 13, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 16, 1, 5, 32, 0, DateTimeKind.Unspecified), 8, 1008, false, null, 65.3m },
                    { 9, new DateTime(2023, 10, 15, 12, 57, 27, 0, DateTimeKind.Unspecified), 3, 1, 1, "SOB Asthma", false, 59, new DateTime(2023, 10, 15, 13, 24, 56, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 16, 22, 57, 40, 0, DateTimeKind.Unspecified), 9, 1009, true, 119, 75.0m },
                    { 10, new DateTime(2023, 10, 10, 4, 24, 27, 0, DateTimeKind.Unspecified), 2, 2, 2, "LLE Cellulitis", false, 68, new DateTime(2023, 10, 16, 20, 19, 13, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 16, 20, 40, 52, 0, DateTimeKind.Unspecified), 10, 1010, false, null, 89.6m },
                    { 11, new DateTime(2023, 10, 7, 22, 19, 45, 0, DateTimeKind.Unspecified), 2, 2, 1, "Altered Mental Status", false, 52, new DateTime(2023, 10, 15, 15, 43, 9, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 16, 3, 34, 41, 0, DateTimeKind.Unspecified), 11, 1011, false, null, 43.6m },
                    { 12, new DateTime(2023, 10, 6, 7, 16, 38, 0, DateTimeKind.Unspecified), 1, 1, 1, "Chrohn's Exacerbation", false, 65, new DateTime(2023, 10, 16, 20, 57, 58, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 16, 17, 41, 3, 0, DateTimeKind.Unspecified), 12, 1013, true, 501, 70.4m },
                    { 13, new DateTime(2023, 10, 8, 3, 38, 11, 0, DateTimeKind.Unspecified), 2, 1, 1, "Fatigue", true, 71, new DateTime(2023, 10, 16, 8, 35, 4, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 16, 5, 46, 25, 0, DateTimeKind.Unspecified), 13, 1014, false, null, 69.7m },
                    { 14, new DateTime(2023, 10, 5, 0, 49, 28, 0, DateTimeKind.Unspecified), 2, 1, 4, "Influenza", false, 48, new DateTime(2023, 10, 15, 14, 57, 34, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 16, 9, 32, 54, 0, DateTimeKind.Unspecified), 14, 1015, false, null, 43.2m },
                    { 15, new DateTime(2023, 10, 13, 9, 12, 23, 0, DateTimeKind.Unspecified), 3, 2, 5, "Covid", false, 45, new DateTime(2023, 10, 15, 21, 3, 25, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 16, 1, 31, 37, 0, DateTimeKind.Unspecified), 15, 1016, true, 333, 88.8m }
                });

            migrationBuilder.InsertData(
                table: "Intakes",
                columns: new[] { "Id", "IntakeAmount", "PatientProfileId", "ProviderId", "TimeRecorded" },
                values: new object[,]
                {
                    { 1, 240, 1, 1, new DateTime(2023, 10, 16, 5, 8, 49, 0, DateTimeKind.Unspecified) },
                    { 2, 500, 1, 2, new DateTime(2023, 10, 15, 3, 25, 37, 0, DateTimeKind.Unspecified) },
                    { 3, 350, 3, 1, new DateTime(2023, 10, 16, 9, 19, 9, 0, DateTimeKind.Unspecified) },
                    { 4, 125, 4, 1, new DateTime(2023, 10, 16, 20, 26, 47, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Outputs",
                columns: new[] { "Id", "OutputAmount", "PatientProfileId", "ProviderId", "TimeRecorded" },
                values: new object[,]
                {
                    { 1, 50, 1, 1, new DateTime(2023, 10, 16, 5, 8, 49, 0, DateTimeKind.Unspecified) },
                    { 2, 64, 2, 2, new DateTime(2023, 10, 15, 3, 25, 37, 0, DateTimeKind.Unspecified) },
                    { 3, 51, 3, 3, new DateTime(2023, 10, 16, 9, 19, 9, 0, DateTimeKind.Unspecified) },
                    { 4, 64, 4, 2, new DateTime(2023, 10, 16, 20, 26, 47, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "PatientProviders",
                columns: new[] { "Id", "PatientProfileId", "ProviderId" },
                values: new object[,]
                {
                    { 1, 1, 2 },
                    { 2, 2, 4 },
                    { 3, 3, 2 },
                    { 4, 4, 4 },
                    { 5, 5, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Intakes_PatientProfileId",
                table: "Intakes",
                column: "PatientProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Outputs_PatientProfileId",
                table: "Outputs",
                column: "PatientProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientProfiles_AssistTypeId",
                table: "PatientProfiles",
                column: "AssistTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientProfiles_CodeStatusId",
                table: "PatientProfiles",
                column: "CodeStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientProfiles_ContactPrecautionId",
                table: "PatientProfiles",
                column: "ContactPrecautionId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientProfiles_PatientId",
                table: "PatientProfiles",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientProviders_PatientProfileId",
                table: "PatientProviders",
                column: "PatientProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientProviders_ProviderId",
                table: "PatientProviders",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_GenderId",
                table: "Patients",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Providers_IdentityUserId",
                table: "Providers",
                column: "IdentityUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "Intakes");

            migrationBuilder.DropTable(
                name: "Outputs");

            migrationBuilder.DropTable(
                name: "PatientProviders");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "PatientProfiles");

            migrationBuilder.DropTable(
                name: "Providers");

            migrationBuilder.DropTable(
                name: "AssistTypes");

            migrationBuilder.DropTable(
                name: "CodeStatuses");

            migrationBuilder.DropTable(
                name: "ContactPrecautions");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Genders");
        }
    }
}
