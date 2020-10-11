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
        List<UserTask> GetById(List<Tag> tags);
        List<UserTask> GetById(List<string> tags);
        bool IsThereInProgressTask();
        Task<string> SetUserTaskInProgress(string userTaskID);
        Task<string> SetUserTaskInCompleted(string userTaskID);
    }
}
