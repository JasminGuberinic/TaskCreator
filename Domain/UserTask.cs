using System;

namespace Domain
{
    public class UserTask : IBaseModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime TimeSpent { get; set; }
        public TaskStatus TaskStatus { get; set; }
    }
}
