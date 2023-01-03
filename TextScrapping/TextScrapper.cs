namespace MainFunctions;
using HtmlAgilityPack;
using System.Text;
using System.Web;


public class TextScrapper
{
    private readonly HtmlWeb _web;
    private readonly HtmlDocument _currentPage;
    private readonly string _link;
    private readonly Uri _siteUri;
   // private readonly string _nextPage;
    //public string NextPageLink { get => _nextPage; }

    public TextScrapper(string link)
    {
        _web = new HtmlWeb();
        _currentPage = _web.Load(link);
        this._link = link;
        _siteUri= new Uri(link);
    }

    public StringBuilder ScrappCurrentPageParagraphs(string Xpath)
    {
        var Nodes = _currentPage.DocumentNode.SelectNodes(Xpath);
        StringBuilder text = new StringBuilder();
        foreach (var paragraph in Nodes)
        {
            text.Append(paragraph.InnerText);
            text.Append('\n');
        }
        text.Remove(text.Length - 1, 1);
        return text;
    }

    public string GetNextPageLink()
    {
        var node = _currentPage.DocumentNode.SelectSingleNode("//button[@id='nextChapter']");
        if (node == null)
            throw new NullReferenceException("No object with given xpath");
        node = node.ParentNode;
        var atribs = node.Attributes;
        string link = atribs["href"].Value;
        if (link == null)
            throw new NullReferenceException("There is no href atrib");

        return "https://"+ _siteUri.Host + link;


    }

    public string GetPrevPageLink()
    {
        throw new NotImplementedException("Method is not implemented yet");
    }

}
