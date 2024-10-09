using DoubleV.DTOs;
using DoubleV.Interfaces;
using DoubleV.Modelos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Cors;
using DoubleV.Helpers;
using DoubleV.Servicios;

namespace DoubleV.Controllers
{
    [ApiController]
    [EnableCors("AllowOrigins")]
    [Route("api/[controller]")]
    public class ProyectosController : ControllerBase
    {
        private readonly IProyectoService _proyectoService;
        private readonly IMapper _mapper;
        public IConfiguration _configuration;

        public ProyectosController(IProyectoService proyectoService, IMapper mapper, IConfiguration configuration)
        {
            _proyectoService = proyectoService;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpPost("GuardarProyectoAsync")]
        public async Task<ActionResult<ProyectoResponse>> GuardarProyectoAsync([FromBody] ProyectoSinIdDTO proyectoDto)
        {
            if (proyectoDto == null)
            {
                return BadRequest(new ApiResponse { Message = "Los datos del proyecto son requeridos.", Data = null });
            }

            try
            {    
                var proyecto = _mapper.Map<Proyecto>(proyectoDto);
                
                int nuevoProyectoId = await _proyectoService.CrearProyectoAsync(proyecto);

                // Si se creó correctamente, el ID será mayor que 0
                if (nuevoProyectoId > 0)
                {
                    return Ok(new ApiResponse
                    {
                        Message = "Usuario creado exitosamente.",
                        Data = nuevoProyectoId
                    });
                }
                return BadRequest(new ApiResponse { Message = "Fallo al crear el proyecto", Data = null });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GuardarProyectoAsync: {ex.Message}");
                return StatusCode(500, new ProyectoResponse { Message = "Error interno del servidor" });
            }
        }

        [HttpGet("ObtenerTodosLosProyectosAsync")]
        //[AuthorizeRoles("Administrador")] 
        public async Task<ActionResult<ProyectoResponse>> ObtenerTodosLosProyectosAsync()
        {
            try
            {
                var proyectos = await _proyectoService.ObtenerTodosAsync();

                if (proyectos == null || !proyectos.Any())
                {
                    return Ok(new ProyectoResponse { Message = "No se encontraron proyectos", Proyectos = new List<ProyectoDTO>() });
                }

                // Mapear a DTO si es necesario
                var proyectosDto = _mapper.Map<List<ProyectoDTO>>(proyectos);
                                
                return Ok(new ProyectoResponse
                {
                    Message = "Proyectos obtenidos exitosamente.",
                    Proyectos = proyectosDto
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en ObtenerTodosLosProyectosAsync: {ex.Message}");
                return StatusCode(500, new ProyectoResponse { Message = "Error interno del servidor" });
            }
        }

        [HttpDelete("BorrarProyectoAsync/{proyectoId}")]
        public async Task<IActionResult> BorrarProyectoAsync(int proyectoId)
        {
            try
            {
                bool resultado = await _proyectoService.EliminarProyectoAsync(proyectoId);

                if (!resultado)
                {
                    return NotFound(new { Message = "Proyecto no encontrado" });
                }

                return Ok(new { Message = "Proyecto borrado exitosamente" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al borrar el proyecto: {ex.Message}");
                return StatusCode(500, new { Message = "Error interno del servidor" });
            }
        }
    }
}
