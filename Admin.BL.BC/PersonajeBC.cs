using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Admin.DL.DataModel;
using System.Data.Entity;

namespace Admin.BL.BC
{
    public class PersonajeBC
    {
        public List<Personaje> PersonajeListar()
        {
            GameEntities context = new GameEntities();
            return context.Personaje.ToList();
            // SELECT * FROM Personaje
        }

        public List<Personaje> PersonajeListar(String Filtro)
        {
            GameEntities context = new GameEntities();
            return context.Personaje
                .Where(X => X.Nombre.Contains(Filtro))
                .ToList();
            // SELECT * FROM Personaje 
            // WHERE Nombre LIKE '%' + @Nombre + '%'
        }

        public void PersonajeRegistrar(Personaje objPersonaje)
        {
            GameEntities context = new GameEntities();
            context.Personaje.Add(objPersonaje);
            context.SaveChanges();
            // INSERT INTO Personaje (@Nombre, ... )
        }

        public void PersonajeEditar(Personaje objPersonaje)
        {
            GameEntities context = new GameEntities();
            Personaje objPersonajeOri = context.Personaje
                .FirstOrDefault(X => 
                X.PersonajeId == objPersonaje.PersonajeId);
            objPersonajeOri.Nombre = objPersonaje.Nombre;
            objPersonajeOri.Imagen = objPersonaje.Imagen;
            objPersonajeOri.X = objPersonaje.X;
            objPersonajeOri.Y = objPersonaje.Y;
            context.SaveChanges();
            // UPDATE Personaje SET Nombre = @Nombre, ...
            // WHERE PersonajeId = @PersonajeId
        }

        public Personaje PersonajeObtener(int PersonajeId)
        {
            GameEntities context = new GameEntities();
            return context.Personaje
                .FirstOrDefault(X => 
                X.PersonajeId == PersonajeId);
            // SELECT * FROM Personaje 
            // WHERE PersonajeId = @PersonajeId
            // PCSIJART@UPC.EDU.PE
        }

        public void PersonajeEliminar(int PersonajeId)
        {
            GameEntities context = new GameEntities();
            Personaje objPersonaje = context.Personaje
                .FirstOrDefault(X =>
                X.PersonajeId == PersonajeId);
            context.Personaje.Remove(objPersonaje);
            context.SaveChanges();
            // DELETE FROM Personaje
            // WHERE PersonajeId = @PersonajeId
        }
    }
}
