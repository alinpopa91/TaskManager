using TaskManager.DAL.Abstract;
using TaskManager.DAL.Context;

namespace TaskManager.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private DatabaseContext _dbContext;

        public UnitOfWork(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Commit()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _userRepository?.Dispose();
            _userRepository = null;

            _taskRepository?.Dispose();
            _taskRepository = null;

            _dbContext?.Dispose();
            GC.SuppressFinalize(this);
        }

        private IUserRepository _userRepository;
        public IUserRepository UserRepository
        {
            get { return _userRepository ?? (_userRepository = new UserRepository(_dbContext)); }
        }

        private ITaskRepository _taskRepository;
        public ITaskRepository TaskRepository
        {
            get { return _taskRepository ?? (_taskRepository = new TaskRepository(_dbContext)); }
        }

    }
}
