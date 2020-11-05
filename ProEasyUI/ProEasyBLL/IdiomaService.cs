using BE;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class IdiomaService : EntityService<Idioma>
    {
        private static IdiomaService instance;
        readonly DAL.IdiomaMapper mapper = new DAL.IdiomaMapper();

        private IdiomaService()
        {

        }

        public static IdiomaService getInstance()
        {
            if (instance == null)
                instance = new IdiomaService();
            return instance;
        }

        public override void actualizar(Idioma entity)
        {
            mapper.actualizar(entity);
        }

        public void actualizarIdiomaUsuario(int idioma, Usuario usuario)
        {
            mapper.actualizarIdiomaUsuario(idioma, usuario);
            BitacoraService.getInstance().crear(
                Bitacora.builder()
                .Criticidad("ALTA")
                .Descripcion("SE ACTUALIZO EL IDIOMA DEL USUARIO: " + usuario.Username)
                .Funcionalidad("IDIOMA")
                .Fecha(DateTime.Now)
                .Usuario(usuario)
                .build()
            );
        }

        public override void crear(Idioma entity)
        {
            mapper.crear(entity);
        }

        public override void eliminar(Idioma entity)
        {
            mapper.eliminar(entity);
        }

        public override List<Idioma> listar()
        {
            List<Idioma> list = mapper.listar();
            return list;
        }

        public override Idioma leer(long id)
        {
            Idioma list = mapper.leer(id);
            BitacoraService.getInstance().crear(
                Bitacora.builder()
                .Criticidad("ALTA")
                .Descripcion("SE OBTUVO EL IDIOMA")
                .Funcionalidad("IDIOMA")
                .Fecha(DateTime.Now)
                .Usuario(Session.getInstance().Usuario)
                .build()
            );
            return list;
        }
    }
}