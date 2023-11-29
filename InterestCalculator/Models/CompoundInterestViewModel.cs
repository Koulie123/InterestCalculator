namespace InterestCalculator.Models
{
    public class CompoundInterestViewModel
    {
        public decimal Principal { get; set; }
        public int NumberOfInvestmentYears { get; set; }
        public decimal AmountAddedEachYear { get; set; }
        public decimal Interest { get; set; }

        public decimal InterestGain { get; set;}
        public decimal currentAmount { get; set; }

        public bool InvestAtStartOfMonth;
        public bool DisplayMonthly;
        public CompoundInterestViewModel()
        {
        }
        public List<decimal> CompoundInterestCalculationYear(decimal principal, int numberOfInvestmentYears, decimal amountAddedEachMonth, decimal interest)
        {
            decimal Principal = principal;
            decimal AmountAddedEachMonth = amountAddedEachMonth;
            decimal Interest = interest;
            decimal InterestDecimal = 1m + (Interest / 100m);
            int NumberOfInvestmentYears = numberOfInvestmentYears;
            decimal CurrentValue = Principal;
            List<decimal> listToReturn = new List<decimal>();
            listToReturn.Add(principal);
            for (int i = 0; i < numberOfInvestmentYears; i++)
            {
                CurrentValue = CurrentValue * InterestDecimal;
                listToReturn.Add(CurrentValue);
            }
            return listToReturn;
        }
        public void CalculateCompoundInterest(decimal principal, decimal amountAddedEachYear, decimal interest, int time)
        {
            currentAmount = principal;
            decimal interestRate = interest / 100m;
            for (int i = 0; i < time; i++)
            {
                currentAmount = currentAmount * (1.0m + interestRate);
                currentAmount += amountAddedEachYear;
            }
            currentAmount = Math.Round(currentAmount, 2);
            InterestGain = Math.Round(currentAmount, 2);

        }
    }
}

