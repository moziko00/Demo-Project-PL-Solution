using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Project_DAL.Entities
{
    public class Department
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Code Is Required ! !")]
        public  string Code { get; set; }
        [Required(ErrorMessage ="Name is Required! !")]
        [StringLength(50,ErrorMessage ="Name length is 50 chat")]
        public  string Name { get; set; }
        public DateTime DateOfCreation { get; set; }
    }
}
