using System.ComponentModel.DataAnnotations;

namespace EmployeeRecordMvcAPI.Dtos
{
    public class EmployeeUpdateDto
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [MaxLength(20)]
        public string Email { get; set; } = string.Empty;
        [Required]
        [MaxLength(30)]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
