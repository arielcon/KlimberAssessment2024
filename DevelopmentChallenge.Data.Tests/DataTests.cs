using System;
using System.Collections.Generic;
using DevelopmentChallenge.Data.Classes;
using DevelopmentChallenge.Data.Enums;
using DevelopmentChallenge.Data.Modelos;
using NUnit.Framework;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [Test]
        public void TestImprimir_When_NoShapes_ShouldReturnEmptyListMessageInSpanish()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                ProcesadorDeFormasGeometricas.Imprimir(new List<FormaGeometricaTemplate>(), EIdioma.Castellano));
        }

        [Test]
        public void TestImprimir_When_NoShapes_ShouldReturnEmptyListMessageInEnglish()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                ProcesadorDeFormasGeometricas.Imprimir(new List<FormaGeometricaTemplate>(), EIdioma.Ingles));
        }

        [Test]
        public void TestImprimir_HappyPathCondition_1Square_HappyHappyPathResult()
        {
            var cuadrados = new List<FormaGeometricaTemplate> {new FormaGeometricaTemplate(ETipoForma.Cuadrado, 5)};

            var resumen = ProcesadorDeFormasGeometricas.Imprimir(cuadrados, EIdioma.Castellano);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25", resumen);
        }

        [Test]
        public void TestImprimir_HappyPathCondition_MoreSquares_HappyHappyPathResult()
        {
            var cuadrados = new List<FormaGeometricaTemplate>
            {
                new FormaGeometricaTemplate(ETipoForma.Cuadrado, 5),
                new FormaGeometricaTemplate(ETipoForma.Cuadrado, 1),
                new FormaGeometricaTemplate(ETipoForma.Cuadrado, 3)
            };

            var resumen = ProcesadorDeFormasGeometricas.Imprimir(cuadrados, EIdioma.Ingles);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

        [Test]
        public void TestImprimir_HappyPathCondition_MoreShapes_HappyHappyPathResult()
        {
            var formas = new List<FormaGeometricaTemplate>
            {
                new FormaGeometricaTemplate(ETipoForma.Cuadrado, 5),
                new FormaGeometricaTemplate(ETipoForma.Circulo, 3),
                new FormaGeometricaTemplate(ETipoForma.TrianguloEquilatero, 4),
                new FormaGeometricaTemplate(ETipoForma.Cuadrado, 2),
                new FormaGeometricaTemplate(ETipoForma.TrianguloEquilatero, 9),
                new FormaGeometricaTemplate(ETipoForma.Circulo, 2.75m),
                new FormaGeometricaTemplate(ETipoForma.TrianguloEquilatero, 4.2m)
            };

            var resumen = ProcesadorDeFormasGeometricas.Imprimir(formas, EIdioma.Ingles);

            Assert.IsTrue(resumen.StartsWith("<h1>Shapes report</h1>"));
            Assert.IsTrue(resumen.Contains("2 Squares | Area 29 | Perimeter 28 <br/>"));
            Assert.IsTrue(resumen.Contains("2 Circles | Area 13,01 | Perimeter 18,06 <br/>"));
            Assert.IsTrue(resumen.Contains("3 Triangles | Area 49,64 | Perimeter 51,6 <br/>"));
            Assert.IsTrue(resumen.EndsWith("TOTAL:<br/>7 shapes Perimeter 97,66 Area 91,65"));
        }

        [Test]
        public void TestImprimir_HappyPathCondition_MoreShapesInSpanish_HappyHappyPathResult()
        {
            var formas = new List<FormaGeometricaTemplate>
            {
                new FormaGeometricaTemplate(ETipoForma.Cuadrado, 5),
                new FormaGeometricaTemplate(ETipoForma.Circulo, 3),
                new FormaGeometricaTemplate(ETipoForma.TrianguloEquilatero, 4),
                new FormaGeometricaTemplate(ETipoForma.Cuadrado, 2),
                new FormaGeometricaTemplate(ETipoForma.TrianguloEquilatero, 9),
                new FormaGeometricaTemplate(ETipoForma.Circulo, 2.75m),
                new FormaGeometricaTemplate(ETipoForma.TrianguloEquilatero, 4.2m)
            };

            var resumen = ProcesadorDeFormasGeometricas.Imprimir(formas, EIdioma.Castellano);

            Assert.IsTrue(resumen.StartsWith("<h1>Reporte de Formas</h1>"));
            Assert.IsTrue(resumen.Contains("2 Cuadrados | Area 29 | Perimetro 28 <br/>"));
            Assert.IsTrue(resumen.Contains("2 Círculos | Area 13,01 | Perimetro 18,06 <br/>"));
            Assert.IsTrue(resumen.Contains("3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>"));
            Assert.IsTrue(resumen.EndsWith("TOTAL:<br/>7 formas Perimetro 97,66 Area 91,65"));
        }

        [Test]
        [TestCase(ETipoForma.Trapecio, 5, 6, 7)]
        [TestCase(ETipoForma.Trapecio, 3, 3, 3)]
        public void TestImprimir_HappyPathCondition_Trapecios_HappyHappyPathResult(
            ETipoForma tipoForma, 
            decimal baseMenor,
            decimal altura,
            decimal baseMayor)
        {
            var formas = new List<FormaGeometricaTemplate>
            {
                new FormaGeometricaTemplate(tipoForma, baseMenor, altura, baseMayor)
            };

            var resumen = ProcesadorDeFormasGeometricas.Imprimir(formas, EIdioma.Castellano);

            Assert.IsTrue(resumen.StartsWith("<h1>Reporte de Formas</h1>"));

            var area = (altura / 2) * (baseMenor + baseMayor);
            decimal ladoNoParalelo = (decimal)Math.Sqrt(
                (double)(altura * altura) + Math.Pow((double)((baseMayor - baseMenor) / 2), 2));

            var perimetro = baseMayor + baseMenor + 2 * ladoNoParalelo;

            Assert.IsTrue(resumen.Contains(
                $"1 Trapecio | Area {area.ToString("#.##")} | Perimetro {perimetro.ToString("#.##")}"));
        }
    }
}
