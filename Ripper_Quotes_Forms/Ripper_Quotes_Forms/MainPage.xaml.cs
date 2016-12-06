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
            QuoteList.SeparatorVisibility = SeparatorVisibility.None;
            NavigationPage.SetTitleIcon(this, "");
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await _con.DownloadJson();
            QuoteList.ItemsSource = _con.Quotes;
        }
    }
}
