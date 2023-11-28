namespace InterestCalculator.Models
{
    public class CompoundInterestModelYear
    {
        public decimal Principal { get; set; }
        public int NumberOfInvestmentYears { get; set; }
        public decimal AmountAddedEachMonth { get; set; }
        public decimal Interest {  get; set; }

        public decimal InterestGain;

        public bool InvestAtStartOfMonth;
        public bool DisplayMonthly;

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
        public decimal SimplenterestCalculationTotal()
        {
            decimal valueToReturn = Principal * NumberOfInvestmentYears * (Interest / 100m);      
            InterestGain = valueToReturn;
            return valueToReturn;
        }
    }
}
