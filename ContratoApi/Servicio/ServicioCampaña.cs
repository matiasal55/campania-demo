using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contrato.Contracts.Campania;
using Contrato.Contracts.Campania.ContractDefinition;
using Microsoft.Extensions.Options;
using Nethereum.Contracts;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using Servicio.Models;

namespace Servicio
{
    public class ServicioCampaña : IServicioCampaña
    {
        private CampaniaService _contratoCampaña;
        private readonly ContractData _config;

        public ServicioCampaña(IOptions<ContractData> options)
        {
            _contratoCampaña = InstanciarContrato();
            _config = options.Value;
        }

        private CampaniaService InstanciarContrato()
        {
            var account = new Account(_config.WalletKey);
            var web3 = new Web3(account, _config.GoerliUrl);
         //   var web3 = new Web3(account, _config.PolygonUrl);
            web3.TransactionManager.UseLegacyAsDefault = true;
            return new CampaniaService(web3, _config.GoerliContractHash);
          //  return new CampaniaService(web3, _config.PolygonContractHash);
        }
        
        public async Task<List<DonacionResponse>> ConsultarTodasLasDonaciones()
        {
            return _contratoCampaña.ConsultarTodasLasDonacionesQueryAsync().Result.ReturnValue1;
        }

        public async Task<DonacionResponse> ConsultarDonacionPorId(int id)
        {
            return _contratoCampaña.ConsultarDonacionesPorIdQueryAsync(id).Result.ReturnValue1;
        }

        public async Task<object> CrearDonacion(DonacionRequest request)
        {
            var response = await _contratoCampaña.CrearDonacionRequestAndWaitForReceiptAsync(new CrearDonacionFunction()
            {
                Request = request
            });
            var eventos = response.DecodeAllEvents<DatosDonacionEventDTO>();
            var datosDonacionEvento = eventos[0].Event.Response;
            return response;
        }

        public async Task<List<DonacionResponse>> ConsultarDonacionesPorOrganizacion(int idOrganizacion)
        {
            return _contratoCampaña.ConsultarDonacionesPorOrganizacionQueryAsync(idOrganizacion).Result.ReturnValue1;
        }
    }
}