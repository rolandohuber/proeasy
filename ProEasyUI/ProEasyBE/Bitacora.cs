using System;

namespace BE
{
    public class Bitacora
    {
        public long Id { get; set; }
        public Usuario Usuario { get; set; }
        public string Criticidad { get; set; }
        public string Funcionalidad { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public string Dvh { get; set; }
        public object Data { get; set; }
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }

        public Bitacora()
        {
        }
        public override bool Equals(object obj)
        {
            if (typeof(Bitacora) != obj.GetType())
                return false;
            return obj != null && Id == ((Bitacora)obj).Id;
        }
        public static BitacoraBuilder builder()
        {
            return new BitacoraBuilder();
        }

        public class BitacoraBuilder
        {
            private Bitacora entity = new Bitacora();

            public BitacoraBuilder Id(long Id)
            {
                this.entity.Id = Id;
                return this;
            }
            public BitacoraBuilder Usuario(Usuario Usuario)
            {
                this.entity.Usuario = Usuario;
                return this;
            }
            public BitacoraBuilder Criticidad(string Criticidad)
            {
                this.entity.Criticidad = Criticidad;
                return this;
            }
            public BitacoraBuilder Funcionalidad(string Funcionalidad)
            {
                this.entity.Funcionalidad = Funcionalidad;
                return this;
            }

            public BitacoraBuilder Descripcion(string Descripcion)
            {
                this.entity.Descripcion = Descripcion;
                return this;
            }

            public BitacoraBuilder Fecha(DateTime Fecha)
            {
                this.entity.Fecha = Fecha;
                return this;
            }
            public BitacoraBuilder Dvh(string Dvh)
            {
                this.entity.Dvh = Dvh;
                return this;
            }

            public BitacoraBuilder Data(object data)
            {
                this.entity.Data = data;
                return this;
            }

            public BitacoraBuilder Desde(DateTime Fecha)
            {
                this.entity.Desde = Fecha;
                return this;
            }

            public BitacoraBuilder Hasta(DateTime Fecha)
            {
                this.entity.Hasta = Fecha;
                return this;
            }

            public Bitacora build()
            {
                return this.entity;
            }
        }
    }
}