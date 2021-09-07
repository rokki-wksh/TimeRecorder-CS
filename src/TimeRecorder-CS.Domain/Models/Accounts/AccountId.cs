using System;

namespace TimeRecorder_CS.Domain.Models.Accounts
{
    public sealed class AccountId
    {
        private readonly string _value;

        private AccountId(string value)
        {
            _value = value;
        }

        public static AccountId From(string value)
        {
            return new AccountId(value);
        }

        public static AccountId Create()
        {
            return new AccountId(Ulid.NewUlid().ToString());
        }

        public override string ToString()
        {
            return _value;
        }

        internal string Value => _value;
    }
}