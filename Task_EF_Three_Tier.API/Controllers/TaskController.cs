using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_API_EF_Three_Tier.BLL.Interfaces;
using Task_EF_Three_Tier.API.Mappers;
using Task_EF_Three_Tier.API.Models.DTO;
using Task_EF_Three_Tier.API.Models.Forms;

namespace Task_EF_Three_Tier.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IPersonRepository _personRepository;

        public TaskController(ITaskRepository taskRepository, IPersonRepository personRepository)
        {
            _taskRepository = taskRepository;
            _personRepository = personRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskDTO>>> GetAll()
        {
            IEnumerable<TaskDTO> tasks = await _taskRepository.GetAll().ContinueWith(t => t.Result.Select(t => t.ToTaskDTO()));
            if (!tasks.Any()) return BadRequest();

            return Ok(tasks);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TaskDTO>> GetById(int id)
        {
            TaskDTO? task = await _taskRepository.GetById(id).ContinueWith(t => t.Result?.ToTaskDTO());
            if (task is null) return BadRequest();

            return Ok(task);
        }


        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Create(CreateTaskForm form) {

           int id = await _taskRepository.Create(form.ToTaskEntity());

            if (id < 0) return BadRequest();

            return Created($"https://localhost:7238/api/Task/{id}", form);
        }

        [HttpPut("{id:int}")]

        public async Task<ActionResult> Update(int id, UpdateTaskForm form)
        {
            bool isUpdated = await _taskRepository.Update(id, form.ToTaskEntity());
            return (isUpdated) ? NoContent() : BadRequest();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            bool isDeleted = await _taskRepository.Delete(id);
            return (isDeleted) ? NoContent() : BadRequest();
        }

        [HttpGet("{taskId:int}/person")]
        public async Task<ActionResult<IEnumerable<PersonDTO>>> GetPersonByTask(int taskId) {
        
            IEnumerable<PersonDTO>? people = await _personRepository.GetPersonByTask(taskId).ContinueWith(p => p.Result?.Select(p => p.ToPersonDTO()));
            if (people is null) return BadRequest(); 

            return (people.Count() > 0) ? Ok(people) : NoContent();
        }

        [HttpPatch("{id:int}/status")]

        public async Task<ActionResult> ChangeStatus(int id)
        {
            bool isUpdated = await _taskRepository.ChangeStatus(id);
            return (isUpdated) ? NoContent() : BadRequest();
        }

        [HttpPost("{taskId:int}/assign")]

        public async Task<ActionResult> AssignPerson(int[] personId, int taskId)
        {
            
            bool isInserted = await _taskRepository.AssignPerson(personId, taskId);

            return (isInserted) ? NoContent() : BadRequest();
        }

    }
}
