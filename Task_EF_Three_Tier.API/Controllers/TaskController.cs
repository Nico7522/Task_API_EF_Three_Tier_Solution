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

        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskDTO>>> GetAll()
        {
            IEnumerable<TaskDTO> tasks = await _taskRepository.GetAll().ContinueWith(t => t.Result.Select(t => t.ToTaskDTO()));
            if (!tasks.Any()) return BadRequest();

            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDTO>> GetById(int id)
        {
            TaskDTO? task = await _taskRepository.GetById(id).ContinueWith(t => t.Result?.ToTaskDTO());
            if (task is null) return BadRequest();

            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateTaskForm form) {

           int id = await _taskRepository.Create(form.ToTaskEntity());

            if (id < 0) return BadRequest();

            return Created($"https://localhost:7238/api/Task/{id}", form);
        }

        [HttpPut("{id}")]

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
    }
}
