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

         
           /* Student student = new Student()
            {

                Id = Guid.Parse("95d88143-6ca6-442f-8ed8-5c6c43ec47c4"),
                Name = "Test",
                LastName = "Test",
                Email = "Test",
                MiddeName = "Test",
            };

            await dataBase.Update(student);*/


            //Guid Id = obj.Id;


            //obj.Name = "Johnny";
            //await dataBase.Update(obj);

            // var result = await dataBase.AddAsync(new Student()
            // {
            //    Name = "Kamron",
            //    BirthDate = DateTime.Now,
            //    Email = "Kamron2023@gmail.com",
            //    Gender = Gender.Male,
            //    Id = Guid.NewGuid(),
            //    LastName = "Zokirovich",
            //    MiddeName = "Bobur o'g'li",
            //    PhoneNumber = "1234567890",
            // });

            //  Console.WriteLine(result);

        }
    }
}