using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Tarea1_BD1.Models;

public partial class Dbtarea1Context : DbContext
{
    public Dbtarea1Context()
    {
    }

    public Dbtarea1Context(DbContextOptions<Dbtarea1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Empleado> Empleados { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=DESKTOP-NVUTANU\\SQLEXPRESS; Initial Catalog=DBTarea1; user id= sa ; pwd= 123.elSQLs.;Integrated Security=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Empleado__3213E83F8AAD473A");

            entity.ToTable("Empleado");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.Salario).HasColumnType("money");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
