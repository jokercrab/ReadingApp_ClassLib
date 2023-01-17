//using Android.App;
using MainFunctions;
using Microsoft.Maui.Platform;
using System.Collections;
using System.Text;


namespace App
{
    public partial class MainPage : ContentPage
    {
        private TextScrapper scrapper;
        public MainPage()
        {
            InitializeComponent();
            
        }

        private void LoadPage(string link)
        {
            scrapper = new TextScrapper(link);
            scrapper.ScrappCurrentPageParagraphs();
            //foreach (var line in scrapper.Text)
               // this.TextStack.Add(new Label { Text = line, FontSize=20});
            //this.Title = scrapper.ChapterName;
#if ANDROID

            //Platform.CurrentActivity.HideKeyboard(Platform.CurrentActivity.CurrentFocus);
#endif
            //this.Search.Hide
            
        }


        private void Button1_Clicked(object sender, EventArgs e)
        {
            if (Shell.GetNavBarIsVisible(this))
                Shell.SetNavBarIsVisible(this, false);
            else
                Shell.SetNavBarIsVisible(this, true);
            
            
        }
       

        private void InscreaseFontClicked(object sender, EventArgs e)
        {
            foreach (Label item in this.TextStack.Children)
                item.FontSize += 1;
            
        }

        private async void Button_previous_Clicked(object sender, EventArgs e)
        {
            this.TextStack.Clear();
            LoadPage(scrapper.PreviousPageLink);
            await this.MainText.ScrollToAsync(0.0, 0.0, true);
        }

        private  void Test_Clicked(object sender, EventArgs e)
        {
            LoadPage("https://www.wuxiaworld.eu/chapter/true-martial-world-1");
        }

        private async void Button_next_Clicked(object sender, EventArgs e)
        {
            this.TextStack.Clear();
            LoadPage(scrapper.NextPageLink);
            await this.MainText.ScrollToAsync(0.0, 0.0, true);
        }

        private void DecreaseFontButton_Clicked(object sender, EventArgs e)
        {
            foreach (Label item in this.TextStack.Children)
                item.FontSize -= 1;
        }
    }
}