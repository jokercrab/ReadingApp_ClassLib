namespace MainFunctions;
using HtmlAgilityPack;
using System.Text;
using System.Web;


public class TextScrapper
{
    private HtmlWeb web;
    private HtmlDocument page;
    private string link;
    private Uri siteUri;
    public TextScrapper(string link)
    {
        web = new HtmlWeb();
        page = web.Load(link);
        this.link = link;
        siteUri= new Uri(link);
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

    public string GetNextPageLink(string Xpath)
    {
        var node = page.DocumentNode.SelectSingleNode(Xpath);
        if (node == null)
            throw new NullReferenceException("No object with given xpath");
        node = node.ParentNode;
        var atribs = node.Attributes;
        string link = atribs["href"].Value;
        if (link == null)
            throw new NullReferenceException("There is no href atrib");

        return "https://"+ siteUri.Host + link;


    }

    public string GetPrevPageLink()
    {
        throw new NotImplementedException("Method is not implemented yet");
    }

}
