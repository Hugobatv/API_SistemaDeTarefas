using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Repository.Interfaces
{
    public interface IRepositoryTasks
    {
        Task<List<UserModel>> SearchAllUsers();
        Task<List<UserModel>> SearchById(int id);
        Task<UserModel> Add(UserModel user);
        Task<UserModel> Update(UserModel user , int id);
        Task<bool> Delete(int id);

    }
}
