using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentMarkAutomation.Models
{
    public class Student
    {
        [Required,DisplayName("First Name")]
        public string FirstName { get; set; }
        
        [Required,DisplayName("Last Name")]
        public string LastName { get; set; }
        
        [Required, DisplayName("Roll No")]
        [Key]
        public string RollNo { get; set; }
        
        [Required, DisplayName("Email Id")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public int Math { get; set; }
        
        [Required]
        public int Physics { get; set; }
        
        [Required]
        public int Chemistry { get; set; }
        public float Average { get => (Math + Physics + Chemistry) / 3;}
    }
}
