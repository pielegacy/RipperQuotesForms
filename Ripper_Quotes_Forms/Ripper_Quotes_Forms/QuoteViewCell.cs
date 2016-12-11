using RipperQuotes;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Ripper_Quotes_Forms
{
    class QuoteViewCell : ViewCell
    {
        public QuoteViewCell()
        {
            Grid mainGrid = new Grid()
            {
                RowDefinitions = new RowDefinitionCollection()
                    {
                        new RowDefinition() {Height = GridLength.Auto },
                        new RowDefinition() { Height = 20 }
                    }
            };
            mainGrid.Padding = new Thickness(5, 10);
            mainGrid.Margin = new Thickness(5, 4);
            Label QuoteLabel = new Label() { TextColor = Color.Black };
            QuoteLabel.FontSize = 20;
            QuoteLabel.HorizontalTextAlignment = TextAlignment.Center;
            Label AuthorLabel = new Label() { TextColor = Color.Black };
            AuthorLabel.FontSize = 15;
            AuthorLabel.HorizontalTextAlignment = TextAlignment.End;
            Grid.SetRow(QuoteLabel, 0);
            Grid.SetRow(AuthorLabel, 1);
            QuoteLabel.SetBinding<Quote>(Label.TextProperty, i => i.QuoteTextPresent);
            AuthorLabel.SetBinding<Quote>(Label.TextProperty, i => i.QuoteAuthorPresent);
            mainGrid.Children.Add(QuoteLabel);
            mainGrid.Children.Add(AuthorLabel);
            View = mainGrid;
        }
    }
}
