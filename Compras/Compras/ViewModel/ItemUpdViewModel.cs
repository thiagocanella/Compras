using Acr.UserDialogs;
using Compras.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Compras.ViewModel
{
    public class ItemUpdViewModel
    {
        public ICommand SendToListenerUpdate { get; set; }
        public ICommand DeleteOnListener { get; set; }

        public ItemUpdViewModel(string nome, int id, int idlista, int qnt, bool pegou)
        {
            Nome = nome;
            Id = id;
            IdListaPertencente = idlista;
            Qnt = qnt;
            Pegou = pegou;
            SendToListenerUpdate = new Command(SendMessageUpdate);
            DeleteOnListener = new Command(SendMessageDelete);
        }

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
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Pegou { get; set; }
        public int Quantidade { get; set; }

        private void SendMessageUpdate()
        {
            if (Nome == "" || Nome == null)
            {
                return;
            }
            else
            {
                Item temp = new Item() { Nome = Nome, Id = Id, Pegou = Pegou, IdListaPertencente = IdListaPertencente, Qnt = Qnt };
                MessagingCenter.Send<Item>(temp, "UpdItemReceiver");
                var toastConfig = new ToastConfig("   Item Atualizado");
                toastConfig.SetDuration(3000);
                toastConfig.SetBackgroundColor(System.Drawing.Color.FromArgb(70, 70, 70));
                UserDialogs.Instance.Toast(toastConfig);

            }

        }

        private void SendMessageDelete()
        {
            Item temp = new Item() { Nome = Nome, Id = Id, Pegou = Pegou, IdListaPertencente = IdListaPertencente, Qnt = Qnt };
            MessagingCenter.Send<Item>(temp, "DeleteItemReceiver");
            var toastConfig = new ToastConfig("   Item Removido");
            toastConfig.SetDuration(3000);
            toastConfig.SetBackgroundColor(System.Drawing.Color.FromArgb(70, 70, 70));
            UserDialogs.Instance.Toast(toastConfig);
        }
    }
}
