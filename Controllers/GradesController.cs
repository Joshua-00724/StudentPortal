using Microsoft.AspNetCore.Mvc;
using StudentPortal.Data;
using StudentPortal.Models;
using StudentPortal.Models.Entities;

namespace StudentPortal.Controllers
{
    public class GradesController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public GradesController(ApplicationDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Addgrade()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Addgrade(AddGradeViewModel viewModel)
        {
            var grades = new Grade
            {
                GID = viewModel.GID,
                SID = viewModel.SID,
                CourseID = viewModel.CourseID,
                Score = viewModel.Score,    
            };
            await dbContext.Grades.AddAsync(grades);
            await dbContext.SaveChangesAsync();

            return View();
        }


    }
}
