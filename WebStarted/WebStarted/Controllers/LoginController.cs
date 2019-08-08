using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace WebStarted.Controllers
{
    public class LoginController : Controller
    {
        [ChildActionOnly]
        public JsonResult __PhoneNumber(String PhoneNumber)
        {
            bool valid = false;
            if (string.IsNullOrEmpty(PhoneNumber))
                return Json(false, JsonRequestBehavior.AllowGet);
            Regex regex = new Regex(@"^\+[0-9]{11}$");
            valid = regex.IsMatch(PhoneNumber);
            return Json(valid, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
