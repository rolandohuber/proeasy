using System;

namespace BE
{
    public class Tarea
    {

        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public Proyecto Proyecto { get; set; }
        public Boolean Eliminado { get; set; }
        public string Dvh { get; set; }

        public Tarea(long id, string titulo, string descripcion, Proyecto proyecto, bool eliminado, string dvh)
        {
            Id = id;
            Titulo = titulo;
            Descripcion = descripcion;
            Proyecto = proyecto;
            Eliminado = eliminado;
            Dvh = dvh;
        }

        public Tarea()
        {
        }
        public override string ToString()
        {
            return this.Titulo;
        }

        public override bool Equals(object obj)
        {
            if (typeof(Tarea) != obj.GetType())
                return false;
            return this.Id.Equals(((Tarea)obj).Id);
        }


        public static TareaBuilder builder()
        {
            return new TareaBuilder();
        }

        public class TareaBuilder
        {
            private Tarea entity = new Tarea();

            public TareaBuilder Id(long id)
            {
                this.entity.Id = id;
                return this;
            }
            public TareaBuilder Titulo(string titulo)
            {
                this.entity.Titulo = titulo;
                return this;
            }
            public TareaBuilder Descripcion(string descripcion)
            {
                this.entity.Descripcion = descripcion;
                return this;
            }
            public TareaBuilder Proyecto(Proyecto proyecto)
            {
                this.entity.Proyecto = proyecto;
                return this;
            }
            public TareaBuilder Eliminado(Boolean eliminado)
            {
                this.entity.Eliminado = eliminado;
                return this;
            }
            public TareaBuilder Dvh(string dvh)
            {
                this.entity.Dvh = dvh;
                return this;
            }

            public Tarea build()
            {
                return this.entity;
            }
        }
    }

}