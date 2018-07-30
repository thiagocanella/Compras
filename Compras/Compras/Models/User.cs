using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compras.Models
{
    public class User
    {
        public int id = 1;

        public string Name { get; set; }
        public string Email { get; set; }
        public string UrlPhoto { get; set; }
        public string CreationDate { get; set; }

        
    }
}
