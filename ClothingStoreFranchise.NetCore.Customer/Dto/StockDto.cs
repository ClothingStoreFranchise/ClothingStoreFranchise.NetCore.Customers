using ClothingStoreFranchise.NetCore.Common.Extensible;
using ClothingStoreFranchise.NetCore.Common.Types;
using Newtonsoft.Json;

namespace ClothingStoreFranchise.NetCore.Customers.Dto
{
    public class StockDto : IEntityDto<long>
    {
        [JsonProperty(PropertyName = "productId")]
        public long ProductId { get; set; }

        [JsonProperty(PropertyName = "size")]
        public int Size { get; set; }

        [JsonProperty(PropertyName = "stock")]
        public long Stock { get; set; }

        public long Key()
        {
            return ProductId;
        }
    }
}