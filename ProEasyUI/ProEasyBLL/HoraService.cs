using BE;
using DAL;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class HoraService : EntityService<Hora>
    {
        private static HoraService instance;
        readonly HoraMapper mapper = new HoraMapper();
        readonly DigitoVerificadorService verificadorService = DigitoVerificadorService.getInstance();

        private HoraService()
        {

        }

        public static HoraService getInstance()
        {
            if (instance == null)
                instance = new HoraService();
            return instance;
        }

        public override void actualizar(Hora entity)
        {
            entity.Dvh = verificadorService.generarDVH(new string[] { entity.Proyecto.Id.ToString(), entity.Tarea.Id.ToString(), entity.Usuario.Username, entity.Cantidad.ToString() });
            mapper.actualizar(entity);
            verificadorService.actualizarDVV("HORA");
            BitacoraService.getInstance().crear(
                Bitacora.builder()
                .Criticidad("ALTA")
                .Descripcion("SE ACTUALIZO LA HORA")
                .Funcionalidad("HORA")
                .Fecha(DateTime.Now)
                .Usuario(Session.getInstance().Usuario)
                .build()
            );
        }

        public override void crear(Hora entity)
        {
            entity.Dvh = verificadorService.generarDVH(new string[] { entity.Proyecto.Id.ToString(), entity.Tarea.Id.ToString(), entity.Usuario.Username, entity.Cantidad.ToString() });
            mapper.crear(entity);
            verificadorService.actualizarDVV("HORA");
            BitacoraService.getInstance().crear(
                Bitacora.builder()
                .Criticidad("ALTA")
                .Descripcion("SE CREO LA HORA")
                .Funcionalidad("HORA")
                .Fecha(DateTime.Now)
                .Usuario(Session.getInstance().Usuario)
                .build()
            );
        }

        public override void eliminar(Hora entity)
        {
            mapper.eliminar(entity);
            verificadorService.actualizarDVV("HORA");
            BitacoraService.getInstance().crear(
                Bitacora.builder()
                .Criticidad("ALTA")
                .Descripcion("SE ELIMINO LA HORA")
                .Funcionalidad("HORA")
                .Fecha(DateTime.Now)
                .Usuario(Session.getInstance().Usuario)
                .build()
            );
        }

        public override List<Hora> listar()
        {
            BitacoraService.getInstance().crear(
                Bitacora.builder()
                .Criticidad("ALTA")
                .Descripcion("SE LISTARON LAS HORAS")
                .Funcionalidad("HORA")
                .Fecha(DateTime.Now)
                .Usuario(Session.getInstance().Usuario)
                .build()
            );
            return mapper.listar();
        }

        public override Hora leer(long id)
        {
            BitacoraService.getInstance().crear(
                Bitacora.builder()
                .Criticidad("ALTA")
                .Descripcion("SE OBTUVO LA HORA")
                .Funcionalidad("HORA")
                .Fecha(DateTime.Now)
                .Usuario(Session.getInstance().Usuario)
                .build()
            );
            return mapper.leer(id);
        }

        public List<Hora> listarPorTarea(Tarea tarea)
        {
            BitacoraService.getInstance().crear(
                Bitacora.builder()
                .Criticidad("ALTA")
                .Descripcion("SE OBTUVIERON LAS HORAS DE LA TAREA")
                .Funcionalidad("HORA")
                .Fecha(DateTime.Now)
                .Usuario(Session.getInstance().Usuario)
                .build()
            );
            return mapper.listarPorTarea(tarea);

        }
    }

}