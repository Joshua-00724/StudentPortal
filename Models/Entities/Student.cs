using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Models.Entities
{
    public class Student
    {
        [Key]
        public int SID { get; set; }
        public string FName { get; set; }

        public string LName { get; set; }

        public string Email { get; set; }

        public char Gender {  get; set; }
        public string Phone { get; set; }
        public string Address {  get; set; }

        public DateOnly BirthDate { get; set; }

        public ICollection<Grade> Grades { get; set; }


    }
}
