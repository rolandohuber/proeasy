
using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DAL
{
    public class UsuarioMapper : EntityMapperMapper<Usuario>
    {
        public Boolean existe(Usuario Usuario)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM USUARIO WHERE USUARIO = '" + Usuario.Username + "' AND ID != " + Usuario.Id;
                int count = sqlHelper.ExecuteScalar(query);

                return count > 0;
            }
            catch (Exception ex)
            {
                throw new ProEasyException(1, ex.Message);
            }
        }

        public Boolean estaBloqueado(String usuario)
        {
            try
            {
                string query = "SELECT INTENTOS FROM USUARIO WHERE USUARIO ='" + usuario + "'";
                int count = sqlHelper.ExecuteScalar(query);

                return count >= 3;
            }
            catch (Exception ex)
            {
                throw new ProEasyException(1, ex.Message);
            }
        }

        public Usuario login(String username, String contraseña)
        {
            try
            {
                //string query = "SELECT * FROM USUARIO WHERE USUARIO = '" + username + "' AND CONTRASENIA = '" + contraseña + "'";
                string query = "SELECT * FROM USUARIO WHERE USUARIO = '" + username + "'";
                DataTable list = sqlHelper.ExecuteReader(query);
                if (list.Rows.Count > 1)
                {
                    throw new ProEasyException(15, "mas de un registro");
                }
                else if (list.Rows.Count < 1)
                {
                    throw new ProEasyException(16, "not found");
                }

                DataRow row = list.Rows[0];
                Idioma idioma = new Idioma();
                idioma.Id = Convert.ToInt32(row["id_idioma"]);
                Usuario usuario = new Usuario
                {
                    Id = Convert.ToInt32(row["id"]),
                    Nombre = Convert.ToString(row["nombre"]),
                    Apellido = Convert.ToString(row["apellido"]),
                    Email = Convert.ToString(row["email"]),
                    Username = Convert.ToString(row["usuario"]),
                    Disponibilidad = Convert.ToInt32(row["disponibilidad"]),
                    ValorHora = Convert.ToString(row["valor_hora"]),
                    Habilitado = Convert.ToBoolean(row["habilitado"]),
                    Intentos = Convert.ToInt32(row["intentos"]),
                    Eliminado = Convert.ToBoolean(row["eliminado"]),
                    Contrasenia = Convert.ToString(row["contrasenia"]),
                    Idioma = idioma,
                    Dvh = Convert.ToString(row["dvh"])
                };

                return usuario;
            }
            catch (Exception ex)
            {
                throw new ProEasyException(1, ex.Message);
            }
        }


        public List<Usuario> listar(Proyecto proyecto)
        {
            try
            {
                string query = "SELECT U.* FROM USUARIO U INNER JOIN proyecto_usuario PU ON U.ID=PU.id_usuario AND PU.id_proyecto=" + proyecto.Id;
                DataTable list = sqlHelper.ExecuteReader(query);
                List<Usuario> usuarios = new List<Usuario>();
                foreach (DataRow row in list.Rows)
                {
                    Usuario usuario = new Usuario
                    {
                        Id = Convert.ToInt32(row["id"]),
                        Nombre = Convert.ToString(row["nombre"]),
                        Apellido = Convert.ToString(row["apellido"]),
                        Email = Convert.ToString(row["email"]),
                        Username = Convert.ToString(row["usuario"]),
                        Disponibilidad = Convert.ToInt32(row["disponibilidad"]),
                        ValorHora = Convert.ToString(row["valor_hora"]),
                        Habilitado = Convert.ToBoolean(row["habilitado"]),
                        Intentos = Convert.ToInt32(row["intentos"]),
                        Eliminado = Convert.ToBoolean(row["eliminado"]),
                        Contrasenia = Convert.ToString(row["contrasenia"]),
                        Dvh = Convert.ToString(row["dvh"])
                    };
                    usuarios.Add(usuario);
                }
                return usuarios;
            }
            catch (Exception ex)
            {
                throw new ProEasyException(1, ex.Message);
            }
        }

        public override void crear(Usuario entity)
        {
            try
            {
                string query = "INSERT INTO usuario (id_idioma,nombre,apellido,email,usuario,disponibilidad,valor_hora,habilitado,intentos,eliminado,contrasenia,dvh) " +
                    "VALUES (@id_idioma,@nombre,@apellido,@email,@usuario,@disponibilidad,@valor_hora,@habilitado,@intentos,@eliminado,@contrasenia,@dvh)";

                Dictionary<string, object> paramList = new Dictionary<string, object>();
                paramList.Add("@id_idioma", entity.Idioma != null ? entity.Idioma.Id : 1);
                paramList.Add("@nombre", entity.Nombre);
                paramList.Add("@apellido", entity.Apellido);
                paramList.Add("@email", entity.Email);
                paramList.Add("@usuario", entity.Username);
                paramList.Add("@disponibilidad", entity.Disponibilidad);
                paramList.Add("@valor_hora", entity.ValorHora);
                paramList.Add("@habilitado", entity.Habilitado);
                paramList.Add("@intentos", entity.Intentos);
                paramList.Add("@eliminado", entity.Eliminado);
                paramList.Add("@contrasenia", entity.Contrasenia);
                paramList.Add("@dvh", entity.Dvh);

                sqlHelper.ExecuteQueryWithParams(query, paramList);
            }
            catch (Exception ex)
            {
                throw new ProEasyException(1, ex.Message);
            }
        }

        public override void actualizar(Usuario entity)
        {
            try
            {
                string query = "UPDATE usuario SET id_idioma=@id_idioma,nombre=@nombre,apellido=@apellido,email=@email,usuario=@usuario,disponibilidad=@disponibilidad,valor_hora=@valor_hora,habilitado=@habilitado,intentos=@intentos,eliminado=@eliminado,contrasenia=@contrasenia,dvh=@dvh WHERE id = @id";

                Dictionary<string, object> paramList = new Dictionary<string, object>();
                paramList.Add("@id", entity.Id);
                paramList.Add("@id_idioma", entity.Idioma != null ? entity.Idioma.Id : 1);
                paramList.Add("@nombre", entity.Nombre);
                paramList.Add("@apellido", entity.Apellido);
                paramList.Add("@email", entity.Email);
                paramList.Add("@usuario", entity.Username);
                paramList.Add("@disponibilidad", entity.Disponibilidad);
                paramList.Add("@valor_hora", entity.ValorHora);
                paramList.Add("@habilitado", entity.Habilitado);
                paramList.Add("@intentos", entity.Intentos);
                paramList.Add("@eliminado", entity.Eliminado);
                paramList.Add("@contrasenia", entity.Contrasenia);
                paramList.Add("@dvh", entity.Dvh);

                sqlHelper.ExecuteQueryWithParams(query, paramList);
            }
            catch (Exception ex)
            {
                throw new ProEasyException(1, ex.Message);
            }
        }

        public override void eliminar(Usuario entity)
        {
            try
            {
                string query = "UPDATE USUARIO SET ELIMINADO = 1 WHERE ID=" + entity.Id;
                bool ok = sqlHelper.ExecuteQuery(query);
                if (!ok)
                {
                    throw new ProEasyException(17, "ocurrio un error al eliminar el usuario");
                }
            }
            catch (Exception ex)
            {
                throw new ProEasyException(1, ex.Message);
            }
        }

        public override List<Usuario> listar()
        {
            try
            {
                string query = "SELECT * FROM USUARIO WHERE ELIMINADO=0 ORDER BY DVH";
                DataTable list = sqlHelper.ExecuteReader(query);
                List<Usuario> usuarios = new List<Usuario>();
                foreach (DataRow row in list.Rows)
                {
                    Usuario usuario = new Usuario
                    {
                        Id = Convert.ToInt32(row["id"]),
                        Nombre = Convert.ToString(row["nombre"]),
                        Apellido = Convert.ToString(row["apellido"]),
                        Email = Convert.ToString(row["email"]),
                        Username = Convert.ToString(row["usuario"]),
                        Disponibilidad = Convert.ToInt32(row["disponibilidad"]),
                        ValorHora = Convert.ToString(row["valor_hora"]),
                        Habilitado = Convert.ToBoolean(row["habilitado"]),
                        Intentos = Convert.ToInt32(row["intentos"]),
                        Eliminado = Convert.ToBoolean(row["eliminado"]),
                        Contrasenia = Convert.ToString(row["contrasenia"]),
                        Dvh = Convert.ToString(row["dvh"])
                    };
                    usuarios.Add(usuario);

                }
                return usuarios;
            }
            catch (Exception ex)
            {
                throw new ProEasyException(1, ex.Message);
            }
        }

        public override Usuario leer(long id)
        {
            try
            {
                string query = "SELECT * FROM USUARIO WHERE ID=" + id;
                DataTable list = sqlHelper.ExecuteReader(query);
                if (list.Rows.Count > 1)
                {
                    throw new ProEasyException(15, "mas de un registro");
                }
                else if (list.Rows.Count < 1)
                {
                    throw new ProEasyException(16, "not found");
                }

                DataRow row = list.Rows[0];
                Usuario usuario = new Usuario
                {
                    Id = Convert.ToInt32(row["id"]),
                    Nombre = Convert.ToString(row["nombre"]),
                    Apellido = Convert.ToString(row["apellido"]),
                    Email = Convert.ToString(row["email"]),
                    Username = Convert.ToString(row["usuario"]),
                    Disponibilidad = Convert.ToInt32(row["disponibilidad"]),
                    ValorHora = Convert.ToString(row["valor_hora"]),
                    Habilitado = Convert.ToBoolean(row["habilitado"]),
                    Intentos = Convert.ToInt32(row["intentos"]),
                    Eliminado = Convert.ToBoolean(row["eliminado"]),
                    Contrasenia = Convert.ToString(row["contrasenia"]),
                    Dvh = Convert.ToString(row["dvh"])
                };

                return usuario;
            }
            catch (Exception ex)
            {
                throw new ProEasyException(1, ex.Message);
            }
        }

        public List<Usuario> obtenerUsuariosAsignados(Proyecto proyecto)
        {
            try
            {
                string query = "select U.* from usuario U inner join proyecto_usuario PU on PU.id_usuario=U.id and PU.id_proyecto=" + proyecto.Id;
                DataTable list = sqlHelper.ExecuteReader(query);
                List<Usuario> usuarios = new List<Usuario>();
                foreach (DataRow row in list.Rows)
                {
                    Usuario usuario = new Usuario
                    {
                        Id = Convert.ToInt32(row["id"]),
                        Nombre = Convert.ToString(row["nombre"]),
                        Apellido = Convert.ToString(row["apellido"]),
                        Email = Convert.ToString(row["email"]),
                        Username = Convert.ToString(row["usuario"]),
                        Disponibilidad = Convert.ToInt32(row["disponibilidad"]),
                        ValorHora = Convert.ToString(row["valor_hora"]),
                        Habilitado = Convert.ToBoolean(row["habilitado"]),
                        Intentos = Convert.ToInt32(row["intentos"]),
                        Eliminado = Convert.ToBoolean(row["eliminado"]),
                        Contrasenia = Convert.ToString(row["contrasenia"]),
                        Dvh = Convert.ToString(row["dvh"])
                    };
                    usuarios.Add(usuario);

                }
                return usuarios;
            }
            catch (Exception ex)
            {
                throw new ProEasyException(1, ex.Message);
            }
        }


        public List<Usuario> obtenerUsuariosDisponibles(Proyecto proyecto)
        {
            try
            {
                List<Usuario> lista = listar();
                var ids = obtenerUsuariosAsignados(proyecto).Select(usuario => usuario.Id);

                return lista.Where(p => ids.All(p2 => p2 != p.Id)).ToList();
            }
            catch (Exception ex)
            {
                throw new ProEasyException(1, ex.Message);
            }
        }


        public void asignarRecurso(Proyecto proyecto, Usuario usuario, string dvh)
        {
            try
            {
                string query = "INSERT INTO PROYECTO_USUARIO (id_proyecto,id_usuario,dvh) VALUES (@id_proyecto,@id_usuario,@dvh)";

                Dictionary<string, object> paramList = new Dictionary<string, object>();
                paramList.Add("@id_proyecto", proyecto.Id);
                paramList.Add("@id_usuario", usuario.Id);
                paramList.Add("@dvh", dvh);

                sqlHelper.ExecuteQueryWithParams(query, paramList);
            }
            catch (Exception ex)
            {
                throw new ProEasyException(1, ex.Message);
            }
        }


        public void desasignarRecurso(Proyecto proyecto, Usuario usuario)
        {
            try
            {
                string query = "DELETE FROM PROYECTO_USUARIO WHERE id_proyecto = @id_proyecto AND id_usuario = @id_usuario";

                Dictionary<string, object> paramList = new Dictionary<string, object>();
                paramList.Add("@id_proyecto", proyecto.Id);
                paramList.Add("@id_usuario", usuario.Id);

                sqlHelper.ExecuteQueryWithParams(query, paramList);
            }
            catch (Exception ex)
            {
                throw new ProEasyException(1, ex.Message);
            }
        }


        public List<Usuario> listarTodos()
        {
            try
            {
                string query = "SELECT * FROM USUARIO ORDER BY DVH";
                DataTable list = sqlHelper.ExecuteReader(query);
                List<Usuario> usuarios = new List<Usuario>();
                foreach (DataRow row in list.Rows)
                {
                    Usuario usuario = new Usuario
                    {
                        Id = Convert.ToInt32(row["id"]),
                        Nombre = Convert.ToString(row["nombre"]),
                        Apellido = Convert.ToString(row["apellido"]),
                        Email = Convert.ToString(row["email"]),
                        Username = Convert.ToString(row["usuario"]),
                        Disponibilidad = Convert.ToInt32(row["disponibilidad"]),
                        ValorHora = Convert.ToString(row["valor_hora"]),
                        Habilitado = Convert.ToBoolean(row["habilitado"]),
                        Intentos = Convert.ToInt32(row["intentos"]),
                        Eliminado = Convert.ToBoolean(row["eliminado"]),
                        Contrasenia = Convert.ToString(row["contrasenia"]),
                        Dvh = Convert.ToString(row["dvh"])
                    };
                    usuarios.Add(usuario);

                }
                return usuarios;
            }
            catch (Exception ex)
            {
                throw new ProEasyException(1, ex.Message);
            }
        }
    }
}