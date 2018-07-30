using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compras.Models;
using Compras.ViewModel;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Compras
{
	//[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListsView : ContentPage 
	{
        public ListsView()
		{
            
            InitializeComponent();
            this.BindingContext = new ViewModel.ListasViewModel();
            listView.ItemTapped += async (sender, args) =>
            {
                var item = args.Item as Listas;
                if (item == null) return;
                App.Current.MainPage.Navigation.PushModalAsync(new ItemsView(item));
                listView.SelectedItem = null;
            };

            FloatingActionButtonAdd.Clicked += async (sender, args) =>
            {

                await PopupNavigation.Instance.PushAsync(new PopupLista());
                
            };



        }

        private async void Cadastro_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new PopupLista());
        }


}
}