using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using MainFunctions;

namespace App.ViewModel
{
    public partial class MainContentViewModel : BaseViewModel
    {
        public MainContentViewModel(TextScrapper scraper)
        {
            this.scraper= scraper;
        }

        async Task GetContentAsync()
        {
            scraper.ScrappCurrentPageParagraphs();
            
            var text = scraper.Text;
            if(TextParagraph.Count!=0)
                TextParagraph.Clear();
            foreach(var paragraph in text)
            {
                TextParagraph.Add(paragraph);
            }
        }

        public ObservableCollection<string> TextParagraph { get; } = new();
        TextScrapper scraper;
        [ObservableProperty]
        string nextPageLink;
        [ObservableProperty]
        string previousPageLink;
    }
}
