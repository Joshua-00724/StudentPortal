using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace StudentPortal.Models.Entities
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }

        [Required(ErrorMessage = "First Name is Required")]
        [StringLength(25)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        [StringLength(25)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Enter Personal Email ID")]
        [StringLength(50)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Select your Gender")]
        [StringLength(10)]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Invalid phone number format")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Enter your Home Address")]
        [StringLength(50)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Enter your Date of Birth")]
        public DateOnly BirthDate { get; set; }

        public ICollection<Grade> Grades { get; set; }

       
    }
}
