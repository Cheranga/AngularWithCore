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
        private readonly IPlatePatternRepository _platePatternRepository;

        public PlateController(IPlateRepository plateRepository, IPlatePatternRepository platePatternRepository)
        {
            _plateRepository = plateRepository;
            _platePatternRepository = platePatternRepository;
        }

        [HttpGet]
        public IActionResult GetPlates()
        {
            var plates = _plateRepository.GetAll();
            return Ok(plates);
        }

        [HttpGet("patterns/{id}")]
        public IActionResult GetPlatePatterns(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            //
            // TODO: Remove these 2 queries and combine them to one
            //
            var currentPlate = _plateRepository.GetPlate(id);
            if (currentPlate == null)
            {
                return NotFound();
            }

            var currentPatterns = new List<PlatePattern>(_platePatternRepository.GetPlatePatterns(id));
            
            var platePatterns = new
            {
                currentPlate.Id,
                currentPlate.Name,
                currentPlate.MinCharacters,
                currentPlate.MaxCharacters,
                Patterns = currentPatterns.Select(y => new { y.Name, pattern = y.GetFormat() })
            };

            return Ok(platePatterns);
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
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_plateRepository.DeletePlate(id));
        }
    }
}

