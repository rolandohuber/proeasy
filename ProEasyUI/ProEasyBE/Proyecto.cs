using System;
using System.Collections.Generic;

namespace BE
{
    public class Proyecto
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string HorasEstimadas { get; set; }
        public string ValorHora { get; set; }
        public Boolean Habilitado { get; set; }
        public List<Usuario> Usuarios { get; set; }
        public List<Tarea> Tareas { get; set; }
        public List<Hora> Horas { get; set; }
        public Boolean Eliminado { get; set; }
        public DateTime Fecha { get; set; }
        public String Dvh { get; set; }

        public Proyecto(long id, string nombre, string horasEstimadas, string valorHorav, bool habilitado, List<Usuario> usuarios, List<Tarea> tareas, List<Hora> horas, bool eliminado, DateTime fecha, string dvh)
        {
            Id = id;
            Nombre = nombre;
            HorasEstimadas = horasEstimadas;
            ValorHora = valorHorav;
            Habilitado = habilitado;
            Usuarios = usuarios;
            Tareas = tareas;
            Horas = horas;
            Eliminado = eliminado;
            Fecha = fecha;
            Dvh = dvh;
        }

        public Proyecto()
        {
        }
        public override string ToString()
        {
            return this.Nombre;
        }

        public override bool Equals(object obj)
        {
            if (typeof(Proyecto) != obj.GetType())
                return false;

            return obj != null && this.Id == ((Proyecto)obj).Id;
        }

        public static ProyectoBuilder builder()
        {
            return new ProyectoBuilder();
        }

        public class ProyectoBuilder
        {
            private Proyecto entity = new Proyecto();

            public ProyectoBuilder Id(long Id)
            {
                this.entity.Id = Id;
                return this;
            }

            public ProyectoBuilder Nombre(string nombre)
            {
                this.entity.Nombre = nombre;
                return this;
            }

            public ProyectoBuilder HorasEstimadas(string HorasEstimadas)
            {
                this.entity.HorasEstimadas = HorasEstimadas;
                return this;
            }
            public ProyectoBuilder ValorHora(string ValorHora)
            {
                this.entity.ValorHora = ValorHora;
                return this;
            }
            public ProyectoBuilder Habilitado(Boolean Habilitado)
            {
                this.entity.Habilitado = Habilitado;
                return this;
            }
            public ProyectoBuilder Usuarios(List<Usuario> Usuarios)
            {
                this.entity.Usuarios = Usuarios;
                return this;
            }
            public ProyectoBuilder Tareas(List<Tarea> Tareas)
            {
                this.entity.Tareas = Tareas;
                return this;
            }
            public ProyectoBuilder Horas(List<Hora> Horas)
            {
                this.entity.Horas = Horas;
                return this;
            }
            public ProyectoBuilder Eliminado(Boolean Eliminado)
            {
                this.entity.Eliminado = Eliminado;
                return this;
            }
            public ProyectoBuilder Fecha(DateTime Fecha)
            {
                this.entity.Fecha = Fecha;
                return this;
            }
            public ProyectoBuilder Dvh(string Dvh)
            {
                this.entity.Dvh = Dvh;
                return this;
            }

            public Proyecto build()
            {
                return this.entity;
            }
        }
    }

}