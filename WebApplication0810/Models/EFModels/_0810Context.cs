using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication0810.Models.EFModels;

public partial class _0810Context : DbContext
{
    public _0810Context()
    {
    }

    public _0810Context(DbContextOptions<_0810Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Table0810> Table0810s { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Table0810>(entity =>
        {
            entity.ToTable("Table_0810");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
