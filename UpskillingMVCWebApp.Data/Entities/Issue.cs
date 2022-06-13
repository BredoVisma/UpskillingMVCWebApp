using System.ComponentModel.DataAnnotations;
using UpskillingMVCWebApp.Data.Enums;

namespace UpskillingMVCWebApp.Data.Entities
{
    public class Issue
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [StringLength(4000)]
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public IssueStatus Status { get; set; }
        [Required]
        public Guid ProjectId { get; set; }
        [Required]
        public virtual Project Project { get; set; }

    }
}
