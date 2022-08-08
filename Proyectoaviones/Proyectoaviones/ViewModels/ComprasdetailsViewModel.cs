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
    public class ComprasdetailsViewModel : BaseViewModel
    {
        private VueloViewModel _vueloVM;

        public VueloViewModel VueloVM
        {
            get { return _vueloVM; }
            set { _vueloVM = value; OnPropertyChanged(); }
        }

        public ICommand SaveVueloCommand { private set; get; }
        public ICommand DeleteVueloCommand { private set; get; }

        public ComprasdetailsViewModel(VueloViewModel vuelo)
        {
            VueloVM = vuelo;
            SaveVueloCommand = new Command(async () => await SaveVenta());
            //DeleteVueloCommand = new Command(async () => await DeleteVuelo());
        }

        async Task SaveVenta()
        {
            var isInsert = false;

            Ventas O_ventas = new Ventas();

            if (string.IsNullOrWhiteSpace(O_ventas._id))
            {
                O_ventas._id = Guid.NewGuid().ToString();
                isInsert = true;
            }

            O_ventas.cliente = "Hugo Rodriguez";
            O_ventas.idvuelo = VueloVM._id;
            O_ventas.cantidad = "10";
            O_ventas.precio = "100";
            O_ventas.total = (Convert.ToInt32("10") * Convert.ToInt32("100")).ToString();


           // var hpVuelo = VueloVM.GetVuelo();
            var success = await App.Context.SaveItemAsync<Ventas>(O_ventas, isInsert);
            await UserDialogs.Instance.AlertAsync((success > 0) ? "Success!" : "Error!", "Saving...", "OK");
        }

        async Task DeleteVuelo()
        {
            var confirm = await UserDialogs.Instance.ConfirmAsync("Are you sure?", "Delete?", "Yes", "No");

            if (confirm)
            {
                var hpVuelo = VueloVM.GetVuelo();
                var success = await App.Context.DeleteItemAsync<Vuelos>(hpVuelo);
                await UserDialogs.Instance.AlertAsync((success > 0) ? "Success!" : "Error!", "Deleting...", "OK");
            }
        }
    }
}
