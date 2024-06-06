


using Delegate;
using static Delegate.MethodNamePrinter;

Person person = new()
{
    FirstName = "ali",
    LastName = "salami"
};

/// <summary>
/// اساین کردن متد به دلیگیت
/// </summary>
PersonToString myDelegate = PersonFullName.GetPersonFullName;

PersonPrinter personPrinter = new();

personPrinter.Print(myDelegate, person);

//----------------------------------------------Func<T> , Action<T>

/// <summary>
/// دلیگیت های ثابت
/// </summary>
Func<int, int, int, string> myFuncDelegate = FuncDelegate.GetFullNameTest;
myFuncDelegate(2, 3, 5);

//-------------- mutlit delegate ---------------------

MethodNamePrinter methodNamePrinter = new();

WriteMethodName multiDelegate = methodNamePrinter.MethodName1;
multiDelegate += methodNamePrinter.MethodName2;
multiDelegate += methodNamePrinter.MethodName3;
multiDelegate();

//------------- Anonymous method -----------------
AnonemousMethod anonemousMethod = new();
anonemousMethod.WriteAnonymousMethod();

//----------------- Lamda Ex ---------------

LamdaMethod lamdaMethod = new();
lamdaMethod.TestLamda();

