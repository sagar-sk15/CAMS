using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cams.Web.MVCRazor.Controllers
{
    public class HolidayCalendarController : Controller
    {      
        public ActionResult HolidayCalanderIndex()   
        {
            return  View("HolidayCalendarView"); 
        }

        public ActionResult HolidayCalendarPartial()
        {
            return PartialView("HolidayCalendarPartial");
        }

        //public ActionResult CalendarPopupPartial()
        //{
        //    if (!string.IsNullOrEmpty(Request.Params["DateString"]))
        //      //  ViewData["PopupContent"] = new CalendarDemoHelper(Server.MapPath("~/App_Data/CalendarNotes.xml")).GetNote(Request.Params["DateString"]);
        //    return PartialView("HolidayCalendarPopupPartial");
        //}
    }
        
}
