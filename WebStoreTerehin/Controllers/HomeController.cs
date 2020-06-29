using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebStoreTerehin.Models;

namespace WebStoreTerehin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
    }
}
