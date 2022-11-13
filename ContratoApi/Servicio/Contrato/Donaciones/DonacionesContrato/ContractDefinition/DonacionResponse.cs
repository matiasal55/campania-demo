using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace Donaciones.Contracts.DonacionesContrato.ContractDefinition
{
    public partial class DonacionResponse : DonacionResponseBase { }

    public class DonacionResponseBase 
    {
        [Parameter("uint256", "idDonacion", 1)]
        public virtual BigInteger IdDonacion { get; set; }
        [Parameter("string", "organizacion", 2)]
        public virtual string Organizacion { get; set; }
        [Parameter("string", "campania", 3)]
        public virtual string Campania { get; set; }
        [Parameter("tuple[]", "productosDonados", 4)]
        public virtual List<ProductoDonado> ProductosDonados { get; set; }
        [Parameter("uint256", "timestamp", 5)]
        public virtual BigInteger Timestamp { get; set; }
        [Parameter("string", "estado", 6)]
        public virtual string Estado { get; set; }
    }
}
