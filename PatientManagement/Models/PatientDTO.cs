using System.ComponentModel.DataAnnotations;

namespace PatientManagement.Models
{
    public class PatientDTO
    {
        public int Id { get; set; }
        [Required]
        public string PatientName { get; set; }
        public string Email { get; set; }
        
        public string Address { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
    }
}
