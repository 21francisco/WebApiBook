using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiBook.Models
{
    public class Book
    {

        public int id { get; set; }

        public string  Title { get; set; }

        public string  Author { get; set; }

        public int Pages { get; set; }
    }
}
