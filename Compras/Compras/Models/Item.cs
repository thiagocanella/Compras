using Acr.UserDialogs;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Compras.Models
{
    public class Item : INotifyPropertyChanged

    {
        public Item() { }

        public event PropertyChangedEventHandler PropertyChanged;


        public int Qnt
        {
            get
            { return Quantidade; }
            set
            {
                if (value == 0)
                {
                    Quantidade = 1;
                }
                else
                {
                    Quantidade = value;
                }

            }

        }


        public int IdListaPertencente { get; set; }
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Pegou { get; set; }
        public int Quantidade { get; set; }

    }
}
