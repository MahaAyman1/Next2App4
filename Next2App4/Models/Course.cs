using System.ComponentModel.DataAnnotations;

namespace Next2App4.Models
{
    public class Course
    {
        public Guid CourseID { get; set; }
        [Required(ErrorMessage ="Enter Course Name ")]
        public string CourseName { get; set; }

         public  int houres { get; set; }
        public string Period { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

    }
}
