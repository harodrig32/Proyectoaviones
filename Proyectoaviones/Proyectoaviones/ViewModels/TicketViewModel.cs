using Proyectoaviones.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Proyectoaviones.ViewModels
{
    public class TicketViewModel : BaseViewModel
    {
        private ObservableCollection<TicketsViewModel> _vuelos;

        public ObservableCollection<TicketsViewModel> Vuelos
        {
            get { return _vuelos; }
            set { _vuelos = value; OnPropertyChanged(); }
        }

        private TicketsViewModel _selectedCharacter;

        public TicketsViewModel SelectedCharacter
        {
            get { return _selectedCharacter; }
            set { _selectedCharacter = value; OnPropertyChanged(); }
        }

        public ICommand SearchByNameCommand { private set; get; }
        public ICommand GoToDetailsCommand { private set; get; }
        public ICommand AddNewCharacterCommand { private set; get; }

        public INavigation Navigation { get; set; }

        public TicketViewModel(INavigation navigation)
        {
            Navigation = navigation;

            SearchByNameCommand = new Command<string>(async (name) => await LoadData(name));
            GoToDetailsCommand = new Command<Type>(async (pageType) => await GoToDetails(pageType));
        }

        async Task LoadData(string name)
        {
            Vuelos = new ObservableCollection<TicketsViewModel>();
            var hpVuelos = await App.Context.GetItemsAsync<Ventas>();
               


            foreach (var item in hpVuelos)
                Vuelos.Add(new TicketsViewModel(item));
        }

        async Task GoToDetails(Type pageType)
        {
            if (SelectedCharacter != null)
            {
                var page = (Page)Activator.CreateInstance(pageType);
                //page.BindingContext = new VueloDetailsViewModel(SelectedCharacter);
                await Navigation.PushAsync(page);

                SelectedCharacter = null;
            }
        }

    }
}
