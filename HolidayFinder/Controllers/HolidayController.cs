using Microsoft.AspNetCore.Mvc;
using HolidayFinder.Model;

namespace HolidayFinder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolidayController : Controller
    {
        private static Holiday HolidayFinder = new Holiday();

        [HttpPost("isHoliday")]
        public ActionResult<string> IsHoliday([FromBody] DateTime InputDate)
        {
            if (HolidayFinder.IsFixedHoliday(InputDate) || HolidayFinder.IsMovableHoliday(InputDate))
            {
                return Ok("Is a holiday");
            }

            return Ok("Not a holiday");
            
        }
    }
}
