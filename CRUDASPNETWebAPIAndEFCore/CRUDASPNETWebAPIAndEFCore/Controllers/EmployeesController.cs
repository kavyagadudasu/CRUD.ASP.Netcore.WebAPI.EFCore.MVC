using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CRUDASPNETWebAPIAndEFCore.Models;

namespace CRUDASPNETWebAPIAndEFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        
        [HttpGet]
        public IActionResult GetEmployees()
        {
            using (var db = new EmployeeContext())
            {
                var employees = db.EmployeeTbl.ToList();
                return Ok(employees);           }
            
        }

        [HttpPost]
        public IActionResult InsertEmployee(EmployeeTbl employee)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            using (var db = new EmployeeContext())
            {
                db.EmployeeTbl.Add(employee);

                db.SaveChanges();
            }
            return Ok(employee);
        }

        

        [HttpPut]
        public IActionResult UpdateEmployee(EmployeeTbl employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not A valid model");
            }
            using(var db = new EmployeeContext())
            {
                var existingEmployee = db.EmployeeTbl.Where(x => x.Id == employee.Id).FirstOrDefault();
                if(existingEmployee != null)
                {
                    existingEmployee.FirstName = employee.FirstName;
                    existingEmployee.LastName = employee.LastName;
                    existingEmployee.Salary = employee.Salary;
                    db.SaveChanges();
                }
                else
                {
                    return NotFound();
                }

            }
            return Ok();
        }
       
        [HttpDelete]
        public IActionResult DeleteEmployee(EmployeeTbl employee)
        {
            if (employee.Id <= 0)
                return BadRequest("Not a valid Emplloyee id");
            using (var db = new EmployeeContext())
            {
                var employeeRecord = db.EmployeeTbl
                    .Where(x => x.Id == employee.Id)
                    .FirstOrDefault();
                db.EmployeeTbl.Remove(employeeRecord);
                db.SaveChanges();
            }
            return Ok();
            

        }

    }
}