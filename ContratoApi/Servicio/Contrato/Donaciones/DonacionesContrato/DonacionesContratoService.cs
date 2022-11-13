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
using Donaciones.Contracts.DonacionesContrato.ContractDefinition;

namespace Donaciones.Contracts.DonacionesContrato
{
    public partial class DonacionesContratoService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, DonacionesContratoDeployment donacionesContratoDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<DonacionesContratoDeployment>().SendRequestAndWaitForReceiptAsync(donacionesContratoDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, DonacionesContratoDeployment donacionesContratoDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<DonacionesContratoDeployment>().SendRequestAsync(donacionesContratoDeployment);
        }

        public static async Task<DonacionesContratoService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, DonacionesContratoDeployment donacionesContratoDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, donacionesContratoDeployment, cancellationTokenSource);
            return new DonacionesContratoService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public DonacionesContratoService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> ConfirmarEntregaProductosEnDonacionesRequestAsync(ConfirmarEntregaProductosEnDonacionesFunction confirmarEntregaProductosEnDonacionesFunction)
        {
             return ContractHandler.SendRequestAsync(confirmarEntregaProductosEnDonacionesFunction);
        }

        public Task<TransactionReceipt> ConfirmarEntregaProductosEnDonacionesRequestAndWaitForReceiptAsync(ConfirmarEntregaProductosEnDonacionesFunction confirmarEntregaProductosEnDonacionesFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(confirmarEntregaProductosEnDonacionesFunction, cancellationToken);
        }

        public Task<string> ConfirmarEntregaProductosEnDonacionesRequestAsync(List<BigInteger> donacionesId)
        {
            var confirmarEntregaProductosEnDonacionesFunction = new ConfirmarEntregaProductosEnDonacionesFunction();
                confirmarEntregaProductosEnDonacionesFunction.DonacionesId = donacionesId;
            
             return ContractHandler.SendRequestAsync(confirmarEntregaProductosEnDonacionesFunction);
        }

        public Task<TransactionReceipt> ConfirmarEntregaProductosEnDonacionesRequestAndWaitForReceiptAsync(List<BigInteger> donacionesId, CancellationTokenSource cancellationToken = null)
        {
            var confirmarEntregaProductosEnDonacionesFunction = new ConfirmarEntregaProductosEnDonacionesFunction();
                confirmarEntregaProductosEnDonacionesFunction.DonacionesId = donacionesId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(confirmarEntregaProductosEnDonacionesFunction, cancellationToken);
        }

        public Task<string> ConfirmarReservaProductosEnDonacionesRequestAsync(ConfirmarReservaProductosEnDonacionesFunction confirmarReservaProductosEnDonacionesFunction)
        {
             return ContractHandler.SendRequestAsync(confirmarReservaProductosEnDonacionesFunction);
        }

        public Task<TransactionReceipt> ConfirmarReservaProductosEnDonacionesRequestAndWaitForReceiptAsync(ConfirmarReservaProductosEnDonacionesFunction confirmarReservaProductosEnDonacionesFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(confirmarReservaProductosEnDonacionesFunction, cancellationToken);
        }

        public Task<string> ConfirmarReservaProductosEnDonacionesRequestAsync(List<BigInteger> donacionesId)
        {
            var confirmarReservaProductosEnDonacionesFunction = new ConfirmarReservaProductosEnDonacionesFunction();
                confirmarReservaProductosEnDonacionesFunction.DonacionesId = donacionesId;
            
             return ContractHandler.SendRequestAsync(confirmarReservaProductosEnDonacionesFunction);
        }

        public Task<TransactionReceipt> ConfirmarReservaProductosEnDonacionesRequestAndWaitForReceiptAsync(List<BigInteger> donacionesId, CancellationTokenSource cancellationToken = null)
        {
            var confirmarReservaProductosEnDonacionesFunction = new ConfirmarReservaProductosEnDonacionesFunction();
                confirmarReservaProductosEnDonacionesFunction.DonacionesId = donacionesId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(confirmarReservaProductosEnDonacionesFunction, cancellationToken);
        }

        public Task<string> ConfirmarTrasladoProductosEnDonacionesRequestAsync(ConfirmarTrasladoProductosEnDonacionesFunction confirmarTrasladoProductosEnDonacionesFunction)
        {
             return ContractHandler.SendRequestAsync(confirmarTrasladoProductosEnDonacionesFunction);
        }

        public Task<TransactionReceipt> ConfirmarTrasladoProductosEnDonacionesRequestAndWaitForReceiptAsync(ConfirmarTrasladoProductosEnDonacionesFunction confirmarTrasladoProductosEnDonacionesFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(confirmarTrasladoProductosEnDonacionesFunction, cancellationToken);
        }

        public Task<string> ConfirmarTrasladoProductosEnDonacionesRequestAsync(List<BigInteger> donacionesId)
        {
            var confirmarTrasladoProductosEnDonacionesFunction = new ConfirmarTrasladoProductosEnDonacionesFunction();
                confirmarTrasladoProductosEnDonacionesFunction.DonacionesId = donacionesId;
            
             return ContractHandler.SendRequestAsync(confirmarTrasladoProductosEnDonacionesFunction);
        }

        public Task<TransactionReceipt> ConfirmarTrasladoProductosEnDonacionesRequestAndWaitForReceiptAsync(List<BigInteger> donacionesId, CancellationTokenSource cancellationToken = null)
        {
            var confirmarTrasladoProductosEnDonacionesFunction = new ConfirmarTrasladoProductosEnDonacionesFunction();
                confirmarTrasladoProductosEnDonacionesFunction.DonacionesId = donacionesId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(confirmarTrasladoProductosEnDonacionesFunction, cancellationToken);
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

        public Task<ConsultarHistorialDonacionesOutputDTO> ConsultarHistorialDonacionesQueryAsync(ConsultarHistorialDonacionesFunction consultarHistorialDonacionesFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<ConsultarHistorialDonacionesFunction, ConsultarHistorialDonacionesOutputDTO>(consultarHistorialDonacionesFunction, blockParameter);
        }

        public Task<ConsultarHistorialDonacionesOutputDTO> ConsultarHistorialDonacionesQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<ConsultarHistorialDonacionesFunction, ConsultarHistorialDonacionesOutputDTO>(null, blockParameter);
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
