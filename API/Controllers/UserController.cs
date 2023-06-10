using API.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly StoreContext _context;

        public UserController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetUsersWithReservations()
        {
            var users = _context.Users.ToList();

            var result = new List<object>();

            foreach (var user in users)
            {
                var userWithReservations = new
                {
                    UserName = user.name,
                    Faculty = user.faculty,
                    LastReservationDate = _context.Reserves
                        .Where(r => r.user_id == user.id)
                        .OrderByDescending(r => r.reserved_at)
                        .Select(r => r.reserved_at)
                        .FirstOrDefault(),
                    ReservationsLastMonthCount = _context.Reserves
                        .Count(r => r.user_id == user.id && r.reserved_at >= DateTime.Now.AddDays(-30)),
                    Reservations = _context.Reserves
                        .Where(r => r.user_id == user.id)
                        .Select(r => new
                        {
                            BookId = r.book_id,
                            Code = _context.Books.FirstOrDefault(b => b.id == r.book_id) != null ? _context.Books.FirstOrDefault(b => b.id == r.book_id).code : null,
                            Book = _context.Books.FirstOrDefault(b => b.id == r.book_id) != null ? _context.Books.FirstOrDefault(b => b.id == r.book_id).book : null,
                            Description = _context.Books.FirstOrDefault(b => b.id == r.book_id) != null ? _context.Books.FirstOrDefault(b => b.id == r.book_id).description : null
                        })
                        .ToList()
                    };

                result.Add(userWithReservations);
            }

            return Ok(result);
        }
    }
}
