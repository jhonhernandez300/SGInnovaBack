using DoubleV.DTOs;
using DoubleV.Modelos;

namespace DoubleV.Mapping
{
    public class MappingProyecto : AutoMapper.Profile
    {
        public MappingProyecto()
        {
            CreateMap<Proyecto, ProyectoDTO>();
            
            CreateMap<ProyectoDTO, Proyecto>();
        }
         
    }
}
