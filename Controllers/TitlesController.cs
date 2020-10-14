using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcTitle.Data;
using MvcTitle.Models;
using MvcTitle.Repositories;

namespace MvcTitle.Controllers
{
    public class TitlesController : Controller
    {
        private readonly MvcTitleContext _context;
        private readonly ITitleRepository _titleRepository;

        public TitlesController(MvcTitleContext context, ITitleRepository titleRepository)
        {
            _context = context;
            _titleRepository = titleRepository;
        }

        // GET: Titles
        public async Task<IActionResult> Index(string titleType, string titleGenre, string titleDate,
            string searchString, string castString, string descString)
        {
            IDictionary<string, IQueryable<string>> query = _titleRepository.GetQuery();

            IQueryable<Title> titles = _titleRepository.Filter(titleType, titleGenre,
                titleDate, searchString, castString, descString);

            var titleVM = new TitleViewModel
            {
                Types = new SelectList(await query["type"].Distinct().ToListAsync()),
                Genres = new SelectList(await query["genre"].Distinct().ToListAsync()),
                ReleaseDates = new SelectList(await query["date"].Distinct().ToListAsync()),
                Titles = await titles.Take(50).ToListAsync()
            };

            return View(titleVM);
        }

        // GET: Titles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var title = await _context.Title
                .FirstOrDefaultAsync(m => m.Id == id);
            if (title == null)
            {
                return NotFound();
            }

            return View(title);
        }

        // GET: Titles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Titles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Type,ReleaseDate,Genre,Cast,Description")] Title title)
        {
            if (ModelState.IsValid)
            {
                _context.Add(title);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(title);
        }

        // GET: Titles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var title = await _context.Title.FindAsync(id);
            if (title == null)
            {
                return NotFound();
            }
            return View(title);
        }

        // POST: Titles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Type,ReleaseDate,Genre,Cast,Description")] Title title)
        {
            if (id != title.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(title);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TitleExists(title.Id))
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
            return View(title);
        }

        // GET: Titles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var title = await _context.Title
                .FirstOrDefaultAsync(m => m.Id == id);
            if (title == null)
            {
                return NotFound();
            }

            return View(title);
        }

        // POST: Titles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var title = await _context.Title.FindAsync(id);
            _context.Title.Remove(title);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TitleExists(int id)
        {
            return _context.Title.Any(e => e.Id == id);
        }
    }
}
