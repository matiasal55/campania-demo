using System.Collections.Generic;
using System.Threading.Tasks;
using Donaciones.Contracts.DonacionesContrato.ContractDefinition;
using Servicio.Models;

namespace Servicio
{
    public interface IServicioCampaña
    {
        Task<List<DonacionResponse>> ConsultarTodasLasDonaciones();
        Task<DonacionResponse> ConsultarDonacionPorId(int id);
        Task<object> CrearDonacion(DonacionRequest request);
        Task<List<DonacionResponse>> ConsultarDonacionesPorOrganizacion(int idOrganizacion);
        Task ConfirmarReservaDeProductosDeDonaciones(EstadoDonacionReq donaciones);
        Task ConfirmarTrasladoDeProductosDeDonaciones(EstadoDonacionReq donaciones);
        Task ConfirmarEntregaDeProductosDeDonaciones(EstadoDonacionReq donaciones);
    }
}