using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB_PROYECTOS.Models
{
    public class AsignacionPrint
    {
        public int ProyectoId { get; set; }
        public string NombreProyecto { get; set; }
        public string Apellidos { get; set; }
        public string Nombres { get; set; }
        public DateTime FechaAlta { get; set; }
    }
}