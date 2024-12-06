namespace SuperMarche;

public interface IProduct
{
    public long Id { get; set; }
    string Name { get; set; }
    double Price { get; set; }
}