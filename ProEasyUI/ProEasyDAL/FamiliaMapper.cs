using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DAL
{
    public class FamiliaMapper : EntityMapperMapper<Familia>
    {
        public Boolean existe(long id, string nombre)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM FAMILIA WHERE NOMBRE ='" + nombre + "' AND ID != " + id;
                int count = sqlHelper.ExecuteScalar(query);

                return count > 0;
            }
            catch (ProEasyException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ProEasyException(1, ex.Message);
            }
        }

        public Boolean estaAsignada(Familia familia)
        {
            try
            {
                string query = "select count(*) from usuario_familia UF where UF.id_familia = " + familia.Id;
                int count = sqlHelper.ExecuteScalar(query);

                return count > 0;
            }
            catch (ProEasyException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ProEasyException(1, ex.Message);
            }
        }

        public Boolean tieneAlgunaPatenteSinOtraAsignacion(Familia familia)
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

                foreach (Patente patente in lista)
                {
                    query = "select count(*) from (select * from usuario_patente where id_patente=" + patente.Id +
                                " union " +
                                "select * from usuario_familia " +
                                "where id_familia in (" +
                                    "select distinct id_familia from familia_patente where id_patente != " + patente.Id + " and id_familia!=" + familia.Id +
                                ")) UFC";
                    if (sqlHelper.ExecuteScalar(query) < 1)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (ProEasyException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ProEasyException(1, ex.Message);
            }
        }

        public void asignarPatente(Familia familia, Patente patente)
        {
            try
            {
                string query = "INSERT INTO FAMILIA_PATENTE (id_familia,id_patente,dvh) VALUES (@id_familia,@id_patente,@dvh)";

                Dictionary<string, object> paramList = new Dictionary<string, object>();
                paramList.Add("@id_familia", familia.Id);
                paramList.Add("@id_patente", patente.Id);
                paramList.Add("@dvh", null);

                sqlHelper.ExecuteQueryWithParams(query, paramList);
            }
            catch (ProEasyException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ProEasyException(1, ex.Message);
            }
        }

        public void desasignarPatente(Familia familia, Patente patente)
        {
            try
            {
                string query = "DELLETE FROM FAMILIA_PATENTE WHERE id_familia = @id_familia AND id_patente = @id_patente";

                Dictionary<string, object> paramList = new Dictionary<string, object>();
                paramList.Add("@id_familia", familia.Id);
                paramList.Add("@id_patente", patente.Id);

                sqlHelper.ExecuteQueryWithParams(query, paramList);
            }
            catch (ProEasyException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ProEasyException(1, ex.Message);
            }
        }

        public override void crear(Familia entity)
        {
            try
            {
                string query = "INSERT INTO FAMILIA (nombre,eliminado,dvh) VALUES(@nombre,@eliminado,@dvh)";

                Dictionary<string, object> paramList = new Dictionary<string, object>();
                paramList.Add("@nombre", entity.Nombre);
                paramList.Add("@eliminado", entity.Eliminado);
                paramList.Add("@dvh", entity.Dvh);

                sqlHelper.ExecuteQueryWithParams(query, paramList);
            }
            catch (ProEasyException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ProEasyException(1, ex.Message);
            }
        }

        public override void actualizar(Familia entity)
        {
            try
            {
                string query = "UPDATE FAMILIA SET nombre = @nombre, dvh = @dvh WHERE id = @id";

                Dictionary<string, object> paramList = new Dictionary<string, object>();
                paramList.Add("@id", entity.Id);
                paramList.Add("@nombre", entity.Nombre);
                paramList.Add("@dvh", entity.Dvh);

                sqlHelper.ExecuteQueryWithParams(query, paramList);
            }
            catch (ProEasyException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ProEasyException(1, ex.Message);
            }
        }

        public List<Familia> obtenerFamiliasDisponibles(Usuario usuario)
        {
            try
            {
                List<Familia> lista = listar();
                var ids = obtenerTodasLasFamilias(usuario).Select(familia => familia.Id);

                return lista.Where(p => ids.All(p2 => p2 != p.Id)).ToList();
            }
            catch (ProEasyException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ProEasyException(1, ex.Message);
            }
        }

        public List<Familia> obtenerTodasLasFamilias(Usuario usuario)
        {
            try
            {
                List<Familia> lista = new List<Familia>();
                {
                    string query = "select F.* from familia F where F.id in (select id_familia from usuario_familia where id_usuario=@id_usuario)";
                    Dictionary<string, object> paramList = new Dictionary<string, object>();
                    paramList.Add("@id_usuario", usuario.Id);

                    DataTable list = sqlHelper.ExecuteQueryWithParamsRetDataTable(query, paramList);

                    foreach (DataRow row in list.Rows)
                    {
                        Familia familia = new Familia
                        {
                            Id = Convert.ToInt32(row["id"]),
                            Nombre = Convert.ToString(row["nombre"])
                        };
                        lista.Add(familia);
                    }
                }
                return lista;
            }
            catch (ProEasyException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ProEasyException(1, ex.Message);
            }
        }

        public override void eliminar(Familia entity)
        {
            try
            {
                string query = "DELETE FROM FAMILIA WHERE id = @id";

                Dictionary<string, object> paramList = new Dictionary<string, object>();
                paramList.Add("@id", entity.Id);

                bool ok = sqlHelper.ExecuteQueryWithParams(query, paramList) > 0;

                if (!ok)
                {
                    throw new ProEasyException(55, "ocurrio un error al eliminar la familia");
                }
            }
            catch (ProEasyException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ProEasyException(1, ex.Message);
            }
        }

        public bool tieneFamiliasRelacionadasConUsuarios(Patente p, long idFamilia)
        {
            string q = "select count(*) from familia F left join familia_patente FP on FP.id_familia = F.id and FP.id_patente = " + p.Id + " where F.id != " + idFamilia;
            return sqlHelper.ExecuteScalar(q) > 0;
        }

        public void asignarFamilia(Usuario user, Familia familia, string dvh)
        {
            try
            {
                string query = "INSERT INTO USUARIO_FAMILIA (id_usuario,id_familia,dvh) VALUES (@id_usuario,@id_familia,@dvh)";

                Dictionary<string, object> paramList = new Dictionary<string, object>();
                paramList.Add("@id_usuario", user.Id);
                paramList.Add("@id_familia", familia.Id);
                paramList.Add("@dvh", dvh);

                sqlHelper.ExecuteQueryWithParams(query, paramList);
            }
            catch (ProEasyException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ProEasyException(1, ex.Message);
            }
        }

        public void quitarFamilia(Usuario usuario, Familia familia)
        {
            try
            {
                string query = "DELETE FROM USUARIO_FAMILIA WHERE id_usuario = @id_usuario AND id_familia = @id_familia";

                Dictionary<string, object> paramList = new Dictionary<string, object>();
                paramList.Add("@id_usuario", usuario.Id);
                paramList.Add("@id_familia", familia.Id);

                sqlHelper.ExecuteQueryWithParams(query, paramList);
            }
            catch (ProEasyException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ProEasyException(1, ex.Message);
            }
        }

        public override List<Familia> listar()
        {
            try
            {
                string query = "SELECT * FROM FAMILIA ORDER BY DVH";
                DataTable list = sqlHelper.ExecuteReader(query);
                List<Familia> lista = new List<Familia>();

                foreach (DataRow row in list.Rows)
                {
                    Familia familia = new Familia
                    {
                        Id = Convert.ToInt32(row["id"]),
                        Nombre = Convert.ToString(row["nombre"]),
                        Eliminado = Convert.ToBoolean(row["eliminado"]),
                        Dvh = Convert.ToString(row["dvh"])
                    };
                    //familia.Usuario = row.Field<bool>("usuario");
                    //familia.Patentes = row.Field<bool>("usuario");
                    lista.Add(familia);
                }

                return lista;
            }
            catch (ProEasyException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ProEasyException(1, ex.Message);
            }
        }

        public override Familia leer(long id)
        {
            try
            {
                string query = "SELECT * FROM FAMILIA WHERE ID = " + id;
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

                Familia familia = new Familia
                {
                    Id = Convert.ToInt32(row["id"]),
                    Nombre = Convert.ToString(row["nombre"]),
                    Eliminado = Convert.ToBoolean(row["eliminado"]),
                    Dvh = Convert.ToString(row["dvh"])
                };
                //familia.Usuario = row.Field<bool>("usuario");
                //familia.Patentes = row.Field<bool>("usuario");
                return familia;
            }
            catch (ProEasyException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ProEasyException(1, ex.Message);
            }
        }
    }

}