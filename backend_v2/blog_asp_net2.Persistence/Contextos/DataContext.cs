using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using blog_asp_net2.Domain;

using Microsoft.EntityFrameworkCore;
using System;
using blog_asp_net2.Domain.Identity;

namespace blog_asp_net2.Persistence.Contextos
{
    public class DataContext  : IdentityDbContext<User, Role, int, 
                                                       IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>, 
                                                       IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Comment> Comments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            //ligacao do identity
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<UserRole>(userRole => 
                {
                    userRole.HasKey(ur => new { ur.UserId, ur.RoleId});

                    userRole.HasOne(ur => ur.Role)
                        .WithMany(r => r.UserRoles)
                        .HasForeignKey(ur => ur.RoleId)
                        .IsRequired();

                    userRole.HasOne(ur => ur.User)
                        .WithMany(r => r.UserRoles)
                        .HasForeignKey(ur => ur.UserId)
                        .IsRequired();
                }
            );

            //ligacao de post com comment
            modelBuilder.Entity<Post>()
                .HasMany(e => e.comment)
                .WithOne(rs => rs.post)
                .OnDelete(DeleteBehavior.Cascade);
        }

            // mencionar as outras entities aqui

            // aqui tem tambem as definições das tabelas aula: novo contexto
    }
}
