using Microsoft.AspNetCore.Mvc.Rendering;

namespace Input_Forms.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        public List<SelectListItem> StudentList { get; set; }
    }
}
