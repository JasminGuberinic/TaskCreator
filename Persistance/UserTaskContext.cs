using Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace Persistance
{
    public class UserTaskContext : DbContext
    {

        public UserTaskContext(DbContextOptions<UserTaskContext> options) : base(options)
        {
        }

        public DbSet<UserTask> UserTasks { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
