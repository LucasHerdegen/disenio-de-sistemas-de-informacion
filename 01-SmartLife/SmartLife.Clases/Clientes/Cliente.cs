using SmartLife.Clases.Planes;

namespace SmartLife.Clases.Clientes
{
    public class Cliente
    {
        private string _email;
        private string _id;
        public int DispositivosConectados { get; private set; }
        public Plan Plan { get; }

        public Cliente(string email, int dispositivosConectados, Plan plan)
        {
            _email = email;
            _id = Guid.NewGuid().ToString();
            DispositivosConectados = dispositivosConectados;
            Plan = plan;
        }
    }
}