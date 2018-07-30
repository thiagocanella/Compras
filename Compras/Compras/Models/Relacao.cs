using System;
using System.Collections.Generic;
using System.Text;

namespace Compras.Models
{
    public class Relacao
    {
        private int _idlista;
        private int _idproduto;

        public int IdLista
        {
            get { return _idlista; }
            set { _idlista = value; }
        }


        public int IdProduto
        {
            get { return _idproduto; }
            set { _idproduto = value; }
        }

    }
}
