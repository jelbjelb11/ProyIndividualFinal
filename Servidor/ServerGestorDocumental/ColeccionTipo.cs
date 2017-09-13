using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace formulario
{
    public class ColeccionTipo
    {
        public long Id { get; set; }
        public string Titulo { get; set; }
        public int Formato { get; set; }
        public String FechaInicio { get; set; }
        public String FechaFin { get; set; }
       // public string Tamanio { get; set; }
        public int NumeroCromos { get; set; }
        public bool Periodica { get; set; }

    }
}