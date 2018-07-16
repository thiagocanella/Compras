using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Compras.Models
{
    public class Listas : INotifyPropertyChanged
    {
        public Listas() {}

        private string nomeLista;
        private string criacao;
        public string Criacao
        {
            get { return criacao; }
            set
            {
                criacao = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(criacao)));

            }
        }



        public string NomeLista
        {
            get { return nomeLista; }
            set { nomeLista = value; this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(nomeLista))); } 

        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
