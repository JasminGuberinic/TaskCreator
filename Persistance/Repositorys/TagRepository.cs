using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public class TagRepository : ITagRepository
    {
        private readonly UserTaskContext _dbContext;

        public TagRepository(UserTaskContext dbContext)
        {
            _dbContext = dbContext;
        }

        public TagRepository()
        {
        }

        public async Task<Guid> CreateUserTag(string userTaskID, string tagName)
        {
            var guid = Guid.NewGuid();
            _dbContext.Tags.Add(new Tag
            {
                ID = guid.ToString(),
                UserTaskID = userTaskID,
                TagName = tagName,
            });
            await _dbContext.SaveChangesAsync();
            return guid;
        }

        public Tag GetById(string id)
        {
            return _dbContext.Tags.FirstOrDefault( t => t.ID == id);
        }

        public List<Tag> GetByIds(List<string> tagIds)
        {
            return _dbContext.Tags.Where(tag => tagIds.Any(tg => tg == tag.ID)).ToList();
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

        public List<string> GetUserTaskIdsByTagNames(List<string> names)
        {
            var userTasks = _dbContext.Tags.Where(tg => names.Any(nm => nm == tg.TagName));
            return userTasks.Select(tg => tg.UserTaskID).ToList();
        }

        public List<Tag> GetByName(List<string> names)
        {
            return  _dbContext.Tags.Where(tag => names.Any(ut => ut == tag.TagName)).ToList();
        }

        public async Task<string> DeleteTag(string id)
        {
            var tagToDelete = GetById(id);
            _dbContext.Tags.Remove(tagToDelete);
            await _dbContext.SaveChangesAsync();
            return id;
        }
    }
}
