namespace Task3
{
    public interface Product
    {
        string Description { get; }

        decimal GetPrice(Currency currency);
    }
}
