namespace SuperMarche;

public class ProductRegistrationService: IProductRegistrationService
{
    private readonly IExtraProductScanner _extraProductScanner;
    private readonly IDiscountScanner _discountScanner;

    private double _totalPrice;
    private List<IProduct> _productsScanned;
    private List<IProduct> _extraProducts;
    
    //injection des dépendences
    public ProductRegistrationService(IExtraProductScanner extraProductScanner, IDiscountScanner discountScanner)
    {
        _extraProductScanner = extraProductScanner;
        _discountScanner = discountScanner;

        _productsScanned = new List<IProduct>();
        _extraProducts = new List<IProduct>();
    }
 
    /// <summary>
    /// l'utlisateur scan le produit
    /// </summary>
    /// <param name="product"></param>
    public void ScanProduct(IProduct product)
    {
        _totalPrice += product.Price;
        if (_extraProductScanner.ScanForEligibleExtraProduct(product))
        {
            _extraProducts.Add(product);
        }
        _productsScanned.Add(product);
        
        var discount = _discountScanner.ScanForDiscount(_productsScanned, product);
        _totalPrice -= discount;
        
        
    }

    /// <summary>
    /// l'utilisateur finit l'achat
    /// </summary>
    public ProductRegistrationResult FinishBuy()
    {
        var productRegistrationResult = new ProductRegistrationResult();
        productRegistrationResult.TotalPrice = _totalPrice;
        productRegistrationResult.ExtraProducts = _extraProducts;
        return productRegistrationResult;
    }
}