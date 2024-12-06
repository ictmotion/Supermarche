namespace SuperMarche;

public class BlackFridayScanProductStrategy: IScanProductStrategy
{
    private readonly List<Product> _productsYieldingExtraProduct;
    private double DiscountFactor = 0.3; 
    
    public BlackFridayScanProductStrategy()
    {
        _productsYieldingExtraProduct = new List<Product>() { new Product() { Id = 99, Name = "X", Price = 1}};
    }
    
    public void ScanProduct(ScanProductSession scanProductSession, IProduct product)
    {
        //tous les produits -30%
        scanProductSession.Amount += product.Price * (1 - DiscountFactor);
    }
    
    /// <summary>
    /// l'utilisateur finit l'achat
    /// </summary>
    public ScanProductSession FinishBuy(ScanProductSession scanProductSession)
    {
        return scanProductSession;
    }
}