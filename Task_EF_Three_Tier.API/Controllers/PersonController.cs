﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Task_API_EF_Three_Tier.BLL.Interfaces;
using Task_API_EF_Three_Tier.DAL.Entities;
using Task_EF_Three_Tier.API.Mappers;
using Task_EF_Three_Tier.API.Models;
using Task_EF_Three_Tier.API.Models.DTO;
using Task_EF_Three_Tier.API.Models.Forms;
using Task_EF_Three_Tier.API.Utils;

namespace Task_EF_Three_Tier.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;
        private readonly ITaskRepository _taskRepository;
        private IConfiguration _configuration;
        public PersonController(IPersonRepository personRepository, ITaskRepository taskRepository, IConfiguration configuration)
        {
            _personRepository = personRepository;
            _taskRepository = taskRepository;
            _configuration = configuration;
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
        public async Task<ActionResult<AuthResponse>> Create(CreatePersonForm form)
        {
            if (!ModelState.IsValid) return BadRequest();
            
            PersonEntity person = await _personRepository.Create(form.ToPersonEntity());
            if (person is null) return BadRequest();

            AuthResponse response = Method.GenerateToken(_configuration, person.ToPersonDTO());
            if (response is not null)
                Method.GenerateCookie(Response, "token", response.Token);

           return Created($"https://localhost:7238/api/Person/{person.PersonId}", response);
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
            if(fileModel is null ) return BadRequest();

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
        public async Task<ActionResult<AuthResponse>> Login([FromBody] LoginForm form)
        {
            if(!ModelState.IsValid) return BadRequest();


           PersonDTO? person = await _personRepository.Login(form.Email, form.Password).ContinueWith(p => p.Result?.ToPersonDTO());
            if (person is null) return NotFound();

           AuthResponse? response = Method.GenerateToken(_configuration, person);
            if(response is not null)
                Method.GenerateCookie(Response, "token", response.Token );

            return Ok(response);
        }
    


    }
}
