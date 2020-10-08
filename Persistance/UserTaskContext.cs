using Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace Persistance
{
    public class UserTaskContext : DbContext
    {
        public DbSet<UserTask> Boogles { get; set; }
    }
}
