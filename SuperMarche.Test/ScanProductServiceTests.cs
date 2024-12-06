
namespace SuperMarche.Test;

public class ScanProductServiceTests
{
    [Fact]
    public void ScanProducts_SimplePriceCalculation_Success()
    {
        var product1 = new Product() { Id = 1, Name = "Chocolat", Price = 1.6 };
        var product2 = new Product() { Id = 1, Name = "Baguette", Price = 1.9 };
        var products = new List<Product>() {product1, product2};

        var normalStrategy = new NormalScanProductStrategy();
        var productRegistrationService = new ScanProductService(normalStrategy);
        
        foreach (var product in products)
        {
            productRegistrationService.ScanProduct(product);    
        }
        
        var result = productRegistrationService.FinishBuy();
        
        Assert.Equal(3.5, result.AmountWithDiscount);
    }
    
    [Fact]
    public void ScanProducts_ExtraProduct_Success()
    {
        var product1 = new Product() { Id = 1, Name = "Chocolat", Price = 1.6 };
        var product2 = new Product() { Id = 99, Name = "X", Price = 1 };
        var products = new List<Product>() {product1, product2};

        var normalStrategy = new NormalScanProductStrategy();
        var scanProductService = new ScanProductService(normalStrategy);
        
        foreach (var product in products)
        {
            scanProductService.ScanProduct(product);    
        }
        
        var result = scanProductService.FinishBuy();
        
        Assert.Contains(product2, result.ExtraProducts);
    }
    
    [Fact]
    public void ScanProducts_Discount_Success()
    {
        var product1 = new Product() { Id = 1, Name = "Chocolat", Price = 1.6 };
        var products = new List<Product>() {product1, product1, product1, product1, product1, product1, product1, product1, product1, product1};
        
        var normalStrategy = new NormalScanProductStrategy();
        var scanProductService = new ScanProductService(normalStrategy);
        
        foreach (var product in products)
        {
            scanProductService.ScanProduct(product);    
        }
        
        var result = scanProductService.FinishBuy();
        
        //attend 16 - 1 = 15
        Assert.True(Math.Abs(result.AmountWithDiscount - 15) < 0.0000001);
    }
    
    
    [Fact]
    public void ScanProducts_StrategyBlackFriday_Success()
    {
        var product1 = new Product() { Id = 1, Name = "Chocolat", Price = 1.6 };
        var product2 = new Product() { Id = 99, Name = "X", Price = 1 };
        var product3 = new Product() { Id = 7, Name = "Macaron", Price = 5 };
        var product4 = new Product() { Id = 7, Name = "Journal", Price = 2 };
        
        var products = new List<IProduct>(){product1,product2,product3,product4};

        var blackFridayStrategy = new BlackFridayScanProductStrategy();
        var scanProductService = new ScanProductService(blackFridayStrategy);
        
        foreach (var product in products)
        {
            scanProductService.ScanProduct(product);    
        }
        
        var result = scanProductService.FinishBuy();
        
        // reduction 30%
        Assert.True(Math.Abs(result.AmountWithDiscount - 6.72) < 0.0000001);
    }
    
    /// <summary>
    /// Changement strategy 'on the fly'
    /// </summary>
    [Fact]
    public void ScanProduct_ChangeStrategy_Success()
    {
        var product1 = new Product() { Id = 1, Name = "Chocolat", Price = 1.6 };
        var product2 = new Product() { Id = 99, Name = "X", Price = 1 };

        var normalStrategy = new NormalScanProductStrategy();
        var blackFridayStrategy = new BlackFridayScanProductStrategy();

        var scanProductService = new ScanProductService(normalStrategy);
     
        scanProductService.ScanProduct(product1);
        scanProductService.SetStrategy(blackFridayStrategy);
        scanProductService.ScanProduct(product2);
        
        var result = scanProductService.FinishBuy();
        
        // reduction 30%
        Assert.True(Math.Abs(result.AmountWithDiscount - 2.3) < 0.0000001);
    }
}