using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace EnterpriseMobileApp_ASS1.Models
{
    public class Student 
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public  string  Gender { get; set; }
        
        
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^\d+@stud\.fci-cu\.edu\.eg$", ErrorMessage = "Email format is invalid. It must be ID@stud.fci-cu.edu.eg")]
        public string Email { get; set; }

        [Required]
        public string StudentId { get; set; }

        [Range(1,4,ErrorMessage="level must be btween 1 and 4.")]
        public int Level { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }
        public string Image { get; set; }

        public virtual ICollection<Favourite_Store> favourites { get; set; }


    }
}
