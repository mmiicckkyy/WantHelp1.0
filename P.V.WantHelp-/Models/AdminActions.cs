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
        public bool GuardarArchivo(ResultUpload archivo, int idUs)
        {
            Material mtrl = new Material()
            {
                Id_Usu =idUs,
                urlBase=archivo.fileroute,
                urlHost="http://localhost:2606/"+archivo.fileroute
            };
            server.Material.Add(mtrl);
            server.SaveChanges();
            return true;
        }
        internal List<Material> getFiles(int p)
        {
            return server.Material.Where(a => a.Id_Usu == p).ToList();
        }
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

        internal object getUserId(string p)
        {
            return userserver.UserProfiles.Where(a => a.UserName == p).FirstOrDefault().UserId;
        }
        public List<PermisosDeMenu> getPermisos(int idUs)
        {
            Dictionary<string, string> direcciones = new Dictionary<string, string>();
            direcciones.Add("About", "/Home/About");
            direcciones.Add("Contact", "/Home/Contact");
            direcciones.Add("Home", "/");

            direcciones.Add("Cursos", "/");
            direcciones.Add("Cursos_Create", "/Cursos/Create");
            direcciones.Add("Cursos_Edit", "/Cursos/Edit");
            direcciones.Add("Cursos_Details", "/Cursos/Details");
            direcciones.Add("Cursos_Delete", "/Cursos/Delete");

            direcciones.Add("Material", "/");
            direcciones.Add("Material_Create", "/Material/Create");
            direcciones.Add("Material_Edit", "/Material/Edit");
            direcciones.Add("Material_Details", "/Material/Details");
            direcciones.Add("Material_Delete", "/Material/Delete");

            direcciones.Add("Roles", "/");
            direcciones.Add("Roles_Create", "/Roles/Create");
            direcciones.Add("Roles_Edit", "/Roles/Edit");
            direcciones.Add("Roles_Details", "/Roles/Details");
            direcciones.Add("Roles_Delete", "/Roles/Delete");

            direcciones.Add("RolesUser", "/");
            direcciones.Add("RolesUser_Create", "/RolesUser/Create");

            //string s = direcciones["About"];
            List<PermisosDeMenu> resultado = server.webpages_UsersInRoles.
                Where(a => a.UserId == idUs)
                .Select(
                b => new PermisosDeMenu()
                {
                    idRol = b.RoleId,
                    label = b.webpages_Roles.RoleName
                }).ToList();
            foreach (var item in resultado)
            {
                item.urls = direcciones[item.label];
            }
            return resultado;
        }
    }
}