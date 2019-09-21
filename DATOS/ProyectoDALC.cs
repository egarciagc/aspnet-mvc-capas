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
    }
}
