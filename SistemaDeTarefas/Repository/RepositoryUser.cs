using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repository.Interfaces;

namespace SistemaDeTarefas.Repository
{
    public class RepositoryUser : IRepositoryTasks
    {
        private readonly TaskSystemDBContext _dbContext;
        public RepositoryUser(TaskSystemDBContext taskSystemDBContext )
        {
            _dbContext = taskSystemDBContext;
        }

        public async Task<List<UserModel>> SearchAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<List<UserModel>> SearchById(int id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
           
                return new List<UserModel> { user };
       
        }
        public async Task<UserModel> Add(UserModel user)
        {
             _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            return user;    
        }
        public async Task<UserModel> Update(UserModel user, int id)
        {
            UserModel userId = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (userId == null)
            {
                throw new Exception($"Usuario não encontrado {id}");
            }
            userId.Name = user.Name;
            userId.Email = user.Email;  

            _dbContext.Users.Update(userId);
           await _dbContext.SaveChangesAsync();
            return userId;
        }
        public async Task<bool> Delete(int id)
        {
            UserModel userId = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (userId == null)
            {
                throw new Exception($"Usuario não encontrado {id}");
            }
            _dbContext.Users.Remove(userId);
            await _dbContext.SaveChangesAsync();
            return true ;

        }

        
    }
}
