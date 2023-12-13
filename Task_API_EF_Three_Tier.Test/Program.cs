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

//int id = _taskRepository.Create(new TaskEntity()
//{
//    Title = "Faire les courses",
//    Description = "Acheter du pain et des pommes"
//});

//if (id > 0 ) Console.WriteLine(id);


#endregion

#region Update Task DAL

_taskRepository.Update(1, task);

#endregion