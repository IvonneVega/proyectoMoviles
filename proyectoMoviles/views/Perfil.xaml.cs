using proyectoMoviles.models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace proyectoMoviles.views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Perfil : ContentPage
	{
        private SQLiteAsyncConnection con;
        private int id;
        IEnumerable<Persona> ResultadoUpdate;
        public Perfil (int idUsuario)
		{
			InitializeComponent ();
			BindingContext = new fotoViewModel();
            con = DependencyService.Get<Database>().GetConnection();
            id = idUsuario;
		}

        public static IEnumerable<Persona> Select_where(SQLiteConnection db, int id)
        {
            return db.Query<Persona>("SELECT * FROM Persona where Id=?", id);
        }

        public static IEnumerable<Persona> Update(SQLiteConnection db, string nombre,string apellidos, int edad, string correo, int id)
        {
            return db.Query<Persona>("UPDATE Persona SET Nombres = ?, Apellidos = ?, Edad=?, Correo=? where Id=?", nombre,apellidos,edad,correo,id);
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }

        protected  override void OnAppearing()
        {
            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "marvel.db3");
                var db = new SQLiteConnection(ruta);
                db.CreateTable<Persona>();
                IEnumerable<Persona> resultado = Select_where(db, id);
                if (resultado.Count() > 0)
                {
                    Persona persona = resultado.FirstOrDefault();
                    txtNombres.Text = persona.Nombres.ToString();
                    txtApellidos.Text = persona.Apellidos.ToString();
                    txtEdad.Text = persona.Edad.ToString();
                    txtCorreo.Text = persona.Correo.ToString();
                }
                else
                {
                    DisplayAlert("Alerta", "Usuario o contraseña incorrecta", "Cerrar");
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "Cerrar");
                throw;
            }
            base.OnAppearing();
        }

        private void ok ()
        {
            
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "marvel.db3");
                var db = new SQLiteConnection(databasePath);
                ResultadoUpdate = Update(db, txtNombres.Text, txtApellidos.Text, Convert.ToInt32(txtEdad.Text), txtCorreo.Text, id);
                DisplayAlert("Alerta", "Información actualizada correctamente", "OK");
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "Ok");
                throw;
            }
        }
    }
}