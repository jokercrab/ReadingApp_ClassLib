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
            var given_text = scrapper.ScrappCurrentPageParagraphs("//div[@id='chapterText']");
            using StreamReader file = new("../../../log");
            var text = file.ReadToEnd();
            Assert.Equal(text, given_text.ToString());

        }

        [Fact]
        public void LinkToNextPageIsProper()
        {
            TextScrapper scrapper = new TextScrapper("https://www.wuxiaworld.eu/chapter/true-martial-world-1");
            string expected = "https://www.wuxiaworld.eu/chapter/true-martial-world-2";
            //string expected = "https://www.wuxiaworld.eu/chapter/true-martial-world-1711";
            Assert.Equal(expected, scrapper.GetNextPageLink());
        }
    }
}