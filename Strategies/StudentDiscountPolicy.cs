using SolidPrincipaleDemo.Interfaces;

namespace SolidPrincipaleDemo.Strategies
{
    public class StudentDiscountPolicy : IDiscountPolicy
    {
        public string Name => "Student";

        public bool CanApply(string customerType, decimal amount)
        {
            return customerType == "Student";
        }

        public decimal CalculateDiscount(decimal amount)
        {
            return amount * 0.15m;
        }
    }

}
