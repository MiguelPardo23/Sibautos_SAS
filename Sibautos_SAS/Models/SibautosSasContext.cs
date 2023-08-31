using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Sibautos_SAS.Models;

public partial class SibautosSasContext : DbContext
{
    public SibautosSasContext()
    {
    }

    public SibautosSasContext(DbContextOptions<SibautosSasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alumno> Alumnos { get; set; }

    public virtual DbSet<Aula> Aulas { get; set; }

    public virtual DbSet<ClasePractica> ClasePracticas { get; set; }

    public virtual DbSet<ClaseTeorica> ClaseTeoricas { get; set; }

    public virtual DbSet<ContactoAlum> ContactoAlums { get; set; }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<InscripcionPractica> InscripcionPracticas { get; set; }

    public virtual DbSet<InscripcionTeorica> InscripcionTeoricas { get; set; }

    public virtual DbSet<Instructor> Instructors { get; set; }

    public virtual DbSet<Vehiculo> Vehiculos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-DIB627A\\SQLEXPRESS; Database=Sibautos_SAS; Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.HasKey(e => e.IdAlumno).HasName("PK__Alumno__6D77A7F1656E1EFE");

            entity.ToTable("Alumno");

            entity.Property(e => e.IdAlumno).HasColumnName("id_alumno");
            entity.Property(e => e.Apellido)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Celular)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("celular");
            entity.Property(e => e.Correo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.IdContacto).HasColumnName("id_contacto");
            entity.Property(e => e.IdCurso).HasColumnName("id_curso");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NumDocumento)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("num_documento");
            entity.Property(e => e.TipoDocumento)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("tipo_documento");

            entity.HasOne(d => d.IdContactoNavigation).WithMany(p => p.Alumnos)
                .HasForeignKey(d => d.IdContacto)
                .HasConstraintName("FK__Alumno__id_conta__66603565");

            entity.HasOne(d => d.IdCursoNavigation).WithMany(p => p.Alumnos)
                .HasForeignKey(d => d.IdCurso)
                .HasConstraintName("FK__Alumno__id_curso__6754599E");
        });

        modelBuilder.Entity<Aula>(entity =>
        {
            entity.HasKey(e => e.IdAula).HasName("PK__Aula__B19134FE80BF1366");

            entity.ToTable("Aula");

            entity.Property(e => e.IdAula).HasColumnName("id_aula");
            entity.Property(e => e.Capacidad).HasColumnName("capacidad");
            entity.Property(e => e.Equipamento)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("equipamento");
        });

        modelBuilder.Entity<ClasePractica>(entity =>
        {
            entity.HasKey(e => e.IdClaseP).HasName("PK__Clase_pr__29FB899D910F4235");

            entity.ToTable("Clase_practica");

            entity.Property(e => e.IdClaseP).HasColumnName("id_claseP");
            entity.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");
            entity.Property(e => e.Hora).HasColumnName("hora");
            entity.Property(e => e.Tema)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("tema");
        });

        modelBuilder.Entity<ClaseTeorica>(entity =>
        {
            entity.HasKey(e => e.IdClaseT).HasName("PK__Clase_te__29FB89911FB79C53");

            entity.ToTable("Clase_teorica");

            entity.Property(e => e.IdClaseT).HasColumnName("id_claseT");
            entity.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");
            entity.Property(e => e.Hora).HasColumnName("hora");
            entity.Property(e => e.Tema)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("tema");
        });

        modelBuilder.Entity<ContactoAlum>(entity =>
        {
            entity.HasKey(e => e.IdContacto).HasName("PK__Contacto__099A52B8A5553D0D");

            entity.ToTable("Contacto_alum");

            entity.Property(e => e.IdContacto).HasColumnName("id_contacto");
            entity.Property(e => e.Apellido)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Celular)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("celular");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.IdCurso).HasName("PK__Curso__5D3F750251428302");

            entity.ToTable("Curso");

            entity.Property(e => e.IdCurso).HasColumnName("id_curso");
            entity.Property(e => e.HorasPrecticas).HasColumnName("horas_precticas");
            entity.Property(e => e.HorasTeoricas).HasColumnName("horas_teoricas");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NumDocumento).HasColumnName("num_documento");
        });

        modelBuilder.Entity<InscripcionPractica>(entity =>
        {
            entity.HasKey(e => e.IdInscripcionP).HasName("PK__Inscripc__50A00224F8775CFD");

            entity.ToTable("InscripcionPractica");

            entity.Property(e => e.IdInscripcionP).HasColumnName("id_inscripcionP");
            entity.Property(e => e.IdAlumno).HasColumnName("id_alumno");
            entity.Property(e => e.IdClaseP).HasColumnName("id_claseP");
            entity.Property(e => e.IdInstructor).HasColumnName("id_instructor");
            entity.Property(e => e.IdVehiculo).HasColumnName("id_vehiculo");

            entity.HasOne(d => d.IdAlumnoNavigation).WithMany(p => p.InscripcionPracticas)
                .HasForeignKey(d => d.IdAlumno)
                .HasConstraintName("FK__Inscripci__id_al__693CA210");

            entity.HasOne(d => d.IdClasePNavigation).WithMany(p => p.InscripcionPracticas)
                .HasForeignKey(d => d.IdClaseP)
                .HasConstraintName("FK_InscripcionPractica_Clase_practica");

            entity.HasOne(d => d.IdInstructorNavigation).WithMany(p => p.InscripcionPracticas)
                .HasForeignKey(d => d.IdInstructor)
                .HasConstraintName("FK_InscripcionPractica_Instructor");

            entity.HasOne(d => d.IdVehiculoNavigation).WithMany(p => p.InscripcionPracticas)
                .HasForeignKey(d => d.IdVehiculo)
                .HasConstraintName("FK_InscripcionPractica_Vehiculo");
        });

        modelBuilder.Entity<InscripcionTeorica>(entity =>
        {
            entity.HasKey(e => e.IdInscripcionT).HasName("PK__Inscripc__50A002188AC8DF08");

            entity.ToTable("InscripcionTeorica");

            entity.Property(e => e.IdInscripcionT)
                .ValueGeneratedOnAdd()
                .HasColumnName("id_inscripcionT");
            entity.Property(e => e.IdAlumno).HasColumnName("id_alumno");
            entity.Property(e => e.IdAula).HasColumnName("id_aula");
            entity.Property(e => e.IdClase).HasColumnName("id_clase");
            entity.Property(e => e.IdClaseT).HasColumnName("id_claseT");
            entity.Property(e => e.IdInstructor).HasColumnName("id_instructor");

            entity.HasOne(d => d.IdAulaNavigation).WithMany(p => p.InscripcionTeoricas)
                .HasForeignKey(d => d.IdAula)
                .HasConstraintName("FK_InscripcionTeorica_Aula");

            entity.HasOne(d => d.IdClaseTNavigation).WithMany(p => p.InscripcionTeoricas)
                .HasForeignKey(d => d.IdClaseT)
                .HasConstraintName("FK_InscripcionTeorica_Clase_teorica");

            entity.HasOne(d => d.IdInscripcionTNavigation).WithOne(p => p.InscripcionTeorica)
                .HasForeignKey<InscripcionTeorica>(d => d.IdInscripcionT)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InscripcionTeorica_Alumno");

            entity.HasOne(d => d.IdInstructorNavigation).WithMany(p => p.InscripcionTeoricas)
                .HasForeignKey(d => d.IdInstructor)
                .HasConstraintName("FK_InscripcionTeorica_Instructor");
        });

        modelBuilder.Entity<Instructor>(entity =>
        {
            entity.HasKey(e => e.IdInstructor).HasName("PK__Instruct__1CCC4C121CE77CE3");

            entity.ToTable("Instructor");

            entity.Property(e => e.IdInstructor).HasColumnName("id_instructor");
            entity.Property(e => e.Apellido)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Celular)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("celular");
            entity.Property(e => e.Correo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NumDocumento)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("num_documento");
            entity.Property(e => e.TipoDocumento)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("tipo_documento");
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.HasKey(e => e.IdVehiculo).HasName("PK__Vehiculo__F5DC0F391B63CEEB");

            entity.ToTable("Vehiculo");

            entity.HasIndex(e => e.Placa, "UQ__Vehiculo__8310F99D19039AD0").IsUnique();

            entity.Property(e => e.IdVehiculo).HasColumnName("id_vehiculo");
            entity.Property(e => e.Marca)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Modelo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Placa)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.TipoVehiculo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Tipo_vehiculo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
