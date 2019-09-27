using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDAD;
using DATOS;

namespace NEGOCIO
{
    public class ProyectoCN
    {
        private static ProyectoDALC obj = new ProyectoDALC();

        public static void Agregar(Proyecto proyecto)
        {
            obj.Agregar(proyecto);
        }

        public static List<Proyecto> ListarProyectos()
        {
            return obj.ListarProyectos();
        }

        public static Proyecto ObtenerProyecto(int id)
        {
            return obj.ObtenerProyecto(id);
        }

        public static void Editar(Proyecto proyecto)
        {
            obj.Editar(proyecto);
        }

        public static void Eliminar(int id)
        {
            obj.Eliminar(id);
        }
    }
}
