using System;
using Xunit;

namespace TestAccount
{
    public class AccountTests
    {
        private readonly Account.Domain.Entities.Account _source;
        private readonly Account.Domain.Entities.Account _destination;

        public AccountTests()
        {
            _source = new Account.Domain.Entities.Account(1, "0001", "11111-1", 500);
            _destination = new Account.Domain.Entities.Account(1, "0001", "22222-2", 500);
        }

        [Fact]
        public void ShouldReturnErroWhenDebitInsuficientFunds()
        {
            Assert.Throws<Exception>(() => _source.Debit(600));
        }

        [Fact]
        public void ShouldReturnErroWhenCreditValueEqualZero()
        {            
            Assert.Throws<Exception>(() => _destination.Credit(0));
        }
    }
}

