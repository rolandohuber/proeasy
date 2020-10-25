namespace BE
{
    public class DigitoVerificador
    {
        public long Id { get; set; }
        public string Tabla { get; set; }
        public string Valor { get; set; }
        public DigitoVerificador(long id, string tabla, string valor)
        {
            Id = id;
            Tabla = tabla;
            Valor = valor;
        }
        public DigitoVerificador()
        {
        }
        public static DigitoVerificadorBuilder builder()
        {
            return new DigitoVerificadorBuilder();
        }
        public class DigitoVerificadorBuilder
        {
            private DigitoVerificador entity = new DigitoVerificador();
            public DigitoVerificadorBuilder Id(long Id)
            {
                this.entity.Id = Id;
                return this;
            }
            public DigitoVerificadorBuilder Tabla(string Tabla)
            {
                this.entity.Tabla = Tabla;
                return this;
            }
            public DigitoVerificadorBuilder Valor(string Valor)
            {
                this.entity.Valor = Valor;
                return this;
            }
            public DigitoVerificador build()
            {
                return this.entity;
            }
        }
    }
}