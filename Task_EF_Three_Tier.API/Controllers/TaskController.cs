﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_API_EF_Three_Tier.BLL.Interfaces;
using Task_EF_Three_Tier.API.Mappers;
using Task_EF_Three_Tier.API.Models.DTO;

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
        public ActionResult<IEnumerable<TaskDTO>> GetAll()
        {
           IEnumerable<TaskDTO> tasks = _taskRepository.GetAll().Select(t => t.ToTaskDTO());
            if (!tasks.Any()) return BadRequest();

            return Ok(tasks);
        }
    }
}