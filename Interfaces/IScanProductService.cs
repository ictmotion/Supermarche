namespace SuperMarche;

public interface IScanProductService
{
    public void SetStrategy(IScanProductStrategy scanProductStrategy);
    void ScanProduct(IProduct product);
    ScanProductSession FinishBuy();

}