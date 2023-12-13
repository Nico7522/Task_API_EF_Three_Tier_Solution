//// See https://aka.ms/new-console-template for more information
//using Task_API_EF_Three_Tier.DAL.Domain;

//Console.WriteLine("Hello, World!");

//using (DataContext dc = new DataContext())
//{
//    var list = dc.
//}
using Task_API_EF_Three_Tier.DAL.Domain;
using Task_API_EF_Three_Tier.DAL.Entities;
using Task_API_EF_Three_Tier.DAL.Interfaces;
using Task_API_EF_Three_Tier.DAL.Services;

Console.WriteLine("cc");

ITaskRepository _taskRepository = new TaskRepository();
IPersonRepository _personRepository = new PersonService();
TaskEntity task = new TaskEntity()
{
    Title = "Faire les courses",
    Description = "Acheter du pain, des pommes, des éponges, une brosse à dents et de l'eau"
};
#region GetAll Tasks DAL

//var list =  _taskRepository.GetAll();

//foreach (var task in list)
//{
//    Console.WriteLine(task.Description);
//}
#endregion


#region GetById Task DAL

//var task =_taskRepository.GetById(1);

//Console.WriteLine(task.Title);

#endregion

#region Create Task DAL

//int id = await _taskRepository.Create(new TaskEntity()
//{
//    Title = "Allez au coiffeur",
//    Description = "Nouvelle coupe"
//});

//if (id > 0) Console.WriteLine(id);


#endregion

#region Update Task DAL

//_taskRepository.Update(1, task);

#endregion

#region Create Person DAL

//int id = await _personRepository.Create(new PersonEntity()
//{
//    FirstName = "Jane",
//    LastName = "Doe"
//});

//Console.WriteLine(id);

#endregion

#region GetAll Person DAL

//var list = await _personRepository.GetAll();

//foreach (var person in list)
//{
//    Console.WriteLine(person.FirstName);
//}

#endregion