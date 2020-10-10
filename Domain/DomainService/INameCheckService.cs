using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public interface INameCheckService
    {
        bool IsTagNameValid(string tagName);

        string MakeUserTaskNameValid(string userTaskName);
    }
}
