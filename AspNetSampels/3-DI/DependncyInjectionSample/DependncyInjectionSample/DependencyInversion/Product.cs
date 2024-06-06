namespace DependncyInjectionSample.DependencyInversion
{
    public class Product
    {
       public void Handle()
        {
            IProductRepository repo = ProductRepositoryFactory.ProductRepo();

            repo.PrintProducts("hello");
        }
    }

    //هندل کننده  وابستگی ما به کلاس ریپازیتوری 
    public class ProductRepositoryFactory
    {
        public static IProductRepository ProductRepo() =>  new ProductRepository();        
    }

    //رابط ما که بین سطح بالا و پایین اپلیکیشن ما ارتباط برقرار می کند 
    // و باعث عدم وابستگی مستقیم بین آن ها می شود و صرفا تعریف امضای متد است
    public interface IProductRepository
    {
      void PrintProducts(string name);

      int GetProductsCount();
    }
    //پیاده سازی رابط ما در کلاس ریپازیتوری
    public class ProductRepository : IProductRepository
    {
        public int GetProductsCount() => 23;

        public void PrintProducts(string name) => Console.WriteLine(name);
    }
}
