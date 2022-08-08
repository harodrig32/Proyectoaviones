using Acr.UserDialogs;
using Proyectoaviones.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Proyectoaviones.ViewModels
{
    public class ticketDetailsViewModel : BaseViewModel
    {
        private TicketsViewModel _vueloVM;

        public TicketsViewModel VueloVM
        {
            get { return _vueloVM; }
            set { _vueloVM = value; OnPropertyChanged(); }
        }

        public ICommand SaveVueloCommand { private set; get; }
        public ICommand DeleteVueloCommand { private set; get; }

        public ticketDetailsViewModel(TicketsViewModel vuelo)
        {
            VueloVM = vuelo;
            DeleteVueloCommand = new Command(async () => await DeleteVuelo());
        }

        

        async Task DeleteVuelo()
        {
            var confirm = await UserDialogs.Instance.ConfirmAsync("Are you sure?", "Delete?", "Yes", "No");

            if (confirm)
            {
                var hpVuelo = VueloVM.GetVuelo();
                var success = await App.Context.DeleteItemAsync<Ventas>(hpVuelo);
                await UserDialogs.Instance.AlertAsync((success > 0) ? "Success!" : "Error!", "Deleting...", "OK");
            }
        }
    }
}
