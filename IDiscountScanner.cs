namespace SuperMarche;

public interface IDiscountScanner
{
    double ScanForDiscount(List<IProduct> productsScanned, IProduct product);
}