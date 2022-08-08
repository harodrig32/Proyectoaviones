using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
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
    public partial class Comprar : PopupPage
    {
        public Comprar()
        {
            InitializeComponent();
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }

        private void Confirmar_Clicked(object sender, EventArgs e)
        {

        }
    }
}