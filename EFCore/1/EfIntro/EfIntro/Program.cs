using EfIntro.Models;


Repository repository = new Repository();
repository.DeletePersonById(2);
repository.PrintPepole();
Console.ReadKey();