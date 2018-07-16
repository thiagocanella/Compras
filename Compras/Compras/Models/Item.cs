using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Compras.Models
{
    public class Item : INotifyPropertyChanged

    {

        public Item() { }
        private string nomeitem;
        private bool pegou;
        private string id;


        public string ID
        {
            get { return id; }
            set { id = value; this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(id))); }
        }

        public string Nome
        {
            get { return nomeitem; }
            set { nomeitem = value; this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(nomeitem))); }
        }
        public bool Pegou { get { return pegou; }
            set { pegou = value; this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(pegou))); }
        }
        public event PropertyChangedEventHandler PropertyChanged;


    }
}
