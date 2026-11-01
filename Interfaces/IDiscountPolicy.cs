namespace SolidPrincipaleDemo.Interfaces
{
    public interface IDiscountPolicy
    {
        string Name { get; }

        bool CanApply(string customerType, decimal amount);

        decimal CalculateDiscount(decimal amount);
    }

}
