using System;
using System.Collections.Generic;
using System.Text;

namespace lands.ViewModels
{
    class MainViewModel
    {
        public LoginViewModel Login { get; set; }
        public LandsViewModel Lands { get; set; }

        public MainViewModel()
        {
            instance = this;
            this.Login = new LoginViewModel();
        }

        #region Singleton
        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }
            return instance;
        }   
        #endregion
    }
}
