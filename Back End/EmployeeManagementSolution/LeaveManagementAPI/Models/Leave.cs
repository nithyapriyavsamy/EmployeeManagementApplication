using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagementAPI.Models
{
    public class Leave
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Employee Id cannot be null")]
        public int Emp_Id { get; set; }

        [Required(ErrorMessage = "Manager Id cannot be null")]
        public int Manager_Id { get; set;}

        [StringLength(50)]
        public string? Title { get; set;}

        [Range(1, int.MaxValue, ErrorMessage = "Duration must be a positive value.")]
        [DefaultValue(0)]
        public int Duration { get; set;}
        public DateTime FromDate { get; set; }
        public DateTime ToDate
        {
            get
            {
                return FromDate.AddDays(Duration);
            }
            set
            {

            }
        }

        [StringLength(20)]
        public string LeaveStatus { get; set; }
    }
}
