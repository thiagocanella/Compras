using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Compras.ViewModel;
using Compras ;
using Compras.Models;


namespace Compras
{
    public partial class ItemsView : ContentPage
    {
        public ItemsView(Listas item)
        {
            InitializeComponent();
            this.BindingContext = new ViewModel.ComprasViewModel();
            nomelistalocal = item.NomeLista;
            datadacriacao = item.Criacao;
            this.criacaoData.Text = datadacriacao;
            this.nomeDaLista.Text = nomelistalocal;

        }
        private string nomelistalocal;
        private string datadacriacao;

        public string NomeListaLocal { get { return nomelistalocal; } }

    }
}