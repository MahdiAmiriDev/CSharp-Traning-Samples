using Records;

PersonRecord pr = new()
{
    FirstName = "ali",
    LastName = "hasani"
};

PersonRecord pr2 = new()
{
    FirstName = "ali",
    LastName = "hasani"
};

// کپی کردن داده ها با یک تغییر کوچیگ
PersonRecord p3 = pr2 with { FirstName = "larom" };

Console.WriteLine(p3);