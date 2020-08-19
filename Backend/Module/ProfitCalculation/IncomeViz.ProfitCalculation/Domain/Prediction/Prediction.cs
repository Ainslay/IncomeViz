using System;
using System.Linq;
using System.Collections.Generic;
using IncomeViz.ProfitCalculation.Domain.Funds;
using IncomeViz.ProfitCalculation.Domain.Expense.LongTerm;
using IncomeViz.ProfitCalculation.Domain.Expense.ShortTerm;
using IncomeViz.ProfitCalculation.Domain.Income.LongTerm;
using IncomeViz.ProfitCalculation.Domain.Income.ShortTerm;
using IncomeViz.ProfitCalculation.Domain.Prediction.Rules;
using IncomeViz.BuildingBlocks.Domain;
using IncomeViz.BuildingBlocks.ValidationHelpers;
using IncomeViz.BuildingBlocks.CalendarHelpers;

namespace IncomeViz.ProfitCalculation.Domain.Prediction
{
    public class Prediction : Entity, IAggregateRoot
    {
        public int Id { get; set; }
        public IReadOnlyCollection<ShortTermIncome> ShortTermIncomes => _shortTermIncomes.AsReadOnly();
        public IReadOnlyCollection<LongTermIncome> LongTermIncomes => _longTermIncomes.AsReadOnly();
        public IReadOnlyCollection<ShortTermExpense> ShortTermExpenses => _shortTermExpenses.AsReadOnly();
        public IReadOnlyCollection<LongTermExpense> LongTermExpenses => _longTermExpenses.AsReadOnly();

        private string _name;
        private Money _startingMoney;
        private readonly DateTime _startingDate;

        private readonly List<ShortTermIncome> _shortTermIncomes = new List<ShortTermIncome>();
        private readonly List<LongTermIncome> _longTermIncomes = new List<LongTermIncome>();

        private readonly List<ShortTermExpense> _shortTermExpenses = new List<ShortTermExpense>();
        private readonly List<LongTermExpense> _longTermExpenses = new List<LongTermExpense>();

        private Prediction()
        {
            // For ef core purpose
        }

        public Prediction(string name, Money startingMoney, DateTime startingDate)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            _name = name;
            _startingMoney = startingMoney;
            _startingDate = startingDate;
        }
        
        public string GetName() => _name;
        public Money GetStartingMoney() => _startingMoney;
        public DateTime GetStartingDate() => _startingDate;

        public void AddLongTermExpense(string name, DateTime expenseStartingDate, DateTime? effectiveDate, int executionDay, Money money)
        {
            CheckRule(new DuplicateNameNotAllowedRule(name, LongTermExpenses));
            CheckRule(new EffectiveDateMustBeHigherThanStartingDateRule(effectiveDate, _startingDate));
            CheckRule(new StartingDateMustBeHigherThanEffectiveDateRule(expenseStartingDate, effectiveDate));
            _longTermExpenses.Add(new LongTermExpense(Id, name, expenseStartingDate, effectiveDate, executionDay, money));
        }

        public void AddShortTermExpense(string name, DateTime executionDate, Money money)
        {
            CheckRule(new DuplicateNameNotAllowedRule(name, ShortTermExpenses));
            CheckRule(new ExecutionDateMustBeHigherOrEqualThanStartingDateRule(executionDate, _startingDate));
            _shortTermExpenses.Add(new ShortTermExpense(Id, name, executionDate, money));
        }

        public void AddLongTermIncome(string name, DateTime incomeStartingDate, DateTime? effectiveDate, int executionDay, Money money)
        {
            CheckRule(new DuplicateNameNotAllowedRule(name, LongTermIncomes));
            CheckRule(new EffectiveDateMustBeHigherThanStartingDateRule(effectiveDate, _startingDate));
            CheckRule(new StartingDateMustBeHigherThanEffectiveDateRule(incomeStartingDate, effectiveDate));
            _longTermIncomes.Add(new LongTermIncome(Id, name, incomeStartingDate, effectiveDate, executionDay, money));
        }

        public void AddShortTermIncome(string name, DateTime executionDate, Money money)
        {
            CheckRule(new DuplicateNameNotAllowedRule(name, ShortTermIncomes));
            CheckRule(new ExecutionDateMustBeHigherOrEqualThanStartingDateRule(executionDate, _startingDate));
            _shortTermExpenses.Add(new ShortTermExpense(Id, name, executionDate, money));
        }

        public List<DateMoneyDto> GeneratePrediction(DateTime minDate, DateTime maxDate)
        {
            var eachCalendarDay = CalendarHelper.EachCalendarDay(GetStartingDate(), maxDate);
            var predictionByDate = new List<DateMoneyDto>();

            foreach (var date in eachCalendarDay)
            {
                var previousPrediction = predictionByDate.SingleOrDefault(prediction => prediction.Date.Equals(date.AddDays(-1)));

                predictionByDate.Add(GeneratePredictionByDate(
                    date,
                    previousPrediction != null ? previousPrediction.Money : GetStartingMoney()));
            }

            return predictionByDate
                .Where(prediction => prediction.Date >= minDate && prediction.Date <= maxDate)
                .ToList();
        }

        private DateMoneyDto GeneratePredictionByDate(DateTime date, Money currentAmount)
        {
            var incomes = GetIncomesByDate(date);
            var expenses = GetExpensesByDate(date);

            return new DateMoneyDto
            {
                Date = date.Date,
                Money = new Money(currentAmount.AddAmount(incomes).SubtractAmount(expenses))
            };
        }

        private Money GetIncomesByDate(DateTime date)
        {
            var shortTermIncomes = _shortTermIncomes.Where(sti => sti.GetExecutionDate().Equals(date));
            var longTermIncomes = _longTermIncomes
                .Where(lti => lti.GetExecutionDay().Equals(date.Date.Day) && lti.IsDateInValidRange(date));

            var shortTermIncomesMoney = AddShortTermIncomesMoney(shortTermIncomes);
            var longTermIncomesMoney = AddLongTermIncomesMoney(longTermIncomes);
            return new Money(shortTermIncomesMoney).AddAmount(longTermIncomesMoney);
        }

        private Money GetExpensesByDate(DateTime date)
        {
            var shortTimeExpenses = _shortTermExpenses.Where(ste => ste.GetExecutionDate().Equals(date));
            var longTimeExpenses = _longTermExpenses.Where(lte => lte.GetExecutionDay().Equals(date.Date.Day) && lte.IsDateInValidRange(date));

            var shortTimeExpensesMoney = AddShortTimeExpensesMoney(shortTimeExpenses);
            var longTimeExpensesMoney = AddLongTimeExpensesMoney(longTimeExpenses);
            return new Money(shortTimeExpensesMoney).AddAmount(longTimeExpensesMoney);
        }

        private Money AddLongTermIncomesMoney(IEnumerable<LongTermIncome> longTermIncomes)
        {
            var money = new Money(0, Currency.PLN);

            foreach (var lti in longTermIncomes)
            {
                money.AddAmount(lti.GetMoney());
            }

            return money;
        }
        private Money AddShortTermIncomesMoney(IEnumerable<ShortTermIncome> shortTermIncomes)
        {
            var money = new Money(0, Currency.PLN);

            foreach (var sti in shortTermIncomes)
            {
                money.AddAmount(sti.GetMoney());
            }

            return money;
        }
        private Money AddLongTimeExpensesMoney(IEnumerable<LongTermExpense> longTimeExpenses)
        {
            var money = new Money(0, Currency.PLN);

            foreach (var lti in longTimeExpenses)
            {
                money.AddAmount(lti.GetMoney());
            }

            return money;
        }
        private Money AddShortTimeExpensesMoney(IEnumerable<ShortTermExpense> shortTimeExpenses)
        {
            var money = new Money(0, Currency.PLN);

            foreach (var sti in shortTimeExpenses)
            {
                money.AddAmount(sti.GetMoney());
            }

            return money;
        }
    }
}
