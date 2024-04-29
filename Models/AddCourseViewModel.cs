using Microsoft.AspNetCore.Mvc.Rendering;
using StudentPortal.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Models
{
    public class AddCourseViewModel
    {  
        
        public int CourseID {  get; set; }   
        public string CourseName { get; set; }

       public List<SelectListItem> Courselistt { get; set; }


        /*        private static AddCourseViewModel _instance = new AddCourseViewModel();
                public static AddCourseViewModel Instance { get { return _instance; } }
                public List<Course> CourseList { get; set; } */

    }
}
