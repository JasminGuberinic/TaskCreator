using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Tag : IBaseModel
    {
        public string ID { get; set; }
        public string UserTaskID { get; set; }
        public string TagName { get; set; }
    }
}
