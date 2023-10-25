using ADLTracker.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ADLTracker.Data;

public class ADLTrackerDbContext : IdentityDbContext<IdentityUser>
{
    private readonly IConfiguration _configuration;
    public DbSet<Provider> Providers { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<PatientProfile> PatientProfiles { get; set; }
    public DbSet<PatientProvider> PatientProviders { get; set; }
    public DbSet<Output> Outputs { get; set; }
    public DbSet<Intake> Intakes { get; set; }
    public DbSet<Gender> Genders { get; set; }
    public DbSet<CodeStatus> CodeStatuses { get; set; }
    public DbSet<ContactPrecaution> ContactPrecautions { get; set; }
    public DbSet<AssistType> AssistTypes { get; set; }

    public ADLTrackerDbContext(DbContextOptions<ADLTrackerDbContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            Name = "Nurse",
            NormalizedName = "nurse"
        });

        modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser[]
        {
            new IdentityUser
        {
            Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            Email = "good@nurse.comx",
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["NursePassword"])
        },
            new IdentityUser
        {
            Id = "f575a7b0-384c-4c94-abe1-945ec9d041a0",
            Email = "good@tech.comx",
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["NursePassword"])
        },
            new IdentityUser
        {
            Id = "ef18a47a-3a66-4ced-a1a2-75c6acf0b060",
            Email = "mid@tech.comx",
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["NursePassword"])
        },
            new IdentityUser
        {
            Id = "555401a5-2862-4e4c-89db-b462bc2d2e1c",
            Email = "bad@tech.comx",
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["NursePassword"])
        },
        });

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f"
        });

        modelBuilder.Entity<Provider>().HasData(new Provider[]
        {
            new Provider
            {
                Id = 1,
                IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                FirstName = "Bryan",
                LastName = "Sadman",
            },
            new Provider
            {
                Id = 2,
                IdentityUserId = "f575a7b0-384c-4c94-abe1-945ec9d041a0",
                FirstName = "James",
                LastName = "Luck",
            },
            new Provider
            {
                Id = 3,
                IdentityUserId = "ef18a47a-3a66-4ced-a1a2-75c6acf0b060",
                FirstName = "Tiffany",
                LastName = "Eversnow",
            },
            new Provider
            {
                Id = 4,
                IdentityUserId = "555401a5-2862-4e4c-89db-b462bc2d2e1c",
                FirstName = "Holly",
                LastName = "Beaver",
            },
        });

        modelBuilder.Entity<Patient>().HasData(new Patient[]
        {
            new Patient
            {
            Id = 1,
            FirstName = "Bryanty",
            LastName = "Luckett",
            DOB = new DateTime(1977,09,19),
            GenderId = 1
            },
            new Patient
            {
            Id = 2,
            FirstName = "Alanson",
            LastName = "Surpliss",
            DOB = new DateTime(1986,12,02),
            GenderId = 2
            },
            new Patient
            {
            Id = 3,
            FirstName = "Marquita",
            LastName = "Gabbotts",
            DOB = new DateTime(1961,02,10),
            GenderId = 2
            },
            new Patient
            {
            Id = 4,
            FirstName = "Ashlie",
            LastName = "Bertouloume",
            DOB = new DateTime(1959,09,13),
            GenderId = 2
            },
            new Patient
            {
            Id = 5,
            FirstName = "Matias",
            LastName = "Jannings",
            DOB = new DateTime(1999,05,01),
            GenderId = 1
            },
            new Patient
            {
            Id = 6,
            FirstName = "Harley",
            LastName = "Dreger",
            DOB = new DateTime(1949,07,11),
            GenderId = 1
            },
            new Patient
            {
            Id = 7,
            FirstName = "Marlin",
            LastName = "Briddock",
            DOB = new DateTime(1986,05,17),
            GenderId = 1
            },
            new Patient
            {
            Id = 8,
            FirstName = "Sheffy",
            LastName = "McVeighty",
            DOB = new DateTime(1982,08,07),
            GenderId = 2
            },
            new Patient
            {
            Id = 9,
            FirstName = "Nata",
            LastName = "Attle",
            DOB = new DateTime(1947,10,13),
            GenderId = 2
            },
            new Patient
            {
            Id = 10,
            FirstName = "Hodge",
            LastName = "Pilkinton",
            DOB = new DateTime(1970,01,30),
            GenderId = 1
            },
            new Patient
            {
            Id = 11,
            FirstName = "Terrance",
            LastName = "Barthram",
            DOB = new DateTime(1972,07,12),
            GenderId = 1
            },
            new Patient
            {
            Id = 12,
            FirstName = "Monti",
            LastName = "Rominov",
            DOB = new DateTime(1942,06,03),
            GenderId = 2
            },
            new Patient
            {
            Id = 13,
            FirstName = "Gerik",
            LastName = "Street",
            DOB = new DateTime(1950,06,16),
            GenderId = 1
            },
            new Patient
            {
            Id = 14,
            FirstName = "Cassaundra",
            LastName = "McKmurrie",
            DOB = new DateTime(1952,10,11),
            GenderId = 2
            },
            new Patient
            {
            Id = 15,
            FirstName = "Panther",
            LastName = "Moons",
            DOB = new DateTime(1945,09,26),
            GenderId = 2
            }
        });

        modelBuilder.Entity<AssistType>().HasData(new AssistType[]
        {
            new AssistType
            {
                Id = 1,
                Type = "Independent",
                Simple = "IND"
            },
            new AssistType
            {
                Id = 2,
                Type = "Stand-by Assist",
                Simple = "SBA"
            },
            new AssistType
            {
                Id = 3,
                Type = "1 Assist",
                Simple = "x1"
            },
            new AssistType
            {
                Id = 4,
                Type = "Total Assist",
                Simple = "x2+"
            },
        });

        modelBuilder.Entity<Gender>().HasData(new Gender[]
        {
            new Gender
            {
                Id = 1,
                Type = "Male",
                Simple = "M",

            },
            new Gender
            {
                Id = 2,
                Type = "Female",
                Simple = "F",

            },
        });

        modelBuilder.Entity<CodeStatus>().HasData(new CodeStatus[]
        {
            new CodeStatus
            {
                Id = 1,
                Type = "Full Code",
                Description = "Full Code",

            },
            new CodeStatus
            {
                Id = 2,
                Type = "DNR",
                Description = "Do Not Resuscitate",

            },
        });

        modelBuilder.Entity<ContactPrecaution>().HasData(new ContactPrecaution[]
        {
            new ContactPrecaution
            {
                Id = 1,
                Type = "Standard",
            },
            new ContactPrecaution
            {
                Id = 2,
                Type = "Contact",
                Diagram = "https://www.brevis.com/image/lg/cpr7r2.jpg"
            },
            new ContactPrecaution
            {
                Id = 3,
                Type = "Contact+",
                Diagram = "https://brevis.com/images/cprmdro.jpg"
            },
            new ContactPrecaution
            {
                Id = 4,
                Type = "Droplet",
                Diagram = "https://brevis.com/images/dpr14.jpg"
            },
            new ContactPrecaution
            {
                Id = 5,
                Type = "Airborne",
                Diagram = "https://www.brevis.com/image/lg/apr20.jpg"
            },
        });

        modelBuilder.Entity<PatientProfile>().HasData(new PatientProfile[]
        {
            new PatientProfile
            {
            Id = 1,
            PatientId = 1,
            AssistTypeId = 2,
            ContactPrecautionId = 1,
            CodeStatusId = 1,
            Diagnosis = "Diabetes Mellitus",
            RoomNumber = 1000,
            Height = 77,
            Weight = 44.5M,
            AdmissionDate = new DateTime( 2023,10,05,10,49,43),
            LastBath = new DateTime( 2023,10,16,08,51,55),
            LastBM = new DateTime( 2023,10,16,07,19,10),
            Telemetry = false,
            Discharged = false
            },
            new PatientProfile
            {
            Id = 2,
            PatientId = 2,
            AssistTypeId = 3,
            ContactPrecautionId = 1,
            CodeStatusId = 1,
            Diagnosis = "Hypertensive Crisis",
            RoomNumber = 1001,
            Height = 65,
            Weight = 77.3M,
            AdmissionDate = new DateTime( 2023,10,12,06,43,24),
            LastBath = new DateTime( 2023,10,16,07,06,02),
            LastBM = new DateTime( 2023,10,15,04,39,32),
            Telemetry = false,
            Discharged = false
            },
            new PatientProfile
            {
            Id = 3,
            PatientId = 3,
            AssistTypeId = 3,
            ContactPrecautionId = 1,
            CodeStatusId = 2,
            Diagnosis = "SOB Asthma",
            RoomNumber = 1002,
            Height = 61,
            Weight = 78.0M,
            AdmissionDate = new DateTime( 2023,10,07,22,58,47),
            LastBath = new DateTime( 2023,10,16,09,01,01),
            LastBM = new DateTime( 2023,10,16,22,38,27),
            Telemetry = true,
            TelemetryNumber = 345,
            Discharged = true
            },
            new PatientProfile
            {
            Id = 4,
            PatientId = 4,
            AssistTypeId = 4,
            ContactPrecautionId = 1,
            CodeStatusId = 2,
            Diagnosis = "Headache/ L Side Weakness",
            RoomNumber = 1004,
            Height = 72,
            Weight = 58.8M,
            AdmissionDate = new DateTime( 2023,10,12,19,10,05),
            LastBath = new DateTime( 2023,10,16,17,00,37),
            LastBM = new DateTime( 2023,10,15,05,27,11),
            Telemetry = true,
            TelemetryNumber = 123,
            Discharged = false
            },
            new PatientProfile
            {
            Id = 5,
            PatientId = 5,
            AssistTypeId = 4,
            ContactPrecautionId = 1,
            CodeStatusId = 1,
            Diagnosis = "Fatigue",
            RoomNumber = 1005,
            Height = 50,
            Weight = 46.1M,
            AdmissionDate = new DateTime( 2023,10,08,23,06,18),
            LastBath = new DateTime( 2023,10,16,15,28,47),
            LastBM = new DateTime( 2023,10,16,18,28,00),
            Telemetry = false,
            Discharged = true
            },
            new PatientProfile
            {
            Id = 6,
            PatientId = 6,
            AssistTypeId = 2,
            ContactPrecautionId = 3,
            CodeStatusId = 1,
            Diagnosis = "Clostridium difficile",
            RoomNumber = 1006,
            Height = 73,
            Weight = 75.2M,
            AdmissionDate = new DateTime( 2023,10,03,11,53,50),
            LastBath = new DateTime( 2023,10,16,12,51,49),
            LastBM = new DateTime( 2023,10,15,16,15,03),
            Telemetry = true,
            TelemetryNumber = 108,
            Discharged = false
            },
            new PatientProfile
            {
            Id = 7,
            PatientId = 7,
            AssistTypeId = 3,
            ContactPrecautionId = 1,
            CodeStatusId = 1,
            Diagnosis = "Fatigue",
            RoomNumber = 1007,
            Height = 71,
            Weight = 46.7M,
            AdmissionDate = new DateTime( 2023,10,06,11,59,57),
            LastBath = new DateTime( 2023,10,16,16,39,29),
            LastBM = new DateTime( 2023,10,16,11,33,58),
            Telemetry = true,
            TelemetryNumber = 499,
            Discharged = false
            },
            new PatientProfile
            {
            Id = 8,
            PatientId = 8,
            AssistTypeId = 2,
            ContactPrecautionId = 1,
            CodeStatusId = 1,
            Diagnosis = "CHF Exacerbation",
            RoomNumber = 1008,
            Height = 68,
            Weight = 65.3M,
            AdmissionDate = new DateTime( 2023,10,09,05,04,46),
            LastBath = new DateTime( 2023,10,16,01,05,32),
            LastBM = new DateTime( 2023,10,15,14,36,13),
            Telemetry = false,
            Discharged = false
            },
            new PatientProfile
            {
            Id = 9,
            PatientId = 9,
            AssistTypeId = 3,
            ContactPrecautionId = 1,
            CodeStatusId = 1,
            Diagnosis = "SOB Asthma",
            RoomNumber = 1009,
            Height = 59,
            Weight = 75.0M,
            AdmissionDate = new DateTime( 2023,10,15,12,57,27),
            LastBath = new DateTime( 2023,10,16,22,57,40),
            LastBM = new DateTime( 2023,10,15,13,24,56),
            Telemetry = true,
            TelemetryNumber = 119,
            Discharged = false
            },
            new PatientProfile
            {
            Id = 10,
            PatientId = 10,
            AssistTypeId = 2,
            ContactPrecautionId = 2,
            CodeStatusId = 2,
            Diagnosis = "LLE Cellulitis",
            RoomNumber = 1010,
            Height = 68,
            Weight = 89.6M,
            AdmissionDate = new DateTime( 2023,10,10,04,24,27),
            LastBath = new DateTime( 2023,10,16,20,40,52),
            LastBM = new DateTime( 2023,10,16,20,19,13),
            Telemetry = false,
            Discharged = false
            },
            new PatientProfile
            {
            Id = 11,
            PatientId = 11,
            AssistTypeId = 2,
            ContactPrecautionId = 1,
            CodeStatusId = 2,
            Diagnosis = "Altered Mental Status",
            RoomNumber = 1011,
            Height = 52,
            Weight = 43.6M,
            AdmissionDate = new DateTime( 2023,10,07,22,19,45),
            LastBath = new DateTime( 2023,10,16,03,34,41),
            LastBM = new DateTime( 2023,10,15,15,43,09),
            Telemetry = false,
            Discharged = false
            },
            new PatientProfile
            {
            Id = 12,
            PatientId = 12,
            AssistTypeId = 1,
            ContactPrecautionId = 1,
            CodeStatusId = 1,
            Diagnosis = "Chrohn's Exacerbation",
            RoomNumber = 1013,
            Height = 65,
            Weight = 70.4M,
            AdmissionDate = new DateTime( 2023,10,06,07,16,38),
            LastBath = new DateTime( 2023,10,16,17,41,03),
            LastBM = new DateTime( 2023,10,16,20,57,58),
            Telemetry = true,
            TelemetryNumber = 501,
            Discharged = false
            },
            new PatientProfile
            {
            Id = 13,
            PatientId = 13,
            AssistTypeId = 2,
            ContactPrecautionId = 1,
            CodeStatusId = 1,
            Diagnosis = "Fatigue",
            RoomNumber = 1014,
            Height = 71,
            Weight = 69.7M,
            AdmissionDate = new DateTime( 2023,10,08,03,38,11),
            LastBath = new DateTime( 2023,10,16,05,46,25),
            LastBM = new DateTime( 2023,10,16,08,35,04),
            Telemetry = false,
            Discharged = true
            },
            new PatientProfile
            {
            Id = 14,
            PatientId = 14,
            AssistTypeId = 2,
            ContactPrecautionId = 4,
            CodeStatusId = 1,
            Diagnosis = "Influenza",
            RoomNumber = 1015,
            Height = 48,
            Weight = 43.2M,
            AdmissionDate = new DateTime( 2023,10,05,00,49,28),
            LastBath = new DateTime( 2023,10,16,09,32,54),
            LastBM = new DateTime( 2023,10,15,14,57,34),
            Telemetry = false,
            Discharged = false
            },
            new PatientProfile
            {
            Id = 15,
            PatientId = 15,
            AssistTypeId = 3,
            ContactPrecautionId = 5,
            CodeStatusId = 2,
            Diagnosis = "Covid",
            RoomNumber = 1016,
            Height = 45,
            Weight = 88.8M,
            AdmissionDate = new DateTime( 2023,10,13,09,12,23),
            LastBath = new DateTime( 2023,10,16,01,31,37),
            LastBM = new DateTime( 2023,10,15,21,03,25),
            Telemetry = true,
            TelemetryNumber = 333,
            Discharged = false
            }
        });

        modelBuilder.Entity<Intake>().HasData(new Intake[]
        {
            new Intake
           {
              Id = 1,
              PatientProfileId = 1,
              ProviderId = 1,
              IntakeAmount = 240,
              TimeRecorded = new DateTime(2023,10,16,05,08,49)
            },
            new Intake
            {
              Id = 2,
              PatientProfileId = 1,
              ProviderId = 2,
              IntakeAmount = 500,
              TimeRecorded = new DateTime(2023,10,15,03,25,37)
            },
            new Intake
            {
              Id = 3,
              PatientProfileId = 3,
              ProviderId = 1,
              IntakeAmount = 350,
              TimeRecorded = new DateTime(2023,10,16,09,19,09)
            },
            new Intake
            {
              Id = 4,
              PatientProfileId = 4,
              ProviderId = 1,
              IntakeAmount = 125,
              TimeRecorded = new DateTime(2023,10,16,20,26,47)
            }
        });


        modelBuilder.Entity<Output>().HasData(new Output[]
        {
            new Output
           {
              Id = 1,
              PatientProfileId = 1,
              ProviderId = 1,
              OutputAmount = 50,
              TimeRecorded = new DateTime(2023,10,16,05,08,49)
            },
            new Output
            {
              Id = 2,
              PatientProfileId = 2,
              ProviderId = 2,
              OutputAmount = 64,
              TimeRecorded = new DateTime(2023,10,15,03,25,37)
            },
            new Output
            {
              Id = 3,
              PatientProfileId = 3,
              ProviderId = 3,
              OutputAmount = 51,
              TimeRecorded = new DateTime(2023,10,16,09,19,09)
            },
            new Output
            {
              Id = 4,
              PatientProfileId = 4,
              ProviderId = 2,
              OutputAmount = 64,
              TimeRecorded = new DateTime(2023,10,16,20,26,47)
            }
        });

        modelBuilder.Entity<PatientProvider>().HasData(new PatientProvider[]
        {
            new PatientProvider
            {
            Id = 1,
            PatientProfileId = 1,
            ProviderId = 2
            },
            new PatientProvider
            {
            Id = 2,
            PatientProfileId = 2,
            ProviderId = 4
            },
            new PatientProvider
            {
            Id = 3,
            PatientProfileId = 3,
            ProviderId = 2
            },
            new PatientProvider
            {
            Id = 4,
            PatientProfileId = 4,
            ProviderId = 4
            },
            new PatientProvider
            {
            Id = 5,
            PatientProfileId = 5,
            ProviderId = 3
            },
        });
    }
}