using DevelopmentChallenge.Data.Classes;
using DevelopmentChallenge.Data.Enums;
using DevelopmentChallenge.Data.Interfaces;
using System;

public static class FormaGeometricaFactory
{
    public static FormaGeometrica CrearForma(
        ETipoForma tipoForma, 
        decimal valorInicialBase,
        decimal? valorInicialAltura,
        decimal? valorInicialBaseMayor)
    {
        if (tipoForma == ETipoForma.Cuadrado)
        {
            return new Cuadrado(valorInicialBase);
        }
        else if (tipoForma == ETipoForma.TrianguloEquilatero)
        {
            return new TrianguloEquilatero(valorInicialBase);
        }
        else if (tipoForma == ETipoForma.Circulo)
        {
            return new Circulo(valorInicialBase);
        }
        else if (tipoForma == ETipoForma.Trapecio)
        {
            return new Trapecio(valorInicialBase, valorInicialAltura.Value, valorInicialBaseMayor.Value);
        }
        else if (tipoForma == ETipoForma.Rectangulo)
        {
            return new Rectangulo(valorInicialBase, valorInicialAltura.Value);
        }

        throw new ArgumentException(@"Forma desconocida");
    }
}
