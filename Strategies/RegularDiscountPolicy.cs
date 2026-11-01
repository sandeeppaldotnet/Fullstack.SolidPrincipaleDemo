using SolidPrincipaleDemo.Interfaces;

namespace SolidPrincipaleDemo.Strategies
{
    public class RegularDiscountPolicy : IDiscountPolicy
    {
        public string Name => "Regular";

        public bool CanApply(string customerType, decimal amount)
        {
            return customerType == "Regular";
        }

        public decimal CalculateDiscount(decimal amount)
        {
            return 0;
        }
    }

}
