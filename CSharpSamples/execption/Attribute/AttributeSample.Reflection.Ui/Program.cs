using Sample.Domain;

Person person = new();

Type myType = typeof(Person);

var method = myType.GetMethods();
var isSomething = myType.IsEnum;

Type teachertype = Type.GetType("AttributeSample.Reflection.Ui.Teacher",true,true);
Console.WriteLine(teachertype.FullName);

Console.ReadKey();
