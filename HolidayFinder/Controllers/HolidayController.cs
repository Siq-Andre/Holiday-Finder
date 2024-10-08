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

            string response = "";

            if (HolidayFinder.IsHoliday(InputDate))
            {
                response += "Is a holiday ";
            }
            else
            {
                response += "Is not a holiday ";
            }

            if (HolidayFinder.isBusinessDay(InputDate))
            {
                response += "and is a business day";
            }

            else
            {
                response += "and not a business day";
            }

            return Ok(response);

            
        }

        [HttpPost("ChangeHolidayDate")]
        public ActionResult<string> ChangeHolidayDate([FromBody] ChangeHolidayDateRequest request)
        {
            if (HolidayFinder.changeHolidayDate(request.OldDate, request.NewDate))
            {
                return Ok("Holiday date changed");
            }

            return BadRequest("Provided date is not a holiday");
        }
    }
}
