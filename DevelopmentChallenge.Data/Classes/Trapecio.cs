using DevelopmentChallenge.Data.Enums;
using DevelopmentChallenge.Data.Interfaces;
using System;

namespace DevelopmentChallenge.Data.Classes
{
    public class Trapecio : FormaGeometrica
    {
        decimal _baseMenor;
        decimal _baseMayor;
        decimal _altura;
        public Trapecio(
            decimal baseMenor, 
            decimal altura,
            decimal baseMayor) : 
                base(ETipoForma.Trapecio)
        {
            _baseMenor = baseMenor;
            _baseMayor = baseMayor;
            _altura = altura;
        }
        public override decimal CalcularArea()
        {
            return (_altura/2) * (_baseMenor + _baseMayor);
        }

        public override decimal CalcularPerimetro()
        {
            decimal ladoNoParalelo = (decimal)Math.Sqrt(
                (double)(_altura * _altura) + Math.Pow((double)((_baseMayor - _baseMenor) / 2), 2));

            return _baseMayor + _baseMenor + 2 * ladoNoParalelo;
        }
    }
}
