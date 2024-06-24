namespace EmployeeManagement.Models.DTOs
{
    public class UpdateDTO
    {
        public int EmployeeId { get; set; }
        public string? UpdatedLicenceNo { get; set; }
        public string? UpdatedPhoneNo { get; set; }
        public string? UpdatedPassportNo { get; set; }
        public string? UpdatedAddress { get; set; }
    }
}
