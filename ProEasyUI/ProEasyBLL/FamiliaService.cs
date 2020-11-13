using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;

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
            if (familiaMapper.existe(0, entity.Nombre))
                throw new ProEasyException(50, "La Familia existe");
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
            if (familiaMapper.existe(entity.Id, entity.Nombre))
                throw new ProEasyException(50, "La Familia existe");
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
                throw new ProEasyException(51, "La Familia esta asignada a un usuario");

            if (familiaMapper.tieneAlgunaPatenteSinOtraAsignacion(entity))
                throw new ProEasyException(52, "La Familia tiene patentes asignadas");

            if (new PatenteMapper().obtenerPatentesAsignadas(entity).Count > 0)
                throw new ProEasyException(53, "La Familia tiene patentes asignadas");

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
            //chequear si hay al menos un usuario con cada patente de esta familia
            List<Patente> patentes = PatenteService.getInstance().obtenerPatentesAsignadas(familia);
            foreach (Patente p in patentes.ToList())
            {
                if (tieneUsuarioRelacionado(p))
                {
                    patentes.Remove(p);
                }
            }
            if (patentes.Count > 0)
            {
                //reviso si esta asociado a otras familias y si tienen usuarios relacionados
                foreach (Patente p in patentes.ToList())
                {
                    if (tieneFamiliasRelacionadasConUsuarios(p, familia.Id))
                    {
                        patentes.Remove(p);
                    }
                }
            }

            if (patentes.Count > 0)
            {
                throw new ProEasyException(54, "La Familia dejara patentes sin asignar");
            }

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

        private bool tieneFamiliasRelacionadasConUsuarios(Patente p, long idFamilia)
        {
            return this.familiaMapper.tieneFamiliasRelacionadasConUsuarios(p, idFamilia);
        }

        private bool tieneUsuarioRelacionado(Patente p)
        {
            return PatenteService.getInstance().tieneUsuarioRelacionado(p);
        }
    }
}