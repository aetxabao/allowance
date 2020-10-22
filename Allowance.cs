using System;

namespace allowance
{
    class Allowance
    {
        private Account[] accounts;
        private Parent[] parents;
        private Child[] children;

        public void Run(int x, int a, int m, int p, int c1, int c2, int q, int t)
        {
            Console.WriteLine("Saldo inicial: {0}, saldo mínimo posible: {1}", a, m);
            Console.WriteLine("Ingreso semanal: {0}, parents:{1}", p, x);
            Console.WriteLine("Gastos semanales: [{0},{1}], children: {2}", c1, c2, x);
            Console.WriteLine("Probabilidad de que gasten 10 veces más: {0}%", q);
            Console.WriteLine("Timeout gasto:{0}", t);
            Init(x, a, m, p, c1, c2, q, t);
            Start();
            Finish();
            Console.WriteLine("Depositos cada parent: {0}", parents[0].Deposit);
            for (int i = 0; i < x; i++)
            {
                Console.WriteLine("Child {0} ha gastado {1} y ha sido bloqueado {2}", i, children[i].Expenses, children[i].Blocks);
                Console.WriteLine("Saldo final de su cuenta: {0}", accounts[i].Balance);
            }
        }

        private void Init(int x, int a, int m, int p, int c1, int c2, int q, int t)
        {

            accounts = new Account[x];
            parents = new Parent[x];
            children = new Child[x];
            for (int i = 0; i < x; i++)
            {
                accounts[i] = new Account(a, m, t);
                parents[i] = new Parent(accounts[i], p);
                children[i] = new Child(accounts[i], c1, c2, q);
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
            for (int i = 0; i < accounts.Length; i++)
            {
                accounts[i].Close();
            }
            for (int i = 0; i < children.Length; i++)
            {
                children[i].Finish();
            }
        }
        static void Main(string[] args)
        {
            Allowance p = new Allowance();
            p.Run(3, 0, -10, 5, 3, 8, 10, 1);
        }

    }
}
