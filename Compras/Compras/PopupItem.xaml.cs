using Compras.Models;
using Compras.ViewModel;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Syncfusion.SfNumericUpDown.XForms;
using Acr.UserDialogs;

namespace Compras
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PopupItem : PopupPage
    {
        public PopupItem(Listas item )
        {
           
            _localitem = item;
            InitializeComponent();
            this.BindingContext = new ViewModel.ComprasViewModel(item.Id);

        }
        private Listas _localitem;

        async void AddClicked(object sender, EventArgs e)
        {
            if (inputName.Text == "" || inputName.Text == null)
            {
                return;
            }
            else
            {
                PopupNavigation.Instance.PopAsync(true);
                var toastConfig = new ToastConfig("   Item Adicionado");
                toastConfig.SetDuration(3000);
                toastConfig.SetBackgroundColor(System.Drawing.Color.FromArgb(70, 70, 70));
                UserDialogs.Instance.Toast(toastConfig);

            }
        }
    }
}