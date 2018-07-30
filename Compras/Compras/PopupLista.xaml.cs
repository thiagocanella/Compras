using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Compras.ViewModel;
using Rg.Plugins.Popup.Services;
using Compras.Models;
using Acr.UserDialogs;

namespace Compras
{
	
	public partial class PopupLista : PopupPage
    {
		public PopupLista()
		{
			InitializeComponent();
            this.BindingContext = new ListasViewModel();

        }
        void AddClicked(object sender, EventArgs e)
        {
            if (inputName.Text == "" || inputName.Text == null)
            {
                return;
            }
            else
            {
                PopupNavigation.Instance.PopAsync(true);
                App.Current.MainPage = new ListsView();
                var toastConfig = new ToastConfig("   Lista Adicionada");
                toastConfig.SetDuration(3000);
                toastConfig.SetBackgroundColor(System.Drawing.Color.FromArgb(70, 70, 70));
                UserDialogs.Instance.Toast(toastConfig);
            }
        }
    }
}