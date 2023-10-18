namespace TaskManager.BLL.Interfaces
{
    public interface ITaskService
    {
        Task<DAL.Context.Task> GetTask(int taskId);
        Task UpdateTask(DAL.Context.Task task);
        Task AddTask(DAL.Context.Task task);
        Task<List<DAL.Context.Task>> GetAllTasks();
        Task<string> GetTaskSummaryFromAPI(int taskId);
    }
}
