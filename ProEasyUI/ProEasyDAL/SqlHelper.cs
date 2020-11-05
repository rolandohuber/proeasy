using System;
using System.Data;
using Nini.Config;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class SqlHelper
    {
        string Cconnstr;

        private static SqlHelper instance;

        public static SqlHelper GetInstance()
        {
            if (instance == null)
            {
                string configFileName = AppDomain.CurrentDomain.BaseDirectory + "config.ini";
                IniConfigSource configSource = new IniConfigSource(configFileName);

                IConfig demoConfigSection = configSource.Configs["Proeasy"];
                var database = demoConfigSection.Get("connectionString", string.Empty);
                var connectionString = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(database));
                {
                    try
                    {
                        SqlConnection conexion = new SqlConnection();
                        conexion.ConnectionString = connectionString;
                        conexion.Database.ToString();
                        conexion.Open();
                        conexion.Close();
                    }
                    catch (Exception)
                    {
                        throw new BE.ProEasyException(100, "Conexion no establecida");
                    }
                }

                instance = new SqlHelper(connectionString);
            }
            return instance;
        }

        private SqlHelper(string pconnstr)
        {
            Cconnstr = pconnstr;
        }

        public string getDatabaseName()
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = Cconnstr;
            var database = conexion.Database.ToString();
            conexion.Close();
            return database;
        }

        public bool ExecuteQuery(string pQuery)
        {
            try
            {
                SqlConnection conexion = new SqlConnection();
                SqlCommand comando = new SqlCommand();
                bool retorno = false;

                conexion.ConnectionString = Cconnstr;

                comando.Connection = conexion;

                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = pQuery;

                conexion.Open();

                retorno = comando.ExecuteNonQuery() > 0;

                conexion.Close();

                return retorno;
            }
            catch (Exception)
            {
                throw new BE.ProEasyException(100, "Conexion no establecida");
            }

        }

        public DataTable ExecuteReader(string pQuery)
        {
            try
            {
                SqlConnection conexion = new SqlConnection();
                SqlCommand comando = new SqlCommand();
                DataTable DB = new DataTable();

                conexion.ConnectionString = Cconnstr;

                comando.Connection = conexion;

                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = pQuery;

                conexion.Open();

                SqlDataReader reader = comando.ExecuteReader();

                DB.Load(reader);

                conexion.Close();

                return DB;
            }
            catch (Exception)
            {
                throw new BE.ProEasyException(100, "Conexion no establecida");
            }

        }

        public int ExecuteScalar(string pQuery)
        {
            try
            {
                SqlConnection conexion = new SqlConnection();
                SqlCommand comando = new SqlCommand();
                int res = 0;

                conexion.ConnectionString = Cconnstr;

                comando.Connection = conexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = pQuery;

                conexion.Open();

                res = (int)comando.ExecuteScalar();

                conexion.Close();

                return res;
            }
            catch (Exception)
            {
                throw new BE.ProEasyException(100, "Conexion no establecida");
            }
        }

        public int ExecuteQueryWithParams(string pQuery, Dictionary<string, object> paramList)
        {
            try
            {
                SqlConnection conexion = new SqlConnection();
                SqlCommand comando = new SqlCommand();
                int res = 0;

                conexion.ConnectionString = Cconnstr;

                comando.Connection = conexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = pQuery;

                foreach (string key in paramList.Keys)
                {
                    comando.Parameters.AddWithValue(key, paramList[key]);
                }

                conexion.Open();

                res = (int)comando.ExecuteNonQuery();

                conexion.Close();

                return res;
            }
            catch (Exception)
            {
                throw new BE.ProEasyException(100, "Conexion no establecida");
            }
        }

        public DataTable ExecuteQueryWithParamsRetDataTable(string pQuery, Dictionary<string, object> paramList)
        {
            try
            {
                SqlConnection conexion = new SqlConnection();
                SqlCommand comando = new SqlCommand();

                conexion.ConnectionString = Cconnstr;

                comando.Connection = conexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = pQuery;

                foreach (string key in paramList.Keys)
                {
                    comando.Parameters.AddWithValue(key, paramList[key]);
                }
                conexion.Open();

                SqlDataReader reader = comando.ExecuteReader();
                DataTable DB = new DataTable();
                if (reader.HasRows)
                {
                    DB.Load(reader);
                }
                conexion.Close();

                return DB;
            }
            catch (Exception)
            {
                throw new BE.ProEasyException(100, "Conexion no establecida");
            }
        }
    }
}
