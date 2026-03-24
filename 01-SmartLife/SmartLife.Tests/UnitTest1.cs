using FluentAssertions;
using SmartLife.Clases.Clientes;
using SmartLife.Clases.Planes;
using SmartLife.Clases.Facturacion;

namespace SmartLife.Tests
{
    public class FacturacionTests
    {
        [Fact]
        public void PlanHogar_DeberiaCobrarSoloTarifaBase_SinImportarDispositivos()
        {
            // Arrange
            double tarifaBase = 1500;
            var plan = new PlanHogar(tarifaBase);
            var cliente = new Cliente("hogar@test.com", dispositivosConectados: 10, plan);

            // Act
            double resultado = plan.CalcularTarifa(cliente);

            // Assert
            resultado.Should().Be(1500, "El plan hogar no debe cobrar adicionales por dispositivo.");
        }

        [Theory]
        [InlineData(0, 2000)]  // 0 dispositivos: 2000 + (100 * 0) = 2000
        [InlineData(5, 2500)]  // 5 dispositivos: 2000 + (100 * 5) = 2500
        [InlineData(10, 3000)] // 10 dispositivos: 2000 + (100 * 10) = 3000
        public void PlanComercio_DeberiaSumarAdicionalPorDispositivo(int dispositivos, double tarifaEsperada)
        {
            // Arrange
            double tarifaBase = 2000;
            double adicionalPorDispositivo = 100;
            var plan = new PlanComercio(tarifaBase, adicionalPorDispositivo);
            var cliente = new Cliente("comercio@test.com", dispositivos, plan);

            // Act
            double resultado = plan.CalcularTarifa(cliente);

            // Assert
            resultado.Should().Be(tarifaEsperada);
        }

        [Fact]
        public void PlanCorporativo_DeberiaAplicarDescuentoPorcentualCorrectamente()
        {
            // Arrange
            double tarifaBase = 5000;
            double porcentajeDescuento = 20; // 20% de descuento, ojo que es un porcentaje
            var plan = new PlanCorporativo(tarifaBase, porcentajeDescuento);
            var cliente = new Cliente("corp@test.com", dispositivosConectados: 50, plan);

            // Act
            double resultado = plan.CalcularTarifa(cliente);

            // Assert
            // 5000 * (1 - 0.20) = 4000
            resultado.Should().Be(4000);
        }

        [Fact]
        public void FacturaMensual_DeberiaDelegarCalculoAlPlanDelCliente()
        {
            // Arrange
            var planMock = new PlanCorporativo(1000, 10); // 10% de 1000 = 900
            var cliente = new Cliente("delegacion@test.com", 0, planMock);
            var factura = new FacturaMensual(cliente);

            // Act
            double montoFactura = factura.CalcularMonto();

            // Assert
            montoFactura.Should().Be(900, "La factura debe invocar correctamente a la estrategia del cliente.");
        }
    }
}