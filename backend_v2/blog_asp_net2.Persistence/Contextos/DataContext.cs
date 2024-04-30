using blog_asp_net2.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace blog_asp_net2.Persistence.Contextos
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Comment> Comments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasMany(e => e.comment)
                .WithOne(rs => rs.post)
                .OnDelete(DeleteBehavior.Cascade);
        }

            // mencionar as outras entities aqui

            // aqui tem tambem as definições das tabelas aula: novo contexto
    }
}
