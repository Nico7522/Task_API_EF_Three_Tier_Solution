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