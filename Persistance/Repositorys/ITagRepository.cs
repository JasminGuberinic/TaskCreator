using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance
{
    public interface ITagRepository
    {
        Guid CreateUserTag(string name, string description);

        Tag GetById(string id);

        List<Tag> GetByUserTaskId(string userTaskId);
        List<Tag> GetByUserTaskIds(List<string> userTaskIds);

        List<Tag> GetByUserTaskIds(List<UserTask> userTaskIds);

        List<Tag> GetByName(List<string> names);
    }
}
