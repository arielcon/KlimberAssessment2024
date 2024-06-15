using DevelopmentChallenge.Data.Enums;
using DevelopmentChallenge.Data.Helpers;
using DevelopmentChallenge.Data.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevelopmentChallenge.Data.Classes
{
    public class ProcesadorDeFormasGeometricas
    {
        public static string Imprimir(List<FormaGeometricaTemplate> formas, EIdioma idioma)
        {
            LenguajeHelper.InicializarLenguaje(idioma);

            var areaTotal = 0m;
            var perimetroTotal = 0m;

            var sb = new StringBuilder();

            MensajesHelper.AgregarMensajeListaVacia(sb, formas);

            if (formas.Any())
            {
                MensajesHelper.AgregarHeader(sb);

                //Loop por cada tipo de figura
                foreach (int tipoForma in Enum.GetValues(typeof(ETipoForma)))
                {
                    var areaSubTotal = 0m;
                    var perimetroSubTotal = 0m;

                    var formasAProcesar = formas.Where(x => (int)x.TipoForma == tipoForma).ToList();
                    var cantFormasAProcesar = formasAProcesar.Count();

                    for (var i = 0; i < cantFormasAProcesar; i++)
                    {
                        var forma = FormaGeometricaFactory.CrearForma(
                            formasAProcesar[i].TipoForma,
                            formasAProcesar[i].ValorInicialBase,
                            formasAProcesar[i].ValorInicialAltura,
                            formasAProcesar[i].ValorInicialBaseMayor
                            );

                        areaSubTotal += forma.CalcularArea();
                        perimetroSubTotal += forma.CalcularPerimetro();
                    }

                    //Subtotales por tipo de figura
                    MensajesHelper.AgregarLinea(sb, cantFormasAProcesar, areaSubTotal, perimetroSubTotal, (ETipoForma)tipoForma);

                    areaTotal += areaSubTotal;
                    perimetroTotal += perimetroSubTotal;
                }

                MensajesHelper.AgregarFooter(sb, formas.Count, perimetroTotal, areaTotal);
            }

            return sb.ToString();
        }
    }
}
