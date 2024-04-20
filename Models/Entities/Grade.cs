using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Models.Entities
{
    public class Grade
    {
        [Key]
        public int GID { get; set; }
        public int SID {  get; set; }
        public int CourseID { get; set; }
        public int Score {  get; set; }

        public Student Student { get; set; }
        public Course Course { get; set; }

    }
}
