using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public int? ManagerId { get; set; }
        public string? Role { get; set; }
        public string? EmployeeState { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordKey { get; set; }
    }
}
