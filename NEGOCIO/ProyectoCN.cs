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

        public static bool ExisteAsignacion(int proyectoId, int empleadoId)
        {
            return obj.ExisteAsignacion(proyectoId, empleadoId);
        }

        public static bool EsProyectoActivo(int proyectoId)
        {
            return obj.EsProyectoActivo(proyectoId);
        }

        public static void AsignarProyecto(int proyectoId, int empleadoId)
        {
            obj.AsignarProyecto(proyectoId, empleadoId);
        }

        public static List<ProyectoEmpleadoCE> ListarAsignaciones()
        {
            return obj.ListarAsignaciones();
        }

        public static void Eliminarasignacion(int proyectoId, int empleadoId)
        {
            obj.Eliminarasignacion(proyectoId, empleadoId);
        }
    }
}
