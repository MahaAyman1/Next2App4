using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Next2App4.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        [Required(ErrorMessage = "Enter Employee Name")]
        [MinLength(3, ErrorMessage = "Name should be at least 3 characters long")]
        [MaxLength(20, ErrorMessage = "Name can be up to 20 characters long")]
        public string Name { get; set; }
        public DateTime HDate { get; set; }
        [Required(ErrorMessage = "Enter an Email address")]
        [EmailAddress(ErrorMessage = "Invalid Email address")]
        public string Email { get; set; }
        public  decimal salary{ get; set; }
        public string city { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

    }
}
