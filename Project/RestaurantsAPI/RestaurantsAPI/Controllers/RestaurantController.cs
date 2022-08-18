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
        private ICRUDdbOperations<Restaurant> operations;
        public RestaurantController(ICRUDdbOperations<Restaurant> restaurantData)
        {
            operations = restaurantData;            
        }
        [HttpGet]
        [Route("[controller]")]
        public IActionResult GetRestaurants()
        {
            return Ok(operations.Get());
        }

        [HttpGet]
        [Route("[controller]/{id}")]
        public IActionResult GetRestaurant(Guid id)
        {
            Restaurant restaurant = operations.Get(id);
            if (restaurant != null)
            {
                return Ok(restaurant);
            }
            return NotFound($"Ресторан с id:{id} не найден");
        }

        [HttpPost]
        [Route("[controller]")]
        public IActionResult AddRestaurant(Restaurant restaurant)
        {
            operations.Add(restaurant);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + restaurant.Id,
              restaurant);
        }

        [HttpDelete]
        [Route("[controller]/{id}")]
        public IActionResult DeleteRestaurant(Guid id)
        {
            Restaurant restaurant = operations.Get(id);
            if (restaurant != null)
            {
                operations.Delete(id);
                return Ok();
            }
            return NotFound($"Ресторан с id:{id} не найден");
        }

        [HttpPatch]
        [Route("[controller]/{id}")]
        public IActionResult EditRestaurant(Guid id, Restaurant restaurant)
        {
            Restaurant existingRestaurant = operations.Get(id);
            if (existingRestaurant != null)
            {
                restaurant.Id = existingRestaurant.Id;
                operations.Edit(restaurant);
                return Ok();
            }
            else
            {
                return NotFound($"Ресторан с id:{id} не найден");
            }
        }
    }
}
