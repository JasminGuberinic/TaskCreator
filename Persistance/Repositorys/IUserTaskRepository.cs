using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance
{
    public interface IUserTaskRepository
    {
        UserTask GetById(string id);
    }
}
