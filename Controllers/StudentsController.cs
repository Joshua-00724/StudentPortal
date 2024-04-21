using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Data;
using StudentPortal.Models;
using StudentPortal.Models.Entities;

namespace StudentPortal.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public StudentsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Add(AddStudentViewModel viewModel)
        {
            ModelState.Clear();
            var student = new Student
            {
                SID = viewModel.SID,
                FName = viewModel.FName,
                LName = viewModel.LName,
                Email = viewModel.Email,
                Gender = viewModel.Gender,
                Phone = viewModel.Phone,
                Address = viewModel.Address,
                BirthDate = viewModel.BirthDate,
            };
            await dbContext.Students.AddAsync(student);
            await dbContext.SaveChangesAsync();

            TempData["AlertMessage"] = "Record has been created";

            return View();
        }

        [HttpGet]

        public async Task<IActionResult> Display()
        {
            var students = await dbContext.Students.ToListAsync();
            return View(students);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int sid)
        {
            var student = await dbContext.Students.FindAsync(sid);

            return View(student);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(Student viewModel)
        {
            var student = await dbContext.Students.FindAsync(viewModel.SID);

            if (student is not null)
            {
                student.FName = viewModel.FName;
                student.LName = viewModel.LName;   
                student.Email = viewModel.Email;
                student.Gender = viewModel.Gender;
                student.Phone = viewModel.Phone;
                student.Address = viewModel.Address;
                student.BirthDate = viewModel.BirthDate;

                await dbContext.SaveChangesAsync();
                

            }
            TempData["AlertMessage"] = "Record has been updated";
            return RedirectToAction("Display", "Students");
            


        }

        [HttpPost]

        public async Task<IActionResult> Delete(Student viewModel)
        {
            var student = await dbContext.Students.AsNoTracking().FirstOrDefaultAsync(a => a.SID == viewModel.SID);

            if (student is not null)
            {
                dbContext.Students.Remove(viewModel);
                await dbContext.SaveChangesAsync();
                
            }
            TempData["AlertMessage"] = "Record has been deleted";
            return RedirectToAction("Display", "Students");
        }
    }
}
