namespace InterestCalculator.Models
{
    public class SimpleInterestViewModel
    {
        public decimal Principal { get; set; }
        public int NumberOfInvestmentYears { get; set; }
        public decimal AmountAddedEachMonth { get; set; }

        public decimal InterestGain { get; set; }

        public decimal FinalValue { get; set; }


        public decimal InterestRate { get; set; }
        public SimpleInterestViewModel()
        {
            
        }
        public decimal SimpleInterestCalculation()
        {
            decimal valueToReturn = Principal * NumberOfInvestmentYears * (1.0m + (InterestRate / 100m));
            InterestGain = valueToReturn - Principal;
            FinalValue = valueToReturn;
            return valueToReturn;

        }

    }
}
