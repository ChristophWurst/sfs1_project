using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProjectManager.Controllers
{
    public class ProjectController : Controller
    {
        // GET /Project/List
        [HttpGet]
        public IActionResult ListProjects()
        {
            return View();
        }
    }
}