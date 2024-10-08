using DoubleV.Modelos;

namespace DoubleV.Interfaces
{
    public interface IProyectoService
    {
        Task<List<Proyecto>> ObtenerTodosAsync();
        Task<Proyecto?> ObtenerProyectoPorIdAsync(int proyectoId);
        Task<bool> CrearProyectoAsync(Proyecto proyecto);
        Task<bool> ActualizarProyectoAsync(Proyecto proyecto);
        Task<bool> EliminarProyectoAsync(int proyectoId);
    }
}
