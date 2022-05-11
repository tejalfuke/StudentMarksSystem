using System.ComponentModel.DataAnnotations;

namespace StudentMarkAutomation.Models
{
    public class Student
    {
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
        
        [Required]
        [Key]
        public int RollNo { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public int Math { get; set; }
        
        [Required]
        public int Physics { get; set; }
        
        [Required]
        public int Chemistry { get; set; }
        public float Average { get => (Math + Physics + Chemistry) / 3; }
    }
}
