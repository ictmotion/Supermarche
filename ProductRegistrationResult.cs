namespace SuperMarche;

public class ProductRegistrationResult: IProductRegistrationResult
{
    public double TotalPrice { get; set; }

    public List<IProduct> ExtraProducts { get; set; }
    //..
}