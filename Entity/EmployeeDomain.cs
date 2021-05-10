using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class EmployeeDomain
    {
        [Key]
        public int EmpId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public bool IsActive  {get;set;}
        public bool IsDelete { get; set; }
        public DateTime CreateOn { get; set; }
    }
}
