using BE;

namespace BLL
{
    public class Session
    {
        private Usuario _Usuario;
        private static Session session;
        public Usuario Usuario
        {
            get
            {
                return this._Usuario != null ? this._Usuario : Usuario.builder().Username("SYSTEM").build();
            }
            set
            {
                this._Usuario = value;
            }
        }

        public static Session getInstance()
        {
            if (session == null)
                session = new Session();
            return session;
        }

    }
}
