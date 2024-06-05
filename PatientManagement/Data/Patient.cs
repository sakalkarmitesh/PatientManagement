﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientManagement.Data
{
    //this is our Entity class
    public class Patient
    {
        
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)] // we defined that primary key column is a autogenerated column (identity column)
        public int Id { get; set; } //primary key column
        public string PatientName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
    }
}
