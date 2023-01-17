using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace App.ModelsAnServisec
{
    class MainContentPageService
    {
        private HtmlWeb _web;
        private HtmlDocument _currentPage;
        private Uri _siteUri;

        MainContentPageService()
        {
            _web= new HtmlWeb();
            _siteUri = new Uri()
        }
    }
}
