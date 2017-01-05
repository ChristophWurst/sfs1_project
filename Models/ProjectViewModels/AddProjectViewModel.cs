using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Models.ProjectViewModels
{
    public class AddProjectViewModel
    {
        [DataType(DataType.Text)]
        [Required]
        public string Name { get; set; }
    }
}