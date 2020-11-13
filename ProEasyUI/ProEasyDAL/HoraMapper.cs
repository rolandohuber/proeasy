using BE;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class HoraMapper : EntityMapperMapper<Hora>
    {
        public override void actualizar(Hora entity)
        {
            try
            {
                string query = "UPDATE HORA SET id_proyecto = @id_proyecto,id_tarea = @id_tarea,id_usuario = @id_usuario,fecha = @fecha,cantidad = @cantidad,eliminado = @eliminado,dvh = @dvh WHERE id = @id";
                Dictionary<string, object> paramList = new Dictionary<string, object>();
                paramList.Add("@id", entity.Id);
                paramList.Add("@id_proyecto", entity.Proyecto.Id);
                paramList.Add("@id_tarea", entity.Tarea.Id);
                paramList.Add("@id_usuario", entity.Usuario.Id);
                paramList.Add("@fecha", entity.Fecha);
                paramList.Add("@cantidad", entity.Cantidad);
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

        public override void crear(Hora entity)
        {
            try
            {
                string query = "INSERT INTO HORA(id_proyecto,id_tarea,id_usuario,fecha,cantidad,eliminado,dvh)VALUES(@id_proyecto,@id_tarea,@id_usuario,@fecha,@cantidad,@eliminado,@dvh)";

                Dictionary<string, object> paramList = new Dictionary<string, object>();
                paramList.Add("@id_proyecto", entity.Proyecto.Id);
                paramList.Add("@id_tarea", entity.Tarea.Id);
                paramList.Add("@id_usuario", entity.Usuario.Id);
                paramList.Add("@fecha", entity.Fecha);
                paramList.Add("@cantidad", entity.Cantidad);
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

        public List<Hora> listarPorTarea(Tarea tarea)
        {
            try
            {
                string query = "SELECT * FROM HORA H where H.ID_TAREA=" + tarea.Id;
                DataTable list = sqlHelper.ExecuteReader(query);

                List<Hora> lista = new List<Hora>();
                foreach (DataRow row in list.Rows)
                {
                    Usuario u = new Usuario();
                    u.Id = Convert.ToInt32(row["id_usuario"]);

                    Proyecto p = new Proyecto();
                    p.Id = Convert.ToInt32(row["id_proyecto"]);

                    Hora hora = new Hora
                    {
                        Id = Convert.ToInt32(row["id"]),
                        Cantidad = Convert.ToInt32(row["cantidad"]),
                        Eliminado = Convert.ToBoolean(row["eliminado"]),
                        Fecha = Convert.ToDateTime(row["fecha"]),
                        Usuario = u,
                        Proyecto = p,
                        Tarea = tarea,
                        Dvh = Convert.ToString(row["dvh"])
                    };
                    lista.Add(hora);
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

        public override void eliminar(Hora entity)
        {
            try
            {
                string query = "DELETE FROM HORA WHERE id = @id";
                Dictionary<string, object> paramList = new Dictionary<string, object>();
                paramList.Add("@id", entity.Id);

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

        public override Hora leer(long id)
        {
            try
            {
                string query = "SELECT * FROM HORA WHERE ID=" + id;
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

                Hora hora = new Hora
                {
                    Id = Convert.ToInt32(row["id"]),
                    Cantidad = Convert.ToInt32(row["cantidad"]),
                    Eliminado = Convert.ToBoolean(row["eliminado"]),
                    Fecha = Convert.ToDateTime(row["fecha"]),
                    //hora.Usuario = row.Field<long>("id_usuario");
                    //hora.Proyecto = row.Field<long>("id_proyecto");
                    //hora.Tarea = row.Field<long>("id_tarea");
                    Dvh = Convert.ToString(row["dvh"])
                };

                return hora;
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

        public override List<Hora> listar()
        {
            try
            {
                string query = "SELECT * FROM HORA ORDER BY DVH";
                DataTable list = sqlHelper.ExecuteReader(query);

                List<Hora> lista = new List<Hora>();
                foreach (DataRow row in list.Rows)
                {
                    Hora hora = new Hora
                    {
                        Id = Convert.ToInt32(row["id"]),
                        Cantidad = Convert.ToInt32(row["cantidad"]),
                        Eliminado = Convert.ToBoolean(row["eliminado"]),
                        Fecha = Convert.ToDateTime(row["fecha"]),
                        Usuario = Usuario.builder().Id(Convert.ToInt32(row["id_usuario"])).build(),
                        Proyecto = Proyecto.builder().Id(Convert.ToInt32(row["id_proyecto"])).build(),
                        Tarea = Tarea.builder().Id(Convert.ToInt32(row["id_tarea"])).build(),
                        Dvh = Convert.ToString(row["dvh"])
                    };
                    lista.Add(hora);
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

        public List<Hora> buscar(Hora filtro)
        {
            try
            {
                string query = "SELECT * FROM HORA WHERE ID_USUARIO=@USUARIO OR ID_PROYECTO=@PROYECTO OR ID_TAREA=@TAREA";

                Dictionary<string, object> paramList = new Dictionary<string, object>();
                paramList.Add("@USUARIO", filtro.Usuario != null ? filtro.Usuario.Id : 0);
                paramList.Add("@PROYECTO", filtro.Proyecto != null ? filtro.Proyecto.Id : 0);
                paramList.Add("@TAREA", filtro.Tarea != null ? filtro.Tarea.Id : 0);


                DataTable list = sqlHelper.ExecuteQueryWithParamsRetDataTable(query, paramList);

                List<Hora> lista = new List<Hora>();
                foreach (DataRow row in list.Rows)
                {
                    Hora hora = new Hora
                    {
                        Id = Convert.ToInt32(row["id"]),
                        Cantidad = Convert.ToInt32(row["cantidad"]),
                        Eliminado = Convert.ToBoolean(row["eliminado"]),
                        Fecha = Convert.ToDateTime(row["fecha"]),
                        Usuario = Usuario.builder().Id(Convert.ToUInt32(row["id_usuario"])).build(),
                        Proyecto = Proyecto.builder().Id(Convert.ToUInt32(row["id_proyecto"])).build(),
                        Tarea = Tarea.builder().Id(Convert.ToUInt32(row["id_tarea"])).build(),
                        Dvh = Convert.ToString(row["dvh"])
                    };
                    lista.Add(hora);
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
    }

}