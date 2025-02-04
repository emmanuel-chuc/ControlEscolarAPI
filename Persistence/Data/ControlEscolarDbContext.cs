using System;
using System.Collections.Generic;
using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data;

public partial class ControlEscolarDbContext : DbContext
{
    public ControlEscolarDbContext()
    {
    }

    public ControlEscolarDbContext(DbContextOptions<ControlEscolarDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alumno> Alumnos { get; set; }

    public virtual DbSet<Personal> Personals { get; set; }

    public virtual DbSet<TipoPersonal> TipoPersonals { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<VwAlumno> VwAlumnos { get; set; }

    public virtual DbSet<VwPersonal> VwPersonals { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.HasKey(e => e.AlumnoId).HasName("PK__Alumno__375A03849802E861");

            entity.ToTable("Alumno");

            entity.Property(e => e.AlumnoId).HasColumnName("alumnoId");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .HasColumnName("apellidos");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .HasColumnName("correoElectronico");
            entity.Property(e => e.Estatus).HasColumnName("estatus");
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("datetime")
                .HasColumnName("fechaNacimiento");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.NumeroControl)
                .HasMaxLength(8)
                .HasColumnName("numeroControl");
            entity.Property(e => e.TipoPersonalId).HasColumnName("tipoPersonalId");
        });

        modelBuilder.Entity<Personal>(entity =>
        {
            entity.HasKey(e => e.PersonalId).HasName("PK__Personal__55FE13F8DBE9667F");

            entity.ToTable("Personal");

            entity.Property(e => e.PersonalId).HasColumnName("personalId");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .HasColumnName("apellidos");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .HasColumnName("correoElectronico");
            entity.Property(e => e.Estatus).HasColumnName("estatus");
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("datetime")
                .HasColumnName("fechaNacimiento");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.NumeroControl)
                .HasMaxLength(13)
                .HasColumnName("numeroControl");
            entity.Property(e => e.Sueldo)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("sueldo");
            entity.Property(e => e.TipoPersonalId).HasColumnName("tipoPersonalId");
        });

        modelBuilder.Entity<TipoPersonal>(entity =>
        {
            entity.HasKey(e => e.TipoPersonalId).HasName("PK__TipoPers__55FE13F86C00CBD2");

            entity.ToTable("TipoPersonal");

            entity.Property(e => e.TipoPersonalId).HasColumnName("tipoPersonalId");
            entity.Property(e => e.ClaveControl)
                .HasMaxLength(2)
                .HasColumnName("claveControl");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .HasColumnName("descripcion");
            entity.Property(e => e.SueldoMaximo)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("sueldoMaximo");
            entity.Property(e => e.SueldoMinimo)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("sueldoMinimo");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.ToTable("Usuario");

            entity.Property(e => e.UsuarioId)
                .ValueGeneratedNever()
                .HasColumnName("usuarioId");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .HasColumnName("password");
            entity.Property(e => e.Rol).HasMaxLength(20);
        });

        modelBuilder.Entity<VwAlumno>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwAlumnos");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .HasColumnName("descripcion");
            entity.Property(e => e.NombreCompleto).HasMaxLength(151);
            entity.Property(e => e.NumeroControl)
                .HasMaxLength(8)
                .HasColumnName("numeroControl");
        });

        modelBuilder.Entity<VwPersonal>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwPersonal");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .HasColumnName("descripcion");
            entity.Property(e => e.NombreCompleto).HasMaxLength(151);
            entity.Property(e => e.NumeroControl)
                .HasMaxLength(13)
                .HasColumnName("numeroControl");
            entity.Property(e => e.Sueldo)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("sueldo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
