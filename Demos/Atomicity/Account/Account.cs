using System.Threading;

namespace Atomicity
{
    public class Account
    {
        volatile int _balance;

        public void Credit(int amount)
        {
            _balance += amount;
        }

        public void Debit(int amount)
        {
            _balance -= amount;
        }

        public int CurrentBalance
        {
            get { return _balance; } 
        }
    }
}
