using BE;
using DAL;
using System;
using System.Text;
using System.Collections.Generic;

namespace BLL
{
    public class UsuarioService : EntityService<Usuario>
    {
        private static UsuarioService instance;
        readonly UsuarioMapper usuarioMapper = new UsuarioMapper();
        readonly PatenteMapper patenteMapper = new PatenteMapper();
        readonly IdiomaMapper idiomaMapper = new IdiomaMapper();
        readonly DigitoVerificadorService verificadorService = DigitoVerificadorService.getInstance();

        private UsuarioService()
        {

        }

        public static UsuarioService getInstance()
        {
            if (instance == null)
                instance = new UsuarioService();
            return instance;
        }

        public string generarContrasenia()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ!@#$%abcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();

            try
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < 12; i++)
                    sb.Append(chars[random.Next(chars.Length)]);

                return sb.ToString(); ;
            }
            catch (Exception)
            {
                throw new ProEasyException(10, "Ocurrio un error al generar la contraseña");
            }

        }

        public Usuario login(string usuario, string contraseña)
        {
            if (!verificadorService.verificarIntegridad())
                throw new ProEasyException(11, "Error al verificar la integridad de la base");

            if (usuarioMapper.estaBloqueado(encriptarAES(usuario)))
                throw new ProEasyException(12, "El usuario se encuentra bloqueado");

            Usuario user = usuarioMapper.login(encriptarAES(usuario), encriptarMD5(contraseña));
            user.Idioma = idiomaMapper.leer(user.Idioma.Id);
            user.Intentos = 0;
            usuarioMapper.actualizar(user);

            List<Patente> patentes = patenteMapper.obtenerTodasLasPatentes(user);
            foreach (Patente p in patentes)
            {
                p.Nombre = desencriptarAES(p.Nombre);
            }
            user.Patentes = patentes;
            BitacoraService.getInstance().crear(
                Bitacora.builder()
                .Criticidad("ALTA")
                .Criticidad("ALTA")
                .Descripcion("Login usuario")
                .Funcionalidad("LOGIN")
                .Fecha(DateTime.Now)
                .Usuario(user)
                .Data(user)
                .build()
            );
            return user;
        }

        public override void crear(Usuario entity)
        {
            var usernameMail = entity.Username;
            entity.Username = encriptarAES(entity.Username);

            if (this.usuarioMapper.existe(entity))
                throw new ProEasyException(13, "El usuario ya existe");
            var passMail = generarContrasenia();

            entity.Contrasenia = encriptarMD5(passMail);
            entity.ValorHora = encriptarAES(entity.ValorHora);
            entity.Dvh = verificadorService.generarDVH(new string[] { entity.Username, entity.Apellido, entity.Nombre, entity.Contrasenia });
            this.usuarioMapper.crear(entity);
            verificadorService.actualizarDVV("USUARIO");

            entity.Contrasenia = passMail;
            entity.Username = usernameMail;
            new EmailService().send(entity, false);
            BitacoraService.getInstance().crear(
            Bitacora.builder()
                .Criticidad("ALTA")
                .Descripcion("Se creo un usuario")
                .Funcionalidad("CREAR_USUARIO")
                .Fecha(DateTime.Now)
                .Usuario(Session.getInstance().Usuario)
                .Data(entity)
                .build()
            );
        }

        public override void actualizar(Usuario entity)
        {
            entity.Username = encriptarAES(entity.Username);

            if (this.usuarioMapper.existe(entity))
                throw new ProEasyException(13, "El usuario ya existe");

            entity.ValorHora = encriptarAES(entity.ValorHora);
            entity.Dvh = verificadorService.generarDVH(new string[] { entity.Username, entity.Apellido, entity.Nombre, entity.Contrasenia });

            this.usuarioMapper.actualizar(entity);
            verificadorService.actualizarDVV("USUARIO");

            BitacoraService.getInstance().crear(
            Bitacora.builder()
               .Criticidad("ALTA")
               .Descripcion("Se actualizo un usuario")
               .Funcionalidad("ACTUALIZAR_USUARIO")
               .Fecha(DateTime.Now)
               .Usuario(Session.getInstance().Usuario)
               .Data(entity)
               .build()
           );
        }

        public override void eliminar(Usuario entity)
        {
            foreach (Patente patente in patenteMapper.obtenerTodasLasPatentes(entity))
            {
                if (!patenteMapper.existeOtraAsignacion(patente.Id, entity.Id))
                    throw new ProEasyException(14, "Hay patentes que quedaran sin asignacion");
            }

            this.usuarioMapper.eliminar(entity);
            BitacoraService.getInstance().crear(
            Bitacora.builder()
              .Criticidad("ALTA")
              .Descripcion("Se elimino un usuario")
              .Funcionalidad("ELIMINAR_USUARIO")
              .Fecha(DateTime.Now)
              .Usuario(Session.getInstance().Usuario)
              .Data(entity)
              .build()
            );
            verificadorService.actualizarDVV("USUARIO");
        }

        public override List<Usuario> listar()
        {
            List<Usuario> list = this.usuarioMapper.listar();
            foreach (Usuario usuario in list)
            {
                usuario.Username = desencriptarAES(usuario.Username);
                usuario.ValorHora = desencriptarAES(usuario.ValorHora);
            }
            BitacoraService.getInstance().crear(
             Bitacora.builder()
             .Criticidad("BAJA")
             .Descripcion("Se listaron los usuarios")
             .Funcionalidad("LISTAR_USUARIO")
             .Fecha(DateTime.Now)
             .Usuario(Session.getInstance().Usuario)
             .build()
         );
            return list;
        }

        public override Usuario leer(long id)
        {
            Usuario usuario = this.usuarioMapper.leer(id);
            usuario.Username = desencriptarAES(usuario.Username);
            usuario.ValorHora = desencriptarAES(usuario.ValorHora);

            BitacoraService.getInstance().crear(
            Bitacora.builder()
            .Criticidad("BAJA")
            .Descripcion("Se consulto un usuario")
            .Funcionalidad("LEER_USUARIO")
            .Fecha(DateTime.Now)
            .Usuario(Session.getInstance().Usuario)
            .build()
        );
            return usuario;
        }

        public void resetPass(Usuario user)
        {
            var newPass = generarContrasenia();
            user.Contrasenia = encriptarMD5(newPass);
            actualizar(user);
            BitacoraService.getInstance().crear(
                Bitacora.builder()
                .Criticidad("MEDIA")
                .Descripcion("Se reseteo la contraseña de un usuario")
                .Funcionalidad("RESET_PASS_USUARIO")
                .Fecha(DateTime.Now)
                .Usuario(Session.getInstance().Usuario)
                .build()
            );
            user.Contrasenia = newPass;
            new EmailService().send(user, true);
        }

        public List<Usuario> obtenerUsuariosAsignados(Proyecto proyecto)
        {
            List<Usuario> usuarios = usuarioMapper.obtenerUsuariosAsignados(proyecto);
            BitacoraService.getInstance().crear(
               Bitacora.builder()
               .Criticidad("BAJA")
               .Descripcion("Se obtienen los usuarios asociados al proyecto")
               .Funcionalidad("LISTAR_USUARIOS_ASIGNADOS")
               .Fecha(DateTime.Now)
               .Usuario(Session.getInstance().Usuario)
               .build()
           );
            return usuarios;
        }

        public List<Usuario> obtenerUsuariosDisponibles(Proyecto proyecto)
        {
            List<Usuario> usuarios = usuarioMapper.obtenerUsuariosDisponibles(proyecto);
            BitacoraService.getInstance().crear(
              Bitacora.builder()
              .Criticidad("BAJA")
              .Descripcion("Se obtienen los usuarios disponibles para el proyecto")
              .Funcionalidad("LISTAR_USUARIOS_DISPONIBLES")
              .Fecha(DateTime.Now)
              .Usuario(Session.getInstance().Usuario)
              .build()
          );
            return usuarios;
        }

        public void asignarRecurso(Proyecto proyecto, Usuario usuario)
        {
            usuarioMapper.asignarRecurso(proyecto, usuario, verificadorService.generarDVH(new string[] { proyecto.Id.ToString(), usuario.Username }));
            verificadorService.actualizarDVV("PROYECTO_USUARIO");
            BitacoraService.getInstance().crear(
              Bitacora.builder()
              .Criticidad("BAJA")
              .Descripcion("Se asigna un usuario al proyecto")
              .Funcionalidad("ASIGNAR USUARIO PROYECTO")
              .Fecha(DateTime.Now)
              .Usuario(Session.getInstance().Usuario)
              .build()
          );
        }

        public void desasignarRecurso(Proyecto proyecto, Usuario usuario)
        {
            usuarioMapper.desasignarRecurso(proyecto, usuario);
            verificadorService.actualizarDVV("PROYECTO_USUARIO");
            BitacoraService.getInstance().crear(
              Bitacora.builder()
              .Criticidad("BAJA")
              .Descripcion("Se desasigna un usuario al proyecto")
              .Funcionalidad("DESASIGNAR USUARIO PROYECTO")
              .Fecha(DateTime.Now)
              .Usuario(Session.getInstance().Usuario)
              .build()
          );
        }
    }
}