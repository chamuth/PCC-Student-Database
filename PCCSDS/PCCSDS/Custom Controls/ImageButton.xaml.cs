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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PCCSDS
{
	/// <summary>
	/// Interaction logic for ImageButton.xaml
	/// </summary>
	public partial class ImageButton : UserControl
	{
		public ImageButton()
		{
			InitializeComponent();

			UpdateButtonImage();
		}

		private void UpdateButtonImage()
		{

			//Set the details
			ButtonImage.Source = Src;
			ButtonLabel.Content = Text;
		}

		private ImageSource _src = new BitmapImage();

		public ImageSource Src
		{
			get
			{
				return _src;
			}
			set
			{
				_src = value;
				UpdateButtonImage();
			}
		}

		private string _text = "ImageButton";

		public string Text
		{
			get
			{
				return _text;
			}
			set
			{
				_text = value;
				UpdateButtonImage();
			}
		}


		private void RectangularContent_MouseDown(object sender, MouseButtonEventArgs e)
		{
			DoubleAnimation OpacityAnimation = new DoubleAnimation();
			OpacityAnimation.From = Opacity;
			OpacityAnimation.To = 0.8d;
			OpacityAnimation.Duration = TimeSpan.FromMilliseconds(200);

			BeginAnimation(OpacityProperty, OpacityAnimation);

			//This line of code is very stupid
			//Circulator.Margin = new Thickness(Mouse.GetPosition(this).X, Mouse.GetPosition(this).Y, Mouse.GetPosition(this).X, Mouse.GetPosition(this).Y);

			DoubleAnimation circulator_dissappearing = new DoubleAnimation();
			circulator_dissappearing.From = Circulator.Opacity;
			circulator_dissappearing.To = 1;
			circulator_dissappearing.Duration = TimeSpan.FromMilliseconds(100);
			circulator_dissappearing.EasingFunction = new ExponentialEase();

			Circulator.BeginAnimation(OpacityProperty, circulator_dissappearing);

			DoubleAnimation increment = new DoubleAnimation(0, 200, new Duration(TimeSpan.FromMilliseconds(800)));
			increment.EasingFunction = new QuarticEase();
			Circulator.BeginAnimation(WidthProperty, increment);
			Circulator.BeginAnimation(HeightProperty, increment);
		}


		private void RectangularContent_MouseLeave(object sender, MouseEventArgs e)
		{
			DoubleAnimation OpacityAnimation = new DoubleAnimation();
			OpacityAnimation.From = Opacity;
			OpacityAnimation.To = 1;
			OpacityAnimation.Duration = TimeSpan.FromMilliseconds(200);

			BeginAnimation(OpacityProperty, OpacityAnimation);

			DoubleAnimation circulator_dissappearing = new DoubleAnimation();
			circulator_dissappearing.From = Circulator.Opacity;
			circulator_dissappearing.To = 0;
			circulator_dissappearing.Duration = TimeSpan.FromMilliseconds(400);
			circulator_dissappearing.EasingFunction = new ExponentialEase();

			Circulator.BeginAnimation(OpacityProperty, circulator_dissappearing);
		}

		private void RectangularContent_MouseUp(object sender, MouseButtonEventArgs e)
		{
			DoubleAnimation OpacityAnimation = new DoubleAnimation();
			OpacityAnimation.From = Opacity;
			OpacityAnimation.To = 1;
			OpacityAnimation.Duration = TimeSpan.FromMilliseconds(200);

			BeginAnimation(OpacityProperty, OpacityAnimation);

			DoubleAnimation circulator_dissappearing = new DoubleAnimation();
			circulator_dissappearing.From = Circulator.Opacity;
			circulator_dissappearing.To = 0;
			circulator_dissappearing.Duration = TimeSpan.FromMilliseconds(400);
			circulator_dissappearing.EasingFunction = new ExponentialEase();

			Circulator.BeginAnimation(OpacityProperty, circulator_dissappearing);
		}
	}
}
