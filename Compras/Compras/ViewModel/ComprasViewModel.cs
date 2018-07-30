using Acr.UserDialogs;
using Compras.Banco;
using Compras.Models;
using Compras.Services;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;


namespace Compras.ViewModel
{
    public class ComprasViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public ICommand AdicionarItem { get; set; }
        public ICommand RemoverItem { get; set; }
        public ICommand RemoverLista { get; set; }
        public ICommand AdicionarItemPorFora { get; set; }


        public ComprasViewModel(int id)
        {

            IDherdada = id;
            _item = new ObservableCollection<Models.Item>();
            Items = _item;
            Retrieve();
            AdicionarItemPorFora = new Command(AddFora);
            RemoverLista = new Command(RemoveLista);
            RemoverItem = new Command(Remover);
            AdicionarItem = new Command(Adicionar);


            MessagingCenter.Subscribe<Item>(this, "MandaComando", (e) =>
            {
                Retrieve();
            });

            MessagingCenter.Subscribe<Item>(this, "UpdItemReceiver", (e) =>
            {
                UpdateItem(e);
            });


            MessagingCenter.Subscribe<Item>(this, "DeleteItemReceiver", (e) =>
            {
                DeleteItem(e);
            });


        }

        private void AddFora()
        {

            if (NovoItem == null || NovoItem == "")
            {
                return;
            }
            else
            {
                Item temp = new Item();
                Adicionar();
                MessagingCenter.Send<Item>(temp, "MandaComando");
            }
        }

        public void DeleteItem(Item todelete)
        {
            Retrieve();
            ItemService.Remove(todelete.Id);
            Retrieve();
            MessagingCenter.Send<Item>(todelete, "MandaComando");
        }

        public void UpdateItem(Item toupdate)
        {
            Retrieve();

            ItemService.Edit(toupdate);
            Retrieve();
            MessagingCenter.Send<Item>(toupdate, "MandaComando");

        }

        public int IDherdada { get; set; }

        private string _novoitem = "";
        public string NovoItem
        {
            get { return _novoitem; }

            set { _novoitem = value; }
        }


        private ObservableCollection<Models.Item> _item { get; set; }
        public ObservableCollection<Models.Item> Items
        {
            get
            {
                return _item;
            }

            set
            {
                _item = value;
                NotifyPropertyChanged("Item");

            }
        }
        private string _erro;
        public string Erro
        {
            get
            {
                return _erro;
            }

            set
            {
                _erro = value;
                NotifyPropertyChanged("Erro");
            }
        }

        public List<Models.Item> Filter()
        {
            List<Relacao> relfilter = new List<Relacao>();
            relfilter = RelationService.ListAll();
            for (int x = relfilter.Count - 1; x >= 0; x--)
            {
                if (relfilter[x].IdLista != IDherdada)
                {
                    relfilter.RemoveAt(x);
                }
            }
            List<Models.Item> temp = new List<Models.Item>(ItemService.ListAll());
            List<Models.Item> aux = new List<Models.Item>();
            for (int x = 0; x < temp.Count; x++)
            {
                for (int y = 0; y < relfilter.Count; y++)
                {
                    if (relfilter[y].IdProduto == temp[x].Id)
                    {
                        aux.Add(temp[x]);

                    }
                }
            }

            return aux;
        }

        private void Retrieve()
        {



            Items.Clear();
            List<Models.Item> temp = new List<Models.Item>();
            temp = Filter();
            foreach (Models.Item element in temp)
            {
                Items.Add(element);
            }



        }

        private void RemoveLista()
        {
            try
            {
                ListaService.Remove(IDherdada);
                App.Current.MainPage = new ListsView();

            }
            catch { }
        }



        private void Remover()
        {
            try
            {
                if (Items.Count > 0)
                {
                    ItemService.Remove(Items[Items.Count - 1].Id);
                    Items.RemoveAt(Items.Count - 1);
                }


            }
            catch { }
        }

        public int Quantidade { get; set; }

        public void Adicionar()
        {


            try
            {
                Retrieve();
                Models.Item items = new Models.Item { Nome = NovoItem, Pegou = false, IdListaPertencente = IDherdada, Qnt = Quantidade };
                ItemService.Insert(items);
                Relacao relation = new Relacao();
                Items.Add(items);
                relation.IdProduto = items.Id;
                relation.IdLista = IDherdada;
                RelationService.Insert(relation);
                Retrieve();


            }
            catch (Exception ex)
            {
                Erro = ex.Message;

            }
        }



    }
}
