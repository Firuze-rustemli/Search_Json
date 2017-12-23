using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Search.Models;

namespace Search.Controllers
{
    public class HomeController : Controller
    {
        SearchEntities db = new SearchEntities();

        public ActionResult Index()
        {
            return View(db.info.ToList());
        }

        public JsonResult GetSearchData(string searchBy, string searchVal)
        {
            List<info> Lists = new List<info>();

            if (searchBy == "id")
            {
                try
                {
                    int Id = Convert.ToInt32(searchVal);
                    Lists = db.info.Where(a => a.id == Id || searchVal == null).ToList();
                }
                catch(FormatException)
                {
                    Console.WriteLine("{0} is not a Id", searchVal);
                }
                return Json(Lists, JsonRequestBehavior.AllowGet);
            }
            else
            {
                Lists = db.info.Where(a => a.name.Contains(searchVal) || searchVal == null).ToList();
                return Json(Lists, JsonRequestBehavior.AllowGet);
            }
        }

    }
}