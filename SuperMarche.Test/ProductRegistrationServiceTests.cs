
namespace SuperMarche.Test;

public class ProductRegistrationServiceTests
{
    [Fact]
    public void Register_SimplePriceCalculation_Success()
    {
        var product1 = new Product() { Id = 1, Name = "Chocolat", Price = 1.6 };
        var product2 = new Product() { Id = 1, Name = "Baguette", Price = 1.9 };
        var products = new List<Product>() {product1, product2};

        var productRegistrationService = new ProductRegistrationService(new ExtraProductScanner(), new DiscountScanner());

        foreach (var product in products)
        {
            productRegistrationService.ScanProduct(product);    
        }
        
        var result = productRegistrationService.FinishBuy();
        
        Assert.Equal(3.5, result.TotalPrice);
    }
    
    [Fact]
    public void Registration_SimplePriceCalculation_Success()
    {
        var product1 = new Product() { Id = 1, Name = "Chocolat", Price = 1.6 };
        var product2 = new Product() { Id = 1, Name = "Baguette", Price = 1.9 };
        var products = new List<Product>() {product1, product2};

        var productRegistrationService = new ProductRegistrationService(new ExtraProductScanner(), new DiscountScanner());

        foreach (var product in products)
        {
            productRegistrationService.ScanProduct(product);    
        }
        
        var result = productRegistrationService.FinishBuy();
        
        Assert.Equal(3.5, result.TotalPrice);
    }
    
    
    [Fact]
    public void Registration_ExtraProduct_Success()
    {
        var product1 = new Product() { Id = 1, Name = "Chocolat", Price = 1.6 };
        var product2 = new Product() { Id = 99, Name = "X", Price = 1.9 };
        var products = new List<Product>() {product1, product2};

        var productRegistrationService = new ProductRegistrationService(new ExtraProductScanner(), new DiscountScanner());

        foreach (var product in products)
        {
            productRegistrationService.ScanProduct(product);    
        }
        
        var result = productRegistrationService.FinishBuy();
        
        Assert.True(result.ExtraProducts.Contains(product2));
    }
    
    [Fact]
    public void Registration_Discount_Success()
    {
        var product1 = new Product() { Id = 1, Name = "Chocolat", Price = 1 };
        var products = new List<IProduct>(){product1,product1,product1,product1,product1,product1,product1,product1,product1, product1};
        
        var productRegistrationService = new ProductRegistrationService(new ExtraProductScanner(), new DiscountScanner());

        foreach (var product in products)
        {
            productRegistrationService.ScanProduct(product);    
        }
        
        var result = productRegistrationService.FinishBuy();
        
        Assert.Equal(9, result.TotalPrice);
    }
    
}