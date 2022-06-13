using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpskillingMVCWebApp.Data.Entities;
using UpskillingMVCWebApp.Data.Interfaces;
using Bogus;
using UpskillingMVCWebApp.Data.Enums;

namespace UpskillingMVCWebApp.Data.Services
{
    public class IssueDataInMemory : IIssueData
    {
        List<Issue> issues;

        public IssueDataInMemory()
        {
            var faker = new Faker<Issue>()
                .RuleFor(x => x.Title, x => x.Commerce.Product())
                .RuleFor(x => x.Description, x => x.Lorem.Paragraph())
                .RuleFor(x => x.Status, x => x.Random.Enum<IssueStatus>());

            this.issues = faker.GenerateBetween(10, 20);
        }

        public void Add(Issue issue)
        {
            if (issue.Id == null)
                issue.Id = Guid.NewGuid();

            issue.CreatedDate = DateTime.Now;
            issues.Add(issue);
        }

        public void Delete(Guid id)
        {
            var item = Get(id);
            issues.Remove(item);
        }

        public Issue Get(Guid id)
        {
            return issues.FirstOrDefault(x => x.Id == id);
        }

        public List<Issue> GetIssues()
        {
            return issues;
        }

        public void Update(Issue issue)
        {
            var item = Get(issue.Id);
            if (item != null)
            {
                item.Title = issue.Title;
                item.Description = issue.Description;
                item.Status = issue.Status;
                item.UpdatedDate = DateTime.Now;
            } else {
                throw new Exception("Could not find item");
            }
        }
    }
}
