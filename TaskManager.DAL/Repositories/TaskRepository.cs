using TaskManager.DAL.Abstract;
using TaskManager.DAL.Context;
using Microsoft.EntityFrameworkCore;
using TaskManager.DAL.Exceptions;
using System.Threading.Tasks;

namespace TaskManager.DAL.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private DatabaseContext _databaseContext;

        public TaskRepository(DatabaseContext dbContext)
        {
            _databaseContext = dbContext;
        }

        public async Task<List<Context.Task>> GetAllTasks()
        {
            try
            {
                var tasks = await _databaseContext.Tasks.ToListAsync();
                return tasks;
            }
            catch (ArgumentNullException ane)
            {
                throw new CustomException(ExceptionType.Database, $"Error on retrieving list (Argument Null Exception) {ane.Message}");
            }
            catch (CustomException ex)
            {
                throw new CustomException(ExceptionType.Other, "Other database error");
            }
        }

        public async Task<Context.Task> GetTask(int taskId)
        {
            try
            {
                var tsk = await _databaseContext.Tasks.FirstOrDefaultAsync(a => a.TaskId == taskId);
                return tsk;
            }
            catch (ArgumentNullException ane)
            {
                throw new CustomException(ExceptionType.Database, $"Error on retrieving task {taskId} (Argument Null Exception) {ane.Message}");
            }
            catch (CustomException ex)
            {
                throw new CustomException(ExceptionType.Other, "Other database error");
            }
        }

        public async System.Threading.Tasks.Task UpdateTask(Context.Task task)
        {
            try
            {
                var tsk = await _databaseContext.Tasks.FirstOrDefaultAsync(a => a.TaskId == task.TaskId);
                if (tsk == null)
                {
                    throw new CustomException(ExceptionType.Database, $"Error on retrieving task {task.TaskId} from database");
                }

                tsk.TaskName = task.TaskName;
                tsk.TaskDescription = task.TaskDescription;
                tsk.IsComplete = task.IsComplete;
                tsk.UserId = task.UserId;

                _databaseContext.Update(tsk);
            }
            catch (ArgumentNullException ane)
            {
                throw new CustomException(ExceptionType.Database, $"Error on retrieving task {task.TaskId} (Argument Null Exception) {ane.Message}");
            }
            catch (CustomException ex)
            {
                throw new CustomException(ExceptionType.Other, "Other database error");
            }
        }

        public async Task<bool> AddTask(Context.Task task)
        {
            try
            {
                await _databaseContext.Tasks.AddAsync(task);
                return true;
            }
            catch (ArgumentNullException ane)
            {
                throw new CustomException(ExceptionType.Database, $"Error on retrieving task {task.TaskId} (Argument Null Exception) {ane.Message}");
            }
            catch (CustomException ex)
            {
                throw new CustomException(ExceptionType.Other, "Other database error");
            }
        }

        public virtual void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
