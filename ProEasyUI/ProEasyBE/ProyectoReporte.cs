using System;

namespace BE
{
    public class ProyectoReporte
    {
        public string Nombre { get; set; }
        public Int64 HorasEstimadas { get; set; }
        public Int64 HorasInsumidas { get; set; }
        public Int64 DesvioDinero { get; set; }
        public Int64 DesvioHoras { get; set; }
        public DateTime Fecha { get; set; }

        public ProyectoReporte(string nombre, long horasEstimadas, long horasInsumidas, long desvioDinero, long desvioHoras, DateTime fecha)
        {
            Nombre = nombre;
            HorasEstimadas = horasEstimadas;
            HorasInsumidas = horasInsumidas;
            DesvioDinero = desvioDinero;
            DesvioHoras = desvioHoras;
            Fecha = fecha;
        }

        public ProyectoReporte()
        {
        }
        public override string ToString()
        {
            return this.Nombre;
        }
        public static ProyectoReporteBuilder builder()
        {
            return new ProyectoReporteBuilder();
        }

        public class ProyectoReporteBuilder
        {
            private ProyectoReporte entity = new ProyectoReporte();

            public ProyectoReporteBuilder Nombre(string nombre)
            {
                this.entity.Nombre = nombre;
                return this;
            }

            public ProyectoReporteBuilder HorasEstimadas(long HorasEstimadas)
            {
                this.entity.HorasEstimadas = HorasEstimadas;
                return this;
            }
            public ProyectoReporteBuilder HorasInsumidas(long HorasInsumidas
                )
            {
                this.entity.HorasInsumidas = HorasInsumidas;
                return this;
            }
            public ProyectoReporteBuilder DesvioDinero(long DesvioDinero)
            {
                this.entity.DesvioDinero = DesvioDinero;
                return this;
            }
            public ProyectoReporteBuilder DesvioHoras(long DesvioHoras)
            {
                this.entity.DesvioHoras = DesvioHoras;
                return this;
            }
            public ProyectoReporteBuilder Fecha(DateTime Fecha)
            {
                this.entity.Fecha = Fecha;
                return this;
            }

            public ProyectoReporte build()
            {
                return this.entity;
            }
        }
    }

}