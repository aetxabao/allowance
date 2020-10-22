using System.Threading;

namespace allowance
{
    public class Account
    {
        private readonly object token = new object();
        public int Balance { get; set; }
        private int limit;
        private int timeout;

        private bool isClosed = false;

        public Account(int amount, int limit, int timeout)
        {
            this.Balance = amount;
            this.limit = limit;
            this.timeout = timeout;
        }

        public bool Remove(int amount)
        {
            lock (token)
            {
                while (!isClosed)
                {
                    if (Balance - amount < limit)
                    {
                        if (Monitor.Wait(token, timeout))
                        {
                            if (Balance - amount < limit)
                            {
                                return false;
                            }
                            else
                            {
                                Balance -= amount;
                                return true;
                            }
                        }
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