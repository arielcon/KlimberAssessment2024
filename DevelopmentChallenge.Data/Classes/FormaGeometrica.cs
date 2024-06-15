using DevelopmentChallenge.Data.Enums;

namespace DevelopmentChallenge.Data.Interfaces
{
    public abstract class FormaGeometrica
    {
        public ETipoForma TipoForma { get; set; }

        public FormaGeometrica(ETipoForma tipoForma)
        {
            TipoForma = tipoForma;
        }
        public abstract decimal CalcularPerimetro();
        public abstract decimal CalcularArea();
    }
}
