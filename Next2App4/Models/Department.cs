using System.ComponentModel.DataAnnotations;

namespace Next2App4.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }
        [Required]
        public string DepartmentName { get; set; }
    }
}
