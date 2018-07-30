﻿using Compras.Banco;
using Compras.Helpers;
using Compras.Models;
using PCLExt.FileStorage;
using PCLExt.FileStorage.Folders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Compras.Services
{
    public static class UserService
    {
        public static DbAccess<User> dbAccess = new DbAccess<User>();

        public static void Insert(User user)
        {
               dbAccess.Save(user);
        }

        public static User Authenticate(string email, string password)
        {
            var user = dbAccess.Find(x => x.Email.ToLower().Equals(email.ToLower()));
            if (user != null)
            {
                Edit(user);
                return user;
            }

            return null;
        }

        public static void Edit(User user)
        {
            dbAccess.Update(user);
        }

        public static User Load(int id)
        {
            return dbAccess.Find(x => x.id == 1);
        }

        public static void Remove(int id)
        {
            dbAccess.Delete(id);
        }

        


        public static List<User> List(Expression<Func<User, bool>> predicate)
        {
            return dbAccess.List(predicate).ToList();
        }

        public static List<User> ListAll()
        {
            return dbAccess.ListAll().ToList();
        }

        public async static Task<string> SaveOrUpdatePhoto(Stream stream, string email)
        {
            //Create File Photo
            var rootFolder = new LocalRootFolder();
            var folder = await rootFolder.CreateFolderAsync(email, CreationCollisionOption.OpenIfExists);
            var file = await folder.CreateFileAsync("profile.jpg", CreationCollisionOption.ReplaceExisting);

            var memory = new MemoryStream();
            stream.CopyTo(memory);
            byte[] bytes = memory.ToArray();

            file.WriteAllBytes(bytes);
            Settings.UrlPhoto = file.Path;
            return file.Path;
        }
    }
}
