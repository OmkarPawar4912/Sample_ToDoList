using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
    
namespace Sample_ToDoList.Models
{
    public partial class ToDoListDBContext : DbContext
    {
        public ToDoListDBContext()
        {
        }

        public ToDoListDBContext(DbContextOptions<ToDoListDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblToDoList> TblToDoLists { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblToDoList>(entity =>
            {
                entity.ToTable("tblToDoList");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
