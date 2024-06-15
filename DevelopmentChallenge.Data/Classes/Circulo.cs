using DevelopmentChallenge.Data.Enums;
using DevelopmentChallenge.Data.Interfaces;
using System;

namespace DevelopmentChallenge.Data.Classes
{
    public class Circulo : FormaGeometrica
    {
        decimal _radio;
        public Circulo(decimal radio) : base(ETipoForma.Circulo)
        {
            _radio = radio;
        }
        public override decimal CalcularArea()
        {
            return (decimal)Math.PI * (_radio / 2) * (_radio / 2);
        }

        public override decimal CalcularPerimetro()
        {
            return (decimal)Math.PI * _radio;
        }
    }
}
