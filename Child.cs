using System;
using System.Threading;

namespace allowance
{
    public class Child
    {
        private Account account;
        private Thread thread;
        private int a1;
        private int a2;
        private Random rnd;
        public int Expenses { get; set; }

        public Child(Account storage, int a1, int a2)
        {
            this.account = storage;
            this.a1 = a1;
            this.a2 = a2;
            rnd = new Random();
            this.Expenses = 0;
        }
        public void Start()
        {
            this.thread = new Thread(() => this.Agenda());
            this.thread.Start();
        }

        public void Finish()
        {
            thread.Join();
        }

        private void Agenda()
        {
            int a;
            for (int i = 0; i < 52; i++)
            {
                a = rnd.Next(a1, a2);
                account.Remove(a);
                Expenses += a;
                Thread.Sleep(7);
            }
        }
    }
}