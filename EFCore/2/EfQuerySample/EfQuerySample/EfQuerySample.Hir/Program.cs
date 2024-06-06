using EfQuerySample.Hir;
using Microsoft.EntityFrameworkCore;

var contex = new EmpContext();


//var employe = contex.Employes.Include(x => x.Children).Where(c => !c.ParentId.HasValue).ToList();

//var types = contex.Type01s.Include(x => x.Type02).ThenInclude(x => x.Type03).ToList();

//var types = contex.Type01s.AsSplitQuery().Include(x => x.Type02).ThenInclude(x => x.Type03).ToList();

var person = contex.People.Include(x => x.Adresses).ToList();

Console.ReadLine();