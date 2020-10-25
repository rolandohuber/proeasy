using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DAL
{
    public class FamiliaMapper : EntityMapperMapper<Familia>
    {

        public Boolean existe(string nombre)
        {
            string query = "SELECT COUNT(*) FROM FAMILIA WHERE NOMBRE ='" + nombre + "'";
            int count = sqlHelper.ExecuteScalar(query);

            return count > 0;
        }


        public Boolean estaAsignada(Familia familia)
        {
            string query = "select count(*) from usuario_familia UF where UF.id_familia = " + familia.Id;
            int count = sqlHelper.ExecuteScalar(query);

            return count > 0;
        }


        public Boolean tieneAlgunaPatenteSinOtraAsignacion(Familia familia)
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


        public void asignarPatente(Familia familia, Patente patente)
        {
            string query = "INSERT INTO FAMILIA_PATENTE (id_familia,id_patente,dvh) VALUES (@id_familia,@id_patente,@dvh)";

            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("@id_familia", familia.Id);
            paramList.Add("@id_patente", patente.Id);
            paramList.Add("@dvh", null);

            sqlHelper.ExecuteQueryWithParams(query, paramList);
        }


        public void desasignarPatente(Familia familia, Patente patente)
        {
            string query = "DELLETE FROM FAMILIA_PATENTE WHERE id_familia = @id_familia AND id_patente = @id_patente";

            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("@id_familia", familia.Id);
            paramList.Add("@id_patente", patente.Id);

            sqlHelper.ExecuteQueryWithParams(query, paramList);
        }

        public override void crear(Familia entity)
        {
            string query = "INSERT INTO FAMILIA (nombre,eliminado,dvh) VALUES(@nombre,@eliminado,@dvh)";

            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("@nombre", entity.Nombre);
            paramList.Add("@eliminado", entity.Eliminado);
            paramList.Add("@dvh", entity.Dvh);

            sqlHelper.ExecuteQueryWithParams(query, paramList);
        }

        public override void actualizar(Familia entity)
        {
            string query = "UPDATE FAMILIA SET nombre = @nombre, dvh = @dvh WHERE id = @id";

            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("@id", entity.Id);
            paramList.Add("@nombre", entity.Nombre);
            paramList.Add("@dvh", entity.Dvh);

            sqlHelper.ExecuteQueryWithParams(query, paramList);
        }

        public List<Familia> obtenerFamiliasDisponibles(Usuario usuario)
        {
            List<Familia> lista = listar();
            var ids = obtenerTodasLasFamilias(usuario).Select(familia => familia.Id);

            return lista.Where(p => ids.All(p2 => p2 != p.Id)).ToList();
        }

        public List<Familia> obtenerTodasLasFamilias(Usuario usuario)
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

        public override void eliminar(Familia entity)
        {
            string query = "DELETE FAMILIA WHERE id = @id";

            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("@id", entity.Id);
            paramList.Add("@nombre", entity.Nombre);
            paramList.Add("@eliminado", entity.Eliminado);
            paramList.Add("@dvh", entity.Dvh);

            bool ok = sqlHelper.ExecuteQueryWithParams(query, paramList) > 0;

            if (!ok)
            {
                throw new Exception("ocurrio un error al eliminar la familia");
            }
        }

        public void asignarFamilia(Usuario user, Familia familia, string dvh)
        {
            string query = "INSERT INTO USUARIO_FAMILIA (id_usuario,id_familia,dvh) VALUES (@id_usuario,@id_familia,@dvh)";

            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("@id_usuario", user.Id);
            paramList.Add("@id_familia", familia.Id);
            paramList.Add("@dvh", dvh);

            sqlHelper.ExecuteQueryWithParams(query, paramList);
        }

        public void quitarFamilia(Usuario usuario, Familia familia)
        {
            string query = "DELETE FROM USUARIO_FAMILIA WHERE id_usuario = @id_usuario AND id_familia = @id_familia";

            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("@id_usuario", usuario.Id);
            paramList.Add("@id_familia", familia.Id);

            sqlHelper.ExecuteQueryWithParams(query, paramList);
        }

        public override List<Familia> listar()
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

        public override Familia leer(long id)
        {
            string query = "SELECT * FROM FAMILIA WHERE ID = " + id;
            DataTable list = sqlHelper.ExecuteReader(query);
            if (list.Rows.Count > 1)
            {
                throw new Exception("mas de un registro");
            }
            else if (list.Rows.Count < 1)
            {
                throw new Exception("not found");
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
    }

}