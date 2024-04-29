using Microsoft.AspNetCore.Mvc.Rendering;
using StudentPortal.Models;
using StudentPortal.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//AddCourseViewModel.Instance.CourseList.Add();

namespace StudentPortal.Models
{
    public class AddGradeViewModel
    {
       public int GradeID { get; set; }   
        public int StudentID { get; set; }

        public int CourseID { get; set; }

        public decimal Score { get; set; }

        public List<Course> Courselistt { get; set; }

        public AddGradeViewModel()
        {
            this.Courselistt = new List<Course>();
        }
    }
}
