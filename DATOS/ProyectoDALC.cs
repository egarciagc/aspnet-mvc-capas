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
                db.Configuration.LazyLoadingEnabled = false;
                //var toDay = DateTime.Now.Date;
                //return db.Proyecto.Where(p => p.FechaFin > toDay).ToList();
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

        public bool ExisteAsignacion(int proyectoId, int empleadoId)
        {
            using (var db = new ProyectosContext())
            {
                var existeAsignacion = db.ProyectoEmpleado
                    .Any(p => p.ProyectoId == proyectoId && p.EmpleadoId == empleadoId);

                return existeAsignacion;
            }
        }

        public bool EsProyectoActivo(int proyectoId)
        {
            using (var db = new ProyectosContext())
            {
                var toDay = DateTime.Now.Date;
                var proyectoActivo = db.Proyecto
                    .Any(p => p.ProyectoId == proyectoId && p.FechaFin > toDay);

                return proyectoActivo;
            }
        }

        public void AsignarProyecto(int proyectoId, int empleadoId)
        {
            var proyectoEmp = new ProyectoEmpleado
            {
                ProyectoId = proyectoId,
                EmpleadoId = empleadoId,
                FechaAlta = DateTime.Now
            };

            using (var db = new ProyectosContext())
            {
                db.ProyectoEmpleado.Add(proyectoEmp);
                db.SaveChanges();
            }
        }

        public List<ProyectoEmpleadoCE> ListarAsignaciones()
        {
            string sql = @"select pe.ProyectoId, p.NombreProyecto, pe.EmpleadoId, e.Apellidos, e.Nombres, pe.FechaAlta
                 from ProyectoEmpleado pe
                inner join Proyecto p on pe.ProyectoId = p.ProyectoId
                inner join Empleado e on pe.EmpleadoId = e.EmpleadoId";
            using (var db = new ProyectosContext())
            {
                return db.Database.SqlQuery<ProyectoEmpleadoCE>(sql).ToList();
            }
        }

        public void Eliminarasignacion(int proyectoId, int empleadoId)
        {
            using (var db = new ProyectosContext())
            {
                var empProy = db.ProyectoEmpleado
                    .Where(e => e.ProyectoId == proyectoId && e.EmpleadoId == empleadoId)
                    .FirstOrDefault();
                db.ProyectoEmpleado.Remove(empProy);
                db.SaveChanges();
            }
        }
    }
}
