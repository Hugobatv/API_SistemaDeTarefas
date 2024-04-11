using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repository.Interfaces;
using System.Threading.Tasks;

namespace SistemaDeTarefas.Repository
{
    public class RepositoryTask : IRepositoryTask
    {
        private readonly TaskSystemDBContext _dbContext;
        public RepositoryTask(TaskSystemDBContext taskSystemDBContext )
        {
            _dbContext = taskSystemDBContext;
        }

        public async Task<List<TaskModel>> SearchAllTask()
        {
            return await _dbContext.Tasks.Include(t => t.User).ToListAsync();
        }

        public async Task<List<TaskModel>> SearchId(int id)
        {
            var task = await _dbContext.Tasks.Include(t => t.User).FirstOrDefaultAsync(x => x.Id == id);
           
                return new List<TaskModel> { task };
       
        }
        public async Task<TaskModel> Add(TaskModel Task)
        {
             _dbContext.Tasks.Add(Task);
            await _dbContext.SaveChangesAsync();
            return Task;    
        }
        public async Task<TaskModel> Update(TaskModel task, int id)
        {
            TaskModel taskId = await _dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id);
            if (taskId == null)
            {
                throw new Exception($"Tarefa não encontrada {id}");
            }
            taskId.Name = task.Name;
            taskId.Description = task.Description;
            taskId.Status = task.Status;
            task.UserId = task.UserId;


            _dbContext.Tasks.Update(taskId);
           await _dbContext.SaveChangesAsync();
            return taskId;
        }
        public async Task<bool> Remove(int id)
        {
            TaskModel taskId = await _dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id);
            if (taskId == null)
            {
                throw new Exception($"Tarefa não encontrada {id}");
            }
            _dbContext.Tasks.Remove(taskId);
            await _dbContext.SaveChangesAsync();
            return true ;

        }

       
    }
}
