using System.ComponentModel.DataAnnotations;

namespace UpskillingMVCWebApp.Data.Enums
{
    public enum IssueStatus
    {
        [Display(Name = "None")]
        None,
        [Display(Name = "To do" )]
        Todo,
        [Display(Name = "In Progress")]
        InProgress,
        [Display(Name = "In Review")]
        Review,
        [Display(Name = "Done")]
        Done
    }
}
