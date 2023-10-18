using TaskManager.DAL.Context;
using Task = TaskManager.DAL.Context.Task;

namespace TaskManager.DAL.Utils
{
    public class DbUtils
    {
        private DatabaseContext _databaseContext;
        public DbUtils(DatabaseContext databaseContext)
        {

            _databaseContext = databaseContext;

        }
        public void PopulateUsersData()
        {

            var users = new List<User>
            {
                new User { UserName = "Alin" },
                new User { UserName = "Octavian" },
                new User { UserName = "Alex" }
            };
            _databaseContext.Users.AddRange(users);
            _databaseContext.SaveChanges();
        }

        public void PopulateTasksData()
        {
            // Adaugă sarcini
            var tasks = new List<Task>
            {
                new Task { TaskName = "Complete Task 1", TaskDescription = "Descriere task1", IsComplete = false, UserId = 1 },
                new Task { TaskName = "Complete Task 2", TaskDescription = "Descriere task 2", IsComplete = true, UserId = 2 },
                new Task { TaskName = "Complete Task 3", TaskDescription = "Descriere Task 3", IsComplete = false, UserId = 3 }
            };
            _databaseContext.Tasks.AddRange(tasks);
            _databaseContext.SaveChanges();
            
        }
    }
}
