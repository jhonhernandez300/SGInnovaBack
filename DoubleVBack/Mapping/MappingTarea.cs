using AutoMapper;
using DoubleV.DTOs;
using DoubleV;
using DoubleV.Modelos;

namespace DoubleV.Mapping
{
    public class MappingTarea : AutoMapper.Profile
    {
        public MappingTarea()
        {
            CreateMap<TareaSinIdDTO, Tarea>()
                .ForMember(dest => dest.Usuario, opt => opt.Ignore())
                .ForMember(dest => dest.Proyecto, opt => opt.Ignore());

            CreateMap<Tarea, TareaSinIdDTO>();

            CreateMap<TareaActualizarDTO, Tarea>()
            // Ignorar TareaId para no cambiar el ID
            .ForMember(dest => dest.TareaId, opt => opt.Ignore()) 
            .ForMember(dest => dest.Usuario, opt => opt.Ignore())
            // Ignorar ProyectoId para no cambiar el ID
            .ForMember(dest => dest.ProyectoId, opt => opt.Ignore()) 
            .ForMember(dest => dest.Proyecto, opt => opt.Ignore());

        }        
    }
}
