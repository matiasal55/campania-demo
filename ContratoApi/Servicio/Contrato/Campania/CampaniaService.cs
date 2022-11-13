using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using Contrato.Contracts.Campania.ContractDefinition;

namespace Contrato.Contracts.Campania
{
    public partial class CampaniaService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, CampaniaDeployment campaniaDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<CampaniaDeployment>().SendRequestAndWaitForReceiptAsync(campaniaDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, CampaniaDeployment campaniaDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<CampaniaDeployment>().SendRequestAsync(campaniaDeployment);
        }

        public static async Task<CampaniaService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, CampaniaDeployment campaniaDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, campaniaDeployment, cancellationTokenSource);
            return new CampaniaService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public CampaniaService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<ConsultarDonacionesPorIdOutputDTO> ConsultarDonacionesPorIdQueryAsync(ConsultarDonacionesPorIdFunction consultarDonacionesPorIdFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<ConsultarDonacionesPorIdFunction, ConsultarDonacionesPorIdOutputDTO>(consultarDonacionesPorIdFunction, blockParameter);
        }

        public Task<ConsultarDonacionesPorIdOutputDTO> ConsultarDonacionesPorIdQueryAsync(BigInteger idDonacion, BlockParameter blockParameter = null)
        {
            var consultarDonacionesPorIdFunction = new ConsultarDonacionesPorIdFunction();
                consultarDonacionesPorIdFunction.IdDonacion = idDonacion;
            
            return ContractHandler.QueryDeserializingToObjectAsync<ConsultarDonacionesPorIdFunction, ConsultarDonacionesPorIdOutputDTO>(consultarDonacionesPorIdFunction, blockParameter);
        }

        public Task<ConsultarDonacionesPorOrganizacionOutputDTO> ConsultarDonacionesPorOrganizacionQueryAsync(ConsultarDonacionesPorOrganizacionFunction consultarDonacionesPorOrganizacionFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<ConsultarDonacionesPorOrganizacionFunction, ConsultarDonacionesPorOrganizacionOutputDTO>(consultarDonacionesPorOrganizacionFunction, blockParameter);
        }

        public Task<ConsultarDonacionesPorOrganizacionOutputDTO> ConsultarDonacionesPorOrganizacionQueryAsync(BigInteger idOrganizacion, BlockParameter blockParameter = null)
        {
            var consultarDonacionesPorOrganizacionFunction = new ConsultarDonacionesPorOrganizacionFunction();
                consultarDonacionesPorOrganizacionFunction.IdOrganizacion = idOrganizacion;
            
            return ContractHandler.QueryDeserializingToObjectAsync<ConsultarDonacionesPorOrganizacionFunction, ConsultarDonacionesPorOrganizacionOutputDTO>(consultarDonacionesPorOrganizacionFunction, blockParameter);
        }

        public Task<ConsultarTodasLasDonacionesOutputDTO> ConsultarTodasLasDonacionesQueryAsync(ConsultarTodasLasDonacionesFunction consultarTodasLasDonacionesFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<ConsultarTodasLasDonacionesFunction, ConsultarTodasLasDonacionesOutputDTO>(consultarTodasLasDonacionesFunction, blockParameter);
        }

        public Task<ConsultarTodasLasDonacionesOutputDTO> ConsultarTodasLasDonacionesQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<ConsultarTodasLasDonacionesFunction, ConsultarTodasLasDonacionesOutputDTO>(null, blockParameter);
        }

        public Task<string> CrearDonacionRequestAsync(CrearDonacionFunction crearDonacionFunction)
        {
             return ContractHandler.SendRequestAsync(crearDonacionFunction);
        }

        public Task<TransactionReceipt> CrearDonacionRequestAndWaitForReceiptAsync(CrearDonacionFunction crearDonacionFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(crearDonacionFunction, cancellationToken);
        }

        public Task<string> CrearDonacionRequestAsync(DonacionRequest request)
        {
            var crearDonacionFunction = new CrearDonacionFunction();
                crearDonacionFunction.Request = request;
            
             return ContractHandler.SendRequestAsync(crearDonacionFunction);
        }

        public Task<TransactionReceipt> CrearDonacionRequestAndWaitForReceiptAsync(DonacionRequest request, CancellationTokenSource cancellationToken = null)
        {
            var crearDonacionFunction = new CrearDonacionFunction();
                crearDonacionFunction.Request = request;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(crearDonacionFunction, cancellationToken);
        }
    }
}
