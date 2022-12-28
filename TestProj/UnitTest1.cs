using Xunit.Abstractions;
using System.IO;

namespace TestProj
{
    
    public class UnitTest1
    {
        private readonly ITestOutputHelper output;
        
        public UnitTest1(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void TextFromFirstPageMatchesOutput()
        {
            //TextScrapper scrapper = new TextScrapper("https://www.wuxiaworld.eu/chapter/omniscient-readers-viewpoint-1");
            TextScrapper scrapper = new TextScrapper("https://www.wuxiaworld.eu/chapter/true-martial-world-1");
            var given_text = scrapper.ScrappCurrentPageParagraphs("//div[@id='chapterText']");
            //output.WriteLine(given_text.ToString());
            using StreamReader file = new("../../../text.txt");
            var text = file.ReadToEnd();

            Assert.Equal(text, given_text.ToString());

        }
    }
}