using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcTitle.Data;
using MvcTitle.Models;
using MvcTitle.Repositories;
using MvcTitle.Services;

namespace MvcTitle.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TitlesController : ControllerBase
    {
        private readonly MvcTitleContext _context;
        private readonly ITitleRepository _titleRepository;
        private readonly WebClient _webClient;

        public TitlesController(MvcTitleContext context, ITitleRepository titleRepository,
            WebClient webClient)
        {
            _context = context;
            _titleRepository = titleRepository;
            _webClient = webClient;
        }

        // GET: api/Titles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Title>>> GetTitle()
        {
            return await _context.Title.Take(50).ToListAsync();
        }

        // GET: api/Titles/Filter
        [HttpGet("Filter")]
        public async Task<ActionResult<IEnumerable<Title>>> Filter(string type, string genre, string date,
            string name, string cast, string desc, string order)
        {
            IQueryable<Title> filteredTitles = _titleRepository.Filter(type, genre, date, name, cast, desc);

            IQueryable<Title> titles = _titleRepository.Order(filteredTitles, order);

            return await titles.Take(100).ToListAsync();
        }

        // GET: api/Titles/Details
        [HttpGet("Details")]
        public async Task<ActionResult<string>> GetDetails(string title, string type)
        {
            string url = $"http://www.omdbapi.com/?t={title}&type={type}&apikey=ddb81f42";

            return await _webClient.GetRequest(url);
        }

        // GET: api/Titles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Title>> GetTitle(int id)
        {
            var title = await _context.Title.FindAsync(id);

            if (title == null)
            {
                return NotFound();
            }

            return title;
        }

        // PUT: api/Titles/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTitle(int id, Title title)
        {
            if (id != title.Id)
            {
                return BadRequest();
            }

            _context.Entry(title).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TitleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Titles
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Title>> PostTitle(Title title)
        {
            _context.Title.Add(title);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTitle", new { id = title.Id }, title);
        }

        // DELETE: api/Titles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Title>> DeleteTitle(int id)
        {
            var title = await _context.Title.FindAsync(id);
            if (title == null)
            {
                return NotFound();
            }

            _context.Title.Remove(title);
            await _context.SaveChangesAsync();

            return title;
        }

        private bool TitleExists(int id)
        {
            return _context.Title.Any(e => e.Id == id);
        }
    }
}
