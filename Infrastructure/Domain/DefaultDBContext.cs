using Capstonep2.Infrastructure.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Capstonep2.Infrastructure.Domain
{

    public class DefaultDBContext : DbContext
    {
        public DefaultDBContext(DbContextOptions<DefaultDBContext> options)
     : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<ConsultationRecord> ConsultationRecords { get; set; }
        public DbSet<Finding> Findings { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            List<Patient> patients = new List<Patient>();
            List<ConsultationRecord> consultationRecords = new List<ConsultationRecord>();
            List<Finding> findings = new List<Finding>();
            List<User> users = new List<User>();
            List<Role> roles = new List<Role>();
            List<Appointment> appointments = new List<Appointment>();
            List<Prescription> prescriptions = new List<Prescription>();
            List<UserLogin> userLogins = new List<UserLogin>();
            List<UserRole> userRoles = new List<UserRole>();

            //patientt3
            patients.Add(new Patient()
            {
                ID = Guid.Parse("2b792220-f333-49ec-abe2-3a6fc4edb0c2"),
                FirstName = "Luisa Katrina",
                MiddleName = "Pangilinan",
                LastName = "Reyes",
                Address = "Luakan,Dinalupihan, Bataan",
                BirthDate = DateTime.Parse("23/03/2023"),

                Gender = Models.Enums.Gender.Female
            });

            users.Add(new User()
            {
                ID = Guid.Parse("0352c124-f290-4f99-b1a5-e235cafcd836"),
                PatientID = Guid.Parse("2b792220-f333-49ec-abe2-3a6fc4edb0c2"),
                Email = "luisa@yahoo.com",
                FirstName = "Luisa Katrina",
                LastName = "Pangilinan",
                MiddleName = "Reyes",
                BirthDate = DateTime.Parse("23/01/2001"),
                Gender = Models.Enums.Gender.Female,
                RoleID = Guid.Parse("2afa881f-e519-4e67-a841-e4a2630e8a2a"),
                Address = "Dinalupihan, Orani, Bataan"
            });
            userLogins.AddRange(new List<UserLogin>()
            {
                new UserLogin()
                {
                    ID = Guid.NewGuid(),
                    UserID =Guid.Parse("0352c124-f290-4f99-b1a5-e235cafcd836"),
                    Type = "General",
                    Key = "Password",
                    Value = BCrypt.Net.BCrypt.EnhancedHashPassword("patient")
                },
                new UserLogin()
                {
                    ID = Guid.NewGuid(),
                    UserID =Guid.Parse("0352c124-f290-4f99-b1a5-e235cafcd836"),
                    Type = "General",
                    Key = "IsActive",
                    Value = "true"
                },
                new UserLogin()
                {
                    ID = Guid.NewGuid(),
                    UserID =Guid.Parse("0352c124-f290-4f99-b1a5-e235cafcd836"),
                    Type = "General",
                    Key = "LoginRetries",
                    Value = "0"
                }
            });
            userRoles.Add(new UserRole()
            {
                Id = Guid.NewGuid(),
                UserID = Guid.Parse("0352c124-f290-4f99-b1a5-e235cafcd836"),
                RoleID = Guid.Parse("2afa881f-e519-4e67-a841-e4a2630e8a2a"),
            });
            //pa3
            //patient2
            patients.Add(new Patient()
            {
                ID = Guid.Parse("5a7e7bc3-8816-41df-b44d-eeb60ae99b5b"),
                FirstName = "Clarissa Joy",
                MiddleName = "Gozon",
                LastName = "Flores",
                Address = "Luakan,Dinalupihan, Bataan",
                BirthDate = DateTime.Parse("23/03/2023"),

                Gender = Models.Enums.Gender.Female
            });
            //patient2
            //user2
            users.Add(new User()
            {
                ID = Guid.Parse("d7dbd16f-1c71-4415-a147-22a2b428bf95"),
                PatientID = Guid.Parse("5a7e7bc3-8816-41df-b44d-eeb60ae99b5b"),
                Email = "joy@yahoo.com",
                FirstName = "Clarissa Joy",
                LastName = "Gozon",
                MiddleName = "Flores",
                BirthDate = DateTime.Parse("23/01/2001"),
                Gender = Models.Enums.Gender.Male,
                RoleID = Guid.Parse("2afa881f-e519-4e67-a841-e4a2630e8a2a"),
                Address = "Dinalupihan, Orani, Bataan"
            });
            userLogins.AddRange(new List<UserLogin>()
            {
                new UserLogin()
                {
                    ID = Guid.NewGuid(),
                    UserID =Guid.Parse("d7dbd16f-1c71-4415-a147-22a2b428bf95"),
                    Type = "General",
                    Key = "Password",
                    Value = BCrypt.Net.BCrypt.EnhancedHashPassword("capstone")
                },
                new UserLogin()
                {
                    ID = Guid.NewGuid(),
                    UserID =Guid.Parse("d7dbd16f-1c71-4415-a147-22a2b428bf95"),
                    Type = "General",
                    Key = "IsActive",
                    Value = "true"
                },
                new UserLogin()
                {
                    ID = Guid.NewGuid(),
                    UserID =Guid.Parse("d7dbd16f-1c71-4415-a147-22a2b428bf95"),
                    Type = "General",
                    Key = "LoginRetries",
                    Value = "0"
                }
            });
            userRoles.Add(new UserRole()
            {
                Id = Guid.NewGuid(),
                UserID = Guid.Parse("d7dbd16f-1c71-4415-a147-22a2b428bf95"),
                RoleID = Guid.Parse("2afa881f-e519-4e67-a841-e4a2630e8a2a"),
            });
            // user2

            //appts2
            appointments.Add(new Appointment()
            {
                ID = Guid.Parse("3ce371f9-dc79-4623-b84f-0b2fe7c99962"),
                PatientID = Guid.Parse("5a7e7bc3-8816-41df-b44d-eeb60ae99b5b"),
                StartTime = DateTime.Parse("12-02-23 11:30"),
                EndTime = DateTime.Parse("02-02-23 12:00"),
                PurposeOfVisit = Models.Enums.Purpose.CheckUp,
                Symptom = "Light Sensitivity",
                Status = Models.Enums.Status.Completed,
                Visit = Models.Enums.Visit.Appointment
                

            });
            appointments.Add(new Appointment()
            {
                ID = Guid.Parse("7297d64f-7912-4e46-a663-e543af0102fb"),
                PatientID = Guid.Parse("5a7e7bc3-8816-41df-b44d-eeb60ae99b5b"),
                StartTime = DateTime.Parse("12-02-23 11:30"),
                EndTime = DateTime.Parse("022-02-23 12:00"),
                PurposeOfVisit = Models.Enums.Purpose.CheckUp,
                Symptom = "Light Sensitivity",
                Status = Models.Enums.Status.Cancelled,
                Visit = Models.Enums.Visit.Appointment

            });

            appointments.Add(new Appointment()
            {
                ID = Guid.Parse("a0d287bc-73e8-41b6-88f1-e7385ea7da7d"),
                PatientID = Guid.Parse("5a7e7bc3-8816-41df-b44d-eeb60ae99b5b"),
                StartTime = DateTime.Parse("12-02-23 11:30"),
                EndTime = DateTime.Parse("02-02-23 12:00"),
                PurposeOfVisit = Models.Enums.Purpose.CheckUp,
                Symptom = "Light Sensitivity",
                Status = Models.Enums.Status.Pending,
                Visit = Models.Enums.Visit.Appointment

            });
            appointments.Add(new Appointment()
            {
                ID = Guid.Parse("e822435f-5110-465f-a276-c89ee9a5dc54"),
                PatientID = Guid.Parse("5a7e7bc3-8816-41df-b44d-eeb60ae99b5b"),
                StartTime = DateTime.Parse("12-02-23 11:30"),
                EndTime = DateTime.Parse("02-02-23 12:00"),
                PurposeOfVisit = Models.Enums.Purpose.CheckUp,
                Symptom = "Light Sensitivity",
                Status = Models.Enums.Status.NoShow,
                Visit = Models.Enums.Visit.Appointment

            });
            //appts2

            //cr2
            consultationRecords.Add(new ConsultationRecord()
            {
                PatientID = Guid.Parse("5a7e7bc3-8816-41df-b44d-eeb60ae99b5b"),
                AppointmentID = Guid.Parse("3ce371f9-dc79-4623-b84f-0b2fe7c99962"),
                ID = Guid.Parse("a11b823f-8eff-4d89-abdc-8efa8f28291c"),

            });
            //cr
            //finding2-Prescription
            findings.Add(new Finding()
            {
                ConsultationRecordID = Guid.Parse("a11b823f-8eff-4d89-abdc-8efa8f28291c"),
                Description = "test2",
                ID = Guid.NewGuid(),
                Tags = "test2"
            });

            prescriptions.Add(new Prescription()
            {
                ConsultationRecordID = Guid.Parse("a11b823f-8eff-4d89-abdc-8efa8f28291c"),
                Description = " test 2",
                ID = Guid.NewGuid(),
                Tags = "test2"
            });
            //finding2

            patients.Add(new Patient()
            {
                ID = Guid.Parse("8664a4bd-0ec6-4aaa-83e6-7d2bd0315b5a"),
                FirstName = "Raniel",
                MiddleName = "Mallari",
                LastName = "David",
                Address = "Bacong,Hermosa, Bataan",
                BirthDate = DateTime.Parse("23/03/2023"),

                Gender = Models.Enums.Gender.Male
            });

            appointments.Add(new Appointment()
            {
                ID = Guid.Parse("c7d431a6-579b-4841-8629-2bbcb79a5e15"),
                PatientID = Guid.Parse("8664a4bd-0ec6-4aaa-83e6-7d2bd0315b5a"),
                StartTime = DateTime.Parse("12-02-23 11:30"),
                EndTime = DateTime.Parse("12-02-23 12:00"),
                PurposeOfVisit = Models.Enums.Purpose.FollowUp,
                Symptom= "Light Sensitivity",
                Status = Models.Enums.Status.Pending
                
            }); 

            appointments.Add(new Appointment()
            {
                ID = Guid.Parse("20f20659-d4e3-466e-b2df-e6a6b1f62fab"),
                PatientID = Guid.Parse("8664a4bd-0ec6-4aaa-83e6-7d2bd0315b5a"),
                StartTime = DateTime.Parse("12-02-22 11:30"),
                EndTime = DateTime.Parse("02-02-22 12:00"),
                Symptom = "Red Eyes",
                Status = Models.Enums.Status.Completed,
                Visit = Models.Enums.Visit.WalkIn
            });

            appointments.Add(new Appointment()
            {
                ID = Guid.Parse("861c579e-bb80-4dea-b8f2-4b189cb6a362"),
                PatientID = Guid.Parse("8664a4bd-0ec6-4aaa-83e6-7d2bd0315b5a"),
                StartTime = DateTime.Parse("12-02-22 11:30"),
                EndTime = DateTime.Parse("02-02-22 12:00"),
                Symptom = "Headache",
                Status = Models.Enums.Status.Cancelled,
                Visit = Models.Enums.Visit.Appointment

            });

            appointments.Add(new Appointment()
            {
                ID = Guid.Parse("2222ed0f-aaea-45f3-8a72-f0ee3ed23a22"),
                PatientID = Guid.Parse("8664a4bd-0ec6-4aaa-83e6-7d2bd0315b5a"),
                StartTime = DateTime.Parse("12-02-22 11:30"),
                EndTime = DateTime.Parse("02-02-22 12:00"),
                Symptom = "Swelling",
                Status = Models.Enums.Status.NoShow
            });






            consultationRecords.Add(new ConsultationRecord()
            {
                PatientID = Guid.Parse("8664a4bd-0ec6-4aaa-83e6-7d2bd0315b5a"),
                AppointmentID = Guid.Parse("20f20659-d4e3-466e-b2df-e6a6b1f62fab"),
                ID = Guid.Parse("73ec06ac-56aa-453a-a29d-447691d51cd9"),

            });

            consultationRecords.Add(new ConsultationRecord()
            {
                PatientID = Guid.Parse("8664a4bd-0ec6-4aaa-83e6-7d2bd0315b5a"),
                AppointmentID = Guid.Parse("c7d431a6-579b-4841-8629-2bbcb79a5e15"),
                ID = Guid.Parse("0c096359-c9ef-4f37-9c37-47b7bf247746"),
              
            });

            findings.Add(new Finding()
            {
                ConsultationRecordID = Guid.Parse("73ec06ac-56aa-453a-a29d-447691d51cd9"),
                Description = "findings test 1",
                ID = Guid.NewGuid(),
                Tags = "testtable123"
            });

            prescriptions.Add(new Prescription()
            {
                ConsultationRecordID = Guid.Parse("73ec06ac-56aa-453a-a29d-447691d51cd9"),
                Description = "prescriptions test 2",
                ID = Guid.NewGuid(),
                Tags = "tabletest123"
            });

            findings.Add(new Finding()
            {
                ConsultationRecordID = Guid.Parse("0c096359-c9ef-4f37-9c37-47b7bf247746"),
                Description = "sore eyes",
                ID = Guid.NewGuid(),
                Tags = "123"
            });

            prescriptions.Add(new Prescription()
            {
                ConsultationRecordID = Guid.Parse("0c096359-c9ef-4f37-9c37-47b7bf247746"),
                Description = "biogesic",
                ID = Guid.NewGuid(),
                Tags = "123"
            });
            users.Add(new User()
            {
                ID = Guid.Parse("7e5e4f74-9902-43da-9974-4b2a08814398"),
                PatientID = Guid.Parse("8664a4bd-0ec6-4aaa-83e6-7d2bd0315b5a"),
                Email = "renieldavid@yahoo.com",
                FirstName = "Reniel",
                LastName = "Mallari",
                MiddleName = "David",
                BirthDate = DateTime.Parse("23/01/2001"),
                Gender = Models.Enums.Gender.Male,
                RoleID = Guid.Parse("2afa881f-e519-4e67-a841-e4a2630e8a2a"),
                Address = "Dinalupihan, Orani, Bataan"
            });
            //adminacc
            users.Add(new User()
            {
                ID = Guid.Parse("1bd5f519-b891-4491-9a7c-a86cd0c2a15e"),
                Email = "admin@yahoo.com",
                FirstName = "admin",
                LastName = "admin",
                MiddleName = "admin",
                BirthDate = DateTime.Parse("21/02/2002"),

                Gender = Models.Enums.Gender.Female,
                RoleID = Guid.Parse("54f00f70-72b8-4d34-a953-83321ff6b101"),
                Address = "Dinalupihan, Orani , Bataan"

            });
            userLogins.AddRange(new List<UserLogin>()
            {
                new UserLogin()
                {
                    ID = Guid.NewGuid(),
                    UserID =Guid.Parse("1bd5f519-b891-4491-9a7c-a86cd0c2a15e"),
                    Type = "General",
                    Key = "Password",
                    Value = BCrypt.Net.BCrypt.EnhancedHashPassword("admin")
                },
                new UserLogin()
                {
                    ID = Guid.NewGuid(),
                    UserID =Guid.Parse("1bd5f519-b891-4491-9a7c-a86cd0c2a15e"),
                    Type = "General",
                    Key = "IsActive",
                    Value = "true"
                },
                new UserLogin()
                {
                    ID = Guid.NewGuid(),
                    UserID =Guid.Parse("1bd5f519-b891-4491-9a7c-a86cd0c2a15e"),
                    Type = "General",
                    Key = "LoginRetries",
                    Value = "0"
                }
            });
            userRoles.Add(new UserRole()
            {
                Id = Guid.NewGuid(),
                UserID = Guid.Parse("1bd5f519-b891-4491-9a7c-a86cd0c2a15e"),
                RoleID = Guid.Parse("54f00f70-72b8-4d34-a953-83321ff6b101"),
            });


            //

            users.Add(new User()
            {
                ID = Guid.Parse("00acfb7f-6c90-459a-b53f-bf73ddac85b4"),
                Email = "Janedavid@yahoo.com",
                FirstName = "Jane",
                LastName = "David",
                MiddleName = "Adan",
                BirthDate = DateTime.Parse("21/02/2002"),

                Gender = Models.Enums.Gender.Female,
                RoleID = Guid.Parse("54f00f70-72b8-4d34-a953-83321ff6b101"),
                Address = "Dinalupihan, Orani , Bataan"

            });
            userLogins.AddRange(new List<UserLogin>()
            {
                new UserLogin()
                {
                    ID = Guid.NewGuid(),
                    UserID =Guid.Parse("00acfb7f-6c90-459a-b53f-bf73ddac85b4"),
                    Type = "General",
                    Key = "Password",
                    Value = BCrypt.Net.BCrypt.EnhancedHashPassword("capstone")
                },
                new UserLogin()
                {
                    ID = Guid.NewGuid(),
                    UserID =Guid.Parse("00acfb7f-6c90-459a-b53f-bf73ddac85b4"),
                    Type = "General",
                    Key = "IsActive",
                    Value = "true"
                },
                new UserLogin()
                {
                    ID = Guid.NewGuid(),
                    UserID =Guid.Parse("00acfb7f-6c90-459a-b53f-bf73ddac85b4"),
                    Type = "General",
                    Key = "LoginRetries",
                    Value = "0"
                }
            });
            userRoles.Add(new UserRole()
            {
                Id = Guid.NewGuid(),
                UserID = Guid.Parse("00acfb7f-6c90-459a-b53f-bf73ddac85b4"),
                RoleID = Guid.Parse("54f00f70-72b8-4d34-a953-83321ff6b101"),
            });
            //role
            roles.Add(new Role()
            {
                ID = Guid.Parse("2afa881f-e519-4e67-a841-e4a2630e8a2a"),
                Name = "patient",
                Abbreviation = "Pt",
                Description = "One who receives medical treatment"
            });

            roles.Add(new Role()
            {
                ID = Guid.Parse("54f00f70-72b8-4d34-a953-83321ff6b101"),
                Name = "admin",
                Abbreviation = "Adm",
                Description = "One who manages the system"
            });
            //role

            userLogins.AddRange(new List<UserLogin>()
            {
                new UserLogin()
                {
                    ID = Guid.NewGuid(),
                    UserID =Guid.Parse("7e5e4f74-9902-43da-9974-4b2a08814398"),
                    Type = "General",
                    Key = "Password",
                    Value = BCrypt.Net.BCrypt.EnhancedHashPassword("capstone")
                },
                new UserLogin()
                {
                    ID = Guid.NewGuid(),
                    UserID =Guid.Parse("7e5e4f74-9902-43da-9974-4b2a08814398"),
                    Type = "General",
                    Key = "IsActive",
                    Value = "true"
                },
                new UserLogin()
                {
                    ID = Guid.NewGuid(),
                    UserID =Guid.Parse("7e5e4f74-9902-43da-9974-4b2a08814398"),
                    Type = "General",
                    Key = "LoginRetries",
                    Value = "0"
                }
            });
            userRoles.Add(new UserRole()
            {
                Id = Guid.NewGuid(),
                UserID = Guid.Parse("7e5e4f74-9902-43da-9974-4b2a08814398"),
                RoleID = Guid.Parse("2afa881f-e519-4e67-a841-e4a2630e8a2a"),
            });

          


            modelBuilder.Entity<ConsultationRecord>().HasData(consultationRecords);
            modelBuilder.Entity<Finding>().HasData(findings);
            modelBuilder.Entity<Patient>().HasData(patients);
            modelBuilder.Entity<Prescription>().HasData(prescriptions);
            modelBuilder.Entity<Appointment>().HasData(appointments);
            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<UserLogin>().HasData(userLogins);
            modelBuilder.Entity<Role>().HasData(roles);
            modelBuilder.Entity<UserRole>().HasData(userRoles);
          
        }

    }
}
