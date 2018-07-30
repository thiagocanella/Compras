using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Compras.Models
{
    public class Listas : INotifyPropertyChanged
    {
        public Listas() { }
        public event PropertyChangedEventHandler PropertyChanged;

        public DateTime Criacao {
            get
            {
                return Cria;
            }
            set
            {
                Cria = value;
            }
            }

        public string CriacaoFormated
        {
            get { return Cria.ToString("dd/MM/yyyy"); }
        }

        public DateTime DiaCompra
        {
            get
            {
                return Dia;
            }
            set
            {
                Dia = value;
            }
        }




        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string NomeLista { get; set; }
        private DateTime Dia { get; set; }
        private DateTime Cria { get; set; }





    }
}
