using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDAD
{
    public class ProyectoEmpleadoCE
    {
        public int ProyectoId { get; set; }
        public string NombreProyecto { get; set; }
        public int EmpleadoId { get; set; }
        public string Apellidos { get; set; }
        public string Nombres { get; set; }
        public string NombreCompleto { get { return $"{Apellidos} {Nombres}"; } }
        public DateTime FechaAlta { get; set; }
    }
}
