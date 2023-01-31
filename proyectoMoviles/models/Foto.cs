using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace proyectoMoviles.models
{
    public class Foto : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string nombre ="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }
        private ImageSource fotoPerfil;
        public ImageSource FotoPerfil
        {
            get { return fotoPerfil; }
            set {
                fotoPerfil = value;
                OnPropertyChanged();
            }
        }
    }
}
