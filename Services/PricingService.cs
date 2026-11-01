using SolidPrincipaleDemo.Interfaces;

namespace SolidPrincipaleDemo.Services
{
    public class PricingService
    {
        private readonly IEnumerable<IDiscountPolicy> _discountPolicies;

        public PricingService(
            IEnumerable<IDiscountPolicy> discountPolicies)
        {
            _discountPolicies = discountPolicies;
        }

        public decimal CalculateDiscount(
            string customerType,
            decimal amount)
        {
            var policy = _discountPolicies.FirstOrDefault(
                x => x.CanApply(customerType, amount));

            if (policy is null)
            {
                return 0;
            }

            return policy.CalculateDiscount(amount);
        }
    }

}
