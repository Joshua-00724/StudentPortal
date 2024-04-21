using Microsoft.AspNetCore.Mvc;
using StudentPortal.Data;
using StudentPortal.Models;
using StudentPortal.Models.Entities;

namespace StudentPortal.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public CoursesController(ApplicationDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Addcourse()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Addcourse(AddCourseViewModel viewModel)
        {
            var course = new Course
            {
                CourseID = viewModel.CourseID,
                CourseName = viewModel.CourseName,
            };
            await dbContext.Courses.AddAsync(course);
            await dbContext.SaveChangesAsync();

            return View();
        }


    }
}
