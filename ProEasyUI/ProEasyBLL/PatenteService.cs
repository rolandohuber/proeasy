using BE;
using DAL;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class PatenteService : EntityService<Patente>
    {
        private static PatenteService instance;
        readonly PatenteMapper patenteMapper = new PatenteMapper();
        readonly DigitoVerificadorService verificadorService = DigitoVerificadorService.getInstance();

        private PatenteService()
        {

        }

        public static PatenteService getInstance()
        {
            if (instance == null)
                instance = new PatenteService();
            return instance;
        }

        public override void actualizar(Patente entity)
        {
            entity.Nombre = encriptarAES(entity.Nombre);
            patenteMapper.actualizar(entity);
            BitacoraService.getInstance().crear(
                Bitacora.builder()
                .Criticidad("ALTA")
                .Descripcion("SE ACTUALIZO LA PATENTE")
                .Funcionalidad("PATENTE")
                .Fecha(DateTime.Now)
                .Usuario(Session.getInstance().Usuario)
                .build()
            );
        }

        public override void crear(Patente entity)
        {
            entity.Nombre = encriptarAES(entity.Nombre);
            patenteMapper.crear(entity);
            BitacoraService.getInstance().crear(
                Bitacora.builder()
                .Criticidad("ALTA")
                .Descripcion("SE CREO LA PATENTE")
                .Funcionalidad("PATENTE")
                .Fecha(DateTime.Now)
                .Usuario(Session.getInstance().Usuario)
                .build()
            );
        }

        public override void eliminar(Patente entity)
        {
            patenteMapper.eliminar(entity);
            BitacoraService.getInstance().crear(
                 Bitacora.builder()
                 .Criticidad("ALTA")
                 .Descripcion("SE ELIMINO LA PATENTE")
                 .Funcionalidad("PATENTE")
                 .Fecha(DateTime.Now)
                 .Usuario(Session.getInstance().Usuario)
                 .build()
             );
        }

        public override List<Patente> listar()
        {
            List<Patente> patentes = patenteMapper.listar();
            foreach (Patente patente in patentes)
            {
                patente.Nombre = desencriptarAES(patente.Nombre);
            }
            BitacoraService.getInstance().crear(
                 Bitacora.builder()
                 .Criticidad("ALTA")
                 .Descripcion("SE LISTARON LAS PATENTES")
                 .Funcionalidad("PATENTE")
                 .Fecha(DateTime.Now)
                 .Usuario(Session.getInstance().Usuario)
                 .build()
             );
            return patentes;
        }

        public List<Patente> obtenerPatentesAsignadas(Familia familia)
        {
            List<Patente> list = patenteMapper.obtenerPatentesAsignadas(familia);
            foreach (Patente patente in list)
            {
                patente.Nombre = desencriptarAES(patente.Nombre);
            }
            BitacoraService.getInstance().crear(
                 Bitacora.builder()
                 .Criticidad("ALTA")
                 .Descripcion("SE OBTUVIERON LAS PANTENTES ASIGNADAS A LA FAMILIA " + familia.Id)
                 .Funcionalidad("PATENTE")
                 .Fecha(DateTime.Now)
                 .Usuario(Session.getInstance().Usuario)
                 .build()
             );
            return list;
        }

        public List<Patente> obtenerPatentesDisponibles(Familia familia)
        {
            List<Patente> list = patenteMapper.obtenerPatentesDisponibles(familia);
            foreach (Patente patente in list)
            {
                patente.Nombre = desencriptarAES(patente.Nombre);
            }

            BitacoraService.getInstance().crear(
                Bitacora.builder()
                .Criticidad("ALTA")
                .Descripcion("SE OBTUVIERON LAS PATENTES DISPONIBLES DE LA FAMILIA: " + familia.Id)
                .Funcionalidad("PATENTE")
                .Fecha(DateTime.Now)
                .Usuario(Session.getInstance().Usuario)
                .build()
            );
            return list;
        }

        public override Patente leer(long id)
        {
            Patente patente = patenteMapper.leer(id);
            patente.Nombre = desencriptarAES(patente.Nombre);
            BitacoraService.getInstance().crear(
                Bitacora.builder()
                .Criticidad("ALTA")
                .Descripcion("SE OBTUVO LA PATENTE")
                .Funcionalidad("PATENTE")
                .Fecha(DateTime.Now)
                .Usuario(Session.getInstance().Usuario)
                .build()
            );
            return patente;
        }

        public void asignarPatente(Usuario user, Patente patente)
        {
            patenteMapper.asignarPatente(user, patente, verificadorService.generarDVH(new string[] { user.Id.ToString(), patente.Id.ToString() }));
            verificadorService.actualizarDVV("USUARIO_PATENTE");
            BitacoraService.getInstance().crear(
                Bitacora.builder()
                .Criticidad("ALTA")
                .Descripcion("SE ASIGNO LA PATENTE: " + patente.Id + " AL USUARIO: " + user.Id)
                .Funcionalidad("PATENTE")
                .Fecha(DateTime.Now)
                .Usuario(Session.getInstance().Usuario)
                .build()
            );
        }

        public void quitarPatente(Usuario usuario, Patente patente)
        {
            if (!patenteMapper.existeOtraAsignacion(patente.Id, usuario.Id))
                throw new ProEasyException(70, "Patente sin asignacion");
            patenteMapper.quitarPatente(usuario, patente);
            verificadorService.actualizarDVV("USUARIO_PATENTE");
            BitacoraService.getInstance().crear(
                Bitacora.builder()
                .Criticidad("ALTA")
                .Descripcion("SE DESASIGNO LA PATENTE: " + patente.Id + " AL USUARIO: " + usuario.Id)
                .Funcionalidad("PATENTE")
                .Fecha(DateTime.Now)
                .Usuario(Session.getInstance().Usuario)
                .build()
            );
        }

        public List<Patente> obtenerPatentesAsignadas(Usuario user)
        {
            List<Patente> list = patenteMapper.obtenerPatentesAsignadas(user);
            foreach (Patente patente in list)
            {
                patente.Nombre = desencriptarAES(patente.Nombre);
            }
            BitacoraService.getInstance().crear(
                Bitacora.builder()
                .Criticidad("ALTA")
                .Descripcion("SE OBTUVIERON LAS PATENTES ASIGNADAS AL USUARIO: " + user.Id)
                .Funcionalidad("PATENTE")
                .Fecha(DateTime.Now)
                .Usuario(Session.getInstance().Usuario)
                .build()
            );
            return list;
        }

        public List<Patente> obtenerPatentesDisponibles(Usuario user)
        {
            List<Patente> list = patenteMapper.obtenerPatentesDisponibles(user);
            foreach (Patente patente in list)
            {
                patente.Nombre = desencriptarAES(patente.Nombre);
            }
            BitacoraService.getInstance().crear(
                Bitacora.builder()
                .Criticidad("ALTA")
                .Descripcion("SE OBTUVIERON LAS PATENTES DISPONIBLES AL USUARIO: " + user.Id)
                .Funcionalidad("PATENTE")
                .Fecha(DateTime.Now)
                .Usuario(Session.getInstance().Usuario)
                .build()
            );
            return list;
        }

        public void asignarPatente(Familia familia, Patente patente)
        {
            patenteMapper.asignarPatente(familia, patente, verificadorService.generarDVH(new string[] { familia.Id.ToString(), patente.Id.ToString() }));
            verificadorService.actualizarDVV("FAMILIA_PATENTE");
            BitacoraService.getInstance().crear(
                 Bitacora.builder()
                 .Criticidad("ALTA")
                 .Descripcion("SE ASIGNO LA PATENTE:" + patente.Id + " ASIGNADAS A LA FAMILIA: " + familia.Id)
                 .Funcionalidad("PATENTE")
                 .Fecha(DateTime.Now)
                 .Usuario(Session.getInstance().Usuario)
                 .build()
             );
        }

        public void quitarPatente(Familia familia, Patente patente)
        {
            if (!patenteMapper.existeOtraAsignacionFamiliaPatente(patente.Id, familia.Id))
                throw new ProEasyException(70, "Patente sin asignacion");
            patenteMapper.quitarPatente(familia, patente);
            verificadorService.actualizarDVV("FAMILIA_PATENTE");
            BitacoraService.getInstance().crear(
                Bitacora.builder()
                .Criticidad("ALTA")
                .Descripcion("SE DESASIGNO LA PATENTE:" + patente.Id + " ASIGNADAS A LA FAMILIA: " + familia.Id)
                .Funcionalidad("PATENTE")
                .Fecha(DateTime.Now)
                .Usuario(Session.getInstance().Usuario)
                .build()
            );
        }
    }
}