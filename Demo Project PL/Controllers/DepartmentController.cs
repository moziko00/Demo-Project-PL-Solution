﻿using Demo_Project_BLL.Interfaces;
using Demo_Project_BLL.Repositories;
using Demo_Project_DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Demo_Project_PL.Controllers
{
    public class DepartmentController : Controller
    {
        private IDepartmentReposatory _departmentRepository;
        public DepartmentController(IDepartmentReposatory departmentRepository) // ANY Object implemment This Interface
        {
            _departmentRepository = departmentRepository;
        }
        public IActionResult Index()
        {
            var departments = _departmentRepository.GetAll();
            return View(departments);
        }
        //[HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid) // Server Side Validation
            {
                _departmentRepository.Add(department);
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        //Department/details/10
        public IActionResult Details(int? id , string ViewName="Details")
        {
            if (id == null)
                return NotFound();
            var department = _departmentRepository.Get(id.Value);
            if (department == null)
                return NotFound();
            return View(ViewName,department);
        }
        [HttpGet]
        //Department/Edit/id
        public IActionResult Edit(int? id)
        {
            ///if (id == null)
            ///    return BadRequest();
            ///var department = _departmentRepository.Get(id.Value);
            ///if (department == null)
            ///    return BadRequest();
            ///return View(department);
            
            return Details(id,"Edit");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id,Department department)
        {
            if (id != department.Id)
                return BadRequest();
            if (ModelState.IsValid) // Server Side Validation
            {
                try
                {
                    _departmentRepository.Update(department);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    // 1. log Exception
                    // 2. Friendly Message
                    
                    ModelState.AddModelError(string.Empty, ex.Message); // Not Frindely  Message
                    //return View(department);
                }
            }

            return View(department);
        }
        // Department/Delete/id
        // Department/Delete/
        //[HttpGet]
        public IActionResult Delete(int? id)
        {
            //if (id == null)
            //    return BadRequest();
            //var department = _departmentRepository.Get(id.Value);
            //if (department == null)
            //    return BadRequest();
            //return View(department);
            return Details(id, "Delete");
        }
        //[HttpDelete]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromRoute]int id,Department department)
        {
            if (id !=department.Id)
            {
                return BadRequest();
            }
            try
            {
                _departmentRepository.Delete(department);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // 1. Log Error
                // 2. Frindly Message
                ModelState.AddModelError(string.Empty,ex.Message);
                return View(department);
            }
        }
    }
}
