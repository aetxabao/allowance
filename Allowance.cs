using System;

namespace allowance
{
    class Allowance
    {
        private Account account;
        private Parent parent;
        private Child[] children;


        public void Run(int n, int a, int p, int c1, int c2)
        {
            Console.WriteLine("Saldo inicial: {0}, ingreso semanal: {1}, gastos semanales:[{2},{3}], hijos:{4}", a, p, c1, c2, n);
            Init(n, a, p, c1, c2);
            Start();
            Finish();
            Console.WriteLine("Saldo final: {0}", account.Balance);
            Console.WriteLine("Depositos totales: {0}", parent.Deposit);
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Hijo {0} ha gastado {1}", i, children[i].Expenses);
            }
        }

        private void Init(int n, int a, int p, int c1, int c2)
        {
            account = new Account(a);
            parent = new Parent(account, p);
            children = new Child[n];
            for (int i = 0; i < n; i++)
            {
                children[i] = new Child(account, c1, c2);
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
            p.Run(3, 0, 15, 3, 8);
        }

    }
}
