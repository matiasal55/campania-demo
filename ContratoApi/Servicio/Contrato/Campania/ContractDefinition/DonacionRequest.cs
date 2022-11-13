using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace Contrato.Contracts.Campania.ContractDefinition
{
    public partial class DonacionRequest : DonacionRequestBase { }

    public class DonacionRequestBase 
    {
        [Parameter("uint256", "idDonacion", 1)]
        public virtual BigInteger IdDonacion { get; set; }
        [Parameter("uint256", "idOrganizacion", 2)]
        public virtual BigInteger IdOrganizacion { get; set; }
        [Parameter("string", "organizacion", 3)]
        public virtual string Organizacion { get; set; }
        [Parameter("uint256", "idCampania", 4)]
        public virtual BigInteger IdCampania { get; set; }
        [Parameter("string", "campania", 5)]
        public virtual string Campania { get; set; }
        [Parameter("uint256", "idDonador", 6)]
        public virtual BigInteger IdDonador { get; set; }
        [Parameter("string", "descripcionProducto", 7)]
        public virtual string DescripcionProducto { get; set; }
        [Parameter("uint256", "cantidad", 8)]
        public virtual BigInteger Cantidad { get; set; }
    }
}
