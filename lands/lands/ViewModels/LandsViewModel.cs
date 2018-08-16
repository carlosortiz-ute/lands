namespace lands.ViewModels
{
    using lands.Models;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using lands.Services;
    using Xamarin.Forms;

    public class LandsViewModel: BaseViewModel
    {


        #region servicios
        private ApiService apiservice;
        #endregion

        #region atributes
        private ObservableCollection<Land> lands;
        #endregion

        #region properties
        public ObservableCollection<Land> Lands
        {
            get { return this.lands; }

            set
            {
                var obj = this.lands;
                SetValue(ref obj, value);
                this.lands = obj;
            }

        }

        #endregion

        public LandsViewModel()
        {
            this.apiservice = new ApiService();
            this.loadLands();
        }

        #region metodos
        private async void loadLands()
        {
            var conection = await this.apiservice.CheckConnection();
            if (!conection.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("error", conection.Message, "OK");
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }

            var response = await this.apiservice.GetList<Land>("http://restcountries.eu", "/rest", "/v2/all");
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("error", response.Message, "OK");
             
                return;
            }

            var lista = (List<Land>)response.Result;
            this.Lands = new ObservableCollection<Land>(lista);
        } 
        #endregion
    }
}
