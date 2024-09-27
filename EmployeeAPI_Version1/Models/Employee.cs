using System.ComponentModel.DataAnnotations; // Key is part of this ...

namespace EmployeeAPI_Version1.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Address { get; set; }

    }
}
