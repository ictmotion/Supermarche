namespace SuperMarche;

public class ExtraProductScanner: IExtraProductScanner
{
    private List<Product> _productsYieldingExtraProduct;

    public ExtraProductScanner()
    {
        _productsYieldingExtraProduct = new List<Product>()
        {
            new Product() { Id = 99, Name = "X" }
        };
    }

    public bool ScanForEligibleExtraProduct(IProduct product)
    {
         return _productsYieldingExtraProduct.Select(x => x.Id).ToList().Contains(product.Id);
    }
}