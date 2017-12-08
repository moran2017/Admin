using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Admin.DL.DataModel;
using System.Data.Entity;

namespace Admin.BL.BC
{
    public class LoginBC
    {
        public Usuario LoginValidar(String Codigo, String Password)
        {
            GameEntities context = new GameEntities();
            return context.Usuario.FirstOrDefault(X =>
                                X.Codigo == Codigo &&
                                X.Password == Password);
        }
    }
}
