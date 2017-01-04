using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManager.Models
{
    [Table("Projects")]
    public class Project
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
