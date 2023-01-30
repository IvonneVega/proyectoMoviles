using proyectoMoviles.models;
using SQLite;
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
	public partial class Registro : ContentPage
	{
        private SQLiteAsyncConnection con;
        public Registro ()
		{
			InitializeComponent ();
            con = DependencyService.Get<Database>().GetConnection();
        }

        private void btnGuardar_Clicked(object sender, EventArgs e)
        {
            var datos = new Persona { Nombres = txtNombres.Text, Apellidos=txtApellidos.Text, Edad=Convert.ToInt32(txtEdad.Text),
                Correo = txtCorreo.Text,Usuario = txtUsuario.Text, Contrasena = txtContrasena.Text };
            con.InsertAsync(datos);
            txtNombres.Text = "";
            txtApellidos.Text = "";
            txtEdad.Text = "";
            txtCorreo.Text = "";
            txtContrasena.Text = "";
            txtUsuario.Text = "";
            DisplayAlert("Alerta", "Usuario registrado correctamente", "Ok");
            Navigation.PushAsync(new Login());
        }

        private void btnCancelar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Login());
        }
    }
}