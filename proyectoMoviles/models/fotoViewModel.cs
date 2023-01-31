using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace proyectoMoviles.models
{
    public class fotoViewModel:Foto
    {
        public Command CapturarComando { get; set; }
        public fotoViewModel() {
            CapturarComando = new Command(TomarFoto);
        }
        private async void TomarFoto()
        {
            var camara = new StoreCameraMediaOptions();
            camara.PhotoSize = PhotoSize.Full;
            camara.SaveToAlbum= true;
            var foto = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(camara);
            if(foto != null)
            {
                FotoPerfil = ImageSource.FromStream(() => { 
                    return foto.GetStream(); 
                });
            }

        }
    }
}
