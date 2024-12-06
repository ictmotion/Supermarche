namespace SuperMarche;

public class Product: IProduct
{
    public long Id { get; set; }
    
    public string Name { get; set; }
    public double Price { get; set; }
    
}