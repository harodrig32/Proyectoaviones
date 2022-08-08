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
    public class VuelosListViewModel : BaseViewModel
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

        public VuelosListViewModel(INavigation navigation)
        {
            Navigation = navigation;

            SearchByNameCommand = new Command<string>(async (name) => await LoadData(name));
            GoToDetailsCommand = new Command<Type>(async (pageType) => await GoToDetails(pageType));
            AddNewCharacterCommand = new Command<Type>(async (pageType) => await AddNewCharacter(pageType));
        }

        async Task LoadData(string name)
        {
            Vuelos = new ObservableCollection<VueloViewModel>();
            var hpVuelos = string.IsNullOrWhiteSpace(name)
                ? await App.Context.GetItemsAsync<Vuelos>()
                : await App.Context.FilterItemsAsync<Vuelos>("Vuelos", $"Origen LIKE '%{name}%'");

            foreach (var item in hpVuelos)
                Vuelos.Add(new VueloViewModel(item));
        }

        async Task GoToDetails(Type pageType)
        {
            if (SelectedCharacter != null)
            {
                var page = (Page)Activator.CreateInstance(pageType);
                page.BindingContext = new VueloDetailsViewModel(SelectedCharacter);
                await Navigation.PushAsync(page);

                SelectedCharacter = null;
            }
        }

        async Task AddNewCharacter(Type pageType)
        {
            SelectedCharacter = null;

            var page = (Page)Activator.CreateInstance(pageType);
            page.BindingContext = new VueloDetailsViewModel(new VueloViewModel());

            await Navigation.PushModalAsync(page);
           // await Navigation.PushAsync(page);
        }
    }
}
