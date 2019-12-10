using ENTIDAD;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATOS
{
    public class EmpleadoDALC
    {
        public void Agregar(Empleado empleado)
        {
            using (var db = new ProyectosContext())
            {
                db.Empleado.Add(empleado);
                db.SaveChanges();
            }
        }

        public List<EmpleadoCE> ListarEmpleados()
        {
            string sql = @"select e.EmpleadoId, e.Nombres, e.Apellidos, e.Email, e.Direccion, e.Celular,
	                e.DepartamentoId, d.NombreDepartamento
                 from Empleado e
                inner join Departamento d on e.DepartamentoId = d.DepartamentoId";
            using (var db = new ProyectosContext())
            {
                return db.Database.SqlQuery<EmpleadoCE>(sql).ToList();
            }
        }

        public EmpleadoCE ObtenerEmpleado(int id)
        {
            string sql = @"select e.EmpleadoId, e.Nombres, e.Apellidos, e.Email, e.Direccion, e.Celular,
	                e.DepartamentoId, d.NombreDepartamento
                 from Empleado e
                inner join Departamento d on e.DepartamentoId = d.DepartamentoId
                where e.EmpleadoId = @EmpleadoId";
            using (var db = new ProyectosContext())
            {
                //return db.Empleado.Where(p => p.ProyectoId == id).FirstOrDefault();
                //return db.Empleado.Find(id);
                return db.Database.SqlQuery<EmpleadoCE>(sql,
                    new SqlParameter("@EmpleadoId", id)).FirstOrDefault();
            }
        }

        public void Editar(Empleado empleado)
        {
            using (var db = new ProyectosContext())
            {
                var origen = db.Empleado.Find(empleado.EmpleadoId);
                origen.Nombres = empleado.Nombres;
                origen.Apellidos = empleado.Apellidos;
                origen.Email = empleado.Email;
                origen.Direccion = empleado.Direccion;
                origen.Celular = empleado.Celular;
                origen.DepartamentoId = empleado.DepartamentoId;
                db.SaveChanges();
            }
        }

        public void Eliminar(int id)
        {
            using (var db = new ProyectosContext())
            {
                var empleado = db.Empleado.Find(id);
                db.Empleado.Remove(empleado);
                db.SaveChanges();
            }
        }
    }
}
