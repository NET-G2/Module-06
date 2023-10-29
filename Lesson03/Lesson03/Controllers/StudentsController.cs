﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lesson03.DAL;
using Lesson03.Models;

namespace Lesson03.Controllers
{
    public class StudentsController : Controller
    {
        private readonly PdpDbContext _context;

        public StudentsController(PdpDbContext context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index(string order, string? searchString)
        {
            ViewData["CurrentSort"] = order;
            ViewData["FullNameSort"] = order == "fullName_asc" ? "fullName_desc" : "fullName_asc";
            ViewData["AgeSort"] = order == "age_asc" ? "age_desc" : "age_asc";
            ViewData["IdSort"] = order == "id_asc" ? "id_desc" : "id_asc";

             var students = _context.Students.AsQueryable();

            students = order switch
            {
                "fullName_asc" => students.OrderBy(s => s.FullName),
                "fullName_desc" => students.OrderByDescending(s => s.FullName),
                "age_asc" => students.OrderBy(s => s.Age),
                "age_desc" => students.OrderByDescending(s => s.Age),
                "id_asc" => students.OrderByDescending(s => s.Id),
                "id_desc" => students.OrderByDescending(s => s.Id),
                _=> students.OrderBy(s => s.Id)
            };

            return View(await students.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Index(string? searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                return View(await _context.Students.ToListAsync());
            }

            var students = await _context.Students
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Group)
                .Where(s => s.FullName.ToLower().Contains(searchString.ToLower()))
                .ToListAsync();

            return View(students);
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FullName,Age")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,Age")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id))
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
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Students == null)
            {
                return Problem("Entity set 'PdpDbContext.Students'  is null.");
            }
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
          return (_context.Students?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
