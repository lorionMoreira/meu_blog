using blog_asp_net2.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace blog_asp_net2.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Post> Posts { get; set; }

        // mencionar as outras entities aqui

        // aqui tem tambem as definições das tabelas aula: novo contexto
    }
}
