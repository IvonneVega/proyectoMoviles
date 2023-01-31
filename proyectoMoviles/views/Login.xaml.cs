using proyectoMoviles.models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace proyectoMoviles.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private SQLiteAsyncConnection con;
        public Login()
        {
            InitializeComponent(); 
            con = DependencyService.Get<Database>().GetConnection();
        }
        public static IEnumerable<Persona> Select_where(SQLiteConnection db, string usuario, string contrasena)
        {
            return db.Query<Persona>("SELECT * FROM Persona where Usuario=? and Contrasena=?", usuario, contrasena);
        }


        private void loginButton_Clicked(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "marvel.db3");
                var db = new SQLiteConnection(ruta);
                db.CreateTable<Persona>();
                IEnumerable<Persona> resultado = Select_where(db, txtUsuario.Text, txtContrasena.Text);
                if (resultado.Count() > 0)
                {
                    Persona persona = resultado.FirstOrDefault();

                    Navigation.PushAsync(new MenuUsuario(persona.Id));
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
        }

        private void btnRegistro_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registro());
        }
    }
}