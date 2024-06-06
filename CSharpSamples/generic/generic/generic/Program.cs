//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


//using generic.GenericClassAndMethod;

//FirstGeneric<int> genericMethod = new();

//genericMethod.concat(223, 444);

//FirstGeneric<string> genericMethodString = new();

//genericMethodString.concat("hello first", "hello last");

//FirstGeneric<Person> genericMethodPerson = new();

//genericMethodPerson.concat(new Person { FirstName= "ali",LastName="soly"},new Person {FirstName="mmd",LastName="generic" });

//var dictionaryDefault = genericMethod.TestForReturnDefault();

//Console.WriteLine(dictionaryDefault.ToString());


using generic.GenericClassAndMethod;

//var teahcer = new Teacher
//{
//    LastName = "استادی",
//    FirstName = "سارا",
//    Id = 1
//};

//var car = new Car
//{
//    Id = 2,
//    FirstName = "مرسدس",
//    LastName = "سی ال ای"
//};

//var printTeacher = new PrintPerson<Teacher>();

//var printCar = new PrintPerson<Car>();

//printTeacher.Print(teahcer);

//printCar.Print(car);


WithStaticMember<int>.Counter = 23;
WithStaticMember<string>.Counter = 22;
WithStaticMember<bool>.Counter = 24;

Console.WriteLine(WithStaticMember<int>.Counter);
Console.WriteLine(WithStaticMember<string>.Counter);
Console.WriteLine(WithStaticMember<bool>.Counter);
