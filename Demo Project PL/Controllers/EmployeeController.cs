using Demo_Project_BLL.Interfaces;
using Demo_Project_DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Demo_Project_PL.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeReposatory _employeeRepository;
        public EmployeeController(IEmployeeReposatory employeeReposatory) // ANY Object implemment This Interface
        {
            _employeeRepository = employeeReposatory;
        }
        public IActionResult Index()
        {
            var employee = _employeeRepository.GetAll();
            return View(employee);
        }
        //[HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee Employee)
        {
            if (ModelState.IsValid) // Server Side Validation
            {
                _employeeRepository.Add(Employee);
                return RedirectToAction(nameof(Index));
            }
            return View(Employee);
        }

        //Employee/details/10
        public IActionResult Details(int? id, string ViewName = "Details")
        {
            if (id == null)
                return NotFound();
            var employee = _employeeRepository.Get(id.Value);
            if (employee == null)
                return NotFound();
            return View(ViewName, employee);
        }
        [HttpGet]
        //Employee/Edit/id
        public IActionResult Edit(int? id)
        {
            ///if (id == null)
            ///    return BadRequest();
            ///var Employee = _EmployeeRepository.Get(id.Value);
            ///if (Employee == null)
            ///    return BadRequest();
            ///return View(Employee);

            return Details(id, "Edit");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, Employee employee)
        {
            if (id != employee.Id)
                return BadRequest();
            if (ModelState.IsValid) // Server Side Validation
            {
                try
                {
                    _employeeRepository.Update(employee);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    // 1. log Exception
                    // 2. Friendly Message

                    ModelState.AddModelError(string.Empty, ex.Message); // Not Frindely  Message
                    //return View(Employee);
                }
            }

            return View(employee);
        }
        // Employee/Delete/id
        // Employee/Delete/
        //[HttpGet]
        public IActionResult Delete(int? id)
        {
            //if (id == null)
            //    return BadRequest();
            //var Employee = _EmployeeRepository.Get(id.Value);
            //if (Employee == null)
            //    return BadRequest();
            //return View(Employee);
            return Details(id, "Delete");
        }
        //[HttpDelete]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromRoute] int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }
            try
            {
                _employeeRepository.Delete(employee);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // 1. Log Error
                // 2. Frindly Message
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(employee);
            }
        }
    }
}
