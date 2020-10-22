using System.Threading;

namespace allowance
{
    public class Parent
    {
        private Account account;
        private Thread thread;
        private int amount;
        public int Deposit { get; set; }

        public Parent(Account account, int amount)
        {
            this.account = account;
            this.amount = amount;
            this.Deposit = 0;
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
            for (int i = 0; i < 52; i++)
            {
                account.Insert(amount);
                Deposit += amount;
                Thread.Sleep(7);
            }
        }
    }
}