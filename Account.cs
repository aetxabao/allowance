namespace allowance
{
    public class Account
    {
        private readonly object token = new object();
        public int Balance { get; set; }

        public Account(int amount)
        {
            this.Balance = amount;
        }

        public void Remove(int amount)
        {
            lock (token)
            {
                Balance -= amount;
            }
        }

        public void Insert(int amount)
        {
            lock (token)
            {
                Balance += amount;
            }
        }
    }
}