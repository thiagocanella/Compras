using Acr.UserDialogs;
using Compras.Helpers;
using Compras.Models;
using Compras.Services;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Xamarin.Forms;

namespace Compras.ViewModel
{
    class RegisterViewModel : BaseViewModel
    {
        public ICommand LogoutCommand { get; set; }
        public ICommand PhotoCommand { get; set; }
        public ICommand RegisterCommand { get; set; }
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
        private string _useremail = "";
        private string _username = "";
        public string UserName { get { return _username; } set { _username = value; } }
        public string UserEmail { get { return _useremail; } set { _useremail = value; } }


        public RegisterViewModel()
        {
            this.PhotoCommand = new Command(Photo);
            RegisterCommand = new Command(Register);
            GetUser();
        }
        public void Register()
        {
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(UserEmail))
            {
                string email = UserName;
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(email);
                if (match.Success == false)
                {
                    UserDialogs.Instance.Alert("Voce deve digitar email válido", "Erro", "OK");

                }
                else
                {
                    UserDialogs.Instance.Alert("Não deixe os campos em branco", "Erro", "OK");

                }
            }
            else
            {

                User = new User { Name = _username, Email = _useremail, CreationDate = $"{DateTime.Now}", UrlPhoto = string.IsNullOrEmpty(Settings.UrlPhoto) ? "profile_default.png" : Settings.UrlPhoto                };
                Settings.Name = User.Name;
                Settings.Email = User.Email;
                Settings.Date = User.CreationDate;
                Settings.UrlPhoto = User.UrlPhoto;
                UserService.Insert(User);
                App.Current.MainPage = new ListsView();
                var toastConfig = new ToastConfig("   BEM VINDO");
                toastConfig.SetDuration(3000);
                toastConfig.SetBackgroundColor(System.Drawing.Color.FromArgb(70,70 , 70));

                UserDialogs.Instance.Toast(toastConfig);
            }





        }


        private void GetUser()
        {
            User = new User()
            {
                Email = Settings.Email,
                Name = Settings.Name,
                UrlPhoto = string.IsNullOrEmpty(Settings.UrlPhoto) ? "profile_default.png" : Settings.UrlPhoto
            };
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


    }
}
