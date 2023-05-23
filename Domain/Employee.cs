using System.ComponentModel.DataAnnotations;

namespace EmployeeRecordMvcAPI.Domain
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [MaxLength(30)]
        public string Email { get; set; } = string.Empty;
        [Required]
        [MaxLength(30)]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
