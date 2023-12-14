using ITaskRepositoryBLL = Task_API_EF_Three_Tier.BLL.Interfaces.ITaskRepository;
using IPersonRepositoryBLL = Task_API_EF_Three_Tier.BLL.Interfaces.IPersonRepository;
using TaskServiceBLL = Task_API_EF_Three_Tier.BLL.Services.TaskService;
using PersonServiceBLL = Task_API_EF_Three_Tier.BLL.Services.PersonService;


using IPersonRepositoryDAL = Task_API_EF_Three_Tier.DAL.Interfaces.IPersonRepository;
using ITaskRepositoryDAL = Task_API_EF_Three_Tier.DAL.Interfaces.ITaskRepository;
using TaskServiceDAL = Task_API_EF_Three_Tier.DAL.Services.TaskRepository;
using PersonServiceDAL = Task_API_EF_Three_Tier.DAL.Services.PersonService;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",  new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Task_EF_Three_Tier.API", Version = "v1", });
    //c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "api.xml"));


});
builder.Services.AddScoped<ITaskRepositoryDAL, TaskServiceDAL>();
builder.Services.AddScoped<ITaskRepositoryBLL, TaskServiceBLL>();

builder.Services.AddScoped<IPersonRepositoryDAL, PersonServiceDAL>();
builder.Services.AddScoped<IPersonRepositoryBLL, PersonServiceBLL>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
