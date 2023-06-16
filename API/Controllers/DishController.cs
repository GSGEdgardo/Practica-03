using API.Data;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DishController : ControllerBase
    {
        private readonly StoreContext _context;

        public DishController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetDishes()
        {
            var dishes = _context.Dishes.ToList();

            var result = new List<object>();

            foreach (var dish in dishes)
            {
                var dishData = new
                {
                    name = dish.name,
                    price = dish.price.ToString(),
                    clients = GetDishClients(dish.id)
                };

                result.Add(dishData);
            }

            return Ok(result);
        }

        private List<object> GetDishClients(int dishId)
        {
            var purchases = _context.Purchases
                .Where(p => p.dish_id == dishId)
                .ToList();

            var result = new List<object>();

            foreach (var purchase in purchases)
            {
                var customer = _context.Customers.FirstOrDefault(c => c.id == purchase.customer_id);

                if (customer != null)
                {
                    var customerData = new
                    {
                        id = customer.id,
                        name = customer.name,
                        created_at = purchase.created_at,
                        updated_at = purchase.updated_at
                    };

                    result.Add(customerData);
                }
            }

            return result;
        }
    }
}
