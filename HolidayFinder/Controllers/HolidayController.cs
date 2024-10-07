using Microsoft.AspNetCore.Mvc;
using HolidayFinder.Model;

namespace HolidayFinder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolidayController : Controller
    {
        private static Holiday HolidayFinder = new Holiday();

        [HttpPost("CheckForHoliday")]
        public ActionResult<string> CheckForHoliday([FromBody] DateTime InputDate)
        {
            if (HolidayFinder.IsHoliday(InputDate))
            {
                return Ok("Is a holiday");
            }

            return Ok("Not a holiday");
            
        }

        [HttpPost("ChangeHolidayDate")]
        public ActionResult<string> ChangeHolidayDate([FromBody] DateTime OldDate, DateTime NewDate)
        {
            if (HolidayFinder.changeHolidayDate(OldDate, NewDate))
            {
                return Ok("Holiday date changed");
            }

            return BadRequest("Provided date is not a holiday");
        }
    }
}
