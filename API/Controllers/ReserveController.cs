using API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReserveController : ControllerBase
    {
        private readonly StoreContext _context;

        public ReserveController(StoreContext context)
        {
            _context = context;
        }
    }
}
