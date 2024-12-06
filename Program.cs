// See https://aka.ms/new-console-template for more information
namespace SuperMarche;

class Program
{
    static void Main(string[] args)
    {
        var strategy = new NormalScanProductStrategy();
        var scanProductSessionContext = new ScanProductService(strategy);
        
        Console.WriteLine("Svp testez avec les tests unitaires");
    }
}