using Compras.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Compras
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InputPage : CarouselPage
	{
		public InputPage ()
		{
            InitializeComponent();
            this.BindingContext = new RegisterViewModel();

        }
        private async void Continuar_Clicked(object sender, System.EventArgs e)
        {

        }
    }
}