using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DAL
{
    public class PatenteMapper : EntityMapperMapper<Patente>
    {

        public Boolean existeOtraAsignacion(long patente, long userId)
        {
            try
            {
                string query = "select count(*) from (select U.*from usuario U inner join usuario_patente UP on UP.id_patente = " + patente
                    + " and UP.id_usuario = U.id and UP.id_usuario != " + userId + " where U.eliminado=0 and U.habilitado=1  union " +
                    "select U.* from usuario U inner join usuario_familia UF on UF.id_usuario = U.id and UF.id_usuario != " + userId + " inner join familia_patente FP on FP.id_familia = UF.id_familia and FP.id_patente = " + patente + " where U.eliminado=0 and U.habilitado=1) US";
                return sqlHelper.ExecuteScalar(query) > 0;
            }
            catch (Exception ex)
            {
                throw new ProEasyException(1, ex.Message);
            }
        }

        public List<Patente> obtenerPatentesAsignadas(Familia familia)
        {
            try
            {
                List<Patente> lista = new List<Patente>();
                string query = "select P.* from patente P inner join familia_patente FP on FP.id_familia=@id_familia and FP.id_patente=p.id";
                Dictionary<string, object> paramList = new Dictionary<string, object>();
                paramList.Add("@id_familia", familia.Id);

                DataTable list = sqlHelper.ExecuteQueryWithParamsRetDataTable(query, paramList);

                foreach (DataRow row in list.Rows)
                {
                    Patente patente = new Patente
                    {
                        Id = Convert.ToInt32(row["id"]),
                        Nombre = Convert.ToString(row["nombre"])
                    };
                    lista.Add(patente);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new ProEasyException(1, ex.Message);
            }
        }

        public List<Patente> obtenerPatentesDisponibles(Familia familia)
        {
            try
            {
                List<Patente> lista = listar();
                var ids = obtenerPatentesAsignadas(familia).Select(patente => patente.Id);

                return lista.Where(p => ids.All(p2 => p2 != p.Id)).ToList();
            }
            catch (Exception ex)
            {
                throw new ProEasyException(1, ex.Message);
            }
        }

        public List<Patente> obtenerPatentesDisponibles(Usuario usuario)
        {
            try
            {
                List<Patente> lista = listar();
                var ids = obtenerTodasLasPatentes(usuario).Select(patente => patente.Id);

                return lista.Where(p => ids.All(p2 => p2 != p.Id)).ToList();
            }
            catch (Exception ex)
            {
                throw new ProEasyException(1, ex.Message);
            }
        }

        public List<Patente> obtenerPatentesAsignadas(Usuario usuario)
        {
            try
            {
                List<Patente> lista = new List<Patente>();
                string query = "select P.* from patente P inner join usuario_patente UP on UP.id_usuario=@id_usuario and UP.id_patente=p.id";
                Dictionary<string, object> paramList = new Dictionary<string, object>();
                paramList.Add("@id_usuario", usuario.Id);

                DataTable list = sqlHelper.ExecuteQueryWithParamsRetDataTable(query, paramList);

                foreach (DataRow row in list.Rows)
                {
                    Patente patente = new Patente
                    {
                        Id = Convert.ToInt32(row["id"]),
                        Nombre = Convert.ToString(row["nombre"])
                    };
                    lista.Add(patente);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new ProEasyException(1, ex.Message);
            }
        }

        public List<Patente> obtenerTodasLasPatentes(Usuario usuario)
        {
            try
            {
                List<Patente> lista = new List<Patente>();
                {
                    string query = "select P.* from patente P inner join usuario_patente UP on UP.id_usuario=@id_usuario and UP.id_patente=p.id";
                    Dictionary<string, object> paramList = new Dictionary<string, object>();
                    paramList.Add("@id_usuario", usuario.Id);

                    DataTable list = sqlHelper.ExecuteQueryWithParamsRetDataTable(query, paramList);

                    foreach (DataRow row in list.Rows)
                    {
                        Patente patente = new Patente
                        {
                            Id = Convert.ToInt32(row["id"]),
                            Nombre = Convert.ToString(row["nombre"])
                        };
                        lista.Add(patente);
                    }
                }

                {
                    string query = "select P.* from patente P inner join usuario_familia UF on UF.id_usuario=@id_usuario inner join familia F on F.id=UF.id_familia inner join familia_patente FP on FP.id_familia=F.id and P.id=FP.id_patente";
                    Dictionary<string, object> paramList = new Dictionary<string, object>();
                    paramList.Add("@id_usuario", usuario.Id);

                    DataTable list = sqlHelper.ExecuteQueryWithParamsRetDataTable(query, paramList);

                    foreach (DataRow row in list.Rows)
                    {
                        Patente patente = new Patente
                        {
                            Id = Convert.ToInt32(row["id"]),
                            Nombre = Convert.ToString(row["nombre"])
                        };
                        lista.Add(patente);
                    }
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new ProEasyException(1, ex.Message);
            }
        }

        public override void crear(Patente entity)
        {
            try
            {
                string query = "INSERT INTO PATENTE (nombre) VALUES(@nombre)";

                Dictionary<string, object> paramList = new Dictionary<string, object>();
                paramList.Add("@nombre", entity.Nombre);

                sqlHelper.ExecuteQueryWithParams(query, paramList);
            }
            catch (Exception ex)
            {
                throw new ProEasyException(1, ex.Message);
            }
        }

        public override void actualizar(Patente entity)
        {
            try
            {
                string query = "UPDATE PATENTE SET nombre = @nombre WHERE id = @id";

                Dictionary<string, object> paramList = new Dictionary<string, object>();
                paramList.Add("@id", entity.Id);
                paramList.Add("@nombre", entity.Nombre);

                sqlHelper.ExecuteQueryWithParams(query, paramList);
            }
            catch (Exception ex)
            {
                throw new ProEasyException(1, ex.Message);
            }
        }

        public override void eliminar(Patente entity)
        {
            try
            {
                string query = "DELETE FROM PATENTE WHERE ID=" + entity.Id;
                bool ok = sqlHelper.ExecuteQuery(query);
                if (!ok)
                {
                    throw new ProEasyException(75, "ocurrio un error al eliminar la patente");
                }
            }
            catch (Exception ex)
            {
                throw new ProEasyException(1, ex.Message);
            }
        }

        public override List<Patente> listar()
        {
            try
            {
                string query = "SELECT * FROM PATENTE";
                DataTable list = sqlHelper.ExecuteReader(query);

                List<Patente> lista = new List<Patente>();
                foreach (DataRow row in list.Rows)
                {
                    Patente patente = new Patente
                    {
                        Id = Convert.ToInt32(row["id"]),
                        Nombre = Convert.ToString(row["nombre"])
                    };
                    lista.Add(patente);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new ProEasyException(1, ex.Message);
            }
        }

        public override Patente leer(long id)
        {
            try
            {
                string query = "SELECT * FROM PATENTE WHERE ID=" + id;
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

                Patente patente = new Patente
                {
                    Id = Convert.ToInt32(row["id"]),
                    Nombre = Convert.ToString(row["nombre"])
                };
                return patente;
            }
            catch (Exception ex)
            {
                throw new ProEasyException(1, ex.Message);
            }
        }

        public void asignarPatente(Usuario user, Patente patente, string dvh)
        {
            try
            {
                string query = "INSERT INTO USUARIO_PATENTE (id_usuario,id_patente,dvh) VALUES (@id_usuario,@id_patente,@dvh)";

                Dictionary<string, object> paramList = new Dictionary<string, object>();
                paramList.Add("@id_usuario", user.Id);
                paramList.Add("@id_patente", patente.Id);
                paramList.Add("@dvh", dvh);

                sqlHelper.ExecuteQueryWithParams(query, paramList);
            }
            catch (Exception ex)
            {
                throw new ProEasyException(1, ex.Message);
            }
        }

        public void quitarPatente(Usuario usuario, Patente patente)
        {
            try
            {
                string query = "DELETE FROM USUARIO_PATENTE WHERE id_usuario = @id_usuario AND id_patente = @id_patente";

                Dictionary<string, object> paramList = new Dictionary<string, object>();
                paramList.Add("@id_usuario", usuario.Id);
                paramList.Add("@id_patente", patente.Id);

                sqlHelper.ExecuteQueryWithParams(query, paramList);
            }
            catch (Exception ex)
            {
                throw new ProEasyException(1, ex.Message);
            }
        }


        public void asignarPatente(Familia familia, Patente patente, string dvh)
        {
            try
            {
                string query = "INSERT INTO FAMILIA_PATENTE (id_familia,id_patente,dvh) VALUES (@id_familia,@id_patente,@dvh)";

                Dictionary<string, object> paramList = new Dictionary<string, object>();
                paramList.Add("@id_familia", familia.Id);
                paramList.Add("@id_patente", patente.Id);
                paramList.Add("@dvh", dvh);

                sqlHelper.ExecuteQueryWithParams(query, paramList);
            }
            catch (Exception ex)
            {
                throw new ProEasyException(1, ex.Message);
            }
        }

        public bool existeOtraAsignacionFamiliaPatente(long patente, long familia)
        {
            try
            {
                string query = "select count(*) from (select * from usuario_patente where id_patente=" + patente +
                                " union " +
                                "select * from usuario_familia " +
                                "where id_familia in (" +
                                    "select distinct id_familia from familia_patente where id_patente != " + patente + " and id_familia!=" + familia +
                                ")) UFC";
                return sqlHelper.ExecuteScalar(query) > 0;
            }
            catch (Exception ex)
            {
                throw new ProEasyException(1, ex.Message);
            }
        }

        public void quitarPatente(Familia familia, Patente patente)
        {
            try
            {
                string query = "DELETE FROM FAMILIA_PATENTE WHERE id_familia = @id_familia AND id_patente = @id_patente";

                Dictionary<string, object> paramList = new Dictionary<string, object>();
                paramList.Add("@id_familia", familia.Id);
                paramList.Add("@id_patente", patente.Id);

                sqlHelper.ExecuteQueryWithParams(query, paramList);
            }
            catch (Exception ex)
            {
                throw new ProEasyException(1, ex.Message);
            }
        }
    }

}