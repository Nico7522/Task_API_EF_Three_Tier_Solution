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
        public ActionResult<TaskDTO> GetById(int id)
        {
            TaskDTO? task = _taskRepository.GetById(id)?.ToTaskDTO();
            if (task is null) return BadRequest();

            return Ok(task);
        }

        [HttpPost]
        public ActionResult Create(CreateTaskForm form ) {

           int id = _taskRepository.Create(form.ToTaskEntity());

            if (id < 0 ) return BadRequest();

            return Created($"https://localhost:7238/api/Task/{id}", form);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult> Update(int id, UpdateTaskForm form)
        {
            bool isUpdated = await _taskRepository.Update(id, form.FromUpdateFormToTaskEntity());
            return (isUpdated) ? NoContent() : BadRequest();
        }
    }
}
