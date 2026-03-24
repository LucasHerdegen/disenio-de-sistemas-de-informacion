using SmartLife.Clases.Clientes;

namespace SmartLife.Clases.Planes
{
    public class PlanCorporativo : Plan
    {
        private readonly double _descuento;

        public PlanCorporativo(double tarifaBase, double descuento) : base(tarifaBase)
        {
            _descuento = descuento;
        }

        public override double CalcularTarifa(Cliente cliente) =>
            base.CalcularTarifa(cliente) * (1 - _descuento / 100);
    }
}