using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace PCCSDS
{
	/// <summary>
	/// Interaction logic for Start.xaml
	/// </summary>
	public partial class Start : Window
	{
		public Start()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Starts the loading animations of the window even in Windows XP.
		/// </summary>
		private void StartAnimations()
		{

			//Initialize the loading animations
			DoubleAnimation OpAnim = new DoubleAnimation();
			OpAnim.From = 0;
			OpAnim.To = 1;
			OpAnim.Duration = TimeSpan.FromMilliseconds(1000);
			OpAnim.EasingFunction = new QuinticEase();

			StartWindow.BeginAnimation(OpacityProperty, OpAnim);

			DoubleAnimation da = new DoubleAnimation();
			da.From = StartWindow.Width;
			da.To = StartWindow.Width + 200;
			da.Duration = TimeSpan.FromMilliseconds(1000);
			da.EasingFunction = new QuinticEase();

			StartWindow.BeginAnimation(WidthProperty, da);

			DoubleAnimation da2 = new DoubleAnimation();
			da2.From = StartWindow.Left;
			da2.To = StartWindow.Left - 100;
			da2.Duration = TimeSpan.FromMilliseconds(1000);
			da2.EasingFunction = new QuinticEase();

			StartWindow.BeginAnimation(LeftProperty, da2);

		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			//Start the Window Animations
			StartAnimations(); //QuinticEase looks awesome and looks just like Windows 8.1 and highe animations (especially in Window 10)
		}
	}
}
