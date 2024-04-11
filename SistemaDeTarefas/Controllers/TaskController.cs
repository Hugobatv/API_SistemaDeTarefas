using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repository.Interfaces;

namespace SistemaDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IRepositoryTask _repositoryTask;

        public TaskController(IRepositoryTask repositoryTask)
        {
            _repositoryTask = repositoryTask;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskModel>>> SearchAllTask()
        {
            List<TaskModel> Tasks = await _repositoryTask.SearchAllTask();
            return Ok(Tasks);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskModel>>SearchId(int id)
        {
            List<TaskModel> task = await _repositoryTask.SearchId(id);
            return Ok(task);
        }
        [HttpPost]
        public async Task<ActionResult<TaskModel>> Register([FromBody] TaskModel taskmodel)
        {
            TaskModel task = await _repositoryTask.Add(taskmodel);
            return Ok(taskmodel);

        }
        [HttpPut]
        public async Task<ActionResult<TaskModel>> Update([FromBody] TaskModel taskmodel, int id)
        {
            taskmodel.Id = id;
            TaskModel user = await _repositoryTask.Update(taskmodel, id);
            return Ok(taskmodel);

        }
        [HttpDelete("id")]
        public async Task<ActionResult<TaskModel>> Remove(int id)
        {
          
            bool deleted  = await _repositoryTask.Remove(id);
            return Ok(deleted);

        }

    }
}
