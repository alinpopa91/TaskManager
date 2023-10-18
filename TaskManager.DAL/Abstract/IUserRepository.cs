using TaskManager.DAL.Context;

namespace TaskManager.DAL.Abstract
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUser(int userId);
        void Dispose();
    }
}
