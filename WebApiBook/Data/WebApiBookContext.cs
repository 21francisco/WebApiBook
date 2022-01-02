using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiBook.Models;

namespace WebApiBook.Data
{
    public class WebApiBookContext : DbContext
    {
        public WebApiBookContext (DbContextOptions<WebApiBookContext> options)
            : base(options)
        {
        }

        public DbSet<WebApiBook.Models.Book> Book { get; set; }
    }
}
