using System;

namespace allowance
{
    class Allowance
    {
        private Account account;
        private Parent parent;
        private Child[] children;


        public void Run(int n, int a, int m, int p, int c1, int c2, int q)
        {
            Console.WriteLine("Saldo inicial: {0}, ingreso semanal: {1}, gastos semanales:[{2},{3}], hijos:{4}", a, p, c1, c2, n);
            Console.WriteLine("Saldo mínimo posible: {0}, probabilidad de que gasten 10 veces más:{1}", m, q);
            Init(n, a, m, p, c1, c2, q);
            Start();
            Finish();
            Console.WriteLine("Depositos totales: {0}", parent.Deposit);
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Hijo {0} ha gastado {1}", i, children[i].Expenses);
            }
            Console.WriteLine("Saldo final: {0}", account.Balance);
        }

        private void Init(int n, int a, int m, int p, int c1, int c2, int q)
        {
            account = new Account(a, m);
            parent = new Parent(account, p);
            children = new Child[n];
            for (int i = 0; i < n; i++)
            {
                children[i] = new Child(account, c1, c2, q);
            }
        }

        private void Start()
        {
            parent.Start();
            for (int i = 0; i < children.Length; i++)
            {
                children[i].Start();
            }
        }
        private void Finish()
        {
            parent.Finish();
            account.Close();
            for (int i = 0; i < children.Length; i++)
            {
                children[i].Finish();
            }
        }
        public int Balance()
        {
            return account.Balance;
        }
        static void Main(string[] args)
        {
            Allowance p = new Allowance();
            p.Run(3, 0, -100, 15, 3, 8, 10);
        }

    }
}
