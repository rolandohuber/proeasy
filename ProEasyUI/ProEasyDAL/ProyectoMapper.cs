using BE;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class ProyectoMapper : EntityMapperMapper<Proyecto>
    {
        public List<Proyecto> obtenerProyectos(DateTime desde, DateTime hasta)
        {
            try
            {
                string query = "select p.* from proyecto p where p.fecha <= @until and p.fecha >= @since";

                Dictionary<string, object> paramList = new Dictionary<string, object>();
                paramList.Add("@since", desde != null ? desde : new DateTime());
                paramList.Add("@until", hasta != null ? hasta : DateTime.Now);

                DataTable list = sqlHelper.ExecuteQueryWithParamsRetDataTable(query, paramList);
                List<Proyecto> entities = new List<Proyecto>();
                foreach (DataRow row in list.Rows)
                {
                    Proyecto entity = new Proyecto
                    {
                        Id = Convert.ToInt32(row["id"]),
                        Nombre = Convert.ToString(row["nombre"]),
                        HorasEstimadas = Convert.ToString(row["horas_estimadas"]),
                        ValorHora = Convert.ToString(row["valor_hora"]),
                        Habilitado = Convert.ToBoolean(row["habilitado"]),
                        Fecha = Convert.ToDateTime(row["fecha"]),
                        Eliminado = Convert.ToBoolean(row["eliminado"]),
                        Dvh = Convert.ToString(row["dvh"])
                    };
                    entities.Add(entity);
                }
                return entities;
            }
            catch (Exception ex)
            {
                throw new ProEasyException(1, ex.Message);
            }
        }

        public override void crear(Proyecto entity)
        {
            try
            {
                string query = "INSERT INTO proyecto (nombre,horas_estimadas,valor_hora,habilitado,fecha,eliminado,dvh) VALUES(@nombre,@horas_estimadas,@valor_hora,@habilitado,@fecha,@eliminado,@dvh)";

                Dictionary<string, object> paramList = new Dictionary<string, object>();
                paramList.Add("@id", entity.Id);
                paramList.Add("@nombre", entity.Nombre);
                paramList.Add("@horas_estimadas", entity.HorasEstimadas);
                paramList.Add("@valor_hora", entity.ValorHora);
                paramList.Add("@habilitado", entity.Habilitado);
                paramList.Add("@fecha", entity.Fecha);
                paramList.Add("@eliminado", entity.Eliminado);
                paramList.Add("@dvh", entity.Dvh);

                sqlHelper.ExecuteQueryWithParams(query, paramList);
            }
            catch (Exception ex)
            {
                throw new ProEasyException(1, ex.Message);
            }
        }

        public override void actualizar(Proyecto entity)
        {
            try
            {
                string query = "UPDATE proyecto SET nombre = @nombre,horas_estimadas = @horas_estimadas,valor_hora = @valor_hora,habilitado = @habilitado,fecha = @fecha,eliminado = @eliminado,dvh = @dvh WHERE id = @id";

                Dictionary<string, object> paramList = new Dictionary<string, object>();
                paramList.Add("@id", entity.Id);
                paramList.Add("@nombre", entity.Nombre);
                paramList.Add("@horas_estimadas", entity.HorasEstimadas);
                paramList.Add("@valor_hora", entity.ValorHora);
                paramList.Add("@habilitado", entity.Habilitado);
                paramList.Add("@fecha", entity.Fecha);
                paramList.Add("@eliminado", entity.Eliminado);
                paramList.Add("@dvh", entity.Dvh);

                sqlHelper.ExecuteQueryWithParams(query, paramList);
            }
            catch (Exception ex)
            {
                throw new ProEasyException(1, ex.Message);
            }
        }

        public Boolean existe(long id, String nombre)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM PROYECTO WHERE ID != " + id + " AND nombre = '" + nombre + "'";
                int count = sqlHelper.ExecuteScalar(query);

                return count > 0;
            }
            catch (Exception ex)
            {
                throw new ProEasyException(1, ex.Message);
            }
        }

        public override void eliminar(Proyecto entity)
        {
            try
            {
                string query = "DELETE FROM PROYECTO WHERE ID=" + entity.Id;
                bool ok = sqlHelper.ExecuteQuery(query);
                if (!ok)
                {
                    throw new ProEasyException(45, "ocurrio un error al eliminar el proyecto");
                }
            }
            catch (Exception ex)
            {
                throw new ProEasyException(1, ex.Message);
            }
        }

        public override List<Proyecto> listar()
        {
            try
            {
                string query = "SELECT T.* FROM PROYECTO T  ORDER BY T.DVH";
                DataTable list = sqlHelper.ExecuteReader(query);
                List<Proyecto> entities = new List<Proyecto>();
                foreach (DataRow row in list.Rows)
                {
                    Proyecto entity = new Proyecto
                    {
                        Id = Convert.ToInt32(row["id"]),
                        Nombre = Convert.ToString(row["nombre"]),
                        HorasEstimadas = Convert.ToString(row["horas_estimadas"]),
                        ValorHora = Convert.ToString(row["valor_hora"]),
                        Habilitado = Convert.ToBoolean(row["habilitado"]),
                        Fecha = Convert.ToDateTime(row["fecha"]),
                        Eliminado = Convert.ToBoolean(row["eliminado"]),
                        Dvh = Convert.ToString(row["dvh"])
                    };
                    entities.Add(entity);
                }
                return entities;
            }
            catch (Exception ex)
            {
                throw new ProEasyException(1, ex.Message);
            }
        }

        public override Proyecto leer(long id)
        {
            try
            {
                string query = "SELECT * FROM PROYECTO WHERE ID=" + id;
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

                Proyecto entity = new Proyecto
                {
                    Id = Convert.ToInt32(row["id"]),
                    Nombre = Convert.ToString(row["nombre"]),
                    HorasEstimadas = Convert.ToString(row["horas_estimadas"]),
                    ValorHora = Convert.ToString(row["valor_hora"]),
                    Habilitado = Convert.ToBoolean(row["habilitado"]),
                    Fecha = Convert.ToDateTime(row["fecha"]),
                    Eliminado = Convert.ToBoolean(row["eliminado"]),
                    Dvh = Convert.ToString(row["dvh"])
                };
                return entity;
            }
            catch (Exception ex)
            {
                throw new ProEasyException(1, ex.Message);
            }
        }
    }

}