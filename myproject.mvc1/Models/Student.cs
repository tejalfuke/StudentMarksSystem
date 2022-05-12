using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentMarkAutomation.Models
{
    public class Student
    {
        [Required, DisplayName("First Name")]
        public string FirstName { get; set; }
        
        [Required, DisplayName("Last Name")]
        public string LastName { get; set; }
        
        [Required, DisplayName("Roll Number")]
        [Key]
        public string RollNo { get; set; }
        
        [Required, DisplayName("Email Address")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public int Maths { get; set; }
        
        [Required]
        public int Physics { get; set; }
        
        [Required]
        public int Chemistry { get; set; }

        [DisplayName("Average Marks")]
        public float Average { get => (Maths + Physics + Chemistry) / 3;}
    }
}
