using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiBook.Data;
using WebApiBook.Models;

namespace WebApiBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly WebApiBookContext _context;

        public BooksController(WebApiBookContext context)
        {
            _context = context;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBook()
        {
            return await _context.Book.ToListAsync();
        }

        // GET: api/Books/5
        [HttpGet("{BookId}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _context.Book.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        // PUT: api/Books/5

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int BookId, Book book)
        {
            if (BookId == null)
            {
                _context.Entry(book).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(BookId))
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
            return BadRequest();
        }


        // POST: api/Books

        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            _context.Book.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBook", new { BookId = book }, book);
        }

        // DELETE: api/Books/5
        [HttpDelete("{BookId}")]
        public async Task<ActionResult<Book>> DeleteBook(int BookId)
        {
            var book = await _context.Book.FindAsync(BookId);
            if (book == null)
            {
                return NotFound();
            }

            _context.Book.Remove(book);
            await _context.SaveChangesAsync();

            return book;
        }

        private bool BookExists(int BookId)
        {
            return _context.Book.Any(e => e.BookId == BookId);
        }
    }
}