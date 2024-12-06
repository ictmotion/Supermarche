namespace SuperMarche;

public class NormalScanProductStrategy: IScanProductStrategy
{
    private readonly List<Product> _productsYieldingExtraProduct;
    
    public NormalScanProductStrategy()
    {
        _productsYieldingExtraProduct = new List<Product>() { new Product() { Id = 99, Name = "X", Price = 1}};
    }
    
    public void ScanProduct(ScanProductSession scanProductSession, IProduct product)
    {
        scanProductSession.Amount += product.Price;
        
        bool yieldsExtraProduct = _productsYieldingExtraProduct.Select(x => x.Id).ToList().Contains(product.Id);
        if (yieldsExtraProduct)
        {
            scanProductSession.ExtraProducts.Add(product);
        }
        
        scanProductSession.ScannedProducts.Add(product);
        var numberOfScannedProductss = scanProductSession.ScannedProducts.Select(p => p.Id == product.Id).Count();
        
        if (numberOfScannedProductss >= 10) scanProductSession.IncludedDiscount += 1;
    }
    
    /// <summary>
    /// l'utilisateur finit l'achat
    /// </summary>
    public ScanProductSession FinishBuy(ScanProductSession scanProductSession)
    {
        return scanProductSession;
    }
}