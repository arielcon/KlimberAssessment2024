using DevelopmentChallenge.Data.Enums;

namespace DevelopmentChallenge.Data.Modelos
{
    public class FormaGeometricaTemplate
    {
        public ETipoForma TipoForma { get; set; }

        public decimal ValorInicialBase { get; set; }

        public decimal? ValorInicialAltura { get; set; }

        public decimal? ValorInicialBaseMayor { get; set; }

        public FormaGeometricaTemplate(
            ETipoForma tipoForma,
            decimal valorInicialBase,
            decimal? valorInicialAltura = null,
            decimal? valorInicialBaseMayor = null)
        {
            TipoForma = tipoForma;
            ValorInicialBase = valorInicialBase;
            ValorInicialAltura = valorInicialAltura;
            ValorInicialBaseMayor = valorInicialBaseMayor;
        }
    }
}
