using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Admin.DL.DataModel;
using System.Data.Entity;

namespace Admin.BL.BC
{
    public class MovimientoBC
    {
        public List<Movimiento> MovimientoListar()
        {
            GameEntities context = new GameEntities();
            return context.Movimiento.ToList();
            // SELECT * FROM Movimiento
        }

        public Object[] MovimientoListarCompleto()
        {
            GameEntities context = new GameEntities();
            return context.Movimiento.Select(X => new 
            {
                NombrePersonaje = X.Personaje.Nombre,
                Descripcion = X.Nombre,
                NroMovimientos = X.NroMovimientos
            }).ToArray();
        }
    }
}
