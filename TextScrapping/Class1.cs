namespace TextScrapping;
using HtmlAgilityPack;
using System.Text;

public class TextScrapper
{
	HtmlWeb web;
	HtmlDocument page;// = web.Load("https://www.wuxiaworld.eu/chapter/omniscient-readers-viewpoint-1");
	//HtmlNodeCollection main_text;// = doc.DocumentNode.SelectNodes("//div[@id='chapterText']");
	//HtmlNodeCollection next_link;// = doc.DocumentNode.SelectNodes("//div[@id='chapterText']");

	public TextScrapper(string link)
	{
		web = new HtmlWeb();
		page = web.Load(link);
	}

	public StringBuilder scrapp_current_page(string Xpath)
	{
		var Nodes = page.DocumentNode.SelectNodes(Xpath);
		StringBuilder text = new StringBuilder();
		foreach (var paragraph in Nodes)
		{
			text.Append(paragraph.InnerText);
		}

		return text;
	}
}
