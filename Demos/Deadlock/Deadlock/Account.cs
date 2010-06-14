namespace Deadlock
{
    public class Account
    {
        private readonly int _id;

        public Account(int id)
        {
            _id = id;
        }

        public void Debit(int amount)
        {
        }

        public void Credit(int amount)
        {
        }

        public override string ToString()
        {
            return string.Format("Account ID {0}", _id);
        }
    }
}