using System.Numerics;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace Servicio.Contrato.Campania_v1.Campania.ContractDefinition
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
        [Parameter("string", "descripcionProducto", 4)]
        public virtual string DescripcionProducto { get; set; }
        [Parameter("uint256", "cantidad", 5)]
        public virtual BigInteger Cantidad { get; set; }
        [Parameter("uint256", "timestamp", 6)]
        public virtual BigInteger Timestamp { get; set; }
        [Parameter("bool", "entregado", 7)]
        public virtual bool Entregado { get; set; }
    }
}
