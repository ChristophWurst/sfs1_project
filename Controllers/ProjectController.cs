using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Models;
using ProjectManager.Models.ProjectViewModels;

namespace ProjectManager.Controllers
{
    [Authorize]
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
        [Authorize(Policy = "AdminOnly")]
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

        [HttpGet]
        public async Task<IActionResult> DeleteProject(string id)
        {
            Project project = _context.Projects.Where(p => p.Id == id).FirstOrDefault();
            if (project == null)
            {
                return RedirectToAction(nameof(DeleteProject), new { id = id });
            }
            return View(new DeleteProjectViewModel
            {
                Project = project
            });
        }

        [HttpPost]
        public async Task<IActionResult> DestroyProject(string id, bool delete)
        {
            Project project = _context.Projects.Where(p => p.Id == id).FirstOrDefault();
            if (project == null || !delete)
            {
                // Ignore
                return RedirectToAction(nameof(ListProjects));
            }
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListProjects));
        }
    }
}