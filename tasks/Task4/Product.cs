namespace Task4
{
    public interface Product
    {
        string Description { get; }

        decimal GetPrice(Currency currency);
    }
}
