using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Project_DAL.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name Is Required!")]
        [MaxLength(50 ,ErrorMessage ="Max Lenght is 50 Chars")]
        [MinLength(5, ErrorMessage = "min Lenght is 5 Chars")]
        public string Name { get; set; }
        [Range(22, 30, ErrorMessage = "Age must be Between 22 and 30")]
        public int? Age { get; set; }
        [RegularExpression(@"^[0-9]{1,3}-[a-zA-Z]{5,10}-[a-zA-Z]{5,10}-[a-zA-Z]{5,10}$"
                            , ErrorMessage = "Address must be like 123-street-city-Country")]
        public string Address { get; set; }
        [DataType(DataType.Currency)]
        [Range(4000,8000)]
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;

    }
}
