using System.ComponentModel.DataAnnotations;

namespace UpskillingMVCWebApp.Models
{
    public class ProjectDto
    {
        public Guid ProjectId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public string? Description { get; set; }
        public List<IssueDto> Issues { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
