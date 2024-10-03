

using System.Linq;
using System.Linq.Expressions;

public class TimCourySample
{
    public delegate void PrintTotalItemsValue(decimal totalItems);
    private List<ProductModel> Items { get; set; }
    public TimCourySample(List<ProductModel> items)
    {
        Items = items;
    }
    public decimal CalculateTottalDiscoungWithDelegate(PrintTotalItemsValue printTotalValue)
    {
        var totalPrice = Items.Sum(x => x.Price);

        printTotalValue(totalPrice);

        if (totalPrice > 10)
        {
            return totalPrice * 0.80m;

        }
        else if (totalPrice > 20)
        {
            return totalPrice * 0.85m;
        }
        else if (totalPrice > 30)
        {
            return totalPrice * 0.90m;
        }
        else
        {
            return totalPrice;
        }
    }

    public decimal CalculateTottalDiscoungWithFunc(PrintTotalItemsValue printTotalValue,
        Func<List<ProductModel>, decimal, decimal> func)
    {
        var totalPrice = Items.Sum(x => x.Price);

        printTotalValue(totalPrice);

        return func(Items, totalPrice);
    }

    public decimal CalculateTottalDiscoungWithFuncAndAction(PrintTotalItemsValue printTotalValue,
    Func<List<ProductModel>, decimal, decimal> func, Action<string> finisherMessage)
    {
        var totalPrice = Items.Sum(x => x.Price);

        printTotalValue(totalPrice);

        finisherMessage($"Im Done Isreal !!! , the value is  {func(Items, totalPrice)}");

        return func(Items, totalPrice);
    }


    public bool CheckIsUserBuyAnySoda(Func<ProductModel, bool> checkBuySoda)
    {
        return Items.Any(checkBuySoda);
    }


    //using Linq or Iqueryable with Expression filter !!
    private Expression<Func<ProductModel, bool>> CheckIsActive = (psp) => (psp.Name == "soda");

    public void CheckName()
    {
        Items.AsQueryable().Where(CheckIsActive);
    }


    //Predicate sample in C#
    public void TestPredicate(Predicate<int> predicate)
    {
        List<int> intList = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        var res = intList.FindAll(predicate);

        foreach (int i in res) 
        {
            Console.WriteLine("is even {0}",res);
        }
    }

    public class ProductModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}