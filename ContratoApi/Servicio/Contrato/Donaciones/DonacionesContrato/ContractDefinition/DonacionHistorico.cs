using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace Donaciones.Contracts.DonacionesContrato.ContractDefinition
{
    public partial class DonacionHistorico : DonacionHistoricoBase { }

    public class DonacionHistoricoBase 
    {
        [Parameter("uint256", "idDonacion", 1)]
        public virtual BigInteger IdDonacion { get; set; }
        [Parameter("uint8", "estado", 2)]
        public virtual byte Estado { get; set; }
        [Parameter("uint256", "timestamp", 3)]
        public virtual BigInteger Timestamp { get; set; }
    }
}
