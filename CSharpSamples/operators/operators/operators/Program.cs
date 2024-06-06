//----------compound

//int a = 1, b = 2, c = 0;

//c = a + b;
//a += b;

//Console.WriteLine(a++);
//Console.WriteLine(++a);

//-----------------Conditional expression---------

//var result = (a == b) ? "true" : "false"; 

//Console.WriteLine(result);

//---------------checked and Unchked----------

//byte b = byte.MaxValue;

//checked
//{
//    b += 1;
//    Console.WriteLine(b);
//}

//b = checked(b+=1);

//------------------------ is --- as -------


//using operators;

//CheckAs(34);

//CheckIs(true);

// void CheckAs(object id)
//{
//    var t = id.GetType();

//    var t2 = id as Person;

//    Console.WriteLine(t2.Id);
//}


//void CheckIs(object a)
//{
//    if (a is true) Console.WriteLine("true");
//    else Console.WriteLine("false");    
//}

//------------------------------sizeof

//int a = 34343;
//var c = sizeof(int);
//Console.WriteLine(c);

//-------------------------- typeof

//using operators;

//var type = typeof(Person);

//Console.WriteLine(type.FullName);
//Console.WriteLine(type.Name);
//Console.WriteLine(type.AssemblyQualifiedName);
//Console.WriteLine(type.Assembly.ToString());
//Console.WriteLine(type.GetProperties());


//------------------------------------------ naemof

//using operators;

//void testMehod() => Console.WriteLine("test");

//Console.WriteLine(nameof(Person));
//Console.WriteLine(nameof(testMehod));

//----------------------------------------------- using null

//int? a = 23;
//int? b = null;

//var res1 = a ?? b;
//var res2 = b ?? 0;
//Console.WriteLine(b?.ToString());

//-------------------------------------------------------

using operators;
using static operators.OperatorOverload;

var binaryOperator = new BinaryOperator();

binaryOperator.And();
binaryOperator.Shift();
binaryOperator.Xor();
binaryOperator.Or();
binaryOperator.Reverse();

//-------------------------------------------Type safety


//----------------------Operator Overloading --------------
Money m1 = new(20);
Money m2 = new(40);

Money res = m1 + m2;

Console.WriteLine(res.Value);

//--------------------------------------------------------

//------------------------مقایسه اشیا 

//--------------------------------------------convert types

