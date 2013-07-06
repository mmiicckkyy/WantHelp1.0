using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using P.V.WantHelp_.Models;
namespace P.V.WantHelp_.Models
{
    public class AdminActions
    {
        PlataformaVirtualEntities server;
        UsersContext userserver;
        public AdminActions()
        {
            server = new PlataformaVirtualEntities();
            userserver = new UsersContext();
        }
        /** Lista a los usuarios**/
        public List<UserProfile> getUsers()
        {
            return userserver.UserProfiles.ToList();
        }
        public List<Usuario> getUsuario()
        {
            return server.Usuario.ToList();
        }
        public List<webpages_Roles> getRoles()
        {
            return server.webpages_Roles.ToList();
        }
        public List<webpages_UsersInRoles> getRolesQueTieneUsuario(int idUser)
        {
            return server.webpages_UsersInRoles.Where(a => a.UserId == idUser).ToList();
        }
        /** Insertar **/
        public bool InsertarRol(webpages_Roles roles)
        {
            server.webpages_Roles.Add(roles);
            try
            {
                server.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool insertUsuarioRol(webpages_UsersInRoles roles_usuario)
        {
            server.webpages_UsersInRoles.Add(roles_usuario);
            try {
                server.SaveChanges();
                return true;
            }
            catch {
                return false;
            }
        }
       /* public bool GuardarArchivo(ResultUpload archivo, int idUs)
        {
            files fs= new files(){
                idUs =idUs,
                urlAbs=archivo.fileroute,
                urlWeb="http://localhost:2606/"+archivo.fileroute
            };
            server.files.add(fs);
            server.SaveChanges();
            return true;
        }
        internal List<files> getFiles(int p)
        {
            return server.files.Where(a => a.idUs == p).ToList();
        }*/
        /** Get Id **/
        public Usuario getUsuario(int id)
        {
            return server.Usuario.Where(a => a.Id_Usu == id).FirstOrDefault();
        }
        public UserProfile getUserPr(int id)
        {
            return userserver.UserProfiles.Where(a => a.UserId == id).First();
        }

        internal bool insertarRol(webpages_Roles roles)
        {
            throw new NotImplementedException();
        }
    }
}