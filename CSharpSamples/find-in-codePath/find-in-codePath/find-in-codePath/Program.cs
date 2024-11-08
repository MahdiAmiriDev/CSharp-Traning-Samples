


using find_in_codePath;


    AppDbContext dbContext = new AppDbContext();

    var query = dbContext.MyProperty.AsQueryable();

    string myCompanyId = "2121";    

    var result = query.Where(x => x.CodePath.Contains(myCompanyId)).FirstOrDefault();

    Console.WriteLine(result);

    Console.ReadLine();
