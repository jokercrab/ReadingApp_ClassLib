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
    private string? _chapteName;
    public List<string> Text { get; }
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
    public string ChapterName
    {
        get
        {

            if (_chapteName != null)
                return _chapteName;
            else
                throw new NullReferenceException("There is no chapter loaded yet");

        }
    }
    public TextScrapper(string link)
    {
        _web = new HtmlWeb();
        _currentPage = _web.Load(link);
        _siteUri= new Uri(link);
        Text = new List<string>();
    }

    public void ScrappCurrentPageParagraphs()
    {
        var Nodes = _currentPage.DocumentNode.SelectNodes("//div[@id='chapterText']");
        
        foreach (var paragraph in Nodes)
        {
            Text.Add(paragraph.InnerText);
        }
        _nextPage = GetNextPageLink();
        _previousPage = GetPreviousPageLink();
        _chapteName = GetChapterName();
    }

    private string GetNextPageLink()
    {
        var node = _currentPage.DocumentNode.SelectSingleNode("//button[@id='nextChapter']");
        if (node == null)
            throw new NullReferenceException("No next page with given xpath");
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
            throw new NullReferenceException("No previous page link with given xpath");
        node = node.ParentNode;
        var atribs = node.Attributes;
        string path = atribs["href"].Value;
        //if (link == null)
        //throw new NullReferenceException("There is no href atrib");

        return "https://" + _siteUri.Host + path;
    }
    private string GetChapterName()
    {
        
        var node = _currentPage.DocumentNode.SelectSingleNode("/html/body/div[1]/div/div[3]/div[1]/div[1]/div/div[2]/h1");
        if (node == null)
            throw new NullReferenceException("No chapter with given xpath");
        return node.InnerText;
    }

}
