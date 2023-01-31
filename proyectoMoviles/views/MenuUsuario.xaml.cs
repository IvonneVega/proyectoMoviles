using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace proyectoMoviles.views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuUsuario : ContentPage
	{
        public int id;
		public MenuUsuario (int idUsuario)
		{
			InitializeComponent ();
            id = idUsuario;
		}

        private void btnPerfil_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Perfil(id));
        }

        private void btnSupereroes_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListadoMarvel());
        }

        private void btnCerrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Login());
        }
    }
}