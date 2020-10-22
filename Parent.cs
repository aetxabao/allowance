using System.Threading;

namespace allowance
{
    public class Parent
    {
        private Account account;
        private Thread thread;
        private int amount;

        public Parent(Account account, int amount)
        {
            this.account = account;
            this.amount = amount;
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
                Thread.Sleep(7);
            }
        }
    }
}