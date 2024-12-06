namespace SuperMarche;

public class ScanProductSession
{
    public ScanProductSession()
    {
        ScannedProducts = new List<IProduct>();
        ExtraProducts = new List<IProduct>();
    }
    public double Amount { get; set; }
    public double AmountWithDiscount => Amount - IncludedDiscount;
    public List<IProduct> ScannedProducts { get; set; }
    public List<IProduct> ExtraProducts { get; set; }
    public double IncludedDiscount { get; set; }
    
}
