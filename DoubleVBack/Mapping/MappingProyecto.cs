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

            CreateMap<ProyectoSinIdDTO, Proyecto>()
                .ForMember(dest => dest.ProyectoId, opt => opt.Ignore())
                .ForMember(dest => dest.Tareas, opt => opt.Ignore());

            CreateMap<Proyecto, ProyectoSinIdDTO>();
        }         
    }
}
