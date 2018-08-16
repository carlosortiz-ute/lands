using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Xamarin.Forms;

namespace lands
{
    using lands.Views;
    public partial class App : Application
	{
        #region constructores

        
        public App ()
		{
			InitializeComponent();

			MainPage = new  NavigationPage(  new LoginPage());
		}
        #endregion
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
