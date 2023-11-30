﻿namespace InterestCalculator.Models
{
    public class CompoundInterestViewModel
    {
        public decimal Principal { get; set; }
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

        public void CalculateCompoundInterest()
        {
            TotalInterestGainList = new List<decimal>();
            TotalValuesList = new List<decimal>();
            CurrentInterestGainList = [0.00m];
            TotalInterestGainList.Add(0.00m);
            TotalValuesList.Add(Principal);
            currentAmount = Principal;
            if (ContributionsPerYear == 0) ContributionsPerYear = 1;
            NumberOfContributions = (int)NumberOfYears * ContributionsPerYear;
            decimal interestRate = 0m;
            if (Interest != 0) {interestRate = Interest / 100m / ContributionsPerYear; }
            for (int i = 0; i < NumberOfContributions; i++)
            {
                CurrentInterestGainList.Add(currentAmount * interestRate);
                currentAmount = currentAmount * (1 + interestRate);
                TotalInterestGainList.Add(CurrentInterestGainList[i + 1] + TotalInterestGainList[i]);
                currentAmount += AmountAddedEachPerContribution;
                TotalValuesList.Add(currentAmount);
            }
            currentAmount = Math.Round(TotalValuesList[TotalValuesList.Count - 1], 2);
            InterestGain = Math.Round(currentAmount - Principal, 2);
            if (NumberOfYears == 0)
            {
                currentAmount = Principal;
                InterestGain = 0m;
            }


        }
    }
}

