using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        public Employee()
        {
            Name = string.Empty;
            Gender = "Unknown";
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public User? Users { get; set; }
        public string? Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public string? Gender { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? PassportNumber { get; set; }
        public string? LicenseNumber { get; set; }
    }
}
