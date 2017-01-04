using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Models;
using ProjectManager.Models.ProjectViewModels;

namespace ProjectManager.Controllers
{
    public class ProjectController : Controller
    {
        private ProjectManagerContext _context;

        public ProjectController(ProjectManagerContext context)
        {
            _context = context;
        }

        // GET /Project/ListProjects
        [HttpGet]
        public IActionResult ListProjects()
        {
            return View(new ListProjectViewModel()
            {
                Projects = _context.Projects.ToList()
            });
        }
    }
}