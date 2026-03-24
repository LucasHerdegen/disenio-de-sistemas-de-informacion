using SmartLife.Clases.Clientes;

namespace SmartLife.Clases.Planes
{
    public abstract class Plan
    {
        protected double _tarifaBase;

        public Plan(double tarifaBase)
        {
            _tarifaBase = tarifaBase;
        }

        public virtual double CalcularTarifa(Cliente cliente) => _tarifaBase;
    }
}