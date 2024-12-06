namespace SuperMarche;

public class DiscountScanner: IDiscountScanner
{
    public double ScanForDiscount(List<IProduct> productsScanned, IProduct product)
    {
        var number = productsScanned.Select(p => product.Id == product.Id).Count();
        if (number >= 10) return 1;
        return 0;
    }
}