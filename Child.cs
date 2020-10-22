using System.Threading;

namespace allowance
{
    public class Child
    {
        private Account account;
        private Thread thread;
        private int amount;

        public Child(Account storage, int amount)
        {
            this.account = storage;
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
                account.Remove(amount);
                Thread.Sleep(7);
            }
        }
    }
}