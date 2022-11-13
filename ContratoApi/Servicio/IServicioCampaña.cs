using System.Collections.Generic;
using System.Threading.Tasks;
using Donaciones.Contracts.DonacionesContrato.ContractDefinition;

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