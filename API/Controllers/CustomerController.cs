using API.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly StoreContext _context;

        public CustomerController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetCustomers()
        {
            var customers = _context.Customers.ToList();

            var result = new List<object>();

            foreach (var customer in customers)
            {
                var customerData = new
                {
                    name = customer.name,
                    rut = customer.rut,
                    total_sum_last_month = GetTotalSumLastMonth(customer.id),
                    dishes = GetCustomerDishes(customer.id)
                };

                result.Add(customerData);
            }

            return Ok(result);
        }

        private int GetTotalSumLastMonth(int customerId)
        {
            DateTime fechaActual = DateTime.Now;
            DateTime nuevaFecha = fechaActual.AddMonths(-1);
            DateOnly fechaModificada = DateOnly.FromDateTime(nuevaFecha);

            var purchases = _context.Purchases
                .Where(p => p.customer_id == customerId && p.created_at >= new DateTime(fechaModificada.Year, fechaModificada.Month, fechaModificada.Day))
                .ToList();

            return purchases.Sum(p => GetDishPrice(p.dish_id));
        }

        private List<object> GetCustomerDishes(int customerId)
        {
            var purchases = _context.Purchases
                .Where(p => p.customer_id == customerId)
                .ToList();

            var result = new List<object>();

            foreach (var purchase in purchases)
            {
                var dish = _context.Dishes.FirstOrDefault(d => d.id == purchase.dish_id);

                if (dish != null)
                {
                    var dishData = new
                    {
                        id = dish.id,
                        name = dish.name,
                        price = dish.price.ToString(),
                        created_at = purchase.created_at,
                        updated_at = purchase.updated_at
                    };

                    result.Add(dishData);
                }
            }

            return result;
        }

        private int GetDishPrice(int dishId)
        {
            var dish = _context.Dishes.FirstOrDefault(d => d.id == dishId);
            return dish?.price ?? 0;
        }
    }
}
