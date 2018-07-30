using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Compras.ViewModel;
using Compras;
using Compras.Models;
using Rg.Plugins.Popup.Services;
using Compras.Services;
using System.Collections.ObjectModel;
using Acr.UserDialogs;

namespace Compras
{
    public partial class ItemsView : ContentPage
    {
        public ItemsView(Listas item)
        {

            LocalItem = item;
            InitializeComponent();
            this.BindingContext = new ViewModel.ComprasViewModel(item.Id);
            nomelistalocal = item.NomeLista;
            datadacriacao = $"{item.DiaCompra.ToString("dd/MM/yyyy")}";
            this.criacaoData.Text = datadacriacao;
            this.nomeDaLista.Text = nomelistalocal;

            itemview.ItemTapped += async (sender, args) =>
            {
                var itemget = args.Item as Models.Item;
                if (itemget == null) return;
                await PopupNavigation.Instance.PushAsync(new PopupEditItem(itemget));
                itemview.SelectedItem = null;
            };



            FloatingActionButtonAdd.Clicked += async (sender, args) =>
            {

                await PopupNavigation.Instance.PushAsync(new PopupItem(LocalItem));

            };


        }


        private Listas _localitem;
        private Listas LocalItem { get { return _localitem; } set { _localitem = value; } }
        private string nomelistalocal;
        private string datadacriacao;

        public string NomeListaLocal { get { return nomelistalocal; } }
 
        void DeleteLista(object sender, EventArgs args)
        {
            try
            {
                ListaService.Remove(LocalItem.Id);
                App.Current.MainPage = new ListsView();
                var toastConfig = new ToastConfig("   Lista Deletada");
                toastConfig.SetDuration(3000);
                toastConfig.SetBackgroundColor(System.Drawing.Color.FromArgb(70, 70, 70));
                UserDialogs.Instance.Toast(toastConfig);
            }
            catch { }
        }

    }
}