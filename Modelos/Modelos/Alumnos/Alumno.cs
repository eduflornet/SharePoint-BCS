using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelos.Alumnos
{
    
    public partial class Alumno
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public int edad { get; set; }
    }
}
