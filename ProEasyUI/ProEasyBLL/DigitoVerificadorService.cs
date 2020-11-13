using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class DigitoVerificadorService : EntityService<DigitoVerificador>
    {
        private static DigitoVerificadorService instance;
        readonly DigitoVerificadorMapper mapper = new DigitoVerificadorMapper();

        private DigitoVerificadorService()
        {

        }

        public static DigitoVerificadorService getInstance()
        {
            if (instance == null)
                instance = new DigitoVerificadorService();
            return instance;
        }

        public Boolean verificarIntegridad()
        {
            Boolean isOk = true;
            string dvv = "";
            {
                foreach (Hora entity in new HoraMapper().listar())
                {
                    string dvh = generarDVH(new string[] { entity.Proyecto.Id.ToString(), entity.Tarea.Id.ToString(), new UsuarioMapper().leer(entity.Usuario.Id).Username, entity.Cantidad.ToString() });
                    dvv += dvh;
                    if (!dvh.Equals(entity.Dvh))
                    {
                        this.registrarBitacora("HORA", entity.Id);
                        isOk = false;
                    }
                }
                if (dvv.Length > 0 && !isDvvValid("HORA", dvv))
                {
                    isOk = false;
                }
            }
            {
                dvv = "";
                foreach (Familia entity in new FamiliaMapper().listar())
                {
                    string dvh = generarDVH(new string[] { entity.Nombre });
                    dvv += dvh;
                    if (!dvh.Equals(entity.Dvh))
                    {
                        this.registrarBitacora("FAMILIA", entity.Id);
                        isOk = false;
                    }
                }
                if (dvv.Length > 0 && !isDvvValid("FAMILIA", dvv))
                {
                    isOk = false;
                }
            }
            {
                dvv = "";
                foreach (Proyecto entity in new ProyectoMapper().listar())
                {
                    string dvh = generarDVH(new string[] { entity.Nombre, entity.HorasEstimadas, entity.ValorHora });
                    dvv += dvh;
                    if (!dvh.Equals(entity.Dvh))
                    {
                        this.registrarBitacora("PROYECTO", entity.Id);
                        isOk = false;
                    }
                }
                if (dvv.Length > 0 && !isDvvValid("PROYECTO", dvv))
                {
                    isOk = false;
                }
            }
            {
                dvv = "";
                foreach (Tarea entity in new TareaMapper().listar())
                {
                    string dvh = generarDVH(new string[] { entity.Titulo, entity.Descripcion });
                    dvv += dvh;
                    if (!dvh.Equals(entity.Dvh))
                    {
                        this.registrarBitacora("TAREA", entity.Id);
                        isOk = false;
                    }
                }
                if (dvv.Length > 0 && !isDvvValid("TAREA", dvv))
                {
                    isOk = false;
                }
            }
            {
                dvv = "";
                foreach (Bitacora entity in new BitacoraMapper().listar())
                {
                    string dvh = generarDVH(new string[] { new UsuarioMapper().leer(entity.Usuario.Id).Username, entity.Fecha.ToString("dd/MM/yyyy HH:mm"), entity.Funcionalidad, entity.Descripcion, entity.Criticidad });
                    dvv += dvh;
                    if (!dvh.Equals(entity.Dvh))
                    {
                        this.registrarBitacora("BITACORA", entity.Id);
                        isOk = false;
                    }
                }
                if (!isDvvValid("BITACORA", dvv))
                {
                    isOk = false;
                }
            }
            {
                dvv = "";
                foreach (Usuario entity in new UsuarioMapper().listarTodos())
                {
                    string dvh = generarDVH(new string[] { entity.Username, entity.Apellido, entity.Nombre, entity.Contrasenia });
                    dvv += dvh;
                    if (!dvh.Equals(entity.Dvh))
                    {
                        this.registrarBitacora("USUARIO", entity.Id);
                        isOk = false;
                    }
                }
                if (dvv.Length > 0 && !isDvvValid("USUARIO", dvv))
                {
                    isOk = false;
                }
            }
            {
                dvv = "";

                List<object[]> list = mapper.selectProyectoUsuario();
                foreach (object[] row in list)
                {
                    string dvh = generarDVH(new string[] { row[0].ToString(), new UsuarioMapper().leer((int)row[1]).Username });
                    dvv += dvh;
                    if (!dvh.Equals(row[2].ToString()))
                    {
                        isOk = false;
                    }
                }
                if (!isDvvValid("PROYECTO_USUARIO", dvv))
                {
                    isOk = false;
                }
            }
            {
                dvv = "";
                List<object[]> list = mapper.selectUsuarioFamilia();
                foreach (object[] row in list)
                {
                    string dvh = generarDVH(new string[] { desencriptarAES(new UsuarioMapper().leer((int)row[0]).Username), row[1].ToString() });
                    dvv += dvh;
                    if (!dvh.Equals(row[2]))
                    {
                        isOk = false;
                    }
                }
                if (!isDvvValid("USUARIO_FAMILIA", dvv))
                {
                    isOk = false;
                }
            }
            {
                dvv = "";
                List<object[]> list = mapper.selectFamiliaPatente();
                foreach (object[] row in list)
                {
                    string dvh = generarDVH(new string[] { row[0].ToString(), row[1].ToString() });
                    dvv += dvh;
                    if (!dvh.Equals(row[2]))
                    {
                        isOk = false;
                    }
                }
                if (!isDvvValid("FAMILIA_PATENTE", dvv))
                {
                    isOk = false;
                }
            }
            {
                dvv = "";
                List<object[]> list = mapper.selectUsuarioPatente();
                foreach (object[] row in list)
                {
                    string dvh = generarDVH(new string[] { row[0].ToString(), row[1].ToString() });
                    dvv += dvh;
                    if (!dvh.Equals(row[2]))
                    {
                        isOk = false;
                    }
                }
                if (!isDvvValid("USUARIO_PATENTE", dvv))
                {
                    isOk = false;
                }
            }
            return isOk;
        }

        private bool isDvvValid(string tabla, string dvv)
        {
            return mapper.isDvvValid(tabla, encriptarMD5(dvv));
        }

        public string generarDVH(String[] data)
        {
            String cadena = "";
            for (int i = 0; i < data.Length; i++)
                cadena += data[i];

            return encriptarMD5(cadena);
        }

        public void actualizarDVV(String tabla)
        {
            List<String> dvhs = mapper.listarDvh(tabla);
            StringBuilder dvv = new StringBuilder("");
            foreach (String dvh in dvhs)
                dvv.Append(dvh);

            mapper.actualizar(DigitoVerificador.builder().Tabla(tabla).Valor(encriptarMD5(dvv.ToString())).build());
        }

        public override void crear(DigitoVerificador entity)
        {
            mapper.crear(entity);
        }

        public override void actualizar(DigitoVerificador entity)
        {
            mapper.actualizar(entity);
        }

        public override void eliminar(DigitoVerificador entity)
        {
            mapper.eliminar(entity);
        }

        public override List<DigitoVerificador> listar()
        {
            return mapper.listar();
        }

        public override DigitoVerificador leer(long id)
        {
            return null;
        }

        private string registrarBitacora(string tabla, long Id)
        {
            DateTime fecha = DateTime.Now;
            string dvh = generarDVH(new string[] {
                            "INTEGRIDAD", fecha.ToString("dd/MM/yyyy HH:mm"),
                            "INTEGRIDAD",
                            encriptarAES("ERROR EN CHEQUEO DE DVH HORA ID: " + Id),
                            "ALTA" });
            new BitacoraMapper().crear(Bitacora.builder()
                       .Criticidad("ALTA")
                       .Descripcion(encriptarAES("ERROR EN CHEQUEO DE DVH " + tabla.ToUpper() + " ID: " + Id))
                       .Funcionalidad("INTEGRIDAD")
                       .Fecha(fecha)
                       .Dvh(dvh)
                       .Usuario(Usuario.builder().Username("INTEGRIDAD").build())
                       .build());
            actualizarDVV(tabla.ToUpper());
            return dvh;
        }

        public void recalcularIntegridad()
        {
            string dvv = "";
            {
                foreach (Hora entity in new HoraMapper().listar())
                {
                    string dvh = generarDVH(new string[] { entity.Proyecto.Id.ToString(), entity.Tarea.Id.ToString(), new UsuarioMapper().leer(entity.Usuario.Id).Username, entity.Cantidad.ToString() });
                    dvv += dvh;
                    if (!dvh.Equals(entity.Dvh))
                    {
                        this.registrarBitacora("HORA", entity.Id);
                        this.mapper.actualizarDVH("HORA", entity.Id, dvh);
                    }
                }
            }
            {
                dvv = "";
                foreach (Familia entity in new FamiliaMapper().listar())
                {
                    string dvh = generarDVH(new string[] { entity.Nombre });
                    dvv += dvh;
                    if (!dvh.Equals(entity.Dvh))
                    {
                        this.registrarBitacora("FAMILIA", entity.Id);
                        this.mapper.actualizarDVH("FAMILIA", entity.Id, dvh);
                    }
                }
            }
            {
                dvv = "";
                foreach (Proyecto entity in new ProyectoMapper().listar())
                {
                    string dvh = generarDVH(new string[] { entity.Nombre, entity.HorasEstimadas, entity.ValorHora });
                    dvv += dvh;
                    if (!dvh.Equals(entity.Dvh))
                    {
                        this.registrarBitacora("PROYECTO", entity.Id);
                        this.mapper.actualizarDVH("PROYECTO", entity.Id, dvh);
                    }
                }
            }
            {
                dvv = "";
                foreach (Tarea entity in new TareaMapper().listar())
                {
                    string dvh = generarDVH(new string[] { entity.Titulo, entity.Descripcion });
                    dvv += dvh;
                    if (!dvh.Equals(entity.Dvh))
                    {
                        this.registrarBitacora("TAREA", entity.Id);
                        this.mapper.actualizarDVH("TAREA", entity.Id, dvh);
                    }
                }
            }
            {
                dvv = "";
                foreach (Bitacora entity in new BitacoraMapper().listar())
                {
                    string dvh = generarDVH(new string[] { new UsuarioMapper().leer(entity.Usuario.Id).Username, entity.Fecha.ToString("dd/MM/yyyy HH:mm"), entity.Funcionalidad, entity.Descripcion, entity.Criticidad });
                    dvv += dvh;
                    if (!dvh.Equals(entity.Dvh))
                    {
                        this.registrarBitacora("BITACORA", entity.Id);
                        this.mapper.actualizarDVH("BITACORA", entity.Id, dvh);
                    }
                }
            }
            {
                dvv = "";
                foreach (Usuario entity in new UsuarioMapper().listarTodos())
                {
                    string dvh = generarDVH(new string[] { entity.Username, entity.Apellido, entity.Nombre, entity.Contrasenia });
                    dvv += dvh;
                    if (!dvh.Equals(entity.Dvh))
                    {
                        this.registrarBitacora("USUARIO", entity.Id);
                        this.mapper.actualizarDVH("USUARIO", entity.Id, dvh);
                    }
                }
            }
            {
                dvv = "";

                List<object[]> list = mapper.selectProyectoUsuario();
                foreach (object[] row in list)
                {
                    string dvh = generarDVH(new string[] { row[0].ToString(), new UsuarioMapper().leer((int)row[1]).Username });
                    dvv += dvh;
                    if (!dvh.Equals(row[2].ToString()))
                    {
                        this.mapper.actualizarDVH("PROYECTO_USUARIO", (int)row[0], (int)row[1], dvh);
                    }
                }
            }
            {
                dvv = "";
                List<object[]> list = mapper.selectUsuarioFamilia();
                foreach (object[] row in list)
                {
                    string dvh = generarDVH(new string[] { desencriptarAES(new UsuarioMapper().leer((int)row[0]).Username), row[1].ToString() });
                    dvv += dvh;
                    if (!dvh.Equals(row[2]))
                    {
                        this.mapper.actualizarDVH("USUARIO_FAMILIA", (int)row[0], (int)row[1], dvh);
                    }
                }
            }
            {
                dvv = "";
                List<object[]> list = mapper.selectFamiliaPatente();
                foreach (object[] row in list)
                {
                    string dvh = generarDVH(new string[] { row[0].ToString(), row[1].ToString() });
                    dvv += dvh;
                    if (!dvh.Equals(row[2]))
                    {
                        this.mapper.actualizarDVH("FAMILIA_PATENTE", (int)row[0], (int)row[1], dvh);
                    }
                }
            }
            {
                dvv = "";
                List<object[]> list = mapper.selectUsuarioPatente();
                foreach (object[] row in list)
                {
                    string dvh = generarDVH(new string[] { row[0].ToString(), row[1].ToString() });
                    dvv += dvh;
                    if (!dvh.Equals(row[2]))
                    {
                        this.mapper.actualizarDVH("USUARIO_PATENTE", (int)row[0], (int)row[1], dvh);
                    }
                }
            }
            this.actualizarDVV("HORA");
            this.actualizarDVV("FAMILIA");
            this.actualizarDVV("PROYECTO");
            this.actualizarDVV("TAREA");
            this.actualizarDVV("BITACORA");
            this.actualizarDVV("USUARIO");
            this.actualizarDVV("PROYECTO_USUARIO");
            this.actualizarDVV("USUARIO_FAMILIA");
            this.actualizarDVV("FAMILIA_PATENTE");
            this.actualizarDVV("USUARIO_PATENTE");
        }

    }
}