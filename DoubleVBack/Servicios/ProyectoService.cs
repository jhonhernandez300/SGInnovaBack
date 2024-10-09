using DoubleV.DTOs;
using DoubleV.Interfaces;
using DoubleV.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoubleV.Servicios
{
    public class ProyectoService : IProyectoService
    {
        private readonly ApplicationDbContext _context;

        public ProyectoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Proyecto>> ObtenerTodosAsync()
        {
            try
            {
                return await _context.Proyectos.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener todos los proyectos: {ex.Message}");

                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Detalle: {ex.InnerException.Message}");
                }

                // Retornar una lista vacía en caso de error
                return new List<Proyecto>();
            }
        }

        public async Task<Proyecto?> ObtenerProyectoPorIdAsync(int proyectoId)
        {
            try
            {
                return await _context.Proyectos
                    .Include(p => p.Tareas) // Incluye las tareas asociadas si es necesario
                    .FirstOrDefaultAsync(p => p.ProyectoId == proyectoId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener el proyecto con ID {proyectoId}: {ex.Message}");

                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Detalle: {ex.InnerException.Message}");
                }

                // Devolver null en caso de error
                return null;
            }
        }
        
        public async Task<int> CrearProyectoAsync(Proyecto proyecto)
        {
            try
            {
                _context.Proyectos.Add(proyecto);
                await _context.SaveChangesAsync();
                return proyecto.ProyectoId;
            }
            catch (DbUpdateException dbEx)
            {
                Console.WriteLine("Error de base de datos: " + dbEx.Message);
                if (dbEx.InnerException != null)
                {
                    Console.WriteLine("Detalle: " + dbEx.InnerException.Message);
                }
                // Devuelve -1 en caso de error
                return -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error general: " + ex.Message);
                return -1;
            }
        }
        
        public async Task<bool> ActualizarProyectoAsync(Proyecto proyecto)
        {
            try
            {
                _context.Proyectos.Update(proyecto);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar el proyecto con ID {proyecto.ProyectoId}: {ex.Message}");

                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Detalle: {ex.InnerException.Message}");
                }

                return false;
            }
        }
       
        public async Task<bool> EliminarProyectoAsync(int proyectoId)
        {
            try
            {
                var proyecto = await _context.Proyectos.FirstOrDefaultAsync(p => p.ProyectoId == proyectoId);

                if (proyecto != null)
                {
                    _context.Proyectos.Remove(proyecto);
                    await _context.SaveChangesAsync();
                    return true;
                }

                return false; // No se encontró el proyecto
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar el proyecto con ID {proyectoId}: {ex.Message}");

                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Detalle: {ex.InnerException.Message}");
                }

                return false;
            }
        }
    }
}
