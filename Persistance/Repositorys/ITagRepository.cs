using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public interface ITagRepository
    {
        Task<Guid> CreateUserTag(string name, string description);

        Tag GetById(string id);

        List<Tag> GetByIds(List<string> tagIds);

        List<Tag> GetByUserTaskId(string userTaskId);

        List<Tag> GetByUserTaskIds(List<string> userTaskIds);

        List<Tag> GetByUserTaskIds(List<UserTask> userTaskIds);

        List<Tag> GetByName(List<string> names);

        Task<string> DeleteTag(string id);

        List<string> GetUserTaskIdsByTagNames(List<string> names);
    }
}
