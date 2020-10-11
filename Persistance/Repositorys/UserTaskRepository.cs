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

        public List<UserTask> GetByTags(List<Tag> tags)
        {
            var userTaskIDList = tags.Select(t => t.UserTaskID);
            return _dbContext.UserTasks.Where(ut => userTaskIDList.Any(utid => utid == ut.ID)).ToList();
        }

        public List<UserTask> GetByTagIds(List<string> tags)
        {
            return _dbContext.UserTasks.Where(ut => tags.Any(tg => tg == ut.ID)).ToList();
        }

        public List<string> GetIdsByNames(List<string> names)
        {
            var userTasks = _dbContext.UserTasks.Where(ut => names.Any(nm => nm.ToLower() == ut.Name.ToLower()));
            return userTasks.Select(ut => ut.ID).ToList();
        }

        public List<UserTask> GeUserTaskstByIds(List<string> userTaskIds)
        {
            return _dbContext.UserTasks.Where(ut => userTaskIds.Any(uti => uti == ut.ID)).ToList();
        }

        public UserTask GetByName(string name)
        {
            return _dbContext.UserTasks.FirstOrDefault(ut => ut.Name.ToLower() == name.ToLower());
        }

        public bool IsThereInProgressTask()
        {
            return _dbContext.UserTasks.Any(ut => ut.TaskStatus == Domain.TaskStatus.INPROGRESS);
        }

        public async Task<string> SetUserTaskInProgress(string userTaskID)
        {
            var usetTask = GetById(userTaskID);
            usetTask.TaskStatus = Domain.TaskStatus.INPROGRESS;
            await _dbContext.SaveChangesAsync();
            return userTaskID;
        }

        public async Task<string> SetUserTaskInCompleted(string userTaskID)
        {
            var usetTask = GetById(userTaskID);
            usetTask.TaskStatus = Domain.TaskStatus.COMPLETED;
            await _dbContext.SaveChangesAsync();
            return userTaskID;
        }
    }
}
