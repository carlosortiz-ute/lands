


namespace lands.ViewModels
{
    using GalaSoft.MvvmLight.Command;
  //  using System.ComponentModel;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Views;
    using Microsoft.AppCenter.Analytics;

    class LoginViewModel : BaseViewModel
    {
        #region eventos
       // public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region atributes
        public string password { get; set; }
        private bool isRunning { get; set; }
        private bool isEnabled { get; set; }
        #endregion

        #region properties
        public string Email { get; set; }
        public string Password {
            get {  return this.password;  }

         

            set {
                var obj = this.password;
                SetValue(ref obj, value);
                this.password = obj;
            }

        }
        public bool IsRunning {
            get
            {
                return this.isRunning;
            }

            set
            {
                var obj = this.isRunning;
                SetValue(ref obj, value);
                this.isRunning = obj;
            }
        }
        public bool IsRemember { get; set; }
        public bool IsEnabled
        {
            get
            {
                return this.isEnabled;
            }

            set
            {
                var obj = this.isEnabled;
                SetValue(ref obj, value);
                this.isEnabled = obj;
            }
        }
        #endregion
        #region contructor

        public LoginViewModel()
        {
            this.IsRemember = true;
            this.IsEnabled = true;
            this.Email = "cortiz";
            this.Password = "cortiz";

        } 
        #endregion
        public ICommand LoginCommand
        {

            get
            {
                return new RelayCommand(Login);
            }


        }

       

        public async void Login()
        {
            this.IsRemember = false;
            Analytics.TrackEvent("Login");
         

            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Ingrese el usuario", "OK");
                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Ingrese el password", "OK");
                return;
            }
            this.IsRunning = true;
            this.IsEnabled = false;
            //if (this.Password!="cortiz")
            //{
            //    this.IsRunning = false;
            //    this.IsEnabled = true;
            //    this.Password = string.Empty;
            //}

            this.IsRunning = false;
            this.IsEnabled = true;
            MainViewModel.GetInstance().Lands = new LandsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new LandsPage());



        }
    }
}
