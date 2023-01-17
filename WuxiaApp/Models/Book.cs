using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WuxiaApp.Models
{
    public class Book
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string PicturePath { get; set; }
        public Uri uri { get; set; }
    }
}
