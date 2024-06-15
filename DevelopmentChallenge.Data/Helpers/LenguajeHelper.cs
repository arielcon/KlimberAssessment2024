using DevelopmentChallenge.Data.Enums;
using System.Globalization;

namespace DevelopmentChallenge.Data.Helpers
{
    public static class LenguajeHelper
    {
        public static void InicializarLenguaje(EIdioma idioma = EIdioma.Castellano)
        {
            var culture = new CultureInfo("es");

            switch (idioma)
            {
                case EIdioma.Ingles:
                    culture = new CultureInfo("en");
                    break;
                case EIdioma.Italiano:
                    culture = new CultureInfo("it");
                    break;
            }

            System.Threading.Thread.CurrentThread.CurrentUICulture = culture;
        }
    }
}
