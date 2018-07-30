using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Acr.UserDialogs;
using Compras.Helpers;
using Compras.Models;
using Compras.Services;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Rg.Plugins.Popup.Contracts;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace Compras.ViewModel
{
    public class ListasViewModel : BaseViewModel
    {
        public ICommand AdicionarLista { get; set; }
        public ICommand RemoverLista { get; set; }
        public ICommand PhotoCommand { get; set; }
        public ICommand OpenPopup { get; set; }


        private string _novalista = "";
        public string NovaLista
        {
            get { return _novalista; }

            set { _novalista = value; }
        }

        
        public DateTime Hoje { get { return DateTime.Today; } }
        public DateTime DaquiUmAno { get { return DateTime.Today.AddYears(1); } }
        private DateTime _diadacompra;
        public DateTime DiadaCompra
        {
            get { return _diadacompra.Date; }
                set { _diadacompra = value.Date; }
        }

        public ListasViewModel()
        {
            Listado = new ObservableCollection<Models.Listas>();
            Retrieve();
            PhotoCommand = new Command(Photo);
            RemoverLista = new Command(Remover);

            AdicionarLista = new Command(Adicionar);

        }


        private User _user;
        public User User
        {
            get
            {

                return _user;
            }

            set
            {
                _user = value;
                NotifyPropertyChanged("User");
            }
        }

        private async void Photo()
        {
            var op = await UserDialogs.Instance.ActionSheetAsync("Deseja tirar uma foto ou pega-la na galeria?", "Cancelar", "", null, "Tirar foto", "Galeria de fotos");
            if (op == "Tirar foto")
            {
                var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    PhotoSize = PhotoSize.Medium,
                    AllowCropping = true,
                    CompressionQuality = 90,
                    DefaultCamera = CameraDevice.Rear,
                    SaveToAlbum = false
                });

                if (file == null)
                    return;

                await UserService.SaveOrUpdatePhoto(file.GetStream(), Settings.Email);
                GetUser();
            }
            else if (op == "Galeria de fotos")
            {
                var file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
                {
                    PhotoSize = PhotoSize.Medium,
                    CompressionQuality = 80,
                });

                if (file == null)
                    return;

                await UserService.SaveOrUpdatePhoto(file.GetStream(), Settings.Email);
                GetUser();
            }


        }


        private void GetUser()
        {
            User = new User()
            {
                Email = Settings.Email,
                Name = Settings.Name,
                UrlPhoto = string.IsNullOrEmpty(Settings.UrlPhoto) ? "launcher.png" : Settings.UrlPhoto
            };
        }


        private string _erro;
        public string Erro
        {
            get
            {
                return _erro;
            }

            set
            {
                _erro = value;
                NotifyPropertyChanged("Erro");
            }
        }



        public ObservableCollection<Models.Listas> Listado
        {
            get;
            set;
        }

        private void Retrieve()
        {
            Listado.Clear();
            GetUser();
            List<Listas> temp = new List<Listas>();
            temp = ListaService.ListAll();
            foreach (Listas element in temp)
            {
                Listado.Add(element);
            }



        }


        public void RemoveList(int id)
        {
            try { ListaService.Remove(Listado[id].Id); }
            catch { }

        }

        private void Remover()
        {
            try
            {
                if (Listado.Count > 0)
                {
                    ListaService.Remove(Listado[Listado.Count - 1].Id);
                    Listado.RemoveAt(Listado.Count - 1);
                }


            }
            catch { }
        }

        public void Adicionar()
        {

            if (NovaLista == null || NovaLista == "")
            {
                return;
            }
            else
            {
                try
                {
                    Listas lista = new Listas { NomeLista = NovaLista, Criacao = DateTime.Today, DiaCompra = DiadaCompra };
                    ListaService.Insert(lista);
                    Listado.Add(lista);
                }
                catch (Exception ex)
                {
                    Erro = ex.Message;

                }
            }
        }



    }
}
