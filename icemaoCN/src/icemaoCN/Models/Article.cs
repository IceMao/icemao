using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace icemaoCN.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public DateTime Time { get; set; }
        public string Content { get; set; }

    }
}
