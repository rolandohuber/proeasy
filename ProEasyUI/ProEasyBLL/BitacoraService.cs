using BE;
using DAL;
using System.Collections.Generic;

namespace BLL
{
    public class BitacoraService : EntityService<Bitacora>
    {
        private static BitacoraService instance;
        private DigitoVerificadorService verificadorService = DigitoVerificadorService.getInstance();
        readonly BitacoraMapper mapper = new BitacoraMapper();
        readonly UsuarioMapper usuarioMapper = new UsuarioMapper();

        private BitacoraService()
        {

        }

        public static BitacoraService getInstance()
        {
            if (instance == null)
                instance = new BitacoraService();
            return instance;
        }

        public override void actualizar(Bitacora entity)
        {
            entity.Descripcion = encriptarAES(entity.Descripcion);
            entity.Dvh = verificadorService.generarDVH(new string[] { entity.Usuario.Username, entity.Fecha.ToString("dd/MM/yyyy HH:mm"), entity.Funcionalidad, entity.Descripcion, entity.Criticidad });
            entity.Usuario = Session.getInstance().Usuario;
            mapper.actualizar(entity);
            verificadorService.actualizarDVV("BITACORA");
        }

        public override void crear(Bitacora entity)
        {
            entity.Descripcion = encriptarAES(entity.Descripcion);
            entity.Dvh = verificadorService.generarDVH(new string[] { entity.Usuario.Username, entity.Fecha.ToString("dd/MM/yyyy HH:mm"), entity.Funcionalidad, entity.Descripcion, entity.Criticidad });
            if (entity.Usuario == null)
                entity.Usuario = Session.getInstance().Usuario;
            mapper.crear(entity);
            verificadorService.actualizarDVV("BITACORA");
        }

        public override void eliminar(Bitacora entity)
        {
            mapper.eliminar(entity);
            verificadorService.actualizarDVV("BITACORA");
        }

        public override List<Bitacora> listar()
        {
            List<Bitacora> list = mapper.listar();
            foreach (Bitacora b in list)
            {
                b.Descripcion = desencriptarAES(b.Descripcion);
                b.Usuario = usuarioMapper.leer(b.Usuario.Id);
                b.Usuario.Username = desencriptarAES(b.Usuario.Username);
            }
            return list;
        }

        public override Bitacora leer(long id)
        {
            return null;
        }

        public List<Bitacora> buscar(Bitacora entity)
        {
            List<Bitacora> list = mapper.buscar(entity);
            foreach (Bitacora b in list)
            {
                b.Descripcion = desencriptarAES(b.Descripcion);
                b.Usuario = usuarioMapper.leer(b.Usuario.Id);
                b.Usuario.Username = desencriptarAES(b.Usuario.Username);
            }
            return list;
        }
    }
}