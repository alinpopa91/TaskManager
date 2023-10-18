using TaskManager.DAL.Abstract;
using TaskManager.DAL.Context;
using Microsoft.EntityFrameworkCore;
using TaskManager.DAL.Exceptions;
using System.Threading.Tasks;

namespace TaskManager.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private DatabaseContext _databaseContext;

        public UserRepository(DatabaseContext dbContext)
        {
            _databaseContext = dbContext;
            
        }

        public async Task<List<Context.User>> GetAllUsers()
        {
            try
            {
                var tasks = await _databaseContext.Users.ToListAsync();
                return tasks;
            }
            catch (ArgumentNullException ane)
            {
                throw new CustomException(ExceptionType.Database, $"Error on retrieving user list (Argument Null Exception) {ane.Message}");
            }
            catch (CustomException ex)
            {
                throw new CustomException(ExceptionType.Other, "Other database error");
            }
        }

        public async Task<Context.User> GetUser(int userId)
        {
            try
            {
                var tsk = await _databaseContext.Users.FirstOrDefaultAsync(a => a.UserId == userId);
                return tsk;
            }
            catch (ArgumentNullException ane)
            {
                throw new CustomException(ExceptionType.Database, $"Error on retrieving task {userId} (Argument Null Exception) {ane.Message}");
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
