using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AngularWithCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace AngularWithCore.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly EmployeeDataAccessLayer _dataAccess;

        public EmployeeController(EmployeeDataAccessLayer dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IActionResult Get()
        {
            var employees = _dataAccess.GetAll();
            return Ok(employees);
        }

        public IActionResult Get(int id)
        {
            var employee = _dataAccess.GetEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        public IActionResult Post(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _dataAccess.AddEmployee(employee);
            return Ok(result);
        }

    }
}
