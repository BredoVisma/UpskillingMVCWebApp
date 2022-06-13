﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UpskillingMVCWebApp.Data.Data;
using UpskillingMVCWebApp.Data.Entities;
using UpskillingMVCWebApp.Models;

namespace UpskillingMVCWebApp.Controllers
{
    public class IssuesController : Controller
    {
        private readonly ScrumDbContext _context;
        private readonly IMapper _mapper;

        public IssuesController(ScrumDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Issues
        public async Task<IActionResult> Index()
        {
            if (_context.Issues == null)
                return Problem("Entity set 'IssueContext.Issues'  is null.");

            var issueEntities = await _context.Issues.ToListAsync();
            var model = _mapper.Map<IEnumerable<IssueDto>>(issueEntities);

            return View(model);
        }

        // GET: Issues/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Issues == null)
            {
                return NotFound();
            }

            var issue = await _context.Issues
                .FirstOrDefaultAsync(m => m.Id == id);
            if (issue == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<IssueDto>(issue);

            return View(model);
        }

        // GET: Issues/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Issues/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,CreatedDate,UpdatedDate,Status")] Data.Entities.Issue issue)
        {
            if (ModelState.IsValid)
            {
                issue.Id = Guid.NewGuid();
                _context.Add(issue);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var model = _mapper.Map<IssueDto>(issue);

            return View(model);
        }

        // GET: Issues/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Issues == null)
            {
                return NotFound();
            }

            var issue = await _context.Issues.FindAsync(id);
            if (issue == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<IssueDto>(issue);

            return View(model);
        }

        // POST: Issues/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Title,Description,Status")] IssueEditDto issue)
        {
            if (id != issue.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingIssue = _context.Issues.Single(e => e.Id == issue.Id);
                    
                    existingIssue.Title = issue.Title;
                    existingIssue.Description = issue.Description;
                    existingIssue.Status = issue.Status;
                    existingIssue.UpdatedDate = DateTime.UtcNow;
                    
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IssueExists(issue.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            var model = _mapper.Map<IssueDto>(issue);

            return View(model);
        }

        // GET: Issues/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Issues == null)
            {
                return NotFound();
            }

            var issue = await _context.Issues
                .FirstOrDefaultAsync(m => m.Id == id);
            if (issue == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<IssueDto>(issue);

            return View(model);
        }

        // POST: Issues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Issues == null)
            {
                return Problem("Entity set 'IssueContext.Issues'  is null.");
            }
            var issue = await _context.Issues.FindAsync(id);
            if (issue != null)
            {
                _context.Issues.Remove(issue);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IssueExists(Guid id)
        {
          return (_context.Issues?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
