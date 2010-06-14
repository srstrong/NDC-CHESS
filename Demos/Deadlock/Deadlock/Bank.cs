namespace Deadlock
{
    public class Bank
    {
        public void Transfer(Account source, Account destination, int amount)
        {
            lock (source)
            {
                lock (destination)
                {
                    source.Debit(amount);
                    destination.Credit(amount);
                }
            }
        }
    }
}
