using System;

namespace BE
{
    public class Hora
    {
        public long Id { get; set; }
        public long Cantidad { get; set; }
        public DateTime Fecha { get; set; }
        public Proyecto Proyecto { get; set; }
        public Tarea Tarea { get; set; }
        public Usuario Usuario { get; set; }
        public Boolean Eliminado { get; set; }
        public string Dvh { get; set; }
        public Hora(long id, long cantidad, DateTime fecha, Proyecto proyecto, Tarea tarea, Usuario usuario, bool eliminado, string dvh)
        {
            Id = id;
            Cantidad = cantidad;
            Fecha = fecha;
            Proyecto = proyecto;
            Tarea = tarea;
            Usuario = usuario;
            Eliminado = eliminado;
            Dvh = dvh;
        }
        public Hora()
        {
        }
        public override bool Equals(object obj)
        {
            if (typeof(Hora) != obj.GetType())
                return false;
            return obj != null && Id == ((Hora)obj).Id;
        }
        public static HoraBuilder builder()
        {
            return new HoraBuilder();
        }
        public class HoraBuilder
        {
            private Hora entity = new Hora();
            public HoraBuilder Id(long Id)
            {
                this.entity.Id = Id;
                return this;
            }
            public HoraBuilder Cantidad(long Cantidad)
            {
                this.entity.Cantidad = Cantidad;
                return this;
            }
            public HoraBuilder Proyecto(Proyecto Proyecto)
            {
                this.entity.Proyecto = Proyecto;
                return this;
            }
            public HoraBuilder Tarea(Tarea Tarea)
            {
                this.entity.Tarea = Tarea;
                return this;
            }
            public HoraBuilder Usuario(Usuario Usuario)
            {
                this.entity.Usuario = Usuario;
                return this;
            }
            public HoraBuilder Eliminado(Boolean Eliminado)
            {
                this.entity.Eliminado = Eliminado;
                return this;
            }
            public HoraBuilder Fecha(DateTime Fecha)
            {
                this.entity.Fecha = Fecha;
                return this;
            }
            public HoraBuilder Dvh(string Dvh)
            {
                this.entity.Dvh = Dvh;
                return this;
            }
            public Hora build()
            {
                return this.entity;
            }
        }
    }
}