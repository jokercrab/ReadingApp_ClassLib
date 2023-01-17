using WuxiaApp.Services;

namespace WuxiaApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        MainService mainService;

        public MainPage()
        {
            InitializeComponent();
            mainService= new MainService();
            //InitializeBooks();
        }

        private async void InitializeBooks()
        {
            //var task = await mainService.GetTopBooksAsync();
            //this.Label1.Text = task;
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }
}