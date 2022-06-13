using System.ComponentModel.DataAnnotations;
using UpskillingMVCWebApp.Data.Enums;

namespace UpskillingMVCWebApp.Models
{
    public class IssueEditDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The issue needs a title")]
        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(4000)]
        public string Description { get; set; }

        public IssueStatus Status { get; set; }
        
        [Required]
        public Guid ProjectId { get; set; }
    }
}
