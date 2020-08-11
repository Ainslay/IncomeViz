using IncomeViz.BuildingBlocks.Domain;
using IncomeViz.BuildingBlocks.ValidationHelpers;

namespace IncomeViz.ProfitCalculation.Domain.Funds
{
    public class Money
    {
        private decimal _amount;
        private Currency _currency;

        private Money()
        {
            // Just for ef core
        }

        public Money(decimal amount, Currency currency)
        {
            _amount = amount;
            _currency = currency;
        }

        public Money(Money money)
        {
            _amount = money.GetAmount();
            _currency = money.GetCurrency();
        }

        public Money SubtractAmount(Money money)
        {
            Check.GreaterOrEqualZero(money.GetAmount());
            _amount -= money.GetAmount();
            return this;
        }

        public Money AddAmount(Money money)
        {
            Check.GreaterOrEqualZero(money.GetAmount());
            _amount += money.GetAmount();
            return this;
        }

        public decimal GetAmount()
        {
            return _amount;
        }

        public Currency GetCurrency()
        {
            return _currency;
        }
    }
}