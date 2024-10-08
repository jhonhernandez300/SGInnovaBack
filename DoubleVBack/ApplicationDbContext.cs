using DoubleV.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using System;

namespace DoubleV
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<Proyecto> Proyectos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rol>().ToTable("Roles");
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            modelBuilder.Entity<Tarea>().ToTable("Tareas");
            modelBuilder.Entity<Proyecto>().ToTable("Proyectos");

            modelBuilder.Entity<Usuario>()
                .HasKey(df => df.UsuarioId);

            modelBuilder.Entity<Rol>()
                .HasKey(df => df.RolId);

            modelBuilder.Entity<Tarea>()
                .HasKey(df => df.TareaId);

            modelBuilder.Entity<Proyecto>()
                .HasKey(df => df.ProyectoId);

            //Las relaciones
            modelBuilder.Entity<Usuario>()
                .HasOne(df => df.Rol)
                .WithMany(f => f.Usuarios)
                .HasForeignKey(df => df.RolId);

            modelBuilder.Entity<Tarea>()
                .HasOne(df => df.Usuario)
                .WithMany(f => f.Tareas)
                .HasForeignKey(df => df.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Tarea>()
               .HasOne(df => df.Proyecto)
               .WithMany(f => f.Tareas)
               .HasForeignKey(df => df.ProyectoId)
               .OnDelete(DeleteBehavior.Cascade);
            

            //Seeds
            modelBuilder.Entity<Usuario>().HasData(
                 new Usuario
                 {
                     UsuarioId = 1,
                     Nombre = "James",
                     Email = "james@gmail.com",
                     Password = "James0101*",
                     RolId = 1
                 },
                 new Usuario
                 {
                     UsuarioId = 2,
                     Nombre = "Radamel",
                     Email = "radamel@gmail.com",
                     Password = "Radamel0101*",
                     RolId = 3
                 },
                 // Nuevos Usuarios
                 new Usuario
                 {
                     UsuarioId = 3,
                     Nombre = "Carlos",
                     Email = "carlos@gmail.com",
                     Password = "Carlos0101*",
                     RolId = 1
                 },
                 new Usuario
                 {
                     UsuarioId = 4,
                     Nombre = "Maria",
                     Email = "maria@gmail.com",
                     Password = "Maria0101*",
                     RolId = 2
                 },
                 new Usuario
                 {
                     UsuarioId = 5,
                     Nombre = "Luis",
                     Email = "luis@gmail.com",
                     Password = "Luis0101*",
                     RolId = 1
                 },
                 new Usuario
                 {
                     UsuarioId = 6,
                     Nombre = "Laura",
                     Email = "laura@gmail.com",
                     Password = "Laura0101*",
                     RolId = 3
                 },
                 new Usuario
                 {
                     UsuarioId = 7,
                     Nombre = "Andres",
                     Email = "andres@gmail.com",
                     Password = "Andres0101*",
                     RolId = 1
                 },
                 new Usuario
                 {
                     UsuarioId = 8,
                     Nombre = "Daniela",
                     Email = "daniela@gmail.com",
                     Password = "Daniela0101*",
                     RolId = 2
                 },
                 new Usuario
                 {
                     UsuarioId = 9,
                     Nombre = "Juan",
                     Email = "juan@gmail.com",
                     Password = "Juan0101*",
                     RolId = 1
                 },
                 new Usuario
                 {
                     UsuarioId = 10,
                     Nombre = "Camila",
                     Email = "camila@gmail.com",
                     Password = "Camila0101*",
                     RolId = 2
                 },
                 new Usuario
                 {
                     UsuarioId = 11,
                     Nombre = "Miguel",
                     Email = "miguel@gmail.com",
                     Password = "Miguel0101*",
                     RolId = 1
                 },
                 new Usuario
                 {
                     UsuarioId = 12,
                     Nombre = "Sofia",
                     Email = "sofia@gmail.com",
                     Password = "Sofia0101*",
                     RolId = 2
                 }
             );

            modelBuilder.Entity<Rol>().HasData(
                new Rol
                {
                    RolId = 1,
                    Nombre = "Administrador"
                },
                new Rol
                {
                    RolId = 2,
                    Nombre = "Supervisor"
                },
                new Rol
                {
                    RolId = 3,
                    Nombre = "Empleado"
                }
            );

            modelBuilder.Entity<Proyecto>().HasData(
                new Proyecto
                {
                    ProyectoId = 1,
                    Nombre = "Crear microservicio de prueba",
                    Descripcion = "Crear microservicio",
                    FechaInicio = new DateTime(2024, 10, 1), 
                    FechaFinalizacion = new DateTime(2024, 12, 31)
                },
                new Proyecto
                {
                    ProyectoId = 2,
                    Nombre = "Hacer pruebas unitarias en el front",
                    Descripcion = "Pruebas con jasmine",
                    FechaInicio = new DateTime(2024, 11, 1), 
                    FechaFinalizacion = new DateTime(2025, 1, 31)
                },
                new Proyecto
                {
                    ProyectoId = 3,
                    Nombre = "Hacer pruebas unitarias en el back",
                    Descripcion = "Hacer pruebas con XUnit",
                    FechaInicio = new DateTime(2024, 9, 15), 
                    FechaFinalizacion = new DateTime(2024, 11, 30)
                }
            );

            modelBuilder.Entity<Tarea>().HasData(
                 new Tarea
                 {
                     TareaId = 1,
                     Descripcion = "Vender",                     
                     Estado = "En Proceso",
                     UsuarioId = 1,
                     ProyectoId = 1
                 },
                 new Tarea
                 {
                     TareaId = 2,
                     Descripcion = "Reparar",                     
                     Estado = "Completada",
                     UsuarioId = 2,
                     ProyectoId = 2
                 }
             );

            base.OnModelCreating(modelBuilder);

        }
    }
}
