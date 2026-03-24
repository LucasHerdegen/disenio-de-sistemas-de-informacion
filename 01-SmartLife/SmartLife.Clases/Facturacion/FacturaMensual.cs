using SmartLife.Clases.Clientes;

namespace SmartLife.Clases.Facturacion
{
    public class FacturaMensual
    {
        private Cliente _cliente;

        public FacturaMensual(Cliente cliente)
        {
            _cliente = cliente;
        }

        public double CalcularMonto() => _cliente.Plan.CalcularTarifa(_cliente);
    }
}