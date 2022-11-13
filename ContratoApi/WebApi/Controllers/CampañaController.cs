using System.Collections.Generic;
using System.Threading.Tasks;
using Donaciones.Contracts.DonacionesContrato.ContractDefinition;
using Microsoft.AspNetCore.Mvc;
using Servicio;

namespace WebApi.Controllers
{
    [Route("api/campania")]
    [ApiController]
    public class CampañaController : ControllerBase
    {
        private IServicioCampaña _servicioCampaña;

        public CampañaController(IServicioCampaña servicioCampaña)
        {
            _servicioCampaña = servicioCampaña;
        }

        // GET: api/Campaña
        [HttpGet]
        public async Task<List<DonacionResponse>> ConsultarTodasLasDonaciones()
        {
            return await _servicioCampaña.ConsultarTodasLasDonaciones();
        }

        // GET: api/Campaña/5
        [HttpGet("{id}")]
        public async Task<DonacionResponse> ConsultarDonacionPorId(int id)
        {
            return await _servicioCampaña.ConsultarDonacionPorId(id);
        }

        // POST: api/Campaña
        [HttpPost]
        public async Task<object> CrearDonacion(DonacionRequest request)
        {
            return await _servicioCampaña.CrearDonacion(request);
        }

        [HttpGet("organizacion/{idOrganizacion}")]
        public async Task<List<DonacionResponse>> ConsultarDonacionesPorOrganizacion(int idOrganizacion)
        {
            return await _servicioCampaña.ConsultarDonacionesPorOrganizacion(idOrganizacion);
        }
    }
}