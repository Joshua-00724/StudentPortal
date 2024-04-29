using StudentPortal.Controllers;
using StudentPortal.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentPortal.Models.Entities
{
    public class Grade
    {
        [Key]
        public int GradeID { get; set; }
       
        public int StudentID {  get; set; }

        public int CourseID { get; set; }  

        [Range(0.00,100.00, ErrorMessage = "The score should lie between 0.00 and 100.00")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Score {  get; set; }

        public Course Course { get; set; }
        public Student Student { get; set; }

       // public List<Course> Courselistt { get; set; }

       


    }
}
