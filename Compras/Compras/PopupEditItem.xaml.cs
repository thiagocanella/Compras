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
	public partial class PopupEditItem : PopupPage
    {
		public PopupEditItem (Item entry)
		{
            InitializeComponent();


            _localitem = entry;
            
            inputName.Placeholder = _localitem.Nome;
            
            this.BindingContext = new ItemUpdViewModel(_localitem.Nome, _localitem.Id, _localitem.IdListaPertencente , _localitem.Qnt, _localitem.Pegou);

        }
        public Item _localitem;
        async void UpdClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(inputName.Text))
            {
                return;
            }
            else
            {
                PopupNavigation.Instance.PopAsync(true);
            }

        }

        async void DeleteClicked(object sender, EventArgs e)
        {

            PopupNavigation.Instance.PopAsync(true);

        }
    }
}