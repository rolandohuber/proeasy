using BE;
using DAL;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class TareaService : EntityService<Tarea>
    {
        private static TareaService instance;
        readonly TareaMapper mapper = new TareaMapper();
        readonly DigitoVerificadorService verificadorService = DigitoVerificadorService.getInstance();

        private TareaService()
        {

        }

        public static TareaService getInstance()
        {
            if (instance == null)
                instance = new TareaService();
            return instance;
        }

        public override void actualizar(Tarea entity)
        {
            if (mapper.existe(entity.Id, entity.Titulo))
                throw new ProEasyException(20, "Ya existe una tarea con ese titulo");
            entity.Dvh = verificadorService.generarDVH(new string[] { entity.Titulo, entity.Descripcion });
            mapper.actualizar(entity);
            verificadorService.actualizarDVV("TAREA");
            BitacoraService.getInstance().crear(
            Bitacora.builder()
              .Criticidad("MEDIA")
              .Descripcion("Se actualizo una tarea")
              .Funcionalidad("TAREAS")
              .Fecha(DateTime.Now)
              .Usuario(Session.getInstance().Usuario)
              .build()
          );
        }

        public override void crear(Tarea entity)
        {
            if (mapper.existe(0, entity.Titulo))
                throw new ProEasyException(20, "Ya existe una tarea con ese titulo");
            entity.Dvh = verificadorService.generarDVH(new string[] { entity.Titulo, entity.Descripcion });
            mapper.crear(entity);
            verificadorService.actualizarDVV("TAREA");
            BitacoraService.getInstance().crear(
            Bitacora.builder()
             .Criticidad("MEDIA")
             .Descripcion("Se creo una tarea")
             .Funcionalidad("TAREAS")
             .Fecha(DateTime.Now)
             .Usuario(Session.getInstance().Usuario)
             .build()
         );
        }

        public override void eliminar(Tarea entity)
        {
            if (new HoraMapper().listarPorTarea(entity).Count > 0)
            {
                throw new ProEasyException(21, "La tarea tiene horas cargadas");
            }
            mapper.eliminar(entity);
            verificadorService.actualizarDVV("TAREA");
            BitacoraService.getInstance().crear(
            Bitacora.builder()
             .Criticidad("MEDIA")
             .Descripcion("Se elimino una tarea")
             .Funcionalidad("TAREAS")
             .Fecha(DateTime.Now)
             .Usuario(Session.getInstance().Usuario)
             .build()
         );
        }

        public override List<Tarea> listar()
        {
            List<Tarea> lista = mapper.listar();
            BitacoraService.getInstance().crear(
             Bitacora.builder()
             .Criticidad("BAJA")
             .Descripcion("Se listaron las tareas")
             .Funcionalidad("TAREAS")
             .Fecha(DateTime.Now)
             .Usuario(Session.getInstance().Usuario)
             .build()
         );
            return lista;
        }

        public override Tarea leer(long id)
        {
            Tarea lista = mapper.leer(id);
            BitacoraService.getInstance().crear(
            Bitacora.builder()
            .Criticidad("BAJA")
            .Descripcion("Se leyo la tarea")
            .Funcionalidad("TAREAS")
            .Fecha(DateTime.Now)
            .Usuario(Session.getInstance().Usuario)
            .build()
        );
            return lista;
        }

        public List<Tarea> listarPorProyecto(Proyecto proyectoSelected)
        {
            List<Tarea> lista = mapper.listarPorProyecto(proyectoSelected);
            BitacoraService.getInstance().crear(
            Bitacora.builder()
               .Criticidad("BAJA")
               .Descripcion("Se listaton las tareas del proyecto")
               .Funcionalidad("TAREAS")
               .Fecha(DateTime.Now)
               .Usuario(Session.getInstance().Usuario)
               .build()
            );
            return lista;
        }
    }
}