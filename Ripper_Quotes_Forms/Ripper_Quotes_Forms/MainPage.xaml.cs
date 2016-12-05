﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using RipperQuotes;
using System.IO;
using System.Diagnostics;

namespace Ripper_Quotes_Forms
{
	public partial class MainPage : ContentPage
	{
        private RipperCon _con = new RipperCon();
		public MainPage()
		{
			InitializeComponent();
            QuoteList.HasUnevenRows = true;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await _con.DownloadJson();
            QuoteList.ItemsSource = _con.Quotes;
        }
    }
}
