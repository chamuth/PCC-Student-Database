using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PCCSDS
{
	/// <summary>
	/// Interaction logic for HomePage.xaml
	/// </summary>
	public partial class HomePage : Window
	{
		public HomePage()
		{
			InitializeComponent();
		}

		private bool isSearchPalleteOpen = false;

		private void Search_Button_MouseUp(object sender, MouseButtonEventArgs e)
		{
			//Start the Search Pallete
			SearchPallete.IsEnabled = true;
			SearchPallete.IsHitTestVisible = true;

			//Reset the Search Query Text
			SearchQueryText.Text = "";

			//Animate the Search Pallete
			DoubleAnimation da = new DoubleAnimation(0, 1d, TimeSpan.FromMilliseconds(500));
			da.EasingFunction = new QuinticEase();
			SearchPallete.BeginAnimation(OpacityProperty, da);

			//Focus to the SearchQueryText to input the text
			SearchQueryText.Focus();

			isSearchPalleteOpen = true;
		}

		private void SearchPallete_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.Key== Key.Escape)
			{
				//Exit the SearchPallete
				DoubleAnimation da = new DoubleAnimation(0, TimeSpan.FromMilliseconds(400));
				da.EasingFunction = new QuinticEase();
				SearchPallete.BeginAnimation(OpacityProperty, da);
				SearchPallete.IsHitTestVisible = false; SearchPallete.IsEnabled = false;
				isSearchPalleteOpen = false;
			}
		}

		private void AdvancedQueryButton_MouseUp(object sender, MouseButtonEventArgs e)
		{
			//Open the Advanced QueryWindow
		}

		private void Window_KeyDown(object sender, KeyEventArgs e)
		{
			if (isSearchPalleteOpen == false)
			{
				//Check whether the search may start or not
				if (e.Key != Key.Escape && e.Key != Key.F1)
				{
					//Start the Search Pallete
					SearchPallete.IsEnabled = true;
					SearchPallete.IsHitTestVisible = true;

					//Reset the Search Query Text
					SearchQueryText.Text = "";

					//Animate the Search Pallete
					DoubleAnimation da = new DoubleAnimation(0, 1d, TimeSpan.FromMilliseconds(500));
					da.EasingFunction = new QuinticEase();
					SearchPallete.BeginAnimation(OpacityProperty, da);

					//Focus to the SearchQueryText to input the text
					SearchQueryText.Focus();

					isSearchPalleteOpen = true;
				}
				else
				{
					if (e.Key == Key.F1)
					{
						//Help is requested, Load the local / server help documentation.
						//TODO:Create help docs and link it here
					}
				}
			}
		}
	}
}
