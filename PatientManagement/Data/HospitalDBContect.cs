using Microsoft.EntityFrameworkCore;
using PatientManagement.Data.Config;

namespace PatientManagement.Data
{
    //this class will act a database inside Entity framework
    public class HospitalDBContect : DbContext
    {
        public HospitalDBContect(DbContextOptions<HospitalDBContect> options):base(options)
        {

        }
        public DbSet<Patient> patients {  get; set; }

        // to feed the mock data we need to override the OnModelCreating method
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // modelBuilder.Entity<Patient>().HasData(new List<Patient>()
          /*  {
                new Patient{ Id =1 ,
                    PatientName = "ashish",
                    Address = "burhanpur",
                    DateOfBirth= new DateTime(2022,12,12),
                    Email = "ashish@gmail.com",
                    Gender = "Male",
                    PhoneNumber = "8319577873459"
                },
                new Patient{ 
                    Id =2 ,
                    PatientName = "anshul",
                    Address = "indoer",
                    DateOfBirth= new DateTime(2022,12,12),
                    Email = "anshul@gmail.com",
                    Gender = "female",
                    PhoneNumber = "8319232873459"
                }
            });*/
            modelBuilder.ApplyConfiguration(new PatientConfig());



            
        }
    }
}
