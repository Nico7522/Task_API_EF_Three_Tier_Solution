using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Net.Http.Headers;
using Task_API_EF_Three_Tier.BLL.Interfaces;
using Task_EF_Three_Tier.API.Mappers;
using Task_EF_Three_Tier.API.Models.DTO;
using Task_EF_Three_Tier.API.Models.Forms;

namespace Task_EF_Three_Tier.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;
        private readonly ITaskRepository _taskRepository;
        public PersonController(IPersonRepository personRepository, ITaskRepository taskRepository)
        {
            _personRepository = personRepository;
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<PersonDTO>> GetAll()
        {
            return await _personRepository.GetAll().ContinueWith(t => t.Result.Select(t => t.ToPersonDTO()));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PersonDTO>> GetById(int id) {

            PersonDTO? person = await _personRepository.GetById(id).ContinueWith(p => p.Result?.ToPersonDTO());

            return (person is not null) ? Ok(person) : BadRequest();
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreatePersonForm form)
        {
            int id = await _personRepository.Create(form.ToPersonEntity());
            return (id > 0) ? Created($"https://localhost:7238/api/Person/{id}", form) : BadRequest();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, UpdatePersonForm form)
        {
           bool isUpdated = await _personRepository.Update(id, form.ToPersonEntity());
           return (isUpdated) ? NoContent() : BadRequest();
        }

        [HttpDelete("{id:int}")]

        public async Task<ActionResult> Delete(int id)
        {
            bool isDeleted = await _personRepository.Delete(id);
            return (isDeleted) ? NoContent() : BadRequest();
        }

        [HttpGet("{personId:int}/task")]
        public async Task<ActionResult<IEnumerable<TaskDTO>>> GetTaskByPerson(int personId)
        {

            IEnumerable<TaskDTO>? tasks = await _taskRepository.GetTaskByPerson(personId).ContinueWith(p => p.Result?.Select(p => p.ToTaskDTO()));
            if (tasks is null) return BadRequest();

            return (tasks.Count() > 0) ? Ok(tasks) : NoContent();
        }

        [HttpPatch("{id:int}/avatar")]
        public async Task<ActionResult> UpdateAvatar(int id, [FromForm] FileForm fileModel)
        {
            try
            {
                bool isUpdated = await _personRepository.UpdateAvatar(id, fileModel.File.FileName);
                string path = Path.Combine(fileModel.Directory, fileModel.File.FileName);
                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    fileModel.File.CopyTo(stream);
                }

                return (isUpdated) ? NoContent() : BadRequest();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<PersonDTO?>> Login(LoginForm form)
        {
           PersonDTO? person = await _personRepository.Login(form.Email, form.Password).ContinueWith(p => p.Result?.ToPersonDTO());

            return (person is null) ? NotFound() : Ok(person);
        }
    


    }
}
