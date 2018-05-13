using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using ASPCoreWithAngular.Models;

namespace ASPCoreWithAngular.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        EmployeeDataAccessLayer objemployee = new EmployeeDataAccessLayer();

        [HttpGet]
        public IActionResult Index()
        {
            var results = objemployee.GetAllEmployees();
            return Ok(results);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] Employee employee)
        {
            return Ok(objemployee.AddEmployee(employee));
        }

        [HttpGet]
        [Route("Details/{id}")]
        public IActionResult Details(int id)
        {
            return Ok(objemployee.GetEmployeeData(id));
        }

        [HttpPut]
        [Route("Edit")]
        public IActionResult Edit([FromBody]Employee employee)
        {
            return Ok(objemployee.UpdateEmployee(employee));
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(objemployee.DeleteEmployee(id));
        }
    }
}
