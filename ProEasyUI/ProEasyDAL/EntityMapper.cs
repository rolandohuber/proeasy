using System.Collections.Generic;

namespace DAL
{
    public abstract class EntityMapperMapper<E>
    {
        protected readonly SqlHelper sqlHelper = SqlHelper.GetInstance();

        public abstract void crear(E entity);

        public abstract void actualizar(E entity);

        public abstract void eliminar(E entity);

        public abstract List<E> listar();

        public abstract E leer(long entity);

    }
}