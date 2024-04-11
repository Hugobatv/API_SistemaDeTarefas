using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Repository.Interfaces
{
    public interface IRepositoryTask
    {
        Task<List<TaskModel>> SearchAllTask();
        Task<List<TaskModel>> SearchId(int id);
        Task<TaskModel> Add(TaskModel task);
        Task<TaskModel> Update(TaskModel task , int id);
        Task<bool> Remove(int id);

    }
}
