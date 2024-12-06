namespace SuperMarche;

public interface IScanProductStrategy
{
    void ScanProduct(ScanProductSession scanProductSession, IProduct product);
    ScanProductSession FinishBuy(ScanProductSession scanProductSession);
    
}