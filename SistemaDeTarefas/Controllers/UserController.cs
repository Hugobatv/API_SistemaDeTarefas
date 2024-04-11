using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repository.Interfaces;

namespace SistemaDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepositoryTasks _repositoryUsers;

        public UserController(IRepositoryTasks repositoryUsers)
        {
            _repositoryUsers = repositoryUsers;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> SearchAllUsers()
        {
            List<UserModel> users = await _repositoryUsers.SearchAllUsers();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<UserModel>>> SearchById(int id)
        {
            List<UserModel> user = await _repositoryUsers.SearchById(id);
            return Ok(user);
        }
        [HttpPost]
        public async Task<ActionResult<UserModel>> Register([FromBody] UserModel usermodel)
        {
            UserModel user = await _repositoryUsers.Add(usermodel);
            return Ok(usermodel);

        }
        [HttpPut]
        public async Task<ActionResult<UserModel>> Update([FromBody] UserModel usermodel, int id)
        {
            usermodel.Id = id;
            UserModel user = await _repositoryUsers.Update(usermodel, id);
            return Ok(usermodel);

        }
        [HttpDelete("id")]
        public async Task<ActionResult<UserModel>> Delete(int id)
        {
          
            bool deleted  = await _repositoryUsers.Delete(id);
            return Ok(deleted);

        }

    }
}
