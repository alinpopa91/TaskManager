using TaskManager.BLL.Interfaces;
using TaskManager.DAL.Abstract;
using TaskManager.DAL.Utils;

namespace TaskManager.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        DbUtils _dbUtils;
        public UserService(IUnitOfWork unitOfWork, DbUtils dbUtils)
        {
            _unitOfWork = unitOfWork;
            _dbUtils = dbUtils;
            _dbUtils.PopulateUsersData();

        }

        public async Task<DAL.Context.User> GetUser(int userId)
        {
            var result = await _unitOfWork.UserRepository.GetUser(userId);
            return result ?? new DAL.Context.User();
        }

        public async Task<List<DAL.Context.User>> GetAllUsers()
        {
            var result = await _unitOfWork.UserRepository.GetAllUsers();
            return result;
        }
    }
}
