﻿// using System;
// using System.Collections.Generic;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata;

// namespace Blog_School.Models
// {
//     public partial class blog_schoolContext : DbContext
//     {
//         public blog_schoolContext()
//         {
//         }

//         public blog_schoolContext(DbContextOptions<blog_schoolContext> options)
//             : base(options)
//         {
//         }

//         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//         {
//             if (!optionsBuilder.IsConfigured)
//             {
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                 optionsBuilder.UseSqlServer("Server=127.0.0.1;Database=blog_school;User=SA;Password=Password12@");
//             }
//         }

//         protected override void OnModelCreating(ModelBuilder modelBuilder)
//         {
//             OnModelCreatingPartial(modelBuilder);
//         }

//         partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//     }
// }
