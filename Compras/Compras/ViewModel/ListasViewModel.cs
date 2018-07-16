using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Compras.Models;

namespace Compras.ViewModel
{
    public class ListasViewModel : BaseViewModel
    {
        public ICommand AdicionarLista { get; set; }
        public ICommand RemoverLista { get; set; }
        private string _novalista = "";
        public string NovaLista{
            get { return _novalista; }

            set { _novalista = value; } }
        private int _id;
        public int ID { get { return _id; } set { _id = value; } }


        public ObservableCollection<Models.Listas> Listado { get; set; }


        public ListasViewModel()
        {
            Listado = new ObservableCollection<Models.Listas>();


            RemoverLista = new Xamarin.Forms.Command(() => { if (Listado.Count > 0) { Listado.RemoveAt(Listado.Count - 1); } });


            AdicionarLista = new Xamarin.Forms.Command(() => { Listado.Add(new Models.Listas { NomeLista = NovaLista, Criacao = $"{DateTime.Now}" }); });

        }


        
    }
}
