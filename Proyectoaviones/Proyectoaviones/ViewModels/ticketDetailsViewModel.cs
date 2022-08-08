using System;
using System.Collections.Generic;
using System.Text;

namespace Proyectoaviones.ViewModels
{
    public class ticketDetailsViewModel
    {
        private VueloViewModel _vueloVM;

        public VueloViewModel VueloVM
        {
            get { return _vueloVM; }
            set { _vueloVM = value; OnPropertyChanged(); }
        }

        public ICommand SaveVueloCommand { private set; get; }
        public ICommand DeleteVueloCommand { private set; get; }

        public VueloDetailsViewModel(VueloViewModel vuelo)
        {
            VueloVM = vuelo;
            SaveVueloCommand = new Command(async () => await SaveVuelo());
            DeleteVueloCommand = new Command(async () => await DeleteVuelo());
        }

        async Task SaveVuelo()
        {
            var isInsert = false;

            if (string.IsNullOrWhiteSpace(VueloVM._id))
            {
                VueloVM._id = Guid.NewGuid().ToString();
                isInsert = true;
            }

            var hpVuelo = VueloVM.GetVuelo();
            var success = await App.Context.SaveItemAsync<Vuelos>(hpVuelo, isInsert);
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
