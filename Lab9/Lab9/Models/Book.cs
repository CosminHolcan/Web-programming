using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab9.Models
{
    public class Book
    {
        public int id { get; set; }
        public string author { get; set; }
        public string title { get; set; }
        public int pages { get; set; }
        public string genre { get; set; }
        public string lended { get; set; }
    }
}