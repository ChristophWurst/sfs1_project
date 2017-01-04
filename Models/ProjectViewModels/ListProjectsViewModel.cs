using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Models.ProjectViewModels
{
    public class ListProjectViewModel
    {
        public IList<Project> Projects { get; set; }
    }

}