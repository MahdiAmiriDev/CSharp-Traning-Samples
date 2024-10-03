

using DelegateSample;
using System.Linq.Expressions;
using System.Threading.Channels;
using static DelegateSample.TestDelegate;
using static TimCourySample;


//----------------------First youTube video-------------------
PrintSomeTextInConsole DoSomeThing = () =>
{
    Console.WriteLine("I want to show You power of delegate");
};

TestDelegate testDelegate = new(DoSomeThing);

testDelegate.CallSendedDelegate();

//-----------------------------------Indian sample of delegate -------------------------------


SecondDelegateSample secondDelegateSample = new();

secondDelegateSample.InvokeDelegate(12);

secondDelegateSample.CallTestGenericDelegate();


secondDelegateSample.PrintWithAction(x => x = "hello baby", "hi");

Predicate<string> Check = x => x.Length > 0;
secondDelegateSample.PridicateTest(Check, "foot");

secondDelegateSample.ExpressionTreeSample();

void CallMeAdCallBack(int i)
{
    Console.WriteLine(i);
}

void CallMeAdCallBackVoid()
{
    Console.WriteLine("you call me");
}

secondDelegateSample.CallBackDelegate(CallMeAdCallBack);
secondDelegateSample.CallBackDelegateVoid(CallMeAdCallBackVoid);


//----------------- Tim coury Sample -------------------------

var items = new List<ProductModel>
{
    new ProductModel(){ Name="soap", Price=2m},   
    new ProductModel(){ Name="rice", Price=4m},
    new ProductModel(){ Name="shirt", Price=5m},
    new ProductModel(){ Name="sodaudfg", Price=3m},
    new ProductModel(){ Name="sodaudfg", Price=3m},
    new ProductModel(){ Name="sodaudfg", Price=3m},
    new ProductModel(){ Name="sodausdgf", Price=3m},
    new ProductModel(){ Name="sodauert", Price=3m},
    new ProductModel(){ Name="soda", Price=3m},
    new ProductModel(){ Name="sodausdfg", Price=3m},
    new ProductModel(){ Name="sodausdfg", Price=3m},
    new ProductModel(){ Name="sodausfdhg", Price=3m},
    new ProductModel(){ Name="sodauert", Price=3m},
};

TimCourySample timCourySample = new(items);

void PrintTotalInConsole(decimal total)
{
    Console.WriteLine($"the total price is {total}");
}

var discountValue = timCourySample.CalculateTottalDiscoungWithDelegate(PrintTotalInConsole);

Console.WriteLine("this is total discount {0}", discountValue);

decimal FuncSignutreMehtod(List<ProductModel> products, decimal totalPrice)
{
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

var result = timCourySample.CalculateTottalDiscoungWithFunc(PrintTotalInConsole, FuncSignutreMehtod);

Console.WriteLine("this is from func return value {0}", result);


void ShowSomethingToMe(string value)
{
    Console.WriteLine(value);
}

timCourySample.CalculateTottalDiscoungWithFuncAndAction(PrintTotalInConsole, FuncSignutreMehtod, ShowSomethingToMe);


Console.WriteLine("\n");

//Anonymous method to send in delegates !!!
var total = timCourySample.CalculateTottalDiscoungWithFuncAndAction(
    (subTotal) => Console.WriteLine("subtotal 2 is {0}", subTotal),
    (items, subTotal) =>
    {
        if (items.Count > 3)
        {
            return subTotal * 0.5m;
        }
        else
        {
            return subTotal;
        }
    }, (message) => Console.WriteLine("the message is {0}", message));

Console.WriteLine("the total is {0}",total);


//----------------------------Predicate Sample ------------
Console.WriteLine("\n");
Console.WriteLine("\n");
Console.WriteLine("\n");
var sodaBuyResult = timCourySample.CheckIsUserBuyAnySoda((item) =>
{
    Console.WriteLine(item.Name);

    if (item.Name == "soda")
        return true;

    return false;
});

Console.WriteLine("user buy soda = {0}",sodaBuyResult);


Predicate<int> evenPredicate = (x) => x % 2 == 0;   

timCourySample.TestPredicate(evenPredicate);













