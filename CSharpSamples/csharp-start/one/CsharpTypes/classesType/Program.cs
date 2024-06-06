using classesType;

var ex = new Teacher()
{
    FirstName = "ali",
    LastName = "amiri"
};
Console.WriteLine(ex.GetFullName());

//----------------------------------------------------------------------
//استفاده از نوع ناشناس
Anonymoustype anonymous = new();
Console.WriteLine(anonymous.AnonymousType());