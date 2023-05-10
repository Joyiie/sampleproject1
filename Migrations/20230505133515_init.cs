using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capstonep2.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FirstName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MiddleName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BirthDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Abbreviation = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Type = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Key = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    StartTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Symptom = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PurposeOfVisit = table.Column<int>(type: "int", nullable: false),
                    PatientID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Visit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PatientID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FirstName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MiddleName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    RoleID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Users_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ConsultationRecords",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PatientID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    AppointmentID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultationRecords", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ConsultationRecords_Appointments_AppointmentID",
                        column: x => x.AppointmentID,
                        principalTable: "Appointments",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ConsultationRecords_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    RoleID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Findings",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Tags = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConsultationRecordID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Findings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Findings_ConsultationRecords_ConsultationRecordID",
                        column: x => x.ConsultationRecordID,
                        principalTable: "ConsultationRecords",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Tags = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConsultationRecordID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Prescriptions_ConsultationRecords_ConsultationRecordID",
                        column: x => x.ConsultationRecordID,
                        principalTable: "ConsultationRecords",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "ID", "Address", "BirthDate", "FirstName", "Gender", "LastName", "MiddleName" },
                values: new object[,]
                {
                    { new Guid("2b792220-f333-49ec-abe2-3a6fc4edb0c2"), "Luakan,Dinalupihan, Bataan", new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luisa Katrina", 0, "Reyes", "Pangilinan" },
                    { new Guid("5a7e7bc3-8816-41df-b44d-eeb60ae99b5b"), "Luakan,Dinalupihan, Bataan", new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clarissa Joy", 0, "Flores", "Gozon" },
                    { new Guid("8664a4bd-0ec6-4aaa-83e6-7d2bd0315b5a"), "Bacong,Hermosa, Bataan", new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Raniel", 1, "David", "Mallari" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "ID", "Abbreviation", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("2afa881f-e519-4e67-a841-e4a2630e8a2a"), "Pt", "One who receives medical treatment", "patient" },
                    { new Guid("54f00f70-72b8-4d34-a953-83321ff6b101"), "Adm", "One who manages the system", "admin" }
                });

            migrationBuilder.InsertData(
                table: "UserLogins",
                columns: new[] { "ID", "Key", "Type", "UserID", "Value" },
                values: new object[,]
                {
                    { new Guid("0fc40e56-755b-4d4d-8591-83f2bb050d75"), "IsActive", "General", new Guid("1bd5f519-b891-4491-9a7c-a86cd0c2a15e"), "true" },
                    { new Guid("2aa6c8b3-1392-4a54-98cc-b1b382f351d8"), "Password", "General", new Guid("00acfb7f-6c90-459a-b53f-bf73ddac85b4"), "$2a$11$2deiUj3FmHdXU1vY79lD1OMuHUmt2aC4f.ijaF/fKmmionCatHoAe" },
                    { new Guid("3d3fe692-9334-4c2f-8fc3-6e8152d27e8a"), "Password", "General", new Guid("0352c124-f290-4f99-b1a5-e235cafcd836"), "$2a$11$iWfyg6LZgU1eCtI08pkaSemyFQVixiJPVMMdUEUgFOebLoe1GhYtm" },
                    { new Guid("532e48c9-8e7c-48a1-8e75-508af3793c98"), "LoginRetries", "General", new Guid("7e5e4f74-9902-43da-9974-4b2a08814398"), "0" },
                    { new Guid("58fe0cb1-9272-45d6-b433-d5cc7f024d76"), "LoginRetries", "General", new Guid("1bd5f519-b891-4491-9a7c-a86cd0c2a15e"), "0" },
                    { new Guid("60e938be-a71b-4f43-bfab-832fc623ca80"), "IsActive", "General", new Guid("d7dbd16f-1c71-4415-a147-22a2b428bf95"), "true" },
                    { new Guid("6945f4d6-5345-4bc0-a12b-3db86af2d20a"), "LoginRetries", "General", new Guid("d7dbd16f-1c71-4415-a147-22a2b428bf95"), "0" },
                    { new Guid("6e047351-75f3-444c-9760-c865a40d123e"), "IsActive", "General", new Guid("00acfb7f-6c90-459a-b53f-bf73ddac85b4"), "true" },
                    { new Guid("aef39b55-c52c-4ece-963f-b6ef5d18d78e"), "IsActive", "General", new Guid("0352c124-f290-4f99-b1a5-e235cafcd836"), "true" },
                    { new Guid("b3974ed8-b0f6-4305-abef-123bb5745425"), "LoginRetries", "General", new Guid("00acfb7f-6c90-459a-b53f-bf73ddac85b4"), "0" },
                    { new Guid("c0d01976-0681-450e-8c67-654c2c498658"), "Password", "General", new Guid("7e5e4f74-9902-43da-9974-4b2a08814398"), "$2a$11$b3tfH9v40U8iAahh39cH1uBf7xjivL4YEPHYzHQQJre5TfF4vVVCm" },
                    { new Guid("de83bde6-67ab-4cc2-b775-3c7a572d1047"), "IsActive", "General", new Guid("7e5e4f74-9902-43da-9974-4b2a08814398"), "true" },
                    { new Guid("df8eac24-0fc5-44a3-bd0a-9d7ea5d74778"), "LoginRetries", "General", new Guid("0352c124-f290-4f99-b1a5-e235cafcd836"), "0" },
                    { new Guid("e12ed029-a0a2-4b14-beb4-4edb8a34e90b"), "Password", "General", new Guid("d7dbd16f-1c71-4415-a147-22a2b428bf95"), "$2a$11$gmyHfpfariIKfKjNsNtIKehcUWyan15Z3XZ54K2VHFVJNPbVf7pIq" },
                    { new Guid("fb1f052f-73b1-41e9-ba18-36b2313f8061"), "Password", "General", new Guid("1bd5f519-b891-4491-9a7c-a86cd0c2a15e"), "$2a$11$9GvbJVrey6RmkHcdldBQn.9RapbHEKE37Yuwow8bD8uDs2qjXay4O" }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "ID", "EndTime", "PatientID", "PurposeOfVisit", "StartTime", "Status", "Symptom", "Visit" },
                values: new object[,]
                {
                    { new Guid("20f20659-d4e3-466e-b2df-e6a6b1f62fab"), new DateTime(2022, 2, 2, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8664a4bd-0ec6-4aaa-83e6-7d2bd0315b5a"), 0, new DateTime(2022, 2, 12, 11, 30, 0, 0, DateTimeKind.Unspecified), 4, "Red Eyes", 0 },
                    { new Guid("2222ed0f-aaea-45f3-8a72-f0ee3ed23a22"), new DateTime(2022, 2, 2, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8664a4bd-0ec6-4aaa-83e6-7d2bd0315b5a"), 0, new DateTime(2022, 2, 12, 11, 30, 0, 0, DateTimeKind.Unspecified), 3, "Swelling", 0 },
                    { new Guid("3ce371f9-dc79-4623-b84f-0b2fe7c99962"), new DateTime(2023, 2, 2, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5a7e7bc3-8816-41df-b44d-eeb60ae99b5b"), 1, new DateTime(2023, 2, 12, 11, 30, 0, 0, DateTimeKind.Unspecified), 4, "Light Sensitivity", 1 },
                    { new Guid("7297d64f-7912-4e46-a663-e543af0102fb"), new DateTime(22, 2, 23, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5a7e7bc3-8816-41df-b44d-eeb60ae99b5b"), 1, new DateTime(2023, 2, 12, 11, 30, 0, 0, DateTimeKind.Unspecified), 1, "Light Sensitivity", 1 },
                    { new Guid("861c579e-bb80-4dea-b8f2-4b189cb6a362"), new DateTime(2022, 2, 2, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8664a4bd-0ec6-4aaa-83e6-7d2bd0315b5a"), 0, new DateTime(2022, 2, 12, 11, 30, 0, 0, DateTimeKind.Unspecified), 1, "Headache", 1 },
                    { new Guid("a0d287bc-73e8-41b6-88f1-e7385ea7da7d"), new DateTime(2023, 2, 2, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5a7e7bc3-8816-41df-b44d-eeb60ae99b5b"), 1, new DateTime(2023, 2, 12, 11, 30, 0, 0, DateTimeKind.Unspecified), 0, "Light Sensitivity", 1 },
                    { new Guid("c7d431a6-579b-4841-8629-2bbcb79a5e15"), new DateTime(2023, 2, 12, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8664a4bd-0ec6-4aaa-83e6-7d2bd0315b5a"), 2, new DateTime(2023, 2, 12, 11, 30, 0, 0, DateTimeKind.Unspecified), 0, "Light Sensitivity", 0 },
                    { new Guid("e822435f-5110-465f-a276-c89ee9a5dc54"), new DateTime(2023, 2, 2, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5a7e7bc3-8816-41df-b44d-eeb60ae99b5b"), 1, new DateTime(2023, 2, 12, 11, 30, 0, 0, DateTimeKind.Unspecified), 3, "Light Sensitivity", 1 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Address", "BirthDate", "Email", "FirstName", "Gender", "LastName", "MiddleName", "PatientID", "RoleID" },
                values: new object[,]
                {
                    { new Guid("00acfb7f-6c90-459a-b53f-bf73ddac85b4"), "Dinalupihan, Orani , Bataan", new DateTime(2002, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Janedavid@yahoo.com", "Jane", 0, "David", "Adan", null, new Guid("54f00f70-72b8-4d34-a953-83321ff6b101") },
                    { new Guid("0352c124-f290-4f99-b1a5-e235cafcd836"), "Dinalupihan, Orani, Bataan", new DateTime(2001, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "luisa@yahoo.com", "Luisa Katrina", 0, "Pangilinan", "Reyes", new Guid("2b792220-f333-49ec-abe2-3a6fc4edb0c2"), new Guid("2afa881f-e519-4e67-a841-e4a2630e8a2a") },
                    { new Guid("1bd5f519-b891-4491-9a7c-a86cd0c2a15e"), "Dinalupihan, Orani , Bataan", new DateTime(2002, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@yahoo.com", "admin", 0, "admin", "admin", null, new Guid("54f00f70-72b8-4d34-a953-83321ff6b101") },
                    { new Guid("7e5e4f74-9902-43da-9974-4b2a08814398"), "Dinalupihan, Orani, Bataan", new DateTime(2001, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "renieldavid@yahoo.com", "Reniel", 1, "Mallari", "David", new Guid("8664a4bd-0ec6-4aaa-83e6-7d2bd0315b5a"), new Guid("2afa881f-e519-4e67-a841-e4a2630e8a2a") },
                    { new Guid("d7dbd16f-1c71-4415-a147-22a2b428bf95"), "Dinalupihan, Orani, Bataan", new DateTime(2001, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "joy@yahoo.com", "Clarissa Joy", 1, "Gozon", "Flores", new Guid("5a7e7bc3-8816-41df-b44d-eeb60ae99b5b"), new Guid("2afa881f-e519-4e67-a841-e4a2630e8a2a") }
                });

            migrationBuilder.InsertData(
                table: "ConsultationRecords",
                columns: new[] { "ID", "AppointmentID", "PatientID" },
                values: new object[,]
                {
                    { new Guid("0c096359-c9ef-4f37-9c37-47b7bf247746"), new Guid("c7d431a6-579b-4841-8629-2bbcb79a5e15"), new Guid("8664a4bd-0ec6-4aaa-83e6-7d2bd0315b5a") },
                    { new Guid("73ec06ac-56aa-453a-a29d-447691d51cd9"), new Guid("20f20659-d4e3-466e-b2df-e6a6b1f62fab"), new Guid("8664a4bd-0ec6-4aaa-83e6-7d2bd0315b5a") },
                    { new Guid("a11b823f-8eff-4d89-abdc-8efa8f28291c"), new Guid("3ce371f9-dc79-4623-b84f-0b2fe7c99962"), new Guid("5a7e7bc3-8816-41df-b44d-eeb60ae99b5b") }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleID", "UserID" },
                values: new object[,]
                {
                    { new Guid("4efce31a-0eac-40cf-9375-df2d69a21a67"), new Guid("2afa881f-e519-4e67-a841-e4a2630e8a2a"), new Guid("0352c124-f290-4f99-b1a5-e235cafcd836") },
                    { new Guid("7e12f852-7533-4a2b-8e7b-b12ee7fcafd3"), new Guid("54f00f70-72b8-4d34-a953-83321ff6b101"), new Guid("00acfb7f-6c90-459a-b53f-bf73ddac85b4") },
                    { new Guid("f8f338ac-b8d8-4759-8092-df84cd131abb"), new Guid("54f00f70-72b8-4d34-a953-83321ff6b101"), new Guid("1bd5f519-b891-4491-9a7c-a86cd0c2a15e") },
                    { new Guid("fda8cb4e-d6a4-4e6f-b68d-0376f1495596"), new Guid("2afa881f-e519-4e67-a841-e4a2630e8a2a"), new Guid("7e5e4f74-9902-43da-9974-4b2a08814398") },
                    { new Guid("fedc5105-2090-41a0-b594-c022a99e99c3"), new Guid("2afa881f-e519-4e67-a841-e4a2630e8a2a"), new Guid("d7dbd16f-1c71-4415-a147-22a2b428bf95") }
                });

            migrationBuilder.InsertData(
                table: "Findings",
                columns: new[] { "ID", "ConsultationRecordID", "Description", "Tags" },
                values: new object[,]
                {
                    { new Guid("3f36d818-7ccd-4219-8144-d7261542750a"), new Guid("73ec06ac-56aa-453a-a29d-447691d51cd9"), "findings test 1", "testtable123" },
                    { new Guid("4d86df61-f006-4e19-a9aa-56e684495d74"), new Guid("0c096359-c9ef-4f37-9c37-47b7bf247746"), "sore eyes", "123" },
                    { new Guid("7694cbc7-2ce9-4312-bd3e-1a262a1b9f1b"), new Guid("a11b823f-8eff-4d89-abdc-8efa8f28291c"), "test2", "test2" }
                });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "ID", "ConsultationRecordID", "Description", "Tags" },
                values: new object[,]
                {
                    { new Guid("577d4bde-7c59-4f5e-ac1c-2a0d9465b917"), new Guid("0c096359-c9ef-4f37-9c37-47b7bf247746"), "biogesic", "123" },
                    { new Guid("b4dae5e3-754c-4b26-b7e6-32cad6660e25"), new Guid("a11b823f-8eff-4d89-abdc-8efa8f28291c"), " test 2", "test2" },
                    { new Guid("f4cd6025-9f83-4843-b84e-f4f706ac0700"), new Guid("73ec06ac-56aa-453a-a29d-447691d51cd9"), "prescriptions test 2", "tabletest123" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientID",
                table: "Appointments",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultationRecords_AppointmentID",
                table: "ConsultationRecords",
                column: "AppointmentID");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultationRecords_PatientID",
                table: "ConsultationRecords",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Findings_ConsultationRecordID",
                table: "Findings",
                column: "ConsultationRecordID");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_ConsultationRecordID",
                table: "Prescriptions",
                column: "ConsultationRecordID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleID",
                table: "UserRoles",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserID",
                table: "UserRoles",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PatientID",
                table: "Users",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleID",
                table: "Users",
                column: "RoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Findings");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "ConsultationRecords");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
