using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WuxiaApp.Models
{
    internal class MainContentPage:Book
    {
        public string MainText;
        public Uri NextPage, PreviousPage;
        public Uri CurrentPage;
    }
}
