using DoubleV.Modelos;

namespace DoubleV.DTOs
{
    public class ProyectoResponse
    {
        public string Message { get; set; }
        public List<ProyectoDTO> Proyectos { get; set; }
    }
}
