using BE;
using DAL;
using Ionic.Zip;
using System;
using System.Data;
using System.IO;

namespace BLL
{
    public class DbBackUpService
    {
        private static DbBackUpService instance;
        protected readonly SqlHelper sqlHelper = SqlHelper.GetInstance();

        private DbBackUpService()
        {

        }

        public static DbBackUpService getInstance()
        {
            if (instance == null)
                instance = new DbBackUpService();
            return instance;
        }

        public string generarBackUp(int partitionNumber)
        {

            BitacoraService.getInstance().crear(
                Bitacora.builder()
                .Criticidad("ALTA")
                .Descripcion("Genero un bkp de la base")
                .Funcionalidad("BACKUP")
                .Fecha(DateTime.Now)
                .Usuario(Session.getInstance().Usuario)
                .build()
            );


            var nombreBaseDeDatos = sqlHelper.getDatabaseName();
            var nombreBackup = nombreBaseDeDatos + "-" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".bak";

            string cmd = "BACKUP DATABASE [" + nombreBaseDeDatos + "] TO DISK='" + nombreBackup + "'";

            sqlHelper.ExecuteQuery(cmd);

            DataTable list = sqlHelper.ExecuteReader(String.Format("SELECT top 1 physical_device_name as ruta ,backup_start_date, backup_finish_date, backup_size AS tamaño FROM msdb.dbo.backupset b JOIN msdb.dbo.backupmediafamily m ON b.media_set_id = m.media_set_id WHERE physical_device_name like '%{0}%' ORDER BY backup_finish_date DESC", nombreBackup));
            if (list.Rows.Count == 0)
            {
                throw new Exception("Ocurrio un error al crear el bkp");
            }
            var path = list.Rows[0].Field<string>("ruta");
            CreateZipFile(path, partitionNumber);
            File.Delete(path);
            return path.Substring(0, path.LastIndexOf("\\"));
        }

        public void restaurar(string path)
        {
            using (ZipFile zip = ZipFile.Read(path))
            {
                foreach (ZipEntry e in zip)
                {
                    e.Extract(path.Substring(0, path.LastIndexOf("\\")));
                }
            }

            var nombreBaseDeDatos = sqlHelper.getDatabaseName();

            string cmd = string.Format("ALTER DATABASE [" + nombreBaseDeDatos + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
            sqlHelper.ExecuteQuery(cmd);

            cmd = "USE MASTER RESTORE DATABASE [" + nombreBaseDeDatos + "] FROM DISK='" + path.Replace(".zip", "") + "'WITH REPLACE;";
            sqlHelper.ExecuteQuery(cmd);

            cmd = string.Format("ALTER DATABASE [" + nombreBaseDeDatos + "] SET MULTI_USER");
            sqlHelper.ExecuteQuery(cmd);

        }

        private static void CreateZipFile(string filePath, int partitions)
        {
            using (var zipFile = new Ionic.Zip.ZipFile())
            {
                zipFile.CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression;
                zipFile.AddFile(filePath, directoryPathInArchive: string.Empty);
                var size = (int)new FileInfo(filePath).Length / partitions;
                zipFile.MaxOutputSegmentSize = size > 65536 ? size : 65536;
                zipFile.Save(filePath + ".zip");
            }
        }

    }

}