using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using P.V.WantHelp_.Models;
namespace P.V.WantHelp_.Models
{
    public class isertar
    {

        PlataformaVirtualEntities conex;
        public isertar()
        {
            conex=new PlataformaVirtualEntities();           
        }
        public bool insertarusuario(Usuario user)
        {
            conex.Usuario.Add(user);
            try
            {
                conex.SaveChanges();
                return true;
            }
            catch {
                return false;
            }
        }
    }
}