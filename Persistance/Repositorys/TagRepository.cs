using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistance
{
    public class TagRepository : ITagRepository
    {
        private readonly UserTaskContext _dbContext;

        public TagRepository(UserTaskContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Guid CreateUserTag(string name, string description)
        {
            var guid = Guid.NewGuid();
            _dbContext.Tags.Add(new Tag
            {
                ID = guid.ToString(),
                UserTaskID = name,
                TagName = description,
            });
            _dbContext.SaveChanges();
            return guid;
        }

        public Tag GetById(string id)
        {
            return _dbContext.Tags.FirstOrDefault();
        }

        public List<Tag> GetByUserTaskId(string userTaskId)
        {
            return _dbContext.Tags.Where(tag => tag.UserTaskID == userTaskId).ToList();
        }

        public List<Tag> GetByUserTaskIds(List<UserTask> userTaskIds)
        {
            return _dbContext.Tags.Where(tag => userTaskIds.Any(ut => ut.ID == tag.UserTaskID)).ToList();
        }

        public List<Tag> GetByUserTaskIds(List<string> userTaskIds)
        {
            return _dbContext.Tags.Where(tag => userTaskIds.Any(ut => ut == tag.UserTaskID)).ToList();
        }

        public List<Tag> GetByName(List<string> names)
        {
            return  _dbContext.Tags.Where(tag => names.Any(ut => ut == tag.TagName)).ToList();
        }
    }
}
