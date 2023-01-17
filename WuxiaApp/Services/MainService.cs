using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;


namespace WuxiaApp.Services
{
    internal class MainService
    {
        private Uri currentPage;
        private string _startPageURI = "https://wuxia.click/search?order_by=-total_views";
        private HtmlWeb _web;
        public MainService() 
        {
            currentPage= new Uri(_startPageURI);
            _web= new HtmlWeb();
        }
        
        public async Task<string> GetTopBooksAsync()
        {
            var doc = await _web.LoadFromWebAsync(_startPageURI);
            string htmldoc = doc.DocumentNode.OuterHtml.ToString();
            return htmldoc;
        }
    }
}
