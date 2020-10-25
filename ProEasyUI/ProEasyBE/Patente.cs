namespace BE
{
    public class Patente
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public Patente(long id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }
        public Patente()
        {
        }
        public override string ToString()
        {
            return this.Nombre;
        }
        public override bool Equals(object obj)
        {
            if (typeof(Patente) != obj.GetType())
                return false;
            return obj != null && Id == ((Patente)obj).Id;
        }
        public static PatenteBuilder builder()
        {
            return new PatenteBuilder();
        }
        public class PatenteBuilder
        {
            private Patente entity = new Patente();
            public PatenteBuilder Id(long Id)
            {
                this.entity.Id = Id;
                return this;
            }
            public PatenteBuilder Nombre(string nombre)
            {
                this.entity.Nombre = nombre;
                return this;
            }
            public Patente build()
            {
                return this.entity;
            }
        }
    }
}