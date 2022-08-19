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
        private ICRUDdbOperations<Kitchen> operations;
        public KitchenController(ICRUDdbOperations<Kitchen> KitchenData)
        {
            operations = KitchenData;
        }
        [HttpGet]
        [Route("[controller]")]
        public IActionResult GetKitchens()
        {
            return Ok(operations.Get());
        }

        [HttpGet]
        [Route("[controller]/{id}")]
        public IActionResult GetKitchen(Guid id)
        {
            Kitchen kitchen = operations.Get(id);
            if (kitchen != null)
            {
                return Ok(kitchen);
            }
            return NotFound($"Кухня с id:{id} не найдена");
        }

        [HttpPost]
        [Route("[controller]")]
        public IActionResult AddKitcen(Kitchen kitchen)
        {
            operations.Add(kitchen);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + kitchen.Id,
              kitchen);
        }

        [HttpDelete]
        [Route("[controller]/{id}")]
        public IActionResult DeleteKitcen(Guid id)
        {
            Kitchen kitcen = operations.Get(id);
            if (kitcen != null)
            {
                if (operations.Delete(id, out string errorMessage))
                {
                    return Ok();
                }
                else
                {
                    return Problem(errorMessage);
                }
            }
            return NotFound($"Кухня с id:{id} не найдена");
        }

        [HttpPatch]
        [Route("[controller]/{id}")]
        public IActionResult EditKitchen(Guid id, Kitchen kitchen)
        {
            Kitchen existingKitchen = operations.Get(id);
            if (existingKitchen != null)
            {
                kitchen.Id = existingKitchen.Id;
                operations.Edit(kitchen);
                return Ok(kitchen);
            }
            else
            {
                return NotFound($"Кухня с id:{id} не найдена");
            }
        }
    }
}
