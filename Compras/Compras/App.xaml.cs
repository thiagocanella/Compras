using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Compras.Services;
using Compras.Helpers;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace Compras
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();
            if (string.IsNullOrEmpty(Settings.Email) || string.IsNullOrEmpty(Settings.Name))
            {
                MainPage = new InputPage();
            }
            else
            {
                MainPage = new ListsView();
            }
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
