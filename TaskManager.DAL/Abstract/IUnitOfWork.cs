namespace TaskManager.DAL.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        ITaskRepository TaskRepository { get; }
        Task<int> Commit();
    }
}
