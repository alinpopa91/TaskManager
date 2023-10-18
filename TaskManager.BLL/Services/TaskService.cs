using TaskManager.BLL.Interfaces;
using TaskManager.DAL.Abstract;
using TaskManager.DAL.Utils;

namespace TaskManager.BLL.Services
{
    public class TaskService : ITaskService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOpenAIService _openAIService;
        DbUtils _dbUtils;
        public TaskService(IUnitOfWork unitOfWork, IOpenAIService openAiService, DbUtils dbUtils)
        {
            _unitOfWork = unitOfWork;
            _openAIService = openAiService;
            _dbUtils = dbUtils;
            _dbUtils.PopulateTasksData();
        }

        public async Task<DAL.Context.Task> GetTask(int taskId)
        {
            var result = await _unitOfWork.TaskRepository.GetTask(taskId);
            return result ?? new DAL.Context.Task();
        }

        public async Task UpdateTask(DAL.Context.Task task)
        {
            await _unitOfWork.TaskRepository.UpdateTask(task);
            await _unitOfWork.Commit();
        }

        public async Task AddTask(DAL.Context.Task task)
        {
            await _unitOfWork.TaskRepository.AddTask(task);
            await _unitOfWork.Commit();
        }

        public async Task<List<DAL.Context.Task>> GetAllTasks()
        {
            var result = await _unitOfWork.TaskRepository.GetAllTasks();
            return result;
        }

        public async Task<string> GetTaskSummaryFromAPI(int taskId)
        {
            var task = await _unitOfWork.TaskRepository.GetTask(taskId);
            var textSummary = await _openAIService.GenerateResponse($"Generate a new dummy description for following task description {task.TaskDescription}");

            return textSummary;
        }
    }
}
