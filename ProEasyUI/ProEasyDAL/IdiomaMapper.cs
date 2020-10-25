using BE;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class IdiomaMapper : EntityMapperMapper<Idioma>
    {
        public override void actualizar(Idioma entity)
        {
            try
            {
                string query = "UPDATE IDIOMA SET NOMBRE = @NOMBRE, ELIMINADO = @ELIMINADO WHERE ID = @ID";
                Dictionary<string, object> paramList = new Dictionary<string, object>();
                paramList.Add("@ID", entity.Id);
                paramList.Add("@NOMBRE", entity.Nombre);
                paramList.Add("@ELIMINADO", entity.Eliminado);

                sqlHelper.ExecuteQueryWithParams(query, paramList);
            }
            catch (Exception ex)
            {
                throw new ProEasyException(1, ex.Message);
            }
        }

        public void actualizarIdiomaUsuario(int idioma, Usuario usuario)
        {
            try
            {
                string query = "UPDATE USUARIO SET ID_IDIOMA = @IDIOMA WHERE ID=@ID";
                Dictionary<string, object> paramList = new Dictionary<string, object>();
                paramList.Add("@ID", usuario.Id);
                paramList.Add("@IDIOMA", idioma);

                sqlHelper.ExecuteQueryWithParams(query, paramList);
            }
            catch (Exception ex)
            {
                throw new ProEasyException(1, ex.Message);
            }
        }

        public override void crear(Idioma entity)
        {
            try
            {
                string query = "INSERT INTO IDIOMA(NOMBRE) VALUES(@NOMBRE)";
                Dictionary<string, object> paramList = new Dictionary<string, object>();
                paramList.Add("@NOMBRE", entity.Nombre);

                sqlHelper.ExecuteQueryWithParams(query, paramList);
            }
            catch (Exception ex)
            {
                throw new ProEasyException(1, ex.Message);
            }
        }

        public override void eliminar(Idioma entity)
        {
            try
            {
                string query = "UPDATE IDIOMA SET eliminado = @eliminado WHERE id = @id";
                Dictionary<string, object> paramList = new Dictionary<string, object>();
                paramList.Add("@id", entity.Id);
                paramList.Add("@eliminado", entity.Eliminado);

                sqlHelper.ExecuteQueryWithParams(query, paramList);
            }
            catch (Exception ex)
            {
                throw new ProEasyException(1, ex.Message);
            }
        }

        public override Idioma leer(long id)
        {
            try
            {
                string query = "SELECT * FROM IDIOMA WHERE ID=" + id;
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

                Idioma idioma = new Idioma
                {
                    Id = Convert.ToInt32(row["id"]),
                    Nombre = Convert.ToString(row["nombre"]),
                    Eliminado = Convert.ToBoolean(row["eliminado"]),
                    Code = Convert.ToString(row["code"])
                };
                return idioma;
            }
            catch (Exception ex)
            {
                throw new ProEasyException(1, ex.Message);
            }
        }

        public override List<Idioma> listar()
        {
            try
            {
                string query = "SELECT * FROM IDIOMA";
                DataTable list = sqlHelper.ExecuteReader(query);

                List<Idioma> lista = new List<Idioma>();
                foreach (DataRow row in list.Rows)
                {
                    Idioma idioma = new Idioma
                    {
                        Id = Convert.ToInt32(row["id"]),
                        Nombre = Convert.ToString(row["nombre"]),
                        Eliminado = Convert.ToBoolean(row["eliminado"]),
                        Code = Convert.ToString(row["code"])
                    };
                    lista.Add(idioma);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new ProEasyException(1, ex.Message);
            }
        }
    }
}