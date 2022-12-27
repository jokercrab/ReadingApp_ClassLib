namespace TextScrapping;
using HtmlAgilityPack

public class TextScrapper
{
	HtmlWeb web = new HtmlWeb();
	HtmlDocument page;// = web.Load("https://www.wuxiaworld.eu/chapter/omniscient-readers-viewpoint-1");
	HtmlNodeCollection main_text;// = doc.DocumentNode.SelectNodes("//div[@id='chapterText']");
	HtmlNodeCollection next_link;// = doc.DocumentNode.SelectNodes("//div[@id='chapterText']");

	public TextScrapper(string link)
	{
		page = web.Load(link);	
		main_text = doc.DocumentNode.SelectNodes(Xpath);	
	}

	public scrapp_current_page(string Xpath)
	{
		main_text = doc.DocumentNode.SelectNodes(Xpath);
	}
}
