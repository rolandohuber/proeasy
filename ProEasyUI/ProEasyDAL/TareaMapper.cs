using BE;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class TareaMapper : EntityMapperMapper<Tarea>
    {
        public override void actualizar(Tarea entity)
        {
            try
            {
                string query = "UPDATE tarea SET id_proyecto = @id_proyecto,titulo = @titulo,descripcion = @descripcion,eliminado = @eliminado,dvh = @dvh WHERE id = @id";

                Dictionary<string, object> paramList = new Dictionary<string, object>();
                paramList.Add("@id", entity.Id);
                paramList.Add("@id_proyecto", entity.Proyecto.Id);
                paramList.Add("@titulo", entity.Titulo);
                paramList.Add("@descripcion", entity.Descripcion);
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

        public override void crear(Tarea entity)
        {
            try
            {
                string query = "INSERT INTO tarea (id_proyecto,titulo,descripcion,eliminado,dvh) VALUES (@id_proyecto,@titulo,@descripcion,@eliminado,@dvh)";

                Dictionary<string, object> paramList = new Dictionary<string, object>();
                paramList.Add("@id_proyecto", entity.Proyecto.Id);
                paramList.Add("@titulo", entity.Titulo);
                paramList.Add("@descripcion", entity.Descripcion);
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

        public override void eliminar(Tarea entity)
        {
            try
            {
                string query = "DELETE FROM TAREA WHERE ID=" + entity.Id;
                bool ok = sqlHelper.ExecuteQuery(query);
                if (!ok)
                {
                    throw new ProEasyException(25, "ocurrio un error al eliminar la tarea");
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

        public List<Tarea> listarPorProyecto(Proyecto proyecto)
        {
            try
            {
                string query = "SELECT T.* FROM TAREA T WHERE ID_PROYECTO=" + proyecto.Id;
                DataTable list = sqlHelper.ExecuteReader(query);
                List<Tarea> tareas = new List<Tarea>();
                foreach (DataRow row in list.Rows)
                {
                    Tarea tarea = new Tarea
                    {
                        Id = Convert.ToInt32(row["id"]),
                        Titulo = Convert.ToString(row["titulo"]),
                        Eliminado = Convert.ToBoolean(row["eliminado"]),
                        Descripcion = Convert.ToString(row["descripcion"]),
                        Dvh = Convert.ToString(row["dvh"])
                    };
                    tarea.Proyecto = proyecto;
                    tareas.Add(tarea);
                }
                return tareas;
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

        public Boolean existe(long id, string titulo)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM TAREA WHERE ID_PROYECTO != " + id + " AND TITULO = '" + titulo + "'";
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

        public override Tarea leer(long id)
        {
            try
            {
                string query = "SELECT * FROM TAREA WHERE ID=" + id;
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

                Tarea tarea = new Tarea
                {
                    Id = Convert.ToInt32(row["id"]),
                    Titulo = Convert.ToString(row["titulo"]),
                    //tarea.Proyecto = Convert.ToInt32(row["proyecto"]);
                    Eliminado = Convert.ToBoolean(row["eliminado"]),
                    Descripcion = Convert.ToString(row["descripcion"]),
                    Dvh = Convert.ToString(row["dvh"])
                };
                return tarea;
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

        public override List<Tarea> listar()
        {
            try
            {
                string query = "SELECT T.* FROM TAREA T  ORDER BY T.DVH";
                DataTable list = sqlHelper.ExecuteReader(query);
                List<Tarea> tareas = new List<Tarea>();
                foreach (DataRow row in list.Rows)
                {
                    Tarea tarea = new Tarea
                    {
                        Id = Convert.ToInt32(row["id"]),
                        Titulo = Convert.ToString(row["titulo"]),
                        //tarea.Proyecto = Convert.ToInt32(row["proyecto"]);
                        Eliminado = Convert.ToBoolean(row["eliminado"]),
                        Descripcion = Convert.ToString(row["descripcion"]),
                        Dvh = Convert.ToString(row["dvh"])
                    };
                    tareas.Add(tarea);
                }
                return tareas;
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