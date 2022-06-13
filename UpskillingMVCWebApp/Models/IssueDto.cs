using System.ComponentModel.DataAnnotations;
using System.Reflection;
using UpskillingMVCWebApp.Data.Enums;

namespace UpskillingMVCWebApp.Models
{
    public class IssueDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The issue needs a title")]
        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(4000)]
        public string Description { get; set; }

        [Display(Name = "Created at")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Updated at")]
        public DateTime UpdatedDate { get; set; }

        public IssueStatus Status { get; set; }

        public string StatusDisplayName {get;set;}
        
        [Required]
        public Guid ProjectId { get; set; }

        public IssueDto()
        {
            StatusDisplayName = Status.GetType().GetMember(Status.ToString()).FirstOrDefault()?.GetCustomAttribute<DisplayAttribute>()?.GetName() ?? "";
        }
    }
}
