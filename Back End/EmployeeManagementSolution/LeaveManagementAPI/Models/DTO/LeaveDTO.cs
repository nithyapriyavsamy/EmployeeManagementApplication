using System.ComponentModel.DataAnnotations;

namespace LeaveManagementAPI.Models.DTO
{
    public class LeaveDTO
    {
        public int Id { get; set; }
        public int Emp_Id { get; set; }
        public int Manager_Id { get; set; }
        public string? LeaveStatus { get; set; }
    }
}
