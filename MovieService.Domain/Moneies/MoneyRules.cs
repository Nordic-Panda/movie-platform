using MovieService.Domain.Common.Exceptions;

namespace MovieService.Domain.Moneies
{
    public class MoneyRules
    {
        public const int BudgetMinValue = 0;

        public static void ValidateBudgetAmount(decimal amount)
        {
            if (amount < BudgetMinValue)
                throw new DomainException(
                    MoneyErrors.NegativeAmountCode,
                    MoneyErrors.NegativeAmountMessage
                );
        }
    }
}
