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
				//Create a new account
				if (!Properties.Settings.Default.FirstTime)
				{
					System.Windows.Forms.MessageBox.Show("PCC Student Database System does not allow you to configure multiple accounts on the same computer / server. Please use the 'Login' option to log in to your current account. If you're having problems signing to your account, please contact the Ultra Admin from the link given in the bottom right corner.", "Does not allow multiple accounts", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
				}
				else
				{
					CreateAccountGrid.Margin = new Thickness(405, 0, 0, 0);

					DoubleAnimation da = new DoubleAnimation();
					da.From = 0;
					da.To = 1;
					da.Duration = TimeSpan.FromSeconds(1);
					da.EasingFunction = new QuinticEase();

					SignUpCancelButton.IsEnabled = true;

					CreateUserName.Focus();

					CreateAccountGrid.BeginAnimation(OpacityProperty, da);
				}
			}
		}

		private void Login_btn_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			//Log in to the account
			if (Properties.Settings.Default.FirstTime)
			{
				System.Windows.Forms.MessageBox.Show("No Administration account found in this computer. Please use the 'Create a New Account' button to create a new administration account to start working with this software", "No account found", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
			}
			else
			{
				LoginAccountGrid.Margin = new Thickness(405, 0, 0, 0);

				DoubleAnimation da = new DoubleAnimation();
				da.From = 0;
				da.To = 1;
				da.Duration = TimeSpan.FromSeconds(1);
				da.EasingFunction = new QuinticEase();

				LoginCancelButton.IsEnabled = true;

				LoginUserName.Focus();

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
			//Log the user in
			if (LoginUserName.Text == Properties.Settings.Default._username && LoginPassword.Password == Properties.Settings.Default._password)
			{
				//Password and user name matches to the records
				//Start the application
				HomePage home = new HomePage();
				home.Show();
				Close();
			}
			else
			{
				MessageBox.Show("Password or User Name does not match, please enter the correct credentials (user name and password). If you're persistently having problems signing in to your account, please be kind to contact the Ultra Admin from the link in the bottom right of the application.", "Credentials does not match", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private void SignUpBtn_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			//Sign the user up
			if (CreateUserName.Text.Trim() != "" && CreatePassword.Password.Trim() != "" && CreateConfirmPassword.Password.Trim() != "")
			{
				//Everything is okay.
				//Create the account and log in 
				if (CreatePassword.Password == CreateConfirmPassword.Password)
				{
					//The password and the confirmation is successful
					Properties.Settings.Default._username = CreateUserName.Text;
					Properties.Settings.Default._password = CreatePassword.Password;

					//Set the first time to false
					Properties.Settings.Default.FirstTime = false;

					Properties.Settings.Default.Save();

					MessageBox.Show("Administration Account creation completed. Now you're being automatically redirected to the PCC Studnet Database System. Thank you for using our software", "Account Successfully Created", MessageBoxButton.OK, MessageBoxImage.Information);
					
					//Start the application
					HomePage home = new HomePage();
					home.Show();
					Close();
				}
				else
				{
					MessageBox.Show("New password and the confirmation does not match. Please make sure that both 'Password' and 'Confirm password' fields are equal in content.", "Passwords does not match", MessageBoxButton.OK, MessageBoxImage.Exclamation);
				}
			}
		}

		private void CreateConfirmPassword_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
		{
			if (e.Key == System.Windows.Input.Key.Enter)
			{
				//Sign the user up
				if (CreateUserName.Text.Trim() != "" && CreatePassword.Password.Trim() != "" && CreateConfirmPassword.Password.Trim() != "")
				{
					//Everything is okay.
					//Create the account and log in 
					if (CreatePassword.Password == CreateConfirmPassword.Password)
					{
						//The password and the confirmation is successful
						Properties.Settings.Default._username = CreateUserName.Text;
						Properties.Settings.Default._password = CreatePassword.Password;

						//Set the first time to false
						Properties.Settings.Default.FirstTime = false;

						Properties.Settings.Default.Save();

						MessageBox.Show("Administration Account creation completed. Now you're being automatically redirected to the PCC Studnet Database System. Thank you for using our software", "Account Successfully Created", MessageBoxButton.OK, MessageBoxImage.Information);

						//Start the application
						HomePage home = new HomePage();
						home.Show();
						Close();
					}
					else
					{
						MessageBox.Show("New password and the confirmation does not match. Please make sure that both 'Password' and 'Confirm password' fields are equal in content.", "Passwords does not match", MessageBoxButton.OK, MessageBoxImage.Exclamation);
					}
				}
			}
		}

		private void LoginPassword_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
		{
			if(e.Key == System.Windows.Input.Key.Enter)
			{
				//Log the user in
				if (LoginUserName.Text == Properties.Settings.Default._username && LoginPassword.Password == Properties.Settings.Default._password)
				{
					//Password and user name matches to the records
					//Start the application
					HomePage home = new HomePage();
					home.Show();
					Close();
				}
				else
				{
					MessageBox.Show("Password or User Name does not match, please enter the correct credentials (user name and password). If you're persistently having problems signing in to your account, please be kind to contact the Ultra Admin from the link in the bottom right of the application.", "Credentials does not match", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
		}
	}
}