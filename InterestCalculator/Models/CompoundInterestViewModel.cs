namespace InterestCalculator.Models
{
    public class CompoundInterestViewModel
    {
        public decimal Principal { get; set; }
        public int NumberOfInvestments { get; set; }
        public decimal AmountAddedEachPerContribution { get; set; }

        public int ContributionsPerYear { get; set; }
        public int NumberOfYears { get; set; }
        public int NumberOfContributions { get; set; }
        public decimal Interest { get; set; }
        
        public List<decimal> TotalValuesList { get; set; }
        public List<decimal> TotalInterestGainList { get; set; }
        public List<decimal> CurrentInterestGainList { get; set; }

        public decimal InterestGain { get; set; }
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
        public void CalculateCompoundInterest()
        {
            TotalInterestGainList = new List<decimal>();
            TotalValuesList = new List<decimal>();
            CurrentInterestGainList = new List<decimal>();
            TotalInterestGainList.Add(0.00m);
            TotalValuesList.Add(Principal);
            currentAmount = Principal;
            decimal interestRate = Interest / 100m / NumberOfContributions;
            NumberOfContributions = (int)NumberOfYears * ContributionsPerYear;
            for (int i = 0; i < NumberOfContributions; i++)
            {
                currentAmount = currentAmount * interestRate;
                InterestGain = currentAmount - TotalValuesList[i];
                CurrentInterestGainList.Add(InterestGain);
                TotalInterestGainList.Add(CurrentInterestGainList[i + 1] + TotalInterestGainList[i]);
                currentAmount += AmountAddedEachPerContribution;
            }
            InterestGain = Math.Round(currentAmount - Principal, 2);
            currentAmount = Math.Round(currentAmount, 2);


        }
    }
}

