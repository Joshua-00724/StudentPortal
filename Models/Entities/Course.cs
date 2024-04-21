using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentPortal.Models.Entities
{
    public class Course
    {
        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID { get; set; }
        
        public string CourseName {  get; set; }
        public ICollection<Grade> Grades { get; set; }
    }
}
