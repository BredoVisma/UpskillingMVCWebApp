using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using UpskillingMVCWebApp.Data.Entities;
using UpskillingMVCWebApp.Data.Enums;

namespace UpskillingMVCWebApp.Data.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ScrumDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Projects.Any())
                return;

            var issueFaker = new Faker<Issue>()
                .RuleFor(x => x.Title, x => x.Lorem.Sentence())
                .RuleFor(x => x.Description, x => x.Lorem.Paragraph())
                .RuleFor(x => x.Status, x => x.Random.Enum<IssueStatus>())
                .RuleFor(x => x.CreatedDate, x => x.Date.Between(DateTime.Now, DateTime.Now.AddMonths(-2)));

            var issues = issueFaker.GenerateBetween(10, 20);

            var projectFaker = new Faker<Project>()
                .RuleFor(x => x.Name, x => "Fake Project")
                .RuleFor(x => x.Issues, x => issues)
                .RuleFor(x => x.CreatedDate, x => x.Date.Between(DateTime.Now, DateTime.Now.AddMonths(-2)));

            var fakeProject = projectFaker.Generate();

            context.Projects.Add(fakeProject);
            context.SaveChanges();

        }
    }
}
