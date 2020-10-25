using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class ProyectoService : EntityService<Proyecto>
    {
        private static ProyectoService instance;
        readonly ProyectoMapper mapper = new ProyectoMapper();
        readonly HoraMapper horasMapper = new HoraMapper();
        readonly DigitoVerificadorService verificadorService = DigitoVerificadorService.getInstance();

        private ProyectoService()
        {

        }

        public static ProyectoService getInstance()
        {
            if (instance == null)
                instance = new ProyectoService();
            return instance;
        }

        public List<ProyectoReporte> generarReporte(DateTime desde, DateTime hasta)
        {
            List<ProyectoReporte> list = new List<ProyectoReporte>();
            List<Proyecto> proyectos = listar();

            if (desde != null)
                proyectos = proyectos.Where(item => item.Fecha.Date.CompareTo(desde.Date) >= 0).ToList();
            if (hasta != null)
                proyectos = proyectos.Where(item => item.Fecha.Date.CompareTo(hasta.Date) <= 0).ToList();

            foreach (Proyecto proyecto in proyectos)
            {
                Hora filtro = new Hora();
                filtro.Proyecto = proyecto;

                long totalHoras = sumarHoras(horasMapper.buscar(filtro));
                list.Add(new ProyectoReporte(proyecto.Nombre, Int32.Parse(proyecto.HorasEstimadas), totalHoras, (Int32.Parse(proyecto.HorasEstimadas) - totalHoras) * Int32.Parse(proyecto.ValorHora), Int32.Parse(proyecto.HorasEstimadas) - totalHoras, proyecto.Fecha));
            }
            BitacoraService.getInstance().crear(
                Bitacora.builder()
                .Criticidad("BAJA")
                .Descripcion("Se genero el reporte")
                .Funcionalidad("REPORTE")
                .Fecha(DateTime.Now)
                .Usuario(Session.getInstance().Usuario)
                .build()
            );
            return list;
        }


        public int calcularMontoAcordado(Proyecto proyecto)
        {
            return (int)Int32.Parse(proyecto.ValorHora);
        }


        public long sumarHoras(List<Hora> horas)
        {
            return horas.Sum(item => item.Cantidad);
        }


        public long sumarMontoInsumido(List<Hora> horas)
        {
            return horas.Sum(item => item.Cantidad);
        }

        public override void crear(Proyecto entity)
        {
            if (this.mapper.existe(0, entity.Nombre))
                throw new Exception("Proyecto ya existe");

            entity.ValorHora = encriptarAES(entity.ValorHora);
            entity.HorasEstimadas = encriptarAES(entity.HorasEstimadas);
            entity.Dvh = verificadorService.generarDVH(new string[] { entity.Nombre, entity.HorasEstimadas, entity.ValorHora });

            mapper.crear(entity);
            verificadorService.actualizarDVV("PROYECTO");
            BitacoraService.getInstance().crear(
               Bitacora.builder()
               .Criticidad("ALTA")
               .Descripcion("Se creo un proyecto")
               .Funcionalidad("PROYECTO")
               .Fecha(DateTime.Now)
               .Usuario(Session.getInstance().Usuario)
               .build()
           );
        }

        public override void actualizar(Proyecto entity)
        {
            if (this.mapper.existe(entity.Id, entity.Nombre))
                throw new Exception("Proyecto ya existe");

            entity.ValorHora = encriptarAES(entity.ValorHora);
            entity.HorasEstimadas = encriptarAES(entity.HorasEstimadas);
            entity.Dvh = verificadorService.generarDVH(new string[] { entity.Nombre, entity.HorasEstimadas, entity.ValorHora });

            mapper.actualizar(entity);
            verificadorService.actualizarDVV("PROYECTO");
            BitacoraService.getInstance().crear(
                Bitacora.builder()
                .Criticidad("ALTA")
                .Descripcion("Se actualizo un proyecto")
                .Funcionalidad("PROYECTO")
                .Fecha(DateTime.Now)
                .Usuario(Session.getInstance().Usuario)
                .build()
            );
        }

        public override void eliminar(Proyecto entity)
        {
            mapper.eliminar(entity);
            verificadorService.actualizarDVV("PROYECTO");
            BitacoraService.getInstance().crear(
                Bitacora.builder()
                .Criticidad("ALTA")
                .Descripcion("Se elimina un proyecto")
                .Funcionalidad("PROYECTO")
                .Fecha(DateTime.Now)
                .Usuario(Session.getInstance().Usuario)
                .build()
            );
        }

        public override List<Proyecto> listar()
        {
            List<Proyecto> list = mapper.listar();
            foreach (Proyecto proyecto in list)
            {
                proyecto.ValorHora = desencriptarAES(proyecto.ValorHora);
                proyecto.HorasEstimadas = desencriptarAES(proyecto.HorasEstimadas);
            }
            BitacoraService.getInstance().crear(
               Bitacora.builder()
               .Criticidad("BAJA")
               .Descripcion("Se LISTARON LOS PROYECTOS")
               .Funcionalidad("PROYECTO")
               .Fecha(DateTime.Now)
               .Usuario(Session.getInstance().Usuario)
               .build()
           );
            return list;
        }

        public override Proyecto leer(long id)
        {
            Proyecto proyecto = mapper.leer(id);
            proyecto.ValorHora = desencriptarAES(proyecto.ValorHora);
            proyecto.HorasEstimadas = desencriptarAES(proyecto.HorasEstimadas);
            BitacoraService.getInstance().crear(
               Bitacora.builder()
               .Criticidad("BAJA")
               .Descripcion("Se leyo el proyecto")
               .Funcionalidad("PROYECTO")
               .Fecha(DateTime.Now)
               .Usuario(Session.getInstance().Usuario)
               .build()
           );
            return proyecto;
        }
    }

}