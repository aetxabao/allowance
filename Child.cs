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
        private int q;
        private Random rnd;
        public int Expenses { get; set; }
        public int Blocks { get; set; }

        public Child(Account storage, int a1, int a2, int q)
        {
            this.account = storage;
            this.a1 = a1;
            this.a2 = a2;
            this.q = q;
            rnd = new Random();
            this.Expenses = 0;
            this.Blocks = 0;
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
            int b;
            try
            {
                for (int i = 0; i < 52; i++)
                {
                    a = rnd.Next(a1, a2);
                    b = rnd.Next(0, 100);
                    if (b < q)
                    {
                        a = a * 10;
                    }
                    if (account.Remove(a))
                    {
                        Expenses += a;
                    }
                    else
                    {
                        Blocks++;
                    }
                    Thread.Sleep(7);
                }
            }
            catch (ThreadAbortException) { }
        }
    }
}