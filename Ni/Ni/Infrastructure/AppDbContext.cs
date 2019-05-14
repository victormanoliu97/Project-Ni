using DefaultNamespace;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ni.Infrastructure
{
        public class AppDbContext : DbContext
        {
            public DbSet<User> Users { get; set; }
            public DbSet<AuthKey> AuthKeys { get; set; }
            public DbSet<Commentary> Commentaries { get; set; }
            public DbSet<PostCommentary> PostCommentaries { get; set; }
            public DbSet<Tag> Tags { get; set; }
            public DbSet<Post> Posts { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseMySql($"Server=ni-db-server.mysql.database.azure.com;Database=ni;User=ni-username@ni-db-server;Password=ni-password15;");
            }
        }
}
