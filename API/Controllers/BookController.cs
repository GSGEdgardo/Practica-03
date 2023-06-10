using API.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly StoreContext _context;

        public BookController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("/api/books")]
        public IActionResult GetBooksAndReservations()
        {
            var books = _context.Books.ToList();

            var result = new List<object>();

            foreach (var book in books)
            {
                var reservations = _context.Reserves
                    .Where(r => r.book_id == book.id)
                    .Join(_context.Users,
                        reserve => reserve.user_id,
                        user => user.id,
                        (reserve, user) => new
                        {
                            Id = reserve.id,
                            Name = user.name,
                            Faculty = user.faculty
                        })
                    .ToList();

                var bookWithReservations = new
                {
                    Name = book.book,
                    Description = book.description,
                    Reserves = reservations
                };

                result.Add(bookWithReservations);
            }
            return Ok(result);
        }
    }
}
