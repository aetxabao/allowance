using System.Threading;

namespace allowance
{
    public class Account
    {
        private readonly object token = new object();
        public int Balance { get; set; }
        private int limit;

        private bool isClosed = false;

        public Account(int amount, int limit)
        {
            this.Balance = amount;
            this.limit = limit;
        }

        public bool Remove(int amount)
        {
            lock (token)
            {
                while (!isClosed)
                {
                    if (Balance - amount < limit)
                    {
                        Monitor.Wait(token);
                    }
                    else
                    {
                        Balance -= amount;
                        return true;
                    }
                }
                return false;
            }
        }

        public void Insert(int amount)
        {
            lock (token)
            {
                Balance += amount;
                Monitor.Pulse(token);
            }
        }

        public void Close()
        {
            lock (token)
            {
                this.isClosed = true;
                Monitor.PulseAll(token);
            }
        }
    }
}