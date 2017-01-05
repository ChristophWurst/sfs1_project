using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Models;
using ProjectManager.Models.ProjectViewModels;

namespace ProjectManager.Controllers
{
    public class ProjectController : Controller
    {
        private ProjectManagerContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        public ProjectController(ProjectManagerContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET /Project/ListProjects
        [HttpGet]
        public async Task<IActionResult> ListProjects()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user == null)
            {
                return RedirectToAction(nameof(AccountController.Login), new { Controller = "Account" });
            }

            return View(new ListProjectViewModel()
            {
                Projects = _context.Projects.ToList()
            });
        }

        // GET Project/AddProject
        [HttpGet]
        public async Task<IActionResult> AddProject() 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryTokenAttribute]
        public async Task<IActionResult> SaveProject(AddProjectViewModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Projects.Add(new Project
                {
                    Name = model.Name
                });
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(ListProjects));
        }
    }
}