using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using RipperQuotes;

namespace Ripper_Quotes_Forms
{
    public partial class MainPage : ContentPage
    {
        private RipperCon _con = new RipperCon();
        public MainPage()
        {
            InitializeComponent();
            QuoteList.HasUnevenRows = true;
            NavigationPage.SetTitleIcon(this, "");

            ToolbarItems.Add(new ToolbarItem("New", "", async () =>
                await Navigation.PushModalAsync(new NewQuotePage())
                ));
            ToolbarItems.Add(new ToolbarItem("More", "", async () =>
                await DisplayActionSheet("More", "Back", "", new string[] { "View Categories" })
            ));
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await _con.DownloadJson();
            QuoteList.ItemsSource = _con.Quotes;
        }
    }
}
