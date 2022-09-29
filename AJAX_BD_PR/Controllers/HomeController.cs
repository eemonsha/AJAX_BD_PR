using AJAX_BD_PR.Data;
using AJAX_BD_PR.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AJAX_BD_PR.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppBDContext _context;

        public HomeController(ILogger<HomeController> logger, AppBDContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var divlists = _context.divList.OrderBy(x => x.Name);
            ViewBag.divlist = divlists;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public JsonResult getDistricts( int id)
        {
            //var dr = _context.District.FirstOrDefault(x => x.divListId == id).Name;
            //return Json(dr);

            if(id <= 0)
            {
                return Json(new { flag = "0", msg = "Invalid division" });
            }
            var dslist = _context.District.Where(x => x.divListId == id).ToList();
            if(dslist.Count>0 && dslist != null)
            {
                return Json(new { flag = "1", msg = "District Fount", data = dslist });
            }
            else
            {
                return Json(new { flag = "0", msg = "District Not Found." });
            }
        }


        public JsonResult getUpazilas(int id)
        {

            if (id <= 0)
            {
                return Json(new { flag = "0", msg = "Invalid District" });
            }
            var uplist = _context.Upazila.Where(x => x.DistrictId == id).ToList();
            if (uplist.Count > 0 && uplist != null)
            {
                return Json(new { flag = "1", msg = "Upazila Fount", data = uplist });
            }
            else
            {
                return Json(new { flag = "0", msg = "Upazila Not Found." });
            }
        }

    }
}
