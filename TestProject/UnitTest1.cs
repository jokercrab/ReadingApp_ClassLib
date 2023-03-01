using General;
using Scraper;
using System.Text.RegularExpressions;
namespace TestProject
{
    public class UnitTest1
    {

        [Fact]
        public async void GetBookOverviewReturnsProperData()
        {

            WuxiaScraper scraper = new("https://wuxia.click/novel/12-hours-after");
            //WuxiaScraper scraper = new("https://wuxia.click/search/alchemy");

            //Book book = await scraper.GetBookOverview();
            scraper.GettingScriptContent();


        }
    }
}