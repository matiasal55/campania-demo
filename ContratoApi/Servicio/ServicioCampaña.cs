using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Donaciones.Contracts.DonacionesContrato;
using Donaciones.Contracts.DonacionesContrato.ContractDefinition;
using Microsoft.Extensions.Options;
using Nethereum.Contracts;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using Servicio.Models;

namespace Servicio
{
    public class ServicioCampaña : IServicioCampaña
    {
        private DonacionesContratoService _contrato;
        private readonly ContractData _config;

        public ServicioCampaña(IOptions<ContractData> options)
        {
            _contrato = InstanciarContrato();
            _config = options.Value;
        }

        private DonacionesContratoService InstanciarContrato()
        {
            var account = new Account(_config.WalletKey);
            var web3 = new Web3(account, _config.LocalUrl);
         //   var web3 = new Web3(account, _config.PolygonUrl);
            web3.TransactionManager.UseLegacyAsDefault = true;
            return new DonacionesContratoService(web3, _config.LocalContractHash);
          //  return new CampaniaService(web3, _config.PolygonContractHash);
        }
        
        public async Task<List<DonacionResponse>> ConsultarTodasLasDonaciones()
        {
            return _contrato.ConsultarTodasLasDonacionesQueryAsync().Result.ReturnValue1;
        }

        public async Task<DonacionResponse> ConsultarDonacionPorId(int id)
        {
            return _contrato.ConsultarDonacionesPorIdQueryAsync(id).Result.ReturnValue1;
        }

        public async Task<object> CrearDonacion(DonacionRequest request)
        {
            var response = await _contrato.CrearDonacionRequestAndWaitForReceiptAsync(new CrearDonacionFunction()
            {
                Request = request
            });
            var eventos = response.DecodeAllEvents<DatosDonacionEventDTO>();
            var datosDonacionEvento = eventos[0].Event.Response;
            return response;
        }

        public async Task<List<DonacionResponse>> ConsultarDonacionesPorOrganizacion(int idOrganizacion)
        {
            return _contrato.ConsultarDonacionesPorOrganizacionQueryAsync(idOrganizacion).Result.ReturnValue1;
        }
    }
}