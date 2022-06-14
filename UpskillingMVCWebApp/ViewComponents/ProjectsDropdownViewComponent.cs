using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UpskillingMVCWebApp.Data.Data;
using UpskillingMVCWebApp.Models;

namespace UpskillingMVCWebApp.ViewComponents
{
    public class ProjectsDropdownViewComponent : ViewComponent
    {
        private readonly ScrumDbContext _context;
        private readonly IMapper _mapper;

        public ProjectsDropdownViewComponent(ScrumDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET PARTIAL: Project Dropdown
        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (_context.Projects != null)
            {
                var projects = _mapper.Map<IEnumerable<ProjectDto>>(await _context.Projects.ToListAsync());
                return View(projects);
            }
            return View(new List<ProjectDto>());
        }
    }
}
