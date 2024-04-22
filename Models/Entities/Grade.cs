using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentPortal.Models.Entities
{
    public class Grade
    {
        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GID { get; set; }
       
        public int StudentID {  get; set; }
        public int CourseID { get; set; }
        public int Score {  get; set; }

        public Student Student { get; set; }
        public Course Course { get; set; }

    }
}
