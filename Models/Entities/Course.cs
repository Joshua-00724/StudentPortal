using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Models.Entities
{
    public class Course
    {
        [Key]
        public int CourseID {  get; set; }
        public string CourseName {  get; set; }
        public ICollection<Grade> Grades { get; set; }
    }
}
