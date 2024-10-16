﻿using Microsoft.AspNetCore.Mvc;
using HolidayFinder.Model;

namespace HolidayFinder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolidayController : Controller
    {
        private static HolidayFinderMethods HolidayFinder = new HolidayFinderMethods();
        private static HolidayList ListOfHolidays = new HolidayList();

        [HttpPost("CheckForHoliday")]
        public ActionResult<CheckForHolidayResponse> CheckForHoliday([FromBody] DateTime InputDate)
        {

            var Response = new CheckForHolidayResponse();
            Response.message = "";
            Response.InputDate = InputDate;

            if (HolidayFinder.IsHoliday(InputDate))
            {
                Response.IsHoliday = true;
                Response.message += "Is a holiday ";
            }
            else
            {
                Response.IsHoliday = false;
                Response.message += "Is not a holiday ";
            }

            if (HolidayFinder.isBusinessDay(InputDate))
            {
                Response.IsBusinessDay = true;
                Response.message += "and is a business day";
            }

            else
            {
                Response.IsBusinessDay = false;
                Response.message += "and not a business day";
            }

            return Ok(Response);

            
        }

        [HttpPost("ChangeHolidayDate")]
        public ActionResult<string> ChangeHolidayDate([FromBody] ChangeHolidayDateRequest request)
        {
            if (HolidayFinder.ChangeHolidayDate(request.OldDate, request.NewDate))
            {
                return Ok("Holiday date changed");
            }

            return BadRequest("Provided date is not a holiday");
        }

        [HttpGet("GetListOfEveryHoliday")]
        public HolidayList GetListOfEveryHoliday()
        {
            return ListOfHolidays;
        }

        [HttpGet("GetHolidayPage")]
        public List<HolidayDate> GetHolidayPage([FromBody] int Page)
        {
            var response = ListOfHolidays.showHolidays(Page);
            return response;
        }

        [HttpPost("AddHoliday")]
        public string AddHolyday([FromBody] AddHolidayRequest HolidayData)
        {
            var response = ListOfHolidays.AddHolidaysToList(HolidayData.Day, HolidayData.Month, HolidayData.Year, HolidayData.HolidayName);
           
            return response;
        }
    }
}
