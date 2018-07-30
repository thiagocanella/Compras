using Compras.Banco;
using Compras.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compras.Services
{
    public static class RelationService
    {

        public static DbAccess<Relacao> dbAccess = new DbAccess<Relacao>();


        public static void Insert(Relacao relacao)
        {

            dbAccess.Save(relacao);
        }

        public static void Edit(Relacao relacao)
        {
            dbAccess.Update(relacao);
        }

        public static Relacao Load(int id)
        {
            return dbAccess.Find(x => x.IdProduto == id);
        }

        public static void Remove(int id)
        {
            dbAccess.Delete(id);
        }

        public static List<Relacao> ListAll()
        {
            return dbAccess.ListAll().ToList();
        }
    }
}
