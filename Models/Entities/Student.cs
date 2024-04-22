using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentPortal.Models.Entities
{
    public class Student
    {
        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StudentID { get; set; } 
        
        public string FName { get; set; }

        public string LName { get; set; }

        public string Email { get; set; }

        public string Gender {  get; set; }
        public string Phone { get; set; }
        public string Address {  get; set; }

        public DateOnly BirthDate { get; set; }

        public ICollection<Grade> Grades { get; set; }

       
    }
}
