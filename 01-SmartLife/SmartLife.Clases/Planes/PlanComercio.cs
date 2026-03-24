using SmartLife.Clases.Clientes;

namespace SmartLife.Clases.Planes
{
    public class PlanComercio : Plan
    {
        private readonly double _adicional;

        public PlanComercio(double tarifaBase, double adicional)
            : base(tarifaBase)
        {
            _adicional = adicional;
        }

        public override double CalcularTarifa(Cliente cliente) =>
            base.CalcularTarifa(cliente) + _adicional * cliente.DispositivosConectados;
    }
}