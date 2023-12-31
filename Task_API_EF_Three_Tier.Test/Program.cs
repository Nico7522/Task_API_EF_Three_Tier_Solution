﻿using IPersonRepositoryBLL = Task_API_EF_Three_Tier.BLL.Interfaces;
using PersonServiceBLL = Task_API_EF_Three_Tier.BLL.Services;
using IPersonRepositoryDAL = Task_API_EF_Three_Tier.DAL.Interfaces;
using PersonServiceDAL = Task_API_EF_Three_Tier.DAL.Services;
using Task_API_EF_Three_Tier.DAL.Entities;
using Task_API_EF_Three_Tier.DAL.Domain;
using ITaskRepositoryBLL = Task_API_EF_Three_Tier.BLL.Interfaces;
using TaskServiceBLL = Task_API_EF_Three_Tier.BLL.Services;
using TaskServiceDAL = Task_API_EF_Three_Tier.DAL.Services;

using ITaskRepositoryDAL = Task_API_EF_Three_Tier.DAL.Interfaces;

Console.WriteLine("cc");


IPersonRepositoryDAL.IPersonRepository  _personRepositoryDAL = new PersonServiceDAL.PersonService();
ITaskRepositoryDAL.ITaskRepository _taskRepositoryDAL = new TaskServiceDAL.TaskRepository();
ITaskRepositoryBLL.ITaskRepository _taskRepositoryBLL = new TaskServiceBLL.TaskService(_taskRepositoryDAL, _personRepositoryDAL);
IPersonRepositoryBLL.IPersonRepository _personRepositoryBLL = new PersonServiceBLL.PersonService(_personRepositoryDAL, _taskRepositoryDAL);

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

#region GetById Person DAL

//var person = await _personRepository.GetById(2);

//Console.WriteLine(person?.FirstName);

#endregion

#region Update Person DAL

//bool isUpated = await _personRepository.Update(1, new PersonEntity() { FirstName = "Jeanmi", LastName = "Chel" });

//if (isUpated) Console.WriteLine("ok");
#endregion

#region Delete Person BLL
//bool isDeleted = await _personRepositoryBLL.Delete(46);

//Console.WriteLine(isDeleted);

#endregion

#region GetPersonByTask BLL

//IEnumerable<PersonEntity> people = await _personRepositoryBLL.GetPersonByTask(2);

//foreach (var person in people)
//{
//    Console.WriteLine(person.FirstName + " " + person.LastName);
//}

#endregion

#region GetTaskByPerson BLL

//IEnumerable<TaskEntity>? tasks = await _taskRepositoryBLL.GetTaskByPerson(1);

//if (tasks is not null)
//{
//    foreach (var taskEntity in tasks)
//    {
//        Console.WriteLine(taskEntity.Description);
//    }

//}
#endregion

#region ChangeStatus Task BLL

//bool isUpdated = await _taskRepositoryBLL.ChangeStatus(2);
//Console.WriteLine(isUpdated);

#endregion

#region Test petite méthode hash password
//string EncodePassword(string password)
//{
//    try
//    {
//        byte[] encData_byte = new byte[password.Length];
//        encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
//        string encodedData = Convert.ToBase64String(encData_byte);
//        return encodedData;
//    }
//    catch (Exception ex)
//    {
//        throw new Exception("Error in base64Encode" + ex.Message);
//    }
//}

//Console.WriteLine("password : ");

//string psw = Console.ReadLine();

//string rawPsw = EncodePassword(psw);

//Console.WriteLine("password : ");
//string psw2 = Console.ReadLine();

//string rawPsw2 = EncodePassword(psw2);

//Console.WriteLine(rawPsw == rawPsw2);

#endregion

#region GetByEmail BLL


//PersonEntity? p = await _personRepositoryBLL.GetPersonByEmail("votreemail2@gmail.com");

//if (p is not null)
//{
//    Console.WriteLine("trouvé");
//} else
//{
//    Console.WriteLine("pas trouvé");
//}

#endregion


#region UpdateAvatar BLL

//bool isUpdated = await _personRepositoryBLL.UpdateAvatar(6, "dd");
//if (isUpdated) Console.WriteLine("ok");

#endregion


#region AssignPerson BLL

//int[] personId = new int[] { 6, 7, 8 };

//bool isInserted = await _taskRepositoryBLL.AssignPerson(personId, 2);

//if (isInserted)
//{
//    Console.WriteLine("OK");
//} else
//{
//    Console.WriteLine("Erreur");
//}

#endregion

#region Login BLL

//PersonEntity? person = await _personRepositoryBLL.Login("dqsdqd", "dqdqd");

//if (person != null)
//{
//    Console.WriteLine("OK");
//}
//else
//{
//    Console.WriteLine("Erreur");
//}

#endregion


