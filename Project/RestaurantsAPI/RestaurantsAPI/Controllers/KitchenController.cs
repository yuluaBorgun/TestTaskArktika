using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantsAPI.DataFasades;
using RestaurantsAPI.Models;
using System;

namespace RestaurantsAPI.Controllers
{
    [ApiController]
    public class KitchenController : ControllerBase
    {
        private ICRUDdbOperations<Kitchen> operation;
        public KitchenController(ICRUDdbOperations<Kitchen> KitchenData)
        {
            operation = KitchenData;
        }
        [HttpGet]
        [Route("[controller]")]
        public IActionResult GetKitchens()
        {
            return Ok(operation.Get());
        }

        [HttpGet]
        [Route("[controller]/{id}")]
        public IActionResult GetKitchen(Guid id)
        {
            Kitchen kitchen = operation.Get(id);
            if (kitchen != null)
            {
                return Ok(kitchen);
            }
            return NotFound($"Кухня с таким id:{id} не найден");
        }

        [HttpPost]
        [Route("[controller]")]
        public IActionResult AddKitceh(Kitchen kitchen)
        {
            operation.Add(kitchen);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + kitchen.Id,
              kitchen);
        }

        [HttpDelete]
        [Route("[controller]/{id}")]
        public IActionResult DeleteKitceh(Guid id)
        {
            Kitchen kitceh = operation.Get(id);
            if (kitceh != null)
            {
                operation.Delete(id);
                return Ok();
            }
            return NotFound($"Кухня с таким id:{id} не найден");
        }

        [HttpPatch]
        [Route("[controller]/{id}")]
        public IActionResult EditKitchen(Guid id, Kitchen kitchen)
        {
            Kitchen existingKitchen = operation.Get(id);
            if (existingKitchen != null)
            {
                kitchen.Id = existingKitchen.Id;
                operation.Edit(kitchen);
                return Ok(kitchen);
            }
            else
            {
                return NotFound($"Кухня с таким id:{id} не найден");
            }
        }
    }
}
