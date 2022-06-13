using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpskillingMVCWebApp.Data.Entities;

namespace UpskillingMVCWebApp.Data.Interfaces
{
    public interface IIssueData
    {
        List<Issue> GetIssues();
        Issue Get(Guid id);
        void Add(Issue issue);
        void Update(Issue issue);
        void Delete(Guid id);
    }
}
