using System.ComponentModel.DataAnnotations;

namespace CPW219_CRUD_Troubleshooting.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Only alphabetic characters are allowed.")]
        public string Name { get; set; } = null!;

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }
}
