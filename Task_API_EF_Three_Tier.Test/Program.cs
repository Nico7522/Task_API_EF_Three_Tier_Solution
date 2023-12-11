//// See https://aka.ms/new-console-template for more information
//using Task_API_EF_Three_Tier.DAL.Domain;

//Console.WriteLine("Hello, World!");

//using (DataContext dc = new DataContext())
//{
//    var list = dc.
//}
using Task_API_EF_Three_Tier.DAL.Domain;
using Task_API_EF_Three_Tier.DAL.Entities;

Console.WriteLine("cc");

using (DataContext dc = new DataContext())
{
    dc.People.Add(new PersonEntity()
    {
        FirstName = "ddefzfezf",
        LastName = "dsqd",
        
    });

    dc.SaveChanges();
}