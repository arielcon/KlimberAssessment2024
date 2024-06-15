using DevelopmentChallenge.Data.Enums;
using DevelopmentChallenge.Data.Idiomas;
using DevelopmentChallenge.Data.Modelos;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevelopmentChallenge.Data.Helpers
{
    public static class MensajesHelper
    {
        public static void AgregarLinea(StringBuilder sb, int cantFiguras, decimal areaSubTotal, decimal perimetroSubTotal, ETipoForma tipoForma)
        {
            var linea = ObtenerLinea(cantFiguras, areaSubTotal, perimetroSubTotal, (ETipoForma)tipoForma);
            sb.Append(linea);
        }

        public static string ObtenerLinea(int cantidad, decimal area, decimal perimetro, ETipoForma tipoForma)
        {
            if (cantidad > 0)
            {
                var tituloArea = Resources.TITLE_AREA;
                var tituloPerimetro = Resources.TITLE_PERIMETER;

                return $"{cantidad} {ObtenerDescripcionForma(tipoForma, cantidad)}| {tituloArea} {area:#.##} | {tituloPerimetro} {perimetro:#.##} <br/>";
            }
            else
                return string.Empty;
        }

        public static void AgregarMensajeListaVacia(StringBuilder sb, List<FormaGeometricaTemplate> formas)
        {
            if (!formas.Any())
            {
                sb.Append($"<h1>{Resources.EMTPY_LIST}</h1>");
            }
        }

        public static void AgregarHeader(StringBuilder sb)
        {
            sb.Append($"<h1>{Resources.SHAPES_REPORT}</h1>");
        }

        public static void AgregarFooter(StringBuilder sb, int cantidadFormas, decimal perimetroTotal, decimal areaTotal)
        {
            sb.Append("TOTAL:<br/>");
            sb.Append(cantidadFormas + " " + Resources.SHAPES_CAPTION + " ");
            sb.Append(Resources.TITLE_PERIMETER + " " + perimetroTotal.ToString("#.##") + " ");
            sb.Append(Resources.TITLE_AREA + " " + (areaTotal).ToString("#.##"));
        }

        private static string ObtenerDescripcionForma(ETipoForma tipoForma, int cantidad)
        {
            switch (tipoForma)
            {
                case ETipoForma.Cuadrado:
                    return $"{Resources.SHAPE_SQUARE}{(cantidad > 1 ? "s " : " ")}";

                case ETipoForma.Circulo:
                    return $"{Resources.SHAPE_CIRCLE}{(cantidad > 1 ? "s " : " ")}";

                case ETipoForma.TrianguloEquilatero:
                    return $"{Resources.SHAPE_TRIANGLE}{(cantidad > 1 ? "s " : " ")}";

                case ETipoForma.Trapecio:
                    return $"{Resources.SHAPE_TRAPEZE}{(cantidad > 1 ? "s " : " ")}";
            }

            return string.Empty;
        }
    }
}
