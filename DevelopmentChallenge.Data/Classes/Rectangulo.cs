using DevelopmentChallenge.Data.Enums;
using DevelopmentChallenge.Data.Interfaces;

namespace DevelopmentChallenge.Data.Classes
{
    public class Rectangulo : FormaGeometrica
    {
        decimal _lado;
        decimal _lado2;

        public Rectangulo(decimal lado, decimal lado2) : 
            base(ETipoForma.Rectangulo)
        {
            _lado = lado;
            _lado2 = lado2;
        }
        public override decimal CalcularArea()
        {
            return _lado * _lado2;
        }

        public override decimal CalcularPerimetro()
        {
            return (_lado * 2) + (_lado2 * 2);
        }
    }
}
