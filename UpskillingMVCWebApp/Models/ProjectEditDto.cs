using System.ComponentModel.DataAnnotations;

namespace UpskillingMVCWebApp.Models
{
    public class ProjectEditDto
    {
        public Guid ProjectId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
