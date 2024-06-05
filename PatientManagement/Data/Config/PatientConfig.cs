using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PatientManagement.Data.Config
{
    public class PatientConfig : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("Patients");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(n => n.Id).IsRequired();
            builder.Property(n => n.PatientName).HasMaxLength(250);
            builder.Property(n => n.Address).IsRequired(false).HasMaxLength(500);
            builder.Property(n => n.Email).IsRequired().HasMaxLength(250);
            builder.Property(n => n.DateOfBirth).IsRequired();
            builder.Property(n => n.Gender).IsRequired();
            builder.Property(n => n.PhoneNumber).IsRequired();
            builder.HasData(new List<Patient>()
            {
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
            });
        }
    }
}
