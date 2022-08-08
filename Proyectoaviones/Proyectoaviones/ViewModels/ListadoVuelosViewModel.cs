using Proyectoaviones.Models;
using Proyectoaviones.Views;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Proyectoaviones.ViewModels
{
    public class ListadoVuelosViewModel : BaseViewModel
    {
        private ObservableCollection<VueloViewModel> _vuelos;

        public ObservableCollection<VueloViewModel> Vuelos
        {
            get { return _vuelos; }
            set { _vuelos = value; OnPropertyChanged(); }
        }

        private VueloViewModel _selectedCharacter;

        public VueloViewModel SelectedCharacter
        {
            get { return _selectedCharacter; }
            set { _selectedCharacter = value; OnPropertyChanged(); }
        }

        public ICommand SearchByNameCommand { private set; get; }
        public ICommand GoToDetailsCommand { private set; get; }
        public ICommand AddNewCharacterCommand { private set; get; }

        public INavigation Navigation { get; set; }

        public ListadoVuelosViewModel(INavigation navigation)
        {
            Navigation = navigation;

            SearchByNameCommand = new Command<string>(async (name) => await LoadData(name));
            GoToDetailsCommand = new Command<Type>(async (pageType) => await GoToDetails(pageType));
            AddNewCharacterCommand = new Command<Type>(async (pageType) => await AddNewCharacter(pageType));
        }

        async Task LoadData(string name)
        {
            Vuelos = new ObservableCollection<VueloViewModel>();
            var hpVuelos = await App.Context.GetItemsAsync<Vuelos>();
            var hpVuelosn = await App.Context.ObtenerVentas<Ventas>();
            //List<Ventas> listofGenres = await App.Context.ObtenerVentas<Ventas>();


            var d = await App.Context.connection.QueryAsync<Ventas>($"SELECT IdVuelo, SUM(cantidad) AS cantidad FROM Ventas Group By IdVuelo");

            foreach (var item in hpVuelos) {

                if (d.Count > 0)
                {
                    foreach (var itemem in d) {


                        if (itemem.idvuelo == item._id && Convert.ToInt32(itemem.cantidad) < Convert.ToInt32(item.numeroasientos)) {

                            Vuelos.Add(new VueloViewModel
                            {
                                _id = item._id,
                                aerolinea = item.aerolinea,
                                origen = item.origen,
                                destino = item.destino,
                                hora = item.hora,
                                fecha = item.fecha,
                                horallegada = item.horallegada,
                                fechallegada = item.fechallegada,
                                numeroasientos = (Convert.ToInt32(item.numeroasientos) - Convert.ToInt32(itemem.cantidad)).ToString()
                            });
                        
                        }
                    }

                }
                else {

                    Vuelos.Add(new VueloViewModel(item));
                }
                
            }
                
        }

        async Task GoToDetails(Type pageType)
        {
            if (SelectedCharacter != null)
            {
                var page = (PopupPage)Activator.CreateInstance(pageType);
                page.BindingContext = new ComprasdetailsViewModel(SelectedCharacter);
               // await Navigation.PushModalAsync(page);// await Navigation.PushAsync(page);
                await PopupNavigation.Instance.PushAsync(page, true);
                SelectedCharacter = null;
            }
        }

        async Task AddNewCharacter(Type pageType)
        {
            SelectedCharacter = null;

            var page = (Page)Activator.CreateInstance(pageType);
            page.BindingContext = new VueloDetailsViewModel(new VueloViewModel());
            await Navigation.PushAsync(page);
        }

    }
}
