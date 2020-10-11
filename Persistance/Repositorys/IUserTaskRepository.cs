using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public interface IUserTaskRepository
    {
        UserTask GetById(string id);
        UserTask GetByName(string name);
        Task<Guid> CreateUserTask(string name, string description);
        List<UserTask> GetByTags(List<Tag> tags);
        List<UserTask> GetByTagIds(List<string> tags);
        bool IsThereInProgressTask();
        Task<string> SetUserTaskInProgress(string userTaskID);
        Task<string> SetUserTaskInCompleted(string userTaskID);
        List<string> GetIdsByNames(List<string> names);
        List<UserTask> GeUserTaskstByIds(List<string> userTaskIds);
    }
}
