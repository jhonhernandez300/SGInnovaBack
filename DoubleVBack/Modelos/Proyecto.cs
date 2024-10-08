using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DoubleV.Modelos
{
    public class Proyecto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProyectoId { get; set; }
        public required string Nombre { get; set; }
        public required string Descripcion { get; set; }
        public required DateTime FechaInicio { get; set; }
        public required DateTime FechaFinalizacion { get; set; }
        
        [JsonIgnore]
        public ICollection<Tarea>? Tareas { get; set; }
    }
}
