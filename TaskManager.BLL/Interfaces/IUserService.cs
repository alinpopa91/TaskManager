namespace TaskManager.BLL.Interfaces
{
    public interface IUserService
    {
        Task<DAL.Context.User> GetUser(int userId);
        Task<List<DAL.Context.User>> GetAllUsers();
    }
}
