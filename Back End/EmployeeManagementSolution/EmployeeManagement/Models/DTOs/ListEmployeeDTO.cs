namespace EmployeeManagement.Models.DTOs
{
    public class ListEmployeeDTO
    {
        public int EmployeeId { get; set; }
        public string? Name { get; set; }
        public string? Status { get; set; }
        public int Age { get; set; }
        public string? Gender { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
    }
}
