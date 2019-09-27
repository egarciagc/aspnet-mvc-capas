using ENTIDAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATOS
{
    public class ProyectoDALC
    {
        public void Agregar(Proyecto proyecto)
        {
            using (var db = new ProyectosContext())
            {
                db.Proyecto.Add(proyecto);
                db.SaveChanges();
            }
        }

        public List<Proyecto> ListarProyectos()
        {
            using (var db = new ProyectosContext())
            {
                return db.Proyecto.ToList();
            }
        }

        public Proyecto ObtenerProyecto(int id)
        {
            using (var db = new ProyectosContext())
            {
                //return db.Proyecto.Where(p => p.ProyectoId == id).FirstOrDefault();
                return db.Proyecto.Find(id);
            }
        }

        public void Editar(Proyecto proyecto)
        {
            using (var db = new ProyectosContext())
            {
                var origen = db.Proyecto.Find(proyecto.ProyectoId);
                origen.NombreProyecto = proyecto.NombreProyecto;
                origen.FechaInicio = proyecto.FechaInicio;
                origen.FechaFin = proyecto.FechaFin;
                db.SaveChanges();
            }
        }

        public void Eliminar(int id)
        {
            using (var db = new ProyectosContext())
            {
                var proyecto = db.Proyecto.Find(id);
                db.Proyecto.Remove(proyecto);
                db.SaveChanges();
            }
        }
    }
}
