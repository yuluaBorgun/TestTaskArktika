using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantsAPI.DataFasades;
using RestaurantsAPI.Migrations;
using System;

namespace RestaurantsAPI.Controllers
{
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private ICRUDdbOperations<Restaurant> operation;
        public RestaurantController(ICRUDdbOperations<Restaurant> restoranData)
        {
            operation = restoranData;            
        }
        [HttpGet]
        [Route("[controller]")]
        public IActionResult GetRestorans()//many
        {
            return Ok(operation.Get());
        }

        [HttpGet]
        [Route("[controller]/{id}")]
        public IActionResult GetRestoran(Guid id)//one
        {
            Restaurant restaurant = operation.Get(id);
            if (restaurant != null)
            {
                return Ok(restaurant);
            }
            return NotFound($"Ресторан с таким id:{id} не найден");
        }

        [HttpPost]
        [Route("[controller]")]
        public IActionResult AddRestoran(Restaurant restaurant)
        {
            operation.Add(restaurant);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + restaurant.Id,
              restaurant);
        }

        [HttpDelete]
        [Route("[controller]/{id}")]
        public IActionResult DeleteRestoran(Guid id)
        {
            Restaurant restaurant = operation.Get(id);
            if (restaurant != null)
            {
                operation.Delete(id);
                return Ok();
            }
            return NotFound($"Ресторан с таким id:{id} не найден");
        }

        [HttpPatch]
        [Route("[controller]/{id}")]
        public IActionResult EditRestoran(Guid id, Restaurant restaurant)
        {
            Restaurant existingRestoren = operation.Get(id);
            if (existingRestoren != null)
            {
                restaurant.Id = existingRestoren.Id;
                operation.Edit(restaurant);
                return Ok();
            }
            else
            {
                return NotFound($"Ресторан с таким id:{id} не найден");
            }
        }
    }
}
