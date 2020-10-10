using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance
{
    public interface IUserTaskRepository
    {
        UserTask GetById(string id);
        UserTask GetByName(string name);
        Guid CreateUserTask(string name, string description);
        List<UserTask> GetById(List<Tag> tags);
        List<UserTask> GetById(List<string> tags);
    }
}
