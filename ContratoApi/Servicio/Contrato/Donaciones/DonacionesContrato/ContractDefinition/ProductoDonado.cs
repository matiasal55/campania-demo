using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace Donaciones.Contracts.DonacionesContrato.ContractDefinition
{
    public partial class ProductoDonado : ProductoDonadoBase { }

    public class ProductoDonadoBase 
    {
        [Parameter("string", "descripcionProducto", 1)]
        public virtual string DescripcionProducto { get; set; }
        [Parameter("uint256", "cantidad", 2)]
        public virtual BigInteger Cantidad { get; set; }
    }
}
