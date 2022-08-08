using Proyectoaviones.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proyectoaviones.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class menu : ContentPage
    {
        public menu()
        {
            InitializeComponent();

            BindingContext = new MenuViewModel();
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ViewModels.Menu d = (ViewModels.Menu)e.Item;

            if (d.Name == "Ver Vuelos")
            {

                await Navigation.PushModalAsync(new VuelosListView());
                //   await Navigation.PushAsync(new NavigationPage(new VuelosListView()));

                // Navigation.PushAsync(new VuelosListView());
            }
            else if (d.Name == "Comprar Boletos")
            {
                await Navigation.PushModalAsync(new ListadoVuelos());

            }
            else if (d.Name == "Ver Ticket") {

                await Navigation.PushModalAsync(new Listadotickets());
            }
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}