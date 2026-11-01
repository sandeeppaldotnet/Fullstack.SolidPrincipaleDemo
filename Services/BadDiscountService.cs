namespace SolidPrincipaleDemo.Services
{
    public class BadDiscountService
    {
        public decimal CalculateDiscount(
            string customerType,
            decimal amount)
        {
            if (customerType == "Regular")
            {
                return 0;
            }
            else if (customerType == "Premium")
            {
                return amount * 0.10m;
            }
            else if (customerType == "Festival")
            {
                return amount * 0.20m;
            }
            else if (customerType == "Employee")
            {
                return amount * 0.30m;
            }
            else if (customerType == "VIP")
            {
                return amount * 0.50m;
            }
            else if (customerType == "Donate")
            {
                return amount * 0.60m;
            }
            return 0;
        }
    }

}
