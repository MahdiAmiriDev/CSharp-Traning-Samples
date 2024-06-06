using Sample.Domain;

Person mahdi = new()
{
    Age = 24,
    FirstName = "mahdi",
    LastName = "javad"
};

PersonPrinter personPrinter = new PersonPrinter(mahdi);

personPrinter.print();

personPrinter.PrintAge();