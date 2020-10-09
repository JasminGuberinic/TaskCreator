using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistance
{
    public class UserTaskRepository : IUserTaskRepository
    {
        private readonly UserTaskContext _dbContext;

        public UserTaskRepository(UserTaskContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Guid CreateUserTask(string name, string description)
        {
            var guid = Guid.NewGuid();
            _dbContext.UserTasks.Add(new UserTask
            {
                ID = guid.ToString(),
                Name = name,
                Description = description,
                TaskStatus = TaskStatus.NOTRUN
            });
            return guid;
        }

        public UserTask GetById(string id)
        {
            return _dbContext.UserTasks.FirstOrDefault(ut => ut.ID == id);
        }
    }
}
