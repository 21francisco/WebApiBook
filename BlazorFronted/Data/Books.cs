using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BlazorFronted.Data
{
    public class Books
    {

        public int BookId { get; set; } = 0;

        public string Title { get; set; } = "";

        public string Author { get; set; } = "";

        public int Pages { get; set; } = 0;
    }
}
