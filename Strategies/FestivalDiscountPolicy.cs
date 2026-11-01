using SolidPrincipaleDemo.Interfaces;

namespace SolidPrincipaleDemo.Strategies
{
    public class FestivalDiscountPolicy : IDiscountPolicy
    {
        public string Name => "Festival";

        public bool CanApply(string customerType, decimal amount)
        {
            return customerType == "Festival";
        }

        public decimal CalculateDiscount(decimal amount)
        {
            return amount * 0.20m;
        }
    }

}
