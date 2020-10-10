using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public class UserTaskRepository : IUserTaskRepository
    {
        private readonly UserTaskContext _dbContext;

        public UserTaskRepository()
        {
        }

        public UserTaskRepository(UserTaskContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> CreateUserTask(string name, string description)
        {
            var guid = Guid.NewGuid();
            _dbContext.UserTasks.Add(new UserTask
            {
                ID = guid.ToString(),
                Name = name,
                Description = description,
                TaskStatus = Domain.TaskStatus.NOTRUN
            });
            await _dbContext.SaveChangesAsync();
            return guid;
        }

        public UserTask GetById(string id)
        {
            return _dbContext.UserTasks.FirstOrDefault(ut => ut.ID == id);
        }

        public List<UserTask> GetById(List<Tag> tags)
        {
            return _dbContext.UserTasks.Where(ut => tags.Any(tg => tg.ID == ut.ID)).ToList();
        }

        public List<UserTask> GetById(List<string> tags)
        {
            return _dbContext.UserTasks.Where(ut => tags.Any(tg => tg == ut.ID)).ToList();
        }

        public UserTask GetByName(string name)
        {
            return _dbContext.UserTasks.FirstOrDefault(ut => ut.Name == name);
        }
    }
}
