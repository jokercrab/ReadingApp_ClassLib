namespace MainFunctions;
using HtmlAgilityPack;
using System.Text;
using System.Web;


public class TextScrapper
{
    private readonly HtmlWeb _web;
    private readonly HtmlDocument _currentPage;
    private readonly Uri _siteUri;
    private string? _nextPage;
    private string? _previousPage;
    public string NextPageLink
    {
        get 
        {

            if (_nextPage != null)
                return _nextPage;
            else
                throw new NullReferenceException("There is no next page link");
  
        }
    }

    public string PreviousPageLink
    {
        get
        {

            if (_previousPage != null)
                return _previousPage;
            else
                throw new NullReferenceException("There is no previous page link");

        }
    }

    public TextScrapper(string link)
    {
        _web = new HtmlWeb();
        _currentPage = _web.Load(link);
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
        _nextPage = GetNextPageLink();
        _previousPage = GetPreviousPageLink();
        return text;
    }

    private string GetNextPageLink()
    {
        var node = _currentPage.DocumentNode.SelectSingleNode("//button[@id='nextChapter']");
        if (node == null)
            throw new NullReferenceException("No object with given xpath");
        node = node.ParentNode;
        var atribs = node.Attributes;
        string path = atribs["href"].Value;
        //if (link == null)
            //throw new NullReferenceException("There is no href atrib");

        return "https://"+ _siteUri.Host + path;


    }

    private string GetPreviousPageLink()
    {
        var node = _currentPage.DocumentNode.SelectSingleNode("//button[@id='previousChapter']");
        if (node == null)
            throw new NullReferenceException("No object with given xpath");
        node = node.ParentNode;
        var atribs = node.Attributes;
        string path = atribs["href"].Value;
        //if (link == null)
        //throw new NullReferenceException("There is no href atrib");

        return "https://" + _siteUri.Host + path;
    }

}
