using IPersonRepositoryBLL = Task_API_EF_Three_Tier.BLL.Interfaces;
using PersonServiceBLL = Task_API_EF_Three_Tier.BLL.Services;
using IPersonRepositoryDAL = Task_API_EF_Three_Tier.DAL.Interfaces;
using PersonServiceDAL = Task_API_EF_Three_Tier.DAL.Services;
using Task_API_EF_Three_Tier.DAL.Entities;
using Task_API_EF_Three_Tier.DAL.Domain;

Console.WriteLine("cc");

IPersonRepositoryDAL.IPersonRepository  _personRepositoryDAL = new PersonServiceDAL.PersonService();
IPersonRepositoryBLL.IPersonRepository _personRepositoryBLL = new PersonServiceBLL.PersonService(_personRepositoryDAL);

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