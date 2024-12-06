namespace SuperMarche;

public interface IProductRegistrationService
{
    void ScanProduct(IProduct product);
    ProductRegistrationResult FinishBuy();

}