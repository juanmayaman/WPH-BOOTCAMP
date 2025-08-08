using FoodOrderApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FoodOrderApi.Models;

namespace FoodOrderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly DataStore _store;
        public FoodController(DataStore store) {
            _store = store;
        }

        [HttpGet]

        public ActionResult<IEnumerable<FoodItem>> GetAllFoods()
        {
            return Ok(_store.FoodItems);
        }
    }
}
