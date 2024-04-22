using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            ModelState.Clear();
            var grades = new Grade
            {
                GID = viewModel.GID,
                StudentID = viewModel.StudentID,
                CourseID = viewModel.CourseID,
                Score = viewModel.Score,    
            };
            await dbContext.Grades.AddAsync(grades);
            await dbContext.SaveChangesAsync();
            TempData["AlertMessage"] = "Student has been graded";

            return View();
        }

        [HttpGet]

        public async Task<IActionResult> DisplayList()
        {
            var grades = await dbContext.Grades.ToListAsync();
            return View(grades);
        }

        [HttpGet]

        public async Task<IActionResult> EditList(int gid)
        {
            var grades = await dbContext.Grades.FindAsync(gid);
            return View(grades);
            
        }

        [HttpPost]
        public async Task<IActionResult> EditList(Grade viewModel)
        {
            var grades = await dbContext.Grades.FindAsync(viewModel.GID);

            if (grades is not  null) 
            {
                grades.StudentID = viewModel.StudentID;
                grades.CourseID = viewModel.CourseID;
                grades.Score = viewModel.Score;

                await dbContext.SaveChangesAsync();

            }
            
            TempData["AlertMessage"] = "Record has been updated";
            return RedirectToAction("DisplayList", "Grades");
        }

        [HttpPost]

        public async Task<IActionResult> Delete(Grade viewModel)
        {
            var student = await dbContext.Grades.AsNoTracking().FirstOrDefaultAsync(a => a.GID == viewModel.GID);

            if (student is not null)
            {
                dbContext.Grades.Remove(viewModel);
                await dbContext.SaveChangesAsync();

            }
            TempData["AlertMessage"] = "Record has been deleted";
            return RedirectToAction("DisplayList", "Grades");
        }


    }
}
