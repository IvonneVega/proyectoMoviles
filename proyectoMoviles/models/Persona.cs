using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace proyectoMoviles.models
{
    public class Persona
    {
        [PrimaryKey, AutoIncrement] 
        public int Id { get; set; }
        [MaxLength(255)]
        public string Nombres { get; set; }
        [MaxLength(255)]
        public string Apellidos { get; set; }
        [MaxLength(255)]
        public string Correo { get; set; }
        [MaxLength(255)]
        public int Edad { get; set; }
        [MaxLength(255)]
        public string Usuario { get; set; }
        [MaxLength(255)]
        public string Contrasena { get; set; }

    }
}
