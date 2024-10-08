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

                return Ok(new ProyectoResponse { Proyectos = proyectosDto });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en ObtenerTodosLosProyectosAsync: {ex.Message}");
                return StatusCode(500, new ProyectoResponse { Message = "Error interno del servidor" });
            }
        }
    }
}
