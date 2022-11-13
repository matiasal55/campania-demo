using System.Collections.Generic;
using System.Threading.Tasks;
using Servicio.Contrato.Campania_v1.Campania.ContractDefinition;

namespace Servicio
{
    public interface IServicioCampaña
    {
        Task<List<DonacionResponse>> ConsultarTodasLasDonaciones();
        Task<DonacionResponse> ConsultarDonacionPorId(int id);
        Task<object> CrearDonacion(DonacionRequest request);
        Task<List<DonacionResponse>> ConsultarDonacionesPorOrganizacion(int idOrganizacion);
    }
}