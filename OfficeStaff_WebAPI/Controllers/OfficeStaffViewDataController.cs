using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OfficeStaff_WebAPI.Controllers
{
    public class OfficeStaffViewDataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
