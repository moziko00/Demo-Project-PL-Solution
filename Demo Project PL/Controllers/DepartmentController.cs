using Demo_Project_BLL.Interfaces;
using Demo_Project_BLL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Demo_Project_PL.Controllers
{
    public class DepartmentController : Controller
    {
        private DepartmentRepository _departmentRepository;
        public DepartmentController(IDepartmentReposatory departmentRepository)
        {
            //_departmentRepository = ;
        }
        public IActionResult Index()
        {

            return View();
        }
    }
}
