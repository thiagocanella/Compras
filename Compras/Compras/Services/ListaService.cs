using Compras.Models;
using Compras.Banco;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Compras.Services
{
    public static class ListaService
    {

        public static DbAccess<Listas> dbAccess = new DbAccess<Listas>();


        public static void Insert(Listas lista)
        {
            
            dbAccess.Save(lista);
        }

        public static void Edit(Listas lista)
        {
            dbAccess.Update(lista);
        }

        public static Listas Load(int id)
        {
            return dbAccess.Find(x => x.Id == id);
        }

        public static void Remove(int id)
        {
            dbAccess.Delete(id);
        }

        public static List<Listas> ListAll()
        {
            return dbAccess.ListAll().ToList();
        }

    }
}
