using BE;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class BitacoraMapper : EntityMapperMapper<Bitacora>
    {
        public override void actualizar(Bitacora entity)
        {
            try
            {
                string query = "UPDATE bitacora SET id_usuario = @id_usuario,criticidad = @criticidad,funcionalidad = @funcionalidad,descripcion = @descripcion,fecha = @fecha,dvh = @dvh WHERE id = @id";

                Dictionary<string, object> paramList = new Dictionary<string, object>();
                paramList.Add("@id", entity.Id);
                paramList.Add("@id_usuario", entity.Usuario.Id);
                paramList.Add("@criticidad", entity.Criticidad);
                paramList.Add("@funcionalidad", entity.Funcionalidad);
                paramList.Add("@descripcion", entity.Descripcion);
                paramList.Add("@fecha", entity.Fecha);
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

        public override void crear(Bitacora entity)
        {
            try
            {
                if (entity.Usuario == null)
                    return;

                string query = "INSERT INTO bitacora (id_usuario,criticidad,funcionalidad,descripcion,fecha,dvh) VALUES(@id_usuario,@criticidad,@funcionalidad,@descripcion,@fecha,@dvh)";

                Dictionary<string, object> paramList = new Dictionary<string, object>();
                paramList.Add("@id_usuario", entity.Usuario.Id);
                paramList.Add("@criticidad", entity.Criticidad);
                paramList.Add("@funcionalidad", entity.Funcionalidad);
                paramList.Add("@descripcion", entity.Descripcion);
                paramList.Add("@fecha", entity.Fecha);
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

        public override void eliminar(Bitacora entity)
        {
            try
            {
                string query = "DELETE FROM BITACORA WHERE ID=" + entity.Id;
                bool ok = sqlHelper.ExecuteQuery(query);
                if (!ok)
                {
                    throw new ProEasyException(105, "ocurrio un error al eliminar la bitacora");
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

        public override Bitacora leer(long id)
        {
            try
            {
                string query = "SELECT * FROM BITACORA WHERE ID=" + id;
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

                Bitacora bitacora = new Bitacora
                {
                    Id = Convert.ToInt32(row["id"]),
                    Criticidad = Convert.ToString(row["criticidad"]),
                    Descripcion = Convert.ToString(row["descripcion"]),
                    Fecha = Convert.ToDateTime(row["fecha"]),
                    Funcionalidad = Convert.ToString(row["funcionalidad"]),
                    //bitacora.Usuario = row.Field<long>("id_usuario");
                    Dvh = Convert.ToString(row["dvh"])
                };

                return bitacora;
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

        public override List<Bitacora> listar()
        {
            try
            {
                string query = "SELECT * FROM BITACORA ORDER BY DVH";
                DataTable list = sqlHelper.ExecuteReader(query);
                List<Bitacora> bitacoras = new List<Bitacora>();
                foreach (DataRow row in list.Rows)
                {
                    Bitacora bitacora = new Bitacora
                    {
                        Id = Convert.ToInt32(row["id"]),
                        Criticidad = Convert.ToString(row["criticidad"]),
                        Descripcion = Convert.ToString(row["descripcion"]),
                        Fecha = Convert.ToDateTime(row["fecha"]),
                        Funcionalidad = Convert.ToString(row["funcionalidad"]),
                        Usuario = Usuario.builder().Id(Convert.ToInt32(row["id_usuario"])).build(),
                        Dvh = Convert.ToString(row["dvh"])
                    };
                    bitacoras.Add(bitacora);
                }
                return bitacoras;
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

        public List<Bitacora> buscar(Bitacora entity)
        {
            try
            {
                string query = "SELECT * FROM BITACORA WHERE fecha between '" + entity.Desde.ToString("yyyy/MM/dd") + " 00:00:00.000' AND '" + entity.Hasta.ToString("yyyy/MM/dd") + " 23:59:59.997' ";
                if (entity.Usuario != null)
                    query += (" AND id_usuario = '" + entity.Usuario.Id + "'");
                if (entity.Criticidad != null)
                    query += (" AND criticidad = '" + entity.Criticidad + "'");


                DataTable list = sqlHelper.ExecuteReader(query);
                List<Bitacora> bitacoras = new List<Bitacora>();
                foreach (DataRow row in list.Rows)
                {
                    Bitacora bitacora = new Bitacora
                    {
                        Id = Convert.ToInt32(row["id"]),
                        Criticidad = Convert.ToString(row["criticidad"]),
                        Descripcion = Convert.ToString(row["descripcion"]),
                        Fecha = Convert.ToDateTime(row["fecha"]),
                        Funcionalidad = Convert.ToString(row["funcionalidad"]),
                        Usuario = Usuario.builder().Id(Convert.ToInt32(row["id_usuario"])).build(),
                        Dvh = Convert.ToString(row["dvh"])
                    };
                    bitacoras.Add(bitacora);
                }
                return bitacoras;
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