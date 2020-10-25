using BE;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class DigitoVerificadorMapper : EntityMapperMapper<DigitoVerificador>
    {
        public override void actualizar(DigitoVerificador entity)
        {
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("@tabla", entity.Tabla);
            paramList.Add("@valor", entity.Valor);

            string query = "SELECT COUNT(*) FROM DIGITO_VERIFICADOR WHERE tabla = '" + entity.Tabla + "'";
            int cant = sqlHelper.ExecuteScalar(query);
            if (cant > 0)
            {
                query = "UPDATE DIGITO_VERIFICADOR SET valor = @valor WHERE tabla = @tabla";
            }
            else
            {
                query = "INSERT INTO DIGITO_VERIFICADOR(tabla,valor) VALUES(@tabla,@valor)";
            }
            sqlHelper.ExecuteQueryWithParams(query, paramList);
        }

        public override void crear(DigitoVerificador entity)
        {
            string query = "INSERT INTO DIGITO_VERIFICADOR(tabla,valor) VALUES (@tabla,@valor)";

            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("@tabla", entity.Tabla);
            paramList.Add("@valor", entity.Valor);

            sqlHelper.ExecuteQueryWithParams(query, paramList);
        }

        public List<String> listarDvh(string tabla)
        {
            string query = "SELECT dvh FROM " + tabla + " order by dvh";
            DataTable list = sqlHelper.ExecuteReader(query);
            List<String> lista = new List<String>();
            foreach (DataRow row in list.Rows)
            {
                lista.Add(Convert.ToString(row["dvh"]));
            }
            return lista;
        }

        public override void eliminar(DigitoVerificador entity)
        {
            string query = "DELETE FROM DIGITO_VERIFICADOR WHERE ID=" + entity.Id;
            bool ok = sqlHelper.ExecuteQuery(query);
            if (!ok)
            {
                throw new Exception("ocurrio un error al eliminar el digito verificador");
            }
        }

        public override DigitoVerificador leer(long id)
        {
            string query = "SELECT * FROM DIGITO_VERIFICADOR WHERE ID = " + id;
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

            DigitoVerificador item = new DigitoVerificador
            {
                Id = Convert.ToInt32(row["id"]),
                Tabla = Convert.ToString(row["tabla"]),
                Valor = Convert.ToString(row["valor"])
            };

            return item;
        }

        public override List<DigitoVerificador> listar()
        {
            string query = "SELECT * FROM DIGITO_VERIFICADOR";
            DataTable list = sqlHelper.ExecuteReader(query);
            List<DigitoVerificador> lista = new List<DigitoVerificador>();
            foreach (DataRow row in list.Rows)
            {
                DigitoVerificador item = new DigitoVerificador
                {
                    Id = Convert.ToInt32(row["id"]),
                    Tabla = Convert.ToString(row["tabla"]),
                    Valor = Convert.ToString(row["valor"])
                };
                lista.Add(item);
            }
            return lista;
        }

        public bool isDvvValid(string tabla, string dvv)
        {
            string query = "SELECT COUNT(*) FROM DIGITO_VERIFICADOR WHERE TABLA='" + tabla + "' AND VALOR='" + dvv + "'";
            return sqlHelper.ExecuteScalar(query) > 0;
        }

        public List<object[]> selectProyectoUsuario()
        {
            List<object[]> list = new List<object[]>();
            string query = "SELECT * FROM PROYECTO_USUARIO ORDER BY DVH";
            DataTable table = sqlHelper.ExecuteReader(query);
            foreach (DataRow row in table.Rows)
            {
                list.Add(new object[] {
                    Convert.ToInt32(row["id_proyecto"]),
                    Convert.ToInt32(row["id_usuario"]),
                    Convert.ToString(row["dvh"])
                });
            }
            return list;
        }

        public List<object[]> selectUsuarioFamilia()
        {
            List<object[]> list = new List<object[]>();
            string query = "SELECT * FROM USUARIO_FAMILIA ORDER BY DVH";
            DataTable table = sqlHelper.ExecuteReader(query);
            foreach (DataRow row in table.Rows)
            {
                list.Add(new object[] {
                    Convert.ToInt32(row["id_usuario"]),
                    Convert.ToInt32(row["id_familia"]),
                    Convert.ToString(row["dvh"])
                });
            }
            return list;
        }

        public List<object[]> selectFamiliaPatente()
        {
            string query = "SELECT * FROM FAMILIA_PATENTE ORDER BY DVH";
            List<object[]> list = new List<object[]>();
            DataTable table = sqlHelper.ExecuteReader(query);
            foreach (DataRow row in table.Rows)
            {
                list.Add(new object[] {
                    Convert.ToInt32(row["id_familia"]),
                    Convert.ToInt32(row["id_patente"]),
                    Convert.ToString(row["dvh"])
                });
            }
            return list;
        }

        public List<object[]> selectUsuarioPatente()
        {
            string query = "SELECT * FROM USUARIO_PATENTE ORDER BY DVH";
            List<object[]> list = new List<object[]>();
            DataTable table = sqlHelper.ExecuteReader(query);
            foreach (DataRow row in table.Rows)
            {
                list.Add(new object[] {
                    Convert.ToInt32(row["id_usuario"]),
                    Convert.ToInt32(row["id_patente"]),
                    Convert.ToString(row["dvh"])
                });
            }
            return list;
        }
    }
}