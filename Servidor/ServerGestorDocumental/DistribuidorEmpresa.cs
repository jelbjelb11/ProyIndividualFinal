using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace formulario
{
    public class DistribuidorEmpresa
    {
        public long Id { get; set; }
        public string RazonSocial { get; set; }
        public string CIF { get; set; }
        public string DomicilioSocial { get; set; }
        public string NombreContacto { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Web { get; set; }
        public bool Activa { get; set; }
    }
}