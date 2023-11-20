using Crm.Website.Models;
using DAL.Data_Storage.Classes;
using DAL.Data_Storage.Repository;

namespace Testter
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            CrmDbContext db = new CrmDbContext();

            CrmRepository<Student> dataBase = new CrmRepository<Student>(db);

            /*
                        Student student = new Student()
                        {

                            Id = Guid.Parse("95d88143-6ca6-442f-8ed8-5c6c43ec47c4"),
                            Name = "new test",
                            LastName = "new test",
                            Email = "new test",
                            MiddleName =  "new test",
                        };

                        await dataBase.Update(student);*/
            //Student student = await dataBase.GetAsync(p => p.Id  == Guid.Parse("95d88143-6ca6-442f-8ed8-5c6c43ec47c4"));
            // dataBase.Delete(student) ;
            var all = await dataBase.GetAllStudents();

            foreach (var student in all)
            {
                Console.WriteLine($"{student.Name} - {student.Id}");
            }



        }
    }
}