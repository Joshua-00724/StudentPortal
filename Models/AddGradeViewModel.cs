using StudentPortal.Models.Entities;
namespace StudentPortal.Models
{
    public class AddGradeViewModel
    {
        public int GID { get; set; }

        public int SID { get; set; }
        public int CourseID { get; set; }
        public int Score { get; set; }

    }
}
