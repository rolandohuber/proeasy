using System;

namespace BE
{
    public class Idioma
    {

        public long Id { get; set; }
        public string Nombre { get; set; }

        public string Code { get; set; }

        public Boolean Eliminado { get; set; }

        public Idioma(long id, string nombre, bool eliminado, string code)
        {
            Id = id;
            Nombre = nombre;
            Eliminado = eliminado;
            Code = code;
        }

        public Idioma()
        {
        }
        public override string ToString()
        {
            return this.Nombre;
        }
        public override bool Equals(object obj)
        {
            if (typeof(Idioma) != obj.GetType())
                return false;
            return obj != null && Id == ((Idioma)obj).Id;
        }

        public static IdiomaBuilder builder()
        {
            return new IdiomaBuilder();
        }

        public class IdiomaBuilder
        {
            private Idioma entity = new Idioma();

            public IdiomaBuilder Id(long Id)
            {
                this.entity.Id = Id;
                return this;
            }

            public IdiomaBuilder Nombre(string nombre)
            {
                this.entity.Nombre = nombre;
                return this;
            }

            public IdiomaBuilder Eliminado(Boolean Eliminado)
            {
                this.entity.Eliminado = Eliminado;
                return this;
            }
            public IdiomaBuilder Code(string Code)
            {
                this.entity.Code = Code;
                return this;
            }

            public Idioma build()
            {
                return this.entity;
            }
        }
    }

}