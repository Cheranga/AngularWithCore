using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPCoreWithAngular.Models.VPlates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace ASPCoreWithAngular.Controllers
{
    [Route("api/[controller]")]
    public class PlateController : Controller
    {
        private readonly IPlateRepository _plateRepository;

        public PlateController(IPlateRepository plateRepository)
        {
            _plateRepository = plateRepository;
        }

        [HttpGet]
        public IActionResult GetPlates()
        {
            var plates = _plateRepository.GetAll();
            return Ok(plates);
        }

        [HttpPost("Create")]
        public IActionResult CreatePlate([FromBody] Plate plate)
        {
            if (ModelState.IsValid)
            {
                var status = _plateRepository.AddPlate(plate);
                return Ok(status);
            }

            return BadRequest();
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_plateRepository.DeletePlate(id));
        }
    }
}
