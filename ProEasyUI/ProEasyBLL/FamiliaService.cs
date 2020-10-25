using BE;
using DAL;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class FamiliaService : EntityService<Familia>
    {
        private static FamiliaService instance;
        readonly FamiliaMapper familiaMapper = new FamiliaMapper();
        readonly DigitoVerificadorService verificadorService = DigitoVerificadorService.getInstance();

        private FamiliaService()
        {

        }

        public static FamiliaService getInstance()
        {
            if (instance == null)
                instance = new FamiliaService();
            return instance;
        }

        public override void crear(Familia entity)
        {
            entity.Nombre = encriptarAES(entity.Nombre);
            if (familiaMapper.existe(entity.Nombre))
                throw new Exception("Familia existe");
            entity.Dvh = verificadorService.generarDVH(new string[] { entity.Nombre });
            familiaMapper.crear(entity);
            verificadorService.actualizarDVV("FAMILIA");

            BitacoraService.getInstance().crear(
                Bitacora.builder()
                .Criticidad("ALTA")
                .Descripcion("SE CREO UNA FAMILIA")
                .Funcionalidad("FAMILIA")
                .Fecha(DateTime.Now)
                .Usuario(Session.getInstance().Usuario)
                .build()
            );
        }

        public override void actualizar(Familia entity)
        {
            entity.Nombre = encriptarAES(entity.Nombre);
            if (familiaMapper.existe(entity.Nombre))
                throw new Exception("FAmilia existe");
            entity.Dvh = verificadorService.generarDVH(new string[] { entity.Nombre });
            familiaMapper.actualizar(entity);
            verificadorService.actualizarDVV("FAMILIA");

            BitacoraService.getInstance().crear(
                Bitacora.builder()
                .Criticidad("ALTA")
                .Descripcion("SE ACTUALIZO UNA FAMILIA")
                .Funcionalidad("FAMILIA")
                .Fecha(DateTime.Now)
                .Usuario(Session.getInstance().Usuario)
                .build()
            );
        }

        public override void eliminar(Familia entity)
        {
            if (familiaMapper.estaAsignada(entity))
                throw new Exception("La familia esta asignada");

            if (familiaMapper.tieneAlgunaPatenteSinOtraAsignacion(entity))
                throw new Exception("La familia tiene patentes sin asignacion");

            familiaMapper.eliminar(entity);
            verificadorService.actualizarDVV("FAMILIA");
            BitacoraService.getInstance().crear(
                Bitacora.builder()
                .Criticidad("ALTA")
                .Descripcion("SE ELIMINO UNA FAMILIA")
                .Funcionalidad("FAMILIA")
                .Fecha(DateTime.Now)
                .Usuario(Session.getInstance().Usuario)
                .build()
            );
        }

        public override Familia leer(long id)
        {
            Familia familia = familiaMapper.leer(id);
            familia.Nombre = desencriptarAES(familia.Nombre);
            BitacoraService.getInstance().crear(
                Bitacora.builder()
                .Criticidad("ALTA")
                .Descripcion("SE OBTUVO EL DETALLE DE UNA FAMILIA")
                .Funcionalidad("FAMILIA")
                .Fecha(DateTime.Now)
                .Usuario(Session.getInstance().Usuario)
                .build()
            );
            return familia;
        }

        public override List<Familia> listar()
        {
            List<Familia> familias = familiaMapper.listar();
            foreach (Familia familia in familias)
            {
                familia.Nombre = desencriptarAES(familia.Nombre);
            }
            BitacoraService.getInstance().crear(
                            Bitacora.builder()
                            .Criticidad("ALTA")
                            .Descripcion("SE OBTUVO EL LISTADO DE FAMILIAS")
                            .Funcionalidad("FAMILIA")
                            .Fecha(DateTime.Now)
                            .Usuario(Session.getInstance().Usuario)
                            .build()
                        );
            return familias;
        }

        public List<Familia> obtenerFamiliasAsignadas(Usuario user)
        {
            List<Familia> list = familiaMapper.obtenerTodasLasFamilias(user);
            foreach (Familia familia in list)
            {
                familia.Nombre = desencriptarAES(familia.Nombre);
            }
            BitacoraService.getInstance().crear(
                            Bitacora.builder()
                            .Criticidad("ALTA")
                            .Descripcion("SE OBTUVIERON LAS FAMILIAS ASIGNADAS DEL USUARIO: " + user.Username)
                            .Funcionalidad("FAMILIA")
                            .Fecha(DateTime.Now)
                            .Usuario(Session.getInstance().Usuario)
                            .build()
                        );
            return list;
        }

        public List<Familia> obtenerFamiliasDisponibles(Usuario user)
        {
            List<Familia> list = familiaMapper.obtenerFamiliasDisponibles(user);
            foreach (Familia familia in list)
            {
                familia.Nombre = desencriptarAES(familia.Nombre);
            }
            BitacoraService.getInstance().crear(
                Bitacora.builder()
                .Criticidad("ALTA")
                .Descripcion("SE OBTUVIERON LAS FAMILIAS DISPONIBLES DEL USUARIO: " + user.Username)
                .Funcionalidad("FAMILIA")
                .Fecha(DateTime.Now)
                .Usuario(Session.getInstance().Usuario)
                .build()
            );
            return list;
        }

        public void asignarFamilia(Usuario user, Familia familia)
        {
            familiaMapper.asignarFamilia(user, familia, verificadorService.generarDVH(new string[] { user.Username, familia.Id.ToString() }));
            verificadorService.actualizarDVV("USUARIO_FAMILIA");
            BitacoraService.getInstance().crear(
                Bitacora.builder()
                .Criticidad("ALTA")
                .Descripcion("SE ASIGNO LA FAMILIA: " + familia.Nombre + " AL USUARIO: " + user.Username)
                .Funcionalidad("FAMILIA")
                .Fecha(DateTime.Now)
                .Usuario(Session.getInstance().Usuario)
                .build()
            );
        }

        public void quitarFamilia(Usuario usuario, Familia familia)
        {
            familiaMapper.quitarFamilia(usuario, familia);
            verificadorService.actualizarDVV("USUARIO_FAMILIA");
            BitacoraService.getInstance().crear(
               Bitacora.builder()
               .Criticidad("ALTA")
               .Descripcion("SE DESASIGNO LA FAMILIA: " + familia.Nombre + " AL USUARIO: " + usuario.Username)
               .Funcionalidad("FAMILIA")
               .Fecha(DateTime.Now)
               .Usuario(Session.getInstance().Usuario)
               .build()
           );
        }
    }

}