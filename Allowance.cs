using System;

namespace allowance
{
    class Allowance
    {
        private Account account;
        private Parent parent;
        private Child child;


        public void Run(int a, int p, int c)
        {
            Init(a, p, c);
            Start();
            Finish();
        }

        private void Init(int a, int p, int c)
        {
            account = new Account(a);
            parent = new Parent(account, p);
            child = new Child(account, c);
        }

        private void Start()
        {
            parent.Start();
            child.Start();
        }
        private void Finish()
        {
            parent.Finish();
            child.Finish();
        }
        public int Balance()
        {
            return account.Balance;
        }
        static void Main(string[] args)
        {
            Allowance p = new Allowance();
            // Si se comentan las sentencias lock de la clase Account
            // El balance final puede variar en cada ejecución
            // aunque las entradas son iguales a las salidas
            Console.WriteLine("Saldo inicial: {0}, ingreso semanal: {1}, gastos semanales:{2}", 0, 5, 5);
            p.Run(0, 5, 5);
            int balance = p.Balance();
            Console.WriteLine("Saldo final: {0}", balance);
            // Ejecución de la misma simulación repetidas veces
            for (int i = 0; i < 100; i++)
            {
                p.Run(0, 5, 5);
                balance = p.Balance();
                Console.WriteLine("Saldo final: {0}", balance);
            }
        }

    }
}
