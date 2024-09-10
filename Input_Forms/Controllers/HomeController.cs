using Input_Forms.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace Input_Forms.Controllers
{
    //public enum Gender
    //{
    //    Male = 0,
    //    Female = 1
    //}
    public class HomeController : Controller
    {
        private readonly InputFormsContext context;

        public HomeController(InputFormsContext context)
        {
            this.context = context;
        }
        private StudentModel BindDDL()
        {
            // Binding DropDownlist
            StudentModel stdModel = new StudentModel();
            stdModel.StudentList = new List<SelectListItem>();

            var data = context.TblStudents.ToList();
            stdModel.StudentList.Add(new SelectListItem
            {
                Text = "Select Name",
                Value = ""
            });
            foreach (var item in data)
            {
                stdModel.StudentList.Add(new SelectListItem
                {
                    Text = item.StudentName,
                    Value = item.Id.ToString()
                });
            }
            return stdModel;
        }
        public IActionResult Index()
        {
            //    List<SelectListItem> Gender = new List<SelectListItem>()
            //    {
            //        new SelectListItem {Value = "male", Text = "Male" },
            //        new SelectListItem {Value = "female", Text = "Female" }
            //    };
            //    ViewBag.Gender = Gender;

            var stds = BindDDL();
            return View(stds);
        }
        [HttpPost]
        public IActionResult Index(StudentModel std)
        {
            var student = context.TblStudents.Where(s => s.Id == std.Id).FirstOrDefault();
            if (student != null)
            {
                ViewBag.SelectedValue = student.StudentName;
            }

            var stds = BindDDL();
            return View(stds);
        }

        public IActionResult Privacy()
        {
            var model = new ViewModel()
            {
                CheckBoxes = new List<CheckBoxOptions>
                {
                    new CheckBoxOptions()
                    {
                        IsChecked = true,
                        Text = "Cricket",
                        Value = "cricket"
                    },
                    new CheckBoxOptions()
                    {
                        IsChecked = false,
                        Text = "Football",
                        Value = "football"
                    },
                    new CheckBoxOptions()
                    {
                        IsChecked = false,
                        Text = "Hockey",
                        Value = "hockey"
                    },
                }
            };
            //var model = new ViewModel()
            //{
            //    AcceptTerms = false,
            //    Text = "I Accept The Terms."
            //};

            return View(model);
        }

        [HttpPost]
        public IActionResult Privacy(ViewModel data)
        {
            //var value = data.AcceptTerms;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
