using System;

namespace allowance
{
    class Allowance
    {
        private Account account;
        private Parent parent;
        private Child child;


        public void Run(int a, int p, int c1, int c2)
        {
            Init(a, p, c1, c2);
            Start();
            Finish();
        }

        private void Init(int a, int p, int c1, int c2)
        {
            account = new Account(a);
            parent = new Parent(account, p);
            child = new Child(account, c1, c2);
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
            Console.WriteLine("Saldo inicial: {0}, ingreso semanal: {1}, gastos semanales:[{2},{3}]", 0, 5, 3, 8);
            p.Run(0, 5, 3, 8);
            int a = p.Balance();
            Console.WriteLine("Saldo final: {0}", a);
            a = Math.Abs(a);
            Console.WriteLine("Saldo inicial: {0}, ingreso semanal: {1}, gastos semanales:[{2},{3}]", a, 5, 3, 8);
            p.Run(a, 5, 3, 8);
            a = p.Balance();
            Console.WriteLine("Saldo final: {0}", a);
        }

    }
}
