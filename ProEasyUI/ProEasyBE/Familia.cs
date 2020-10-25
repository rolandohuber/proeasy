using System;
using System.Collections.Generic;

namespace BE
{
    public class Familia
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public List<Patente> Patentes { get; set; }
        public Boolean Eliminado { get; set; }
        public string Dvh { get; set; }
        public Usuario Usuario { get; set; }
        public Familia(long id, string nombre, List<Patente> patentes, bool eliminado, string dvh, Usuario usuario)
        {
            Id = id;
            Nombre = nombre;
            Patentes = patentes;
            Eliminado = eliminado;
            Dvh = dvh;
            Usuario = usuario;
        }
        public Familia()
        {
        }
        public override string ToString()
        {
            return this.Nombre;
        }
        public override bool Equals(object obj)
        {
            if (typeof(Familia) != obj.GetType())
                return false;
            return obj != null && Id == ((Familia)obj).Id;
        }
        public static FamiliaBuilder builder()
        {
            return new FamiliaBuilder();
        }
        public class FamiliaBuilder
        {
            private Familia entity = new Familia();
            public FamiliaBuilder Id(long Id)
            {
                this.entity.Id = Id;
                return this;
            }
            public FamiliaBuilder Nombre(string Nombre)
            {
                this.entity.Nombre = Nombre;
                return this;
            }
            public FamiliaBuilder Patentes(List<Patente> Patentes)
            {
                this.entity.Patentes = Patentes;
                return this;
            }
            public FamiliaBuilder Usuario(Usuario Usuario)
            {
                this.entity.Usuario = Usuario;
                return this;
            }
            public FamiliaBuilder Eliminado(Boolean Eliminado)
            {
                this.entity.Eliminado = Eliminado;
                return this;
            }
            public FamiliaBuilder Dvh(string Dvh)
            {
                this.entity.Dvh = Dvh;
                return this;
            }
            public Familia build()
            {
                return this.entity;
            }
        }
    }
}