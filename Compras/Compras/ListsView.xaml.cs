using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compras.Models;
using Compras.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Compras
{
	//[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListsView : ContentPage 
	{
        private int _id = 0;
        public ListsView()
		{
            
            InitializeComponent();
            this.BindingContext = new ViewModel.ListasViewModel();
            listView.ItemTapped += async (sender, args) =>
            {
                var item = args.Item as Listas;
                if (item == null) return;
                await App.Current.MainPage.Navigation.PushModalAsync(new ItemsView(item));
                listView.SelectedItem = null;
                _id++;
            };
        }



}
}