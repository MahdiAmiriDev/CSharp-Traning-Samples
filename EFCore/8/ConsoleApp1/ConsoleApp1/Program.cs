
using ConsoleApp1;
using ConsoleApp1.DAL;

MyDbContext dbContext = new MyDbContext();

SamleSource sampleSource = new(dbContext);

//sampleSource.UpadteTeacherValues(1, "mahdi edited", "amiri edited");

//sampleSource.FromSqlRawSample();

sampleSource.addStudenWithOutAudiDate();

Console.ReadKey();