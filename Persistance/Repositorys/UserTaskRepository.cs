using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance
{
    public class UserTaskRepository : IUserTaskRepository
    {
        private readonly UserTaskContext db = new UserTaskContext();

        public UserTask GetById(string id)
        {
            //return db.Boogles.FirstOrDefault(boogle => boogle.Id == id);
            return new UserTask
            {
                ID = "ssss"
            };
        }
    }
}
