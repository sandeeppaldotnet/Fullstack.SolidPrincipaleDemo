using SolidPrincipaleDemo.Interfaces;

namespace SolidPrincipaleDemo.Strategies
{
    public class PremiumDiscountPolicy : IDiscountPolicy
    {
        public string Name => "Premium";

        public bool CanApply(string customerType, decimal amount)
        {
            return customerType == "Premium";
        }

        public decimal CalculateDiscount(decimal amount)
        {
            return amount * 0.10m;
        }
    }
}
