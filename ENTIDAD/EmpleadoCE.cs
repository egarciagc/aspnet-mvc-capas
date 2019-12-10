using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDAD
{
    public class EmpleadoCE
    {
        public int EmpleadoId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string NombreCompleto { get { return $"{Apellidos} {Nombres}"; } }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Celular { get; set; }
        public int DepartamentoId { get; set; }
        public string NombreDepartamento { get; set; }
    }
}
