using SolidPrincipaleDemo.Interfaces;

namespace SolidPrincipaleDemo.Strategies
{
    public class EmployeeDiscountPolicy : IDiscountPolicy
    {
        public string Name => "Employee";

        public bool CanApply(string customerType, decimal amount)
        {
            return customerType == "Employee";
        }

        public decimal CalculateDiscount(decimal amount)
        {
            return amount * 0.30m;
        }
    }

}
