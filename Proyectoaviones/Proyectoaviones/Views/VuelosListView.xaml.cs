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
    public partial class VuelosListView : ContentPage
    {
        VuelosListViewModel vm;
        public VuelosListView()
        {
            InitializeComponent();

            vm = new VuelosListViewModel(Navigation);
            BindingContext = vm;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.SearchByNameCommand.Execute(string.Empty);
        }
    }
}