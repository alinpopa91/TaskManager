namespace TaskManager.DAL.Abstract
{
    public interface ITaskRepository
    {
        Task<List<Context.Task>> GetAllTasks();
        Task<Context.Task> GetTask(int taskId);
        Task UpdateTask(Context.Task task);
        Task<bool> AddTask(Context.Task task);
        void Dispose();
    }
}
