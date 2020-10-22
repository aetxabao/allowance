using System;

namespace allowance
{
    class Allowance
    {
        private Account account;
        private Parent[] parents;
        private Child[] children;

        public void Run(int r, int n, int a, int m, int p, int c1, int c2, int q, int t)
        {
            Console.WriteLine("Saldo inicial: {0}, saldo mínimo posible: {1}", a, m);
            Console.WriteLine("Ingreso semanal: {0}, parents:{1}", p, r);
            Console.WriteLine("Gastos semanales:[{0},{1}], children:{2}", c1, c2, n);
            Console.WriteLine("Probabilidad de que gasten 10 veces más:{0}", q);
            Console.WriteLine("Timeout gasto:{0}", t);
            Init(r, n, a, m, p, c1, c2, q, t);
            Start();
            Finish();
            Console.WriteLine("Depositos cada parent: {0}", parents[0].Deposit);
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Child {0} ha gastado {1} y ha sido bloqueado {2}", i, children[i].Expenses, children[i].Blocks);
            }
            Console.WriteLine("Saldo final: {0}", account.Balance);
        }

        private void Init(int r, int n, int a, int m, int p, int c1, int c2, int q, int t)
        {
            account = new Account(a, m, t);
            parents = new Parent[r];
            for (int i = 0; i < r; i++)
            {
                parents[i] = new Parent(account, p);
            }
            children = new Child[n];
            for (int i = 0; i < n; i++)
            {
                children[i] = new Child(account, c1, c2, q);
            }
        }

        private void Start()
        {
            for (int i = 0; i < parents.Length; i++)
            {
                parents[i].Start();
            }
            for (int i = 0; i < children.Length; i++)
            {
                children[i].Start();
            }
        }
        private void Finish()
        {
            for (int i = 0; i < parents.Length; i++)
            {
                parents[i].Finish();
            }
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
            p.Run(2, 3, 0, -100, 10, 3, 8, 10, 1);
        }

    }
}
