using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Models;
using ProjectManager.Models.ProjectViewModels;

namespace ProjectManager.Controllers
{
    public class ProjectController : Controller
    {
        // GET /Project/ListProjects
        [HttpGet]
        public IActionResult ListProjects()
        {
            return View(new ListProjectViewModel()
            {
                Projects = new List<Project> {
                    new Project() { Name = "project 1" },
                    new Project() { Name = "project 1" }
                }
            });
        }
    }
}