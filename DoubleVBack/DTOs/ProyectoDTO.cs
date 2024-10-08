namespace DoubleV.DTOs
{
    public class ProyectoDTO
    {
        public int ProyectoId { get; set; }
        public required string Nombre { get; set; }
        public required string Descripcion { get; set; }
        public required DateTime FechaInicio { get; set; }
        public required DateTime FechaFinalizacion { get; set; }
    }
}
