namespace Entidades
{
    public enum ESistema
    {
        Decimal,Binario
    }
    public abstract class Numeracion
    {
        protected string msgError;
        protected string valor;

        public string Valor
        {
            get
            {
                return valor;
            }
        }
        internal abstract double ValorNumerico { get; }

        static Numeracion()
        {

        }
        protected Numeracion(string valor)
        {
            InicializaValor(this.valor);
        }
        public abstract Numeracion CambiarSistemaDeNumeracion (ESistema sistema);

        protected bool EsNumeracionValida(string valor)
        {
            if(!string.IsNullOrEmpty(valor))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void InicializaValor(string valor)
        {
            if (EsNumeracionValida(valor))
            {
                this.valor = valor;
            }
            else
            {
                this.valor= "Numero Invalido.";
            }
        }

        public static bool operator ==(Numeracion n1, Numeracion n2)
        {
            if (n1 == null && n2 == null)
            {
                return true;
            }
            if (n1 == null || n2 == null)
            {
                return false;
            }
            return n1.GetType() == n2.GetType();

        }
        
        public static bool operator != (Numeracion n1, Numeracion n2)
        {
            if (n1 == null && n2 == null)
            {
                return false;
            }
            if (n1 == null || n2 == null)
            {
                return true;
            }
            return !(n1.GetType() == n2.GetType());
        }

        public static explicit operator double(Numeracion numeracion)
        {
            return numeracion.ValorNumerico;
        
    }

}