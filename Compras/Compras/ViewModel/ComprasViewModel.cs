using Compras.Banco;
using Compras.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace Compras.ViewModel
{
    public class ComprasViewModel : BaseViewModel
    {
        public ICommand AdicionarItem { get; set; }
        public ICommand RemoverItem { get; set; }
        private string _novoitem = "";
        public string NovoItem {
            get { return _novoitem; }

                set { _novoitem = value; } }

        private string _listID;
        public string ListID {
            get { 
                return _listID; }
            set { _listID = value; }
        }


        public ObservableCollection<Models.Item> Items { get; set; }
     

        public ComprasViewModel()
        {
            Items = new ObservableCollection<Models.Item>();
            RemoverItem = new Xamarin.Forms.Command(() => { if (Items.Count > 0) { Items.RemoveAt(Items.Count - 1); } });


            AdicionarItem = new Xamarin.Forms.Command(() => { Items.Add(new Models.Item { Nome = NovoItem, Pegou = false,ID = ListID }); } );
        }
    }
}
