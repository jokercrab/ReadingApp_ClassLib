//using Android.App;
using MainFunctions;
using Microsoft.Maui.Platform;
using System.Collections;


namespace App
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {
            InitializeComponent();
            
        }

        private void LoadPage(object sender, EventArgs e)
        {
            var scrapper = new TextScrapper("https://www.wuxiaworld.eu/chapter/true-martial-world-1");
            scrapper.ScrappCurrentPageParagraphs();
            this.TextStack.Add(new Label { Text = scrapper.Text[0] });
            
            this.Title = scrapper.ChapterName;
#if ANDROID

            Platform.CurrentActivity.HideKeyboard(Platform.CurrentActivity.CurrentFocus);
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
        
        private void MainText_Scrolled(object sender, ScrolledEventArgs e)// -_-
        {
            //this.Test.Text = $"X = {e.ScrollX}, y = {e.ScrollY}";
            Shell.SetNavBarIsVisible(this, false);
        }
    }
}