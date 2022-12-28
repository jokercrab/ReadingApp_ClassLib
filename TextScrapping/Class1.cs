//namespace TextScrapping;
using HtmlAgilityPack;
using System.Text;

public class TextScrapper
{
    private HtmlWeb web;
    private HtmlDocument page;
    public TextScrapper(string link)
    {
        web = new HtmlWeb();
        page = web.Load(link);

    }

    public StringBuilder ScrappCurrentPageParagraphs(string Xpath)
    {
        var Nodes = page.DocumentNode.SelectNodes(Xpath);
        StringBuilder text = new StringBuilder();
        foreach (var paragraph in Nodes)
        {
            text.Append(paragraph.InnerText);
            text.Append('\n');
        }
        text.Remove(text.Length - 1, 1);
        return text;
    }
}
