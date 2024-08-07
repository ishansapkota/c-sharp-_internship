﻿using DomainLayer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Data_Access
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {
            
        }

       public DbSet<AuthUser> Users { get; set; }
       public DbSet<User> UserDetails { get; set; }
       public DbSet<Post>Posts { get; set; }
       public DbSet<Comment>Comments { get; set; }
       public DbSet<CommentPostUser>CommentPostUsers { get; set; }
       public DbSet<News>News { get; set; }
       public DbSet<Team>Teams { get; set; }
       

    }
}
