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
    dc.Tasks.Add(new TaskEntity()
    {
        
        Title = "Nettoyer la maison",
        Description = "Nettoyer la cuisine, le salon et la salle de bain"
    });

    int EntriesNumber = dc.SaveChanges();

    if (EntriesNumber > 0)
        Console.WriteLine("OK");
}