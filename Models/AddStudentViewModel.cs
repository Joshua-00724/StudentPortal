namespace StudentPortal.Models
{
    public class AddStudentViewModel
    {

        public int StudentID { get; set; }
        public string FName { get; set; }

        public string LName { get; set; }

        public string Email { get; set; }

        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public DateOnly BirthDate { get; set; }

    }
}
