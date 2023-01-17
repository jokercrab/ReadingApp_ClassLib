using System.Runtime.CompilerServices;
using System.Text;
using Xunit;
using Xunit.Sdk;


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
            TextScrapper scrapper = new TextScrapper("https://www.wuxiaworld.eu/chapter/true-martial-world-1");
            scrapper.ScrappCurrentPageParagraphs();
            var given_text = scrapper.Text;
            using StreamReader file = new("../../../log");
            var text = file.ReadToEnd();
            StringBuilder fullText= new StringBuilder();
            foreach (var line in given_text)
            {
                fullText.AppendLine(line);

            }
            fullText.Remove(fullText.Length - 4, 4);
            Assert.Equal(text, fullText.ToString());

        }

        [Fact]
        public void LinkToNextPageIsProper()
        {
            TextScrapper scrapper = new TextScrapper("https://www.wuxiaworld.eu/chapter/true-martial-world-1");
            string expected = "https://www.wuxiaworld.eu/chapter/true-martial-world-2";
            scrapper.ScrappCurrentPageParagraphs();
            //string expected = "https://www.wuxiaworld.eu/chapter/true-martial-world-1711";
            Assert.Equal(expected, scrapper.NextPageLink);
        }

        [Fact]
        public void GetNextPageReturnsExceptionWhenFieldNotSet()
        {
            TextScrapper scrapper = new("https://www.wuxiaworld.eu/chapter/true-martial-world-1");
            var exception = Assert.Throws<NullReferenceException>(() => scrapper.NextPageLink);
            Assert.Equal("There is no next page link", exception.Message);
        }

        [Fact]
        public void GetChapterReturnsProperChapterName()
        {
            TextScrapper scrapper = new("https://www.wuxiaworld.eu/chapter/true-martial-world-4");
            scrapper.ScrappCurrentPageParagraphs();
            Assert.Equal("Chapter 4 - Who said I didn’t have any males in my house", scrapper.ChapterName);
        }
    }
}