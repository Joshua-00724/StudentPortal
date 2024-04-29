using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Data;
using StudentPortal.Models;
using StudentPortal.Models.Entities;
using System.Reflection.Metadata.Ecma335;

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
            
          /*  AddCourseViewModel model = new AddCourseViewModel();
            model.Courselistt = new List<SelectListItem>();
            var courselist = dbContext.Courses.ToList();
            model.Courselistt.Add(new SelectListItem
            {
                Text = "Select The Course",
                Value = ""
            });
            foreach (var item in courselist)
            {
                model.Courselistt.Add(new SelectListItem
                {
                    Text = item.CourseName,
                    Value = Convert.ToString(item.CourseID)
                });
            }*/
           
            return View();
        }

       

        [HttpPost]
        public async Task<IActionResult> Addgrade(AddGradeViewModel viewModel)
        {
            ModelState.Clear();
         /* AddCourseViewModel model = new AddCourseViewModel();
            model.Courselistt = new List<SelectListItem>();
          var courselist = dbContext.Courses.ToList();
            model.Courselistt.Add(new SelectListItem{
                Text = "Select The Course",
                Value = ""
            });
            foreach(var item in courselist)
            {
                model.Courselistt.Add(new SelectListItem
                {
                    Text = item.CourseName,
                    Value = Convert.ToString(item.CourseID)
                });
            }*/
            //model.Courseslist.Add(new SelectListItem
         /*   ViewBag.Value = model.CourseID;
            ViewBag.Text = model.Courselistt.Where(x => x.Value == model.CourseID.ToString()).
            FirstOrDefault().Text;
*/
            var grades = new Grade
                {
                    GradeID = viewModel.GradeID,
                    StudentID = viewModel.StudentID,
                    CourseID = viewModel.CourseID,
            //CourseID = viewModel.CourseID,
            /*Course.ReferenceEquals(courselist) = dbContext.Courses.Select(c => new AddCourseViewModel
             {
                 CourseID = c.CourseID,
                 CourseName = c.CourseName,
             }).ToList(),
*/
           
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
            var grades = await dbContext.Grades.FindAsync(viewModel.GradeID);

            if (grades is not  null) 
            {
                grades.StudentID = viewModel.StudentID;
                
                grades.Score = viewModel.Score;

                await dbContext.SaveChangesAsync();

            }
            
            TempData["AlertMessage"] = "Record has been updated";
            return RedirectToAction("DisplayList", "Grades");
        }

        [HttpPost]

        public async Task<IActionResult> Delete(Grade viewModel)
        {
            var student = await dbContext.Grades.AsNoTracking().FirstOrDefaultAsync(a => a.GradeID == viewModel.GradeID);

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
