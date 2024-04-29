using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentPortal.Models.Entities
{
    public class Course
    {
        [Key]

        public int CourseID { get; set; }

        [Required(ErrorMessage = "Enter the Course Name")]
        [StringLength(50)]
        public string CourseName {  get; set; }

        public ICollection<Grade> Grades { get; set; }
    }
}
