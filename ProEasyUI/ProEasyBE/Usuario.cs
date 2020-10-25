using System;
using System.Collections.Generic;

namespace BE
{
    public class Usuario
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public Int64 Disponibilidad { get; set; }
        public string ValorHora { get; set; }
        public Boolean Habilitado { get; set; }
        public Idioma Idioma { get; set; }
        public List<Familia> Familias { get; set; }
        public List<Patente> Patentes { get; set; }
        public string Contrasenia { get; set; }
        public Boolean Eliminado { get; set; }
        public string Dvh { get; set; }
        public Proyecto Proyecto { get; set; }

        public int Intentos { get; set; }


        public Usuario()
        {
        }

        public override string ToString()
        {
            return this.Nombre;
        }
        public override bool Equals(object obj)
        {
            if (typeof(Usuario) != obj.GetType())
                return false;
            return obj != null && Id == ((Usuario)obj).Id;
        }
        public static UsuarioBuilder builder()
        {
            return new UsuarioBuilder();
        }

        public class UsuarioBuilder
        {
            Usuario usuario = new Usuario();

            public UsuarioBuilder Id(long id)
            {
                this.usuario.Id = id;
                return this;
            }
            public UsuarioBuilder Nombre(string nombre)
            {
                this.usuario.Nombre = nombre;
                return this;
            }
            public UsuarioBuilder Apellido(string apellido)
            {
                this.usuario.Apellido = apellido;
                return this;
            }
            public UsuarioBuilder Email(string email)
            {
                this.usuario.Email = email;
                return this;
            }
            public UsuarioBuilder Username(string username)
            {
                this.usuario.Username = username;
                return this;
            }
            public UsuarioBuilder Disponibilidad(long disponibilidad)
            {
                this.usuario.Disponibilidad = disponibilidad;
                return this;
            }
            public UsuarioBuilder ValorHora(string valorHora)
            {
                this.usuario.ValorHora = valorHora;
                return this;
            }
            public UsuarioBuilder Habilitado(Boolean habilitado)
            {
                this.usuario.Habilitado = habilitado;
                return this;
            }
            public UsuarioBuilder Idioma(Idioma idioma)
            {
                this.usuario.Idioma = idioma;
                return this;
            }
            public UsuarioBuilder Familias(List<Familia> familias)
            {
                this.usuario.Familias = familias;
                return this;
            }
            public UsuarioBuilder Patentes(List<Patente> patentes)
            {
                this.usuario.Patentes = patentes;
                return this;
            }
            public UsuarioBuilder Contrasenia(string contrasenia)
            {
                this.usuario.Contrasenia = contrasenia;
                return this;
            }
            public UsuarioBuilder Eliminado(Boolean eliminado)
            {
                this.usuario.Eliminado = eliminado;
                return this;
            }
            public UsuarioBuilder Dvh(string dvh)
            {
                this.usuario.Dvh = dvh;
                return this;
            }
            public UsuarioBuilder Proyecto(Proyecto proyecto)
            {
                this.usuario.Proyecto = proyecto;
                return this;
            }

            public Usuario build()
            {
                return this.usuario;
            }

        }
    }

}