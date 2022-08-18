using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sample_ToDoList.Models;

namespace Sample_ToDoList.Controllers
{
    public class TblToDoListsController : Controller
    {
        private readonly ToDoListDBContext _context;

        public TblToDoListsController(ToDoListDBContext context)
        {
            _context = context;
        }

        // GET: TblToDoLists
        public async Task<IActionResult> Index()
        {
              return _context.TblToDoLists != null ? 
                          View(await _context.TblToDoLists.ToListAsync()) :
                          Problem("Entity set 'ToDoListDBContext.TblToDoLists'  is null.");
        }

        // GET: TblToDoLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblToDoLists == null)
            {
                return NotFound();
            }

            var tblToDoList = await _context.TblToDoLists
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblToDoList == null)
            {
                return NotFound();
            }

            return View(tblToDoList);
        }

        // GET: TblToDoLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblToDoLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,IsActive,CreatedDate,UpdatedDate,Status")] TblToDoList tblToDoList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblToDoList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblToDoList);
        }

        // GET: TblToDoLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblToDoLists == null)
            {
                return NotFound();
            }

            var tblToDoList = await _context.TblToDoLists.FindAsync(id);
            if (tblToDoList == null)
            {
                return NotFound();
            }
            return View(tblToDoList);
        }

        // POST: TblToDoLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,IsActive,CreatedDate,UpdatedDate,Status")] TblToDoList tblToDoList)
        {
            if (id != tblToDoList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblToDoList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblToDoListExists(tblToDoList.Id))
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
            return View(tblToDoList);
        }

        // GET: TblToDoLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblToDoLists == null)
            {
                return NotFound();
            }

            var tblToDoList = await _context.TblToDoLists
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblToDoList == null)
            {
                return NotFound();
            }

            return View(tblToDoList);
        }

        // POST: TblToDoLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblToDoLists == null)
            {
                return Problem("Entity set 'ToDoListDBContext.TblToDoLists'  is null.");
            }
            var tblToDoList = await _context.TblToDoLists.FindAsync(id);
            if (tblToDoList != null)
            {
                _context.TblToDoLists.Remove(tblToDoList);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblToDoListExists(int id)
        {
          return (_context.TblToDoLists?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
