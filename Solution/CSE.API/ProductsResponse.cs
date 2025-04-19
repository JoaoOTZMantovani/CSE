namespace CSE.API;

public class ProductsResponse
{
    public bool Ok { get; set; }
    public string Message { get; set; } = string.Empty;
    public List<Product> Products { get; set; } = new List<Product>();
}

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public decimal ProfitValue { get; set; }
    public decimal MaterialValue { get; set; }
    public decimal ProductionValue { get; set; }
}