namespace SuperMarche;

public class ScanProductService: IScanProductService
{
    private IScanProductStrategy _scanProductStrategy;
    private ScanProductSession _scanProductSession;
    
    public ScanProductService(IScanProductStrategy scanProductStrategy)
    {
        _scanProductStrategy = scanProductStrategy;
        _scanProductSession = new ScanProductSession();
    }
    
    /// <summary>
    /// setter le strategy en runtime
    /// </summary>
    /// <param name="scanProductStrategy"></param>
    public void SetStrategy(IScanProductStrategy scanProductStrategy)
    {
        _scanProductStrategy = scanProductStrategy;
    }

    public void InitScanProductSession()
    {
        _scanProductSession = new ScanProductSession();
    }
    
    /// <summary>
    /// l'utlisateur scan le produit
    /// </summary>
    /// <param name="product"></param>
    public void ScanProduct(IProduct product)
    {
        _scanProductStrategy.ScanProduct(_scanProductSession, product);
    }

    /// <summary>
    /// l'utilisateur finit l'achat
    /// </summary>
    public ScanProductSession FinishBuy()
    {
        return _scanProductStrategy.FinishBuy(_scanProductSession);
    }
}