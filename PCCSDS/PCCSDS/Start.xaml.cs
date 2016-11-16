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
			LoginGrid.Margin = new Thickness(StartWindow.Width, 0, 0, 0);

			//Set the options available for you.
			if (Properties.Settings.Default.FirstTime)
			{
				LogInButton.IsEnabled = false;
			}
			else
			{
				SignUpBtn.IsEnabled = false;
			}
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			ThicknessAnimation ti = new ThicknessAnimation();
			ti.From = new Thickness(StartWindow.Width, 0, 0, 0);
			ti.To = new Thickness(405, 0, 0, 0);
			ti.BeginTime = TimeSpan.FromMilliseconds(200);
			ti.Duration = TimeSpan.FromSeconds(1);
			ti.EasingFunction = new QuinticEase();

			LoginGrid.BeginAnimation(MarginProperty, ti);
		}

		private void contactAdmin_btn_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			//Ultra Admin Contact Methods
			System.Diagnostics.Process.Start("http://www.facebook.com/c.chamandana");
		}

		private void CreateAccount_btn_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			if (CreateAccount_btn.IsEnabled)
			{
				CreateAccountGrid.Margin = new Thickness(405, 0, 0, 0);

				DoubleAnimation da = new DoubleAnimation();
				da.From = 0;
				da.To = 1;
				da.Duration = TimeSpan.FromSeconds(1);
				da.EasingFunction = new QuinticEase();

				SignUpCancelButton.IsEnabled = true;

				CreateAccountGrid.BeginAnimation(OpacityProperty, da);
			}
		}

		private void Login_btn_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			if (LogInButton.IsEnabled)
			{
				LoginAccountGrid.Margin = new Thickness(405, 0, 0, 0);

				DoubleAnimation da = new DoubleAnimation();
				da.From = 0;
				da.To = 1;
				da.Duration = TimeSpan.FromSeconds(1);
				da.EasingFunction = new QuinticEase();

				LoginCancelButton.IsEnabled = true;

				LoginAccountGrid.BeginAnimation(OpacityProperty, da);
			}
		}

		private void Button_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			DoubleAnimation da = new DoubleAnimation();
			da.From = 1;
			da.To = 0;
			da.Duration = TimeSpan.FromSeconds(1);
			da.EasingFunction = new QuinticEase();
			da.Completed += Da_Completed;

			LoginCancelButton.IsEnabled = false;

			LoginAccountGrid.BeginAnimation(OpacityProperty, da);
		}

		private void Da_Completed(object sender, EventArgs e)
		{
			LoginAccountGrid.Margin = new Thickness(StartWindow.Width, 0, 0, 0);
			CreateAccountGrid.Margin = new Thickness(StartWindow.Width, 0, 0, 0);

		}

		private void SignUpCancelButton_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			DoubleAnimation da = new DoubleAnimation();
			da.From = 1;
			da.To = 0;
			da.Duration = TimeSpan.FromSeconds(1);
			da.EasingFunction = new QuinticEase();
			da.Completed += Da_Completed;

			SignUpCancelButton.IsEnabled = false;

			CreateAccountGrid.BeginAnimation(OpacityProperty, da);
		}

		private void LogInButton_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			//Log in to the account

		}

		private void SignUpBtn_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			//Create a new account
			
		}
	}
}
