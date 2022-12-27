// See https://aka.ms/new-console-template for more information
using HtmlAgilityPack;
using System.IO;
using TextScrapping;


//HtmlWeb web = new HtmlWeb();
//HtmlDocument doc = web.Load("https://www.wuxiaworld.eu/chapter/omniscient-readers-viewpoint-1");
//HtmlNodeCollection paragr = doc.DocumentNode.SelectNodes("//div[@id='chapterText']");

using StreamWriter file = new("text");
    
//foreach(var node in paragr)
//   file.WriteLine(node.InnerText);
TextScrapper scrapper = new TextScrapper("https://www.wuxiaworld.eu/chapter/omniscient-readers-viewpoint-1");
file.WriteLine(scrapper.scrapp_current_page("//div[@id='chapterText']"));

Console.WriteLine("Done!");